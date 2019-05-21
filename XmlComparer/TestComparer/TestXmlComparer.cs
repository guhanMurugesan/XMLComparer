using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XmlComparer;
using XmlComparer.ConsoleApp;

namespace TestComparer
{
    [TestFixture]
    public class TestXmlComparer
    {
        public string currentPath;
        [SetUp]
        public void Init()
        {
            currentPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public void TestChangedProp()
        {
            var handler = new TestXmlCompareHandler();
            Comparer comparer = new Comparer();
            comparer.Compare(@"XmlFiles/Models.xml", @"XmlFiles/Models1.xml", handler);

            //normal operation
            IsPropertyChanged("MaxBet", comparer);
            IsPropertyRemoved("ShouldWaitForPdb", comparer);
            IsPropertyAdded("BroadcastAddress", comparer);
            
            //condition change in right file
            IsPropertyRemoved("FundTransferType", comparer);
            IsPropertyAdded("FundTransferType", comparer);

            //condition change in left file
            IsPropertyRemoved("AlternateAccountLookup", comparer);
            IsPropertyAdded("AlternateAccountLookup", comparer);

            //removed property in a list
            //IsPropertyRemoved("MeterTracker", comparer);

            //removed property from a list in left file
            IsPropertyAdded("3", comparer);

            //removing object in right file
            IsPropertyRemoved("G2SModel", comparer);

            //removing object in left file
            IsPropertyAdded("PhysicalIdReader", comparer);

            EnsureListCount(5,4,1,comparer);
        }

        #region XmlComparer

        private void IsPropertyChanged(string value,Comparer comparer)
        {
            var result = comparer.changes.Where(x=>x.XPath.Contains(value)).Any();
            Assert.IsTrue(result);
        }

        private void IsPropertyAdded(string value, Comparer comparer)
        {
            var result = comparer.additions.Where(x => x.XPath.Contains(value)).Any();
            Assert.IsTrue(result);
        }

        private void IsPropertyRemoved(string value, Comparer comparer)
        {
            var result = comparer.removals.Where(x => x.XPath.Contains(value)).Any();
            Assert.IsTrue(result);
        }

        private void EnsureListCount(int added,int removed,int changed,Comparer comparer)
        {
            Assert.AreEqual(comparer.additions.Count,added);
            Assert.AreEqual(comparer.removals.Count,removed);
            Assert.AreEqual(comparer.changes.Count,changed);
        }

        #endregion
    }
}
