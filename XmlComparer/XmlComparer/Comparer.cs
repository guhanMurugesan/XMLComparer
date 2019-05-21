using GillSoft.XmlComparer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace XmlComparer
{
    public class Comparer : IDisposable
    {
        private readonly IXmlCompareHandler xmlCompareHandler;

        public List<ElementAddedEventArgs> additions = new List<ElementAddedEventArgs>();
        public List<ElementChangedEventArgs> changes = new List<ElementChangedEventArgs>();
        public List<ElementRemovedEventArgs> removals = new List<ElementRemovedEventArgs>();

        public Comparer(IXmlCompareHandler xmlCompareHandler)
        {
            this.xmlCompareHandler = xmlCompareHandler;
        }

        public Comparer()
        {

        }

        private class Elem
        {
            public int LineNumber { get; private set; }

            public XElement Element { get; private set; }

            public KeyValueElementInfo KeyValueInfo { get; private set; }

            public int Source { get; private set; }

            public string XPath { get; private set; }

            public bool isChecked { get; set; }

            public int Level { get; set; }

            public int IsChildrenProcessed { get; set; }

            public static Elem Create(XElement element, int source)
            {
                //var kv = element.GetBestKeyValueInfo();
                var res = new Elem
                {
                    LineNumber = element.LineNumber(),
                    Element = element,
                    KeyValueInfo = null,
                    Source = source,
                    XPath = element.GetXPath(null)
                };
                res.Level = res.XPath.GetLevel();
                return res;
            }

            public override string ToString()
            {
                var res = string.Format("{0,-5}: {1} - {2}", LineNumber, Source, Element.Name.LocalName, XPath);
                return res;
            }
        }

        public void Compare(Stream stream1, Stream stream2, IXmlCompareHandler callback)
        {
            var stopWatch = new Stopwatch();
            var loadOptions = LoadOptions.SetBaseUri | LoadOptions.SetLineInfo;
            const int leftId = 1;
            const int rightId = 2;

            var doc1 = XDocument.Load(stream1, loadOptions);
            var doc2 = XDocument.Load(stream2, loadOptions);

            var nsm1 = new XmlNamespaceManagerEnhanced(doc1);
            var nsm2 = new XmlNamespaceManagerEnhanced(doc2);


            var doc1Descendants = doc1.Descendants()
                .Where(a => a != doc1.Root).Select(a => Elem.Create(a, leftId)).ToList();

            var doc2Descendants = doc2.Descendants()
                .Where(a => a != doc2.Root).Select(a => Elem.Create(a, rightId)).ToList();


            var xPathsAdded = new List<string>();
            var xPathsRemoved = new List<string>();
            var xPathsChanged = new List<string>();

            

            stopWatch.Start();
            foreach (var item1 in doc1Descendants)
            {
                //taken same levels
                var levelCollection = doc2Descendants.Where(x => x.Level == item1.Level);
                //taken same parents
                var groupCollection = levelCollection.Where(x => XPathComparer.CompareParent(item1.XPath, x.XPath));
                //take matched children
                var itemCollection = groupCollection.Where(a => XPathComparer.Compare(item1.XPath, a.XPath)).ToList();

                //handle properties used in a list
                if (itemCollection.Count > 1)
                {
                    var isExist = false;
                    foreach (var prop in itemCollection)
                    {
                        if (item1.XPath == prop.XPath)
                        {
                            isExist = true;
                            prop.isChecked = true;
                        }
                    }
                    if (!isExist)
                    {
                        xPathsChanged.Add(item1.XPath);
                        changes.Add(new ElementChangedEventArgs(item1.XPath, item1.Element, item1.Element.LineNumber(), item1.Element, item1.LineNumber));
                    }
                }
                else
                {
                    var item2 = itemCollection.FirstOrDefault();

                    if (!groupCollection.ToList().Any() && item2 == null) // group collection will be empty when parent property has changed
                    {
                        var changedParentCollection = levelCollection.Where(x => item1.XPath.CompareImmediateParent(x.XPath) && XPathComparer.Compare(item1.XPath, x.XPath));
                        var isPresent = changedParentCollection.Any();
                        if (isPresent)
                        {
                            changedParentCollection.ToList().ForEach(x => x.isChecked = true);
                            continue;
                        }
                        xPathsRemoved.Add(item1.XPath);
                        removals.Add(new ElementRemovedEventArgs(item1.XPath, item1.Element, item1.LineNumber));
                        continue;
                    }
                    if (item2 == null)
                    {
                        if (xPathsRemoved.Any(a => item1.XPath.StartsWith(a)))
                            continue;

                        xPathsRemoved.Add(item1.XPath);
                        removals.Add(new ElementRemovedEventArgs(item1.XPath, item1.Element, item1.LineNumber));
                        continue;
                    }
                    else if (item1.XPath != item2.XPath)
                    {
                        if (!xPathsChanged.Any(a => item1.XPath.StartsWith(a)))
                        {
                            xPathsChanged.Add(item1.XPath);
                            changes.Add(new ElementChangedEventArgs(item1.XPath, item1.Element, item1.LineNumber, item2.Element, item2.LineNumber));
                        }
                    }
                    foreach (var item in itemCollection)// marking searchable objects
                        item.isChecked = true;
                }
            }

            var addedCollection = doc2Descendants.Where(x => !x.isChecked).ToList();

            foreach (var item1 in addedCollection)
            {
                if (xPathsAdded.Any(a => item1.XPath.StartsWith(a)))
                    continue;

                xPathsAdded.Add(item1.XPath);

                additions.Add(new ElementAddedEventArgs(item1.XPath, item1.Element, item1.LineNumber));
            }

            stopWatch.Stop();

            Console.WriteLine("Elapsed Time {0} ms",stopWatch.ElapsedMilliseconds.ToString());

            foreach (var item in removals)
            {
                callback.ElementRemoved(item);
            }
            foreach (var item in additions)
            {
                callback.ElementAdded(item);
            }
            foreach (var item in changes)
            {
                callback.ElementChanged(item);
            }
        }

        private bool ElementsAreEqual(XElement xElement1, XElement xElement2)
        {
            if (xElement1 == null && xElement2 == null)
                return true;

            if (xElement1 == null || xElement2 == null)
                return false;

            if (xElement1.Name.ToString() != xElement2.Name.ToString())
                return false;

            if (!xElement1.HasAttributes != xElement2.HasAttributes)
                return false;

            if (!xElement1.HasElements != xElement2.HasElements)
                return false;

            if (!xElement1.Attributes().Any(a1 => !xElement2.Attributes().Any(a2 => a2.Value == a1.Value)))
                return false;

            return string.Equals(xElement1.Value, xElement2.Value);
        }

        public void Compare(string file1, string file2, IXmlCompareHandler callback)
        {
            using (var stream1 = File.OpenRead(file1))
            {
                using (var stream2 = File.OpenRead(file2))
                {
                    this.Compare(stream1, stream2, callback);
                }
            }
        }

        private void CompareAttributes(XElement node1, XElement node2, IXmlCompareHandler callback)
        {
            var attribs = node1.GetAttributes()
                .Concat(node2.GetAttributes())
                .GroupBy(a => a.Name.ToString())
                .Select(a => a.First());

            foreach (var attrib in attribs)
            {
                // compare Attributes in both documents
                var attribute1 = node1.Attribute(attrib.Name);
                var attribute2 = node2.Attribute(attrib.Name);

                if (attribute1 == null && attribute2 != null)
                {
                    //added
                    callback.AttributeAdded(new AttributeAddedEventArgs(attribute2.GetXPath(), attribute2, attribute2.Parent.LineNumber()));
                    continue;
                }


                if (attribute1 != null && attribute2 == null)
                {
                    //removed
                    callback.AttributeRemoved(new AttributeRemovedEventArgs(attribute1.GetXPath(), attribute1, attribute1.Parent.LineNumber()));
                    continue;
                }


                if (attribute1 != null && attribute2 != null)
                {
                    //might have changed
                    //compare values

                    var val1 = attribute1.Value;
                    var val2 = attribute2.Value;

                    if (string.Equals(val1, val2))
                        continue;

                    callback.AttributeChanged(new AttributeChangedEventArgs(attribute1.GetXPath(), attribute1, attribute1.Parent.LineNumber(), attribute2, attribute2.Parent.LineNumber()));
                    continue;
                }

                throw new Exception("Invalid scenario while comparing Attributes: " + attrib);
            }

        }

        public void Dispose()
        {
        }
    }
}
