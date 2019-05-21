using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlComparer;
using XmlComparer.ConsoleApp;

namespace FileComparer.UI
{
    class Driver
    {
        public static void Main(string filename1,string filename2,string destinationfilepath,string newfilename)
        {
            try
            {
                var handler = new TestXmlCompareHandler(destinationfilepath,newfilename);

                using (var comparer = new Comparer(handler))
                {
                    comparer.Compare(filename1, filename2, handler);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex);
            }
        }
    }
}
