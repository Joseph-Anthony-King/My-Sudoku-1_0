﻿/**
 * SudokuExtensions.cs
 * By Joseph King
 * Published June 5, 2013
 * 
 * This is the extension class for the sudoku program
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySudoku1_0
{
    /// <summary>
    /// This extension method compares two lists to see if they have any similar elements
    /// </summary>
    public static class SudokuExtensions
    {
        public static bool ContainsAnySimilarElements(this IEnumerable<int> aList, IEnumerable<int> bList)
        {
            bool result = false;

            foreach (int a in aList)
            {
                if (bList.Contains(a))
                {
                    result = true;
                }
            }

            return result;
        }
    }

    /// <summary>
    /// This extension method compares verifies if a string can be parsed to an int
    /// </summary>
    public static class SudokuStringExtensions
    {
        public static bool TryParse(this string source)
        {
            int number;
            bool result;

            bool test = Int32.TryParse(source, out number);

            if (test == true)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
    }
}
