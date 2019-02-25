using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace XmlComparer.ConsoleApp
{
    public class TestXmlCompareHandler : IXmlCompareHandler
    {

        private StringBuilder output = new StringBuilder();
        public void ElementAdded(ElementAddedEventArgs e)
        {
            this.output.Clear();

            this.output.Append("Element Added: " );
            this.output.Append(e.Element +" "+ e.LineNumber +" "+ e.XPath);
            this.output.Append(Environment.NewLine);
            this.writeToFile(this.output.ToString());
        }

        public void ElementRemoved(ElementRemovedEventArgs e)
        {
            this.output.Clear();
            this.output.Append("Element Removed: ");
            this.output.Append(e.Element + " " + e.LineNumber + " " + e.XPath);
            this.output.Append(Environment.NewLine);
            this.writeToFile(this.output.ToString());
        }

        public void ElementChanged(ElementChangedEventArgs e)
        {
            this.output.Clear();
            this.output.Append("Element Changed: " + e.XPath);
            this.output.Append(e.LeftElement.Value + " " + e.LeftLineNumber );
            this.output.Append(e.RightLineNumber + "" + e.RightElement.Value);
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
            this.output.Append(e.RightAttribute.Value + " " + e.RightLineNumber );
            this.output.Append(Environment.NewLine);
            this.writeToFile(this.output.ToString());            
        }

        public void writeToFile(string element){        
        // Set a variable to the Documents path.
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // Append text to an existing file named "WriteLines.txt".
        using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "comparedResult.txt"), true))
        {
            outputFile.WriteLine(element);            
        }
        }
    }
}
