using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameSorter;

namespace NameCompareTest
{
    [TestClass]
    public class NameCompareTest
    {
        [TestMethod]
        public void TestName()
        {
            // Check equals
            Assert.AreEqual(0, SortUtil.CompareNames("Daniel", "Daniel"));

            // Check sorted before
            Assert.AreEqual(-1, SortUtil.CompareNames("Robert", "Wilson"));

            // Check sorted after
            Assert.AreEqual(1, SortUtil.CompareNames("Anderson", "Anders"));

        }
    }
}
