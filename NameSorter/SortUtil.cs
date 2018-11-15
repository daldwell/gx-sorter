using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*
    The Sorting Utility class
    Contains helper methods for the main sort class
*/

namespace NameSorter
{
    public class SortUtil
    {

        /// <summary>
        /// Compares the alphabetic order of two strings.
        /// Each character in the string is checked until the first difference found - the result is returned once this happens.
        /// If name1 and name2 are of different lengths but are equal up to the shorter length, the longer name is sorted after.
        /// If one of the names is empty but not the other, the non-empty name is sorted after.
        /// Note that names are treated as case-insensitive when sorting.
        /// </summary>
        /// <param name="name1"></param>
        /// <param name="name2"></param>
        /// <returns>-1 if name1 is sorted before name2, 0 if both strings equal, 1 if name1 is sorted after name2</returns>
        public static int CompareNames(string name1, string name2)
        {

            // Check null cases first
            // If a string does not contain the given name, it will be sorted before the one that does
            // If neither strings contain a value they are treated as equal
            if (String.IsNullOrEmpty(name1) && String.IsNullOrEmpty(name2))
            {
                return 0;
            } 
            else if (!String.IsNullOrEmpty(name1) && String.IsNullOrEmpty(name2))
            {
                return 1;
            }
            else if (String.IsNullOrEmpty(name1) && !String.IsNullOrEmpty(name2))
            {
                return -1;
            }


            // If no nulls on either string we can safely compare the characters of each string
            // Assumed that names are case-insensitive so convert them to upper before comparing
            // Return as soon as we get a different character from each string for the same index
            // If we reach the end of a string before the other, the shorter string is ordered first
            for (int i = 0; i < name1.Length && i < name2.Length; i++)
            {
                if (StringUtil.GetUpperChar(name1, i) < StringUtil.GetUpperChar(name2, i))
                {
                    return -1;
                }
                else if (StringUtil.GetUpperChar(name1, i) > StringUtil.GetUpperChar(name2, i))
                {
                    return 1;
                }
                else if (i == name1.Length - 1 && i != name2.Length - 1)
                {
                    return -1;
                }
                else if (i == name2.Length - 1 && i != name1.Length - 1)
                {
                    return 1;
                }
            }

            return 0;

        }

        /// <summary>
        /// Validates a person's name prior to sorting.
        /// The following rules apply:
        /// 1. The name must not contain special (non-alphanumeric) characters.
        /// 2. The name must not contain digits.
        /// 3. There must be at least one full name and one given name.
        /// 4. There can only be at most 3 given names.
        /// </summary>
        /// <param name="name"></param>
        public static void ValidateName(string name)
        {

            StringBuilder error = new StringBuilder();

            // Name should not contain special characters
            if (StringUtil.ContainsSpecialChars(name))
            {
                StringUtil.AddNewLine(error, name + " must not contain special characters.");
            }

            // Name must not contain digits
            if (StringUtil.ContainsDigits(name))
            {
                StringUtil.AddNewLine(error, name + " must not contain digits");
            }

            string[] names = name.Split(' ');

            // Full name must have at least one given name
            if (names.Length < 2)
            {
                StringUtil.AddNewLine(error, name + " must have at least one given name. ");
            }

            // Full name must not consist of more than 3 given names and 1 last name (i.e. 4 names max)
            if (names.Length > 4)
            {
                StringUtil.AddNewLine(error, name + " must have no more than 3 given names. ");
            }

            if (error.Length > 0)
            {
                throw new Exception(error.ToString());
            }

        }

        /// <summary>
        /// Write list of sorted name objects to file.
        /// </summary>
        /// <param name="names"></param>
        /// <param name="filename"></param>
        public static void WriteNamesToFile(List<NameObject> names, string filename)
        {

            using (System.IO.StreamWriter file = FileUtil.GetFileWriter(filename))
            {

                foreach (NameObject n in names)
                {
                    file.WriteLine(n.ToString());
                    Console.WriteLine(n.ToString());
                }

            }
        }

        /// <summary>
        /// Read names from file.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static List<NameObject> ReadNamesFromFile(string filename)
        {

            List<NameObject> nameList = new List<NameObject>();

            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (StreamReader sr = FileUtil.GetFileReader(filename))
            {
                string line;

                // Read and display lines from the file until 
                // the end of the file is reached. 
                while ((line = sr.ReadLine()) != null)
                {
                    ValidateName(line);
                    nameList.Add(new NameObject(line));
                }
            }

            return nameList;
        }

    }


}

