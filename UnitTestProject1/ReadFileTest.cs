using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameSorter;

namespace ReadFileTest
{
    [TestClass]
    public class ReadFileTest
    {
        [TestMethod]
        public void TestFile()
        {

            System.IO.StreamReader sr = null;

            try
            {
                sr = FileUtil.GetFileReader("unsorted-names-list.txt");
            } 
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            Assert.IsNotNull(sr);
        }
    }
}
