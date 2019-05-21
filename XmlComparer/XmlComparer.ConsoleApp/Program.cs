using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace XmlComparer.ConsoleApp
{
    class Program 
    {
        static void Main(string[] args)
        {
            try
            {
               // var file1 = @".\TestFiles\a1.config";
                //var file2 = @".\TestFiles\a2.config";
                var file1 = @"D:\Perforce\depot\iView\GTM_Branches\Release\iVux21C_24.00.00\Content\IVW3\DHL\Bally\SoftGmu\Config\AppsConfig\Models.xml";
                var file2 = @"D:\Perforce\depot\iView\GTM_Branches\Release\iVux21C_24.00.00\Content\IVW3\DHD\Bally\SoftGmu\Config\AppsConfig\Models.xml";
                
                var handler = new TestXmlCompareHandler();

                using (var comparer = new Comparer(handler))
                {
                    comparer.Compare(file1, file2, handler);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex);
            }
            Console.Write("Press RETURN to close...");
            Console.ReadLine();
        }

    }
}
