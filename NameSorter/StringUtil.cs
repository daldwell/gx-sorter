using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*
    String Utility class
    Custom methods for String operations
*/

namespace NameSorter
{
    public class StringUtil
    {
        
        /// <summary>
        /// Automatically appends a carriage return plus a given string to a Stringbuilder object.
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="str"></param>
        public static void AddNewLine(StringBuilder sb, string str)
        {
            if (sb.Length > 0)
            {
                sb.Append("\n");
            }

            sb.Append(str);

        }


        /// <summary>
        /// Helper method to return an uppercased character at a specified point in a string.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static char GetUpperChar(string name, int i)
        {
            return name.ToUpper()[i];
        }


        /// <summary>
        /// Helper method to determine whether a string contains non-alphanumeric characters.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Boolean ContainsSpecialChars(string s)
        {
            return !Regex.IsMatch(s, @"^[a-zA-Z0-9 ]*$");
        }


        /// <summary>
        /// Helper method to determine a string contains digits (i.e. characters 1-9).
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Boolean ContainsDigits(string s)
        {
            return Regex.IsMatch(s, @"\d\p{L}");
        }

    }
}
