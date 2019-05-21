using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace XmlComparer.ConsoleApp
{
    public class TestXmlCompareHandler : IXmlCompareHandler
    {
        private string DestinationFilePath;
        private string Filename;

        public TestXmlCompareHandler(string filePath,string filename)
        {
            DestinationFilePath = filePath;
            Filename = filename;
        }

        public TestXmlCompareHandler()
        {

        }

        private StringBuilder output = new StringBuilder();
        public void ElementAdded(ElementAddedEventArgs e)
        {
            this.output.Clear();

            this.output.Append("Element Added in right file at : " + e.LineNumber + Environment.NewLine);
            this.output.Append(e.Element.TruncateChildren() + Environment.NewLine+"xPath=>" + e.XPath);
            this.output.Append(Environment.NewLine);
            this.writeToFile(this.output.ToString());
        }

        public void ElementRemoved(ElementRemovedEventArgs e)
        {
            this.output.Clear();
            this.output.Append("Element Removed in left file at : " + e.LineNumber + Environment.NewLine);
            this.output.Append(e.Element.TruncateChildren() + Environment.NewLine + "xPath=>" + e.XPath);
            this.output.Append(Environment.NewLine);
            this.writeToFile(this.output.ToString());
        }

        public void ElementChanged(ElementChangedEventArgs e)
        {
            this.output.Clear();
            this.output.Append("Element Changed: " + e.XPath+Environment.NewLine);
            this.output.Append("Left file at " + + e.LeftLineNumber+ " "+ e.LeftElement.Value + " " + Environment.NewLine);
            this.output.Append("Right file at "+e.RightLineNumber + " " + e.RightElement.Value);
            this.output.Append(Environment.NewLine);
            this.writeToFile(this.output.ToString());
        }

        public void AttributeAdded(AttributeAddedEventArgs e)
        {
            this.output.Clear();
            this.output.Append("Atttribute added: ");
            this.output.Append(e.Attribute.Value + "" + e.LineNumber + "" + e.XPath);
            this.output.Append(Environment.NewLine);
            this.writeToFile(this.output.ToString());
        }

        public void AttributeRemoved(AttributeRemovedEventArgs e)
        {
            this.output.Clear();
            this.output.Append("Attribute Removed: ");
            this.output.Append(e.Attribute.Value + " " +e.LineNumber + " " +e.XPath);
            this.output.Append(Environment.NewLine);
            this.writeToFile(this.output.ToString());
        }

        public void AttributeChanged(AttributeChangedEventArgs e)
        {
            this.output.Clear();
            this.output.Append("Attribute Changed: " + e.XPath);
            this.output.Append(e.LeftAttribute.Value + " " +e.LeftLineNumber);
            this.output.Append(Environment.NewLine);
            this.writeToFile(this.output.ToString());            
        }

        public void writeToFile(string element){
            if (!string.IsNullOrEmpty(DestinationFilePath))
            {
                // Append text to an existing file named "WriteLines.txt".
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(DestinationFilePath, !string.IsNullOrEmpty(Filename) ? Filename+".txt" : "comparedResult.txt"), true))
                {
                    outputFile.WriteLine(element);
                }
            }

            else
            {
                // Set a variable to the Documents path.
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, !string.IsNullOrEmpty(Filename) ? Filename + ".txt" : "comparedResult.txt"), true))
                {
                    outputFile.WriteLine(element);
                }
            }
        }
    }
}
