using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameSorter;

namespace NameValidateTest
{
    [TestClass]
    public class NameValidateTest
    {
        [TestMethod]
        public void TestValidate()
        {

            Boolean validate = false;

            // First, ensure that a valid name passes all checks
            try
            {
                validate = false;
                SortUtil.ValidateName("Bob Jane");
                SortUtil.ValidateName("Bob Robert Jane");
                SortUtil.ValidateName("Bob Robert Mc Jane");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                validate = true;
            }

            Assert.IsFalse(validate);


            // Validate that name does not contain special characters
            validate = StringUtil.ContainsSpecialChars("Bob $Jane");            
            Assert.IsTrue(validate);

            // Validate that name does not contain digits
            validate = StringUtil.ContainsDigits("Bob 1Jane");
            Assert.IsTrue(validate);

            // Validate that name contains at least one given and one last name
            try
            {
                validate = false;
                SortUtil.ValidateName("Bob");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                validate = true;
            }

            Assert.IsTrue(validate);

            // Validate that name contains no more than 3 given names
            try
            {
                validate = false;
                SortUtil.ValidateName("Bob Bob Bob Bob Jane");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                validate = true;
            }

            Assert.IsTrue(validate);

        }
    }
}
