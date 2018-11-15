using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    The Name class
    Represents a person's full name (last name and up to 3 given names)
*/

namespace NameSorter
{
    public class NameObject
    {

        private string Givn_nam1 { get; set; }
        private string Givn_nam2 { get; set; }
        private string Givn_nam3 { get; set; }
        private string Last_name { get; set; }

        public NameObject() { }

        public NameObject(string name)
        {
            string[] names = name.Split(' ');

            for (int i = 0; i < names.Length; i++)
            {
                // If this is the last string in the array it is the last name
                if (i == names.Length - 1)
                {
                    Last_name = names[i];
                }

                else
                {
                    // Otherwise add the name to the field that corresponds to the array index 
                    switch (i)

                    {
                        case 0:
                            Givn_nam1 = names[i];
                            break;
                        case 1:
                            Givn_nam2 = names[i];
                            break;
                        case 2:
                            Givn_nam3 = names[i];
                            break;
                    }
                }
            }
        }

        public override string ToString()
        {
            // First name and last name are mandatory - always add these
            StringBuilder str = new StringBuilder(Givn_nam1);

            // Given names 2 and 3 are optional - only add them if they exist
            str.Append(!String.IsNullOrEmpty(Givn_nam2) ? " " + Givn_nam2 : "");
            str.Append(!String.IsNullOrEmpty(Givn_nam3) ? " " + Givn_nam3 : "");

            str.Append(" " + Last_name);

            return str.ToString();
        }

        /// <summary>
        /// Compares the alphabetical order of two full names.
        /// Orders by Last Name, Given Name 1, Given Name 2, Given Name 3.
        /// </summary>
        /// <param name="obj2"></param>
        /// <returns></returns>
        public int Compare(NameObject obj2)
        {
            NameObject obj1 = this; // Assign context object the name obj1 for readability

            int i = 0;

            // Compare last name first
            i = SortUtil.CompareNames(obj1.Last_name, obj2.Last_name);

            if (i != 0)
                return i;

            // Compare 1st given name
            i = i = SortUtil.CompareNames(obj1.Givn_nam1, obj2.Givn_nam1);

            if (i != 0)
                return i;

            // Compare 2nd given name
            i = SortUtil.CompareNames(obj1.Givn_nam2, obj2.Givn_nam2);

            if (i != 0)
                return i;

            // Compare 3rd given name
            // Always return the result as we have no names left to compare
            i = SortUtil.CompareNames(obj1.Givn_nam3, obj2.Givn_nam3);


            return i;
        }
    }
}
