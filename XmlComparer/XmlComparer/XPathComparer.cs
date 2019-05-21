using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GillSoft.XmlComparer
{
    public static class XPathComparer
    {
      


        public static bool Compare(string textLine1, string textLine2)
        {
            //textLine1 = textLine1.Replace("\"", string.Empty);
            //textLine2 = textLine2.Replace("\"",string.Empty);
            //if (!GetParentXPath(textLine1).Equals(GetParentXPath(textLine2)))
            //     return false;

            var childXPath1 = GetChildKeyXPath(textLine1);
            var childXPath2 = GetChildKeyXPath(textLine2);

            if (childXPath1.Equals(childXPath2))
                return true;

            return false;
        }

        public static bool CompareParent(string xpath1,string xpath2)
        {
            return GetParentXPath(xpath1).Equals(GetParentXPath(xpath2));
        }

        public static string GetParentXPath(string textLine)
        {
            //var parent = textLine.GetImmediateParent();
            //var attributes = parent.Substring(parent.IndexOf('[') + 1, parent.Length - parent.IndexOf('[') - 1) + " ";
            //var splits = attributes.Split('@');
            //return string.Format("{0}+{1}+{2}+{3}", parent.Substring(parent.IndexOf(":") + 1, parent.IndexOf('[') == -1 ? parent.Length - parent.IndexOf(":") - 1 : parent.IndexOf('[') - parent.IndexOf(':') - 1),
            //        GetTagValue(splits, "Name"), GetTagValue(splits, "Condition"), GetTagValue(splits, "Type"));

            return textLine.Substring(0, textLine.LastIndexOf("/ns") - 1);
        }

        public static string GetImmediateParent(this string xPath)
        {
            var parent = xPath.Substring(0, xPath.LastIndexOf("/ns") + 1);
            var immediateParent = xPath.Substring(parent.LastIndexOf("/ns") + 1, xPath.LastIndexOf("/ns") - parent.LastIndexOf("/ns"));
            var attributes = immediateParent.Substring(immediateParent.IndexOf('[') + 1, immediateParent.Length - immediateParent.IndexOf('[') - 1) + " ";
            var splits = attributes.Split('@');
            return string.Format("{0}+{1}+{2}+{3}", immediateParent.Substring(immediateParent.IndexOf(":") + 1, immediateParent.IndexOf('[') == -1 ? immediateParent.Length - immediateParent.IndexOf(":") - 1 : immediateParent.IndexOf('[') - immediateParent.IndexOf(':') - 1),
                    GetTagValue(splits, "Name"), GetTagValue(splits, "Condition"), GetTagValue(splits, "Type"));
        }



        public static string GetChildKeyXPath(string textLine)
        {
            //gets child key ignores attributes
            textLine = textLine.Substring(textLine.LastIndexOf("/ns"), textLine.Length - textLine.LastIndexOf("/ns"));
            var attributes = textLine.Substring(textLine.IndexOf('[')+1, textLine.Length - textLine.IndexOf('[')-1) + " ";
            var splits = attributes.Split('@');
            return string.Format("{0}+{1}+{2}+{3}", textLine.Substring(textLine.IndexOf(":") + 1, textLine.IndexOf('[') == -1 ? textLine.Length - textLine.IndexOf(":") -1 : textLine.IndexOf('[') - textLine.IndexOf(':')-1),
                    GetTagValue(splits, "Name"), GetTagValue(splits, "Condition"), GetTagValue(splits, "Type"));
        }

        public static string GetTagValue(string[] splits, string value)
        {
            var result = splits.Where(x => x.StartsWith(value)).FirstOrDefault();
            if (result != null)
            {
                var startindex = result.IndexOf('=') + 1;
                return result.Substring(result.IndexOf('=') + 1, result.LastIndexOf('\"') - startindex);
            }
            return string.Empty;
        }
    }
}
