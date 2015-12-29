﻿/**
 * Element.cs
 * By Joseph King
 * Published June 5, 2013
 * 
 * This is the element class for the sudoku program
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySudoku1_0
{
    /// <summary>
    /// This class defines the elements of the sudoku matrix
    /// </summary>
    public class Element
    {
        // This field holds the element's value
        private int _number;

        // This field indicates if the value is displayed as a hint
        private bool _displayHint;

        // This property gets and sets the element's value
        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        // This property gets and sets the element's display hint
        public bool DisplayHint
        {
            get { return _displayHint; }
            set { _displayHint = value; }
        }

        // The constructor
        public Element(int x)
        {
            _number = x;
            _displayHint = false;
        }

        public override string ToString()
        {
            string s = Number.ToString();
            return s;
        }
    }
}
