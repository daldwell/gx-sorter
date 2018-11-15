using NameSorter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    The main class
    Entry point for name sorter program
*/

namespace SortMain
{
    class SortMain
    {

        static void Main(string[] args)
        {

            List<NameObject> unsortedNameList = new List<NameObject>();
    
            MergeSorter sorter = new MergeSorter();
            sorter.SortFile("unsorted-names-list.txt", "sorted-names-list.txt");
            
            Console.ReadLine();

        }
    }
}
