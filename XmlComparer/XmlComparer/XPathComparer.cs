using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GillSoft.XmlComparer
{
    public class XPathComparer
    {
        public XPathComparer()
        {

        }


        public static bool Compare(string textLine1, string textLine2)
        {
            textLine1 = textLine1.Replace("\"", string.Empty);
            textLine2 = textLine2.Replace("\"",string.Empty);
            //if (textLine1.Split('/').Length > 1)
            //{
            //    if (!GetParentXPath(textLine1).Equals(GetParentXPath(textLine2)))
            //        return false;
            //}

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
            //returns parent xpath
            return textLine.Substring(0, textLine.LastIndexOf("ns") - 1);
        }


        public static string GetChildKeyXPath(string textLine)
        {
            //gets child key ignores attributes
            textLine = textLine.Substring(textLine.LastIndexOf("/ns"), textLine.Length - textLine.LastIndexOf("/ns"));
            var attributes = textLine.Substring(textLine.IndexOf('[')+1, textLine.Length - textLine.IndexOf('[')-1) + " ";
            var splits = attributes.Split('@');
            return string.Format("{0}={1}={2}", textLine.Substring(textLine.IndexOf(":") + 1, textLine.IndexOf('[') == -1 ? textLine.Length - textLine.IndexOf(":") -1 : textLine.IndexOf('[') - textLine.IndexOf(':')-1),
                    GetTagValue(splits, "Name"), GetTagValue(splits, "Condition"));
        }

        private static string GetTagValue(string[] splits, string value)
        {
            var result = splits.Where(x => x.StartsWith(value)).FirstOrDefault();
            if(result != null)
                return result.Substring(result.IndexOf('=') + 1, result.Length - result.IndexOf('=')-1);
            return string.Empty;
        }
    }
}
