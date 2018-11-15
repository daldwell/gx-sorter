using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    The File Utility class
    Contains methods for obtaining I/O file handles
*/

namespace NameSorter
{
    public class FileUtil
    {

        /// <summary>
        /// Helper method to get a text file writer 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static StreamWriter GetFileWriter(string filename)
        {
            return new StreamWriter(filename);
        }

        /// <summary>
        /// Helper method to get a text file reader
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static StreamReader GetFileReader(string filename)
        {
            try
            {
                return new StreamReader(filename);
            }
            catch (FileNotFoundException e)
            {
                // The file could not be found
                Console.WriteLine("The file name " + filename + " was not found.");
                throw e;
            }
            catch (Exception e)
            {
                // Log all other errors to user
                Console.WriteLine("An error has occured reading file " + filename, e);
                throw e;
            }
        }
    }
}
