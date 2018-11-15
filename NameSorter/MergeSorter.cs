using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    The main Sorter class
    Contains all methods for sorting a list of names
    Uses a merge sorting algorithm
*/

namespace NameSorter
{
    public class MergeSorter
    {

        /// <summary>
        /// Sort all names within the given read file and output to write file.
        /// </summary>
        /// <param name="infile"></param>
        /// <param name="outfile"></param>
        public void SortFile(string infile, string outfile)
        {
            List<NameObject> sortedNamesList = MergeSort(SortUtil.ReadNamesFromFile(infile));
            SortUtil.WriteNamesToFile(sortedNamesList, outfile);
        }

        /// <summary>
        /// Recursive method to break down the list of names to be sorted.
        /// Once list is completely divided, merge and sort the results together.
        /// </summary>
        /// <param name="listMain"></param>
        /// <returns>Merged and sorted list of names</returns>
        public List<NameObject> MergeSort(List<NameObject> listMain)
        {
            int m = listMain.Count / 2;

            // Base case
            if (m == 0)
            {
                return listMain;
            }

            List<NameObject> listLeft = MergeSort(Split(listMain, 0, m));
            List<NameObject> listRight = MergeSort(Split(listMain, m, listMain.Count));
            return Merge(listLeft, listRight);
        }


        /// <summary>
        /// Merge and sort two lists together.
        /// Compares each element in the two lists and sorts them into the merged list accordingly.
        /// </summary>
        /// <param name="listLeft"></param>
        /// <param name="listRight"></param>
        /// <returns>Merged and sorted list of names</returns>
        private List<NameObject> Merge(List<NameObject> listLeft, List<NameObject> listRight)
        {
            List<NameObject> listRet = new List<NameObject>();

            int i = 0;
            int j = 0;

            int listCount = listLeft.Count + listRight.Count;

            for (int k = 0; k < listCount; k++)
            {

                if (j == listRight.Count || (i < listLeft.Count && listLeft[i].Compare(listRight[j]) == -1))
                {
                    listRet.Add(listLeft[i]);
                    i++;
                }
                else
                {
                    listRet.Add(listRight[j]);
                    j++;
                }

            }

            return listRet;
        }

        /// <summary>
        /// Helper method to split a list within the given start and end points.
        /// </summary>
        /// <param name="listIn"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        private List<NameObject> Split(List<NameObject> listIn, int l, int r)
        {
            List<NameObject> listRet = new List<NameObject>();

            for (int i = 0; l + i < r; i++)
            {
                listRet.Add(listIn[l + i]);
            }

            return listRet;
        }



    }
}
