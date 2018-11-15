# gx-sorter
By Daniel Aldwell
15/11/2018

----------------------
1. Description
----------------------

This is a simple Visual Studio C# program that takes a list of people's names from an input text file, sorts the names in alphabetical order by the last and given names, and outputs the result to the screen and an output text file.

This is accomplished by implementing a merge sort algorithm.

Note that the sorting operation could be implemented in a trivial fashion by using one of the existing .NET libraries i.e. a LINQ query or a comparer object. A custom merge sort algorithm was chosen to help showcase my coding style and ability.

----------------------
2. Assumptions
----------------------

- A name must not contain special characters
- A name must not contain digits
- A name must contain at least one last name and one given name
- A name can have at most 3 given names
- Names are case-insensitive for the purpose of sorting (i.e. lower/uppercase characters are treated as identical)


----------------------
3. Class file overview
----------------------

----------------
SortMain.cs
----------------
The main entry point for the program. Note that this is where you can specify the names of the input/output text files - these are passed directly into the sorter.SortFile method call. The current input file is already included in the project so you can edit this directly as needed and not have to change the file name in the program.

----------------
MergeSorter.cs
----------------
This is the primary driving class of the program. The SortFile method takes input/output file names as parameters, retrieves and validates the data from the text file, composes the list of name objects, and sorts them using a merge sort algorithm. The results are displayed on the screen and written to the specified output file in the working directory.

----------------
SortMain.cs
----------------
This is a class that represents a person's full name. It has separate fields for the last name and given names 1, 2, and 3. The constructor takes a name as a string and splits it out into each matching field.

The class definition also contains a method for comparing the name alphabetically to another name object as well as outputting the full name as a string.

----------------
SortUtil.cs
----------------
This class contains helper methods for the sorting operation i.e. reading/writing data files, validating input, name comparisons.

----------------
StringUtil.cs
----------------
Contains helper methods for string checking and manipulation.

----------------
FileUtil.cs
----------------
Contains helper methods for obtaining file read/write handles.


----------------------
4. Unit test overview
----------------------

----------------
NameCompareTest.cs
----------------
Checks that all sorting cases work correctly for two names i.e. sort before, sort after, or no sort needed.

----------------
NameValidateTest.cs
----------------
Checks that all name validation cases are handled correctly, as well as confirming that a valid name passes the checks.

----------------
ReadFileTest.cs
----------------
Checks that the default input file can be read.

----------------
SorterTest.cs
----------------
Checks that the merge sorter works correctly for a small sample of names.
