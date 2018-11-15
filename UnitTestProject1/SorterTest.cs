using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameSorter;

namespace SorterTest
{
    [TestClass]
    public class SorterTest
    {
        [TestMethod]
        public void SortTest()
        {
            // Input to be sorted
            List<NameObject> unsortedList = new List<NameObject>();
            unsortedList.Add(new NameObject("Janet Parsons"));
            unsortedList.Add(new NameObject("Vaughn Lewis"));
            unsortedList.Add(new NameObject("Adonis Julius Archer"));
            unsortedList.Add(new NameObject("Shelby Nathan Yoder"));
            unsortedList.Add(new NameObject("Marin Alvarez"));
            unsortedList.Add(new NameObject("London Lindsey"));
            unsortedList.Add(new NameObject("Beau Tristan Bentley"));
            unsortedList.Add(new NameObject("Leo Gardner"));
            unsortedList.Add(new NameObject("Hunter Uriah Mathew Clarke"));
            unsortedList.Add(new NameObject("Mikayla Lopez"));
            unsortedList.Add(new NameObject("Frankie Conner Ritter"));

            MergeSorter sorter = new MergeSorter();
            List<NameObject> sortedList = sorter.MergeSort(unsortedList);

            // Expected output
            StringBuilder exp = new StringBuilder();
            StringUtil.AddNewLine(exp, "Marin Alvarez");
            StringUtil.AddNewLine(exp, "Adonis Julius Archer");
            StringUtil.AddNewLine(exp, "Beau Tristan Bentley");
            StringUtil.AddNewLine(exp, "Hunter Uriah Mathew Clarke");
            StringUtil.AddNewLine(exp, "Leo Gardner");
            StringUtil.AddNewLine(exp, "Vaughn Lewis");
            StringUtil.AddNewLine(exp, "London Lindsey");
            StringUtil.AddNewLine(exp, "Mikayla Lopez");
            StringUtil.AddNewLine(exp, "Janet Parsons");
            StringUtil.AddNewLine(exp, "Frankie Conner Ritter");
            StringUtil.AddNewLine(exp, "Shelby Nathan Yoder");

            StringBuilder act = new StringBuilder();

            foreach(NameObject n in sortedList)
            {
                StringUtil.AddNewLine(act, n.ToString());
            }

            Assert.AreEqual(exp.ToString(), act.ToString());

        }
    }
}
