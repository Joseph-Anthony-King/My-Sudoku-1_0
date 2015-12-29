﻿/**
 * My Sudoku
 * By Joseph King
 * Published June 5, 2013
 * 
 * This is the main class for the sudoku program
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MySudoku1_0
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set the title
            Console.Title = "My Sudoku";

            // Set the screen size
            Console.SetWindowSize(80, 50);

            // Set the console foreground to cyan
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Display the splash screen
            SplashScreenDisplayed();

            // Display the instructions
            SudokuInstructionsDisplayed();

            // A constant int value to determine how many elements
            // are displayed
            const int DISPLAY = 27;

            // Create a list of lists to hold the sudoku matrix
            List<List<int>> _sudokuMatrix = new List<List<int>>();

            // Generate a random and load a sudoku matrix
            _sudokuMatrix = SudokuGenerator();

            // Create a list to hold the sudoku matrix
            // This will make it easier to evaluate the users answer
            List<int> _sudokuSolution = new List<int>();

            // Load the sudoku matrix into the solution
            foreach (List<int> _row in _sudokuMatrix)
            {
                foreach (int _number in _row)
                {
                    _sudokuSolution.Add(_number);
                }
            }

            // Create the solution string which will be used to test the users solution
            string _solutionString = "";

            foreach (int _number in _sudokuSolution)
            {
                _solutionString = _solutionString + _number + " ";
            }

            // Create a list of element objects, this will be used to
            // create the display
            List<Element> _elementList = new List<Element>();

            // Load the element list with elements
            foreach (int _element in _sudokuSolution)
            {
                Element element = new Element(_element);
                _elementList.Add(element);
            }

            // Determine how many hints will be given to the user
            for (int i = 0; i < DISPLAY; )
            {
                int j = _random.Next(0, _elementList.Count - 1);

                if (_elementList[j].DisplayHint == false)
                {
                    _elementList[j].DisplayHint = true;
                    i++;
                }
            }

            // Create a string to hold the values from the element list
            // This will be used to create the display
            StringBuilder _elementSB = new StringBuilder();

            // Convert the element list into a StringBuilder
            // This StringBuilder is passed to the diplay to build the game board
            // This also records the users entries
            foreach (Element element in _elementList)
            {
                if (element.DisplayHint == true)
                {
                    _elementSB.Append(element.ToString() + " ");
                }
                else
                {
                    _elementSB.Append("_ ");
                }
            }

            // The following fields are used within the game
            // This field determines if the user is playing
            bool _continue = true;

            // This field stores the users response
            string _response;

            do
            {
                // Display the game board
                GameBoard(_elementSB);

                // Take the users response
                _response = Console.ReadLine();

                if (_response.TryParse())
                {

                    int _action = Convert.ToInt32(_response);

                    if (_action > 0 && _action < 6)
                    {
                        // These actions allow the user to enter and delete a value
                        // The code to select the x and y coordinate is the same for each value
                        // The initial choice from the user determines if this is an update of delete
                        if (_action == 1 || _action == 2)
                        {
                            bool _continueX = true;
                            do
                            {
                                Console.Write("\nEnter the X Coordinate> ");
                                string _xValue = Console.ReadLine();

                                if (_xValue.TryParse())
                                {
                                    int _xInt = Convert.ToInt32(_xValue);

                                    if (_xInt > 0 && _xInt < 10)
                                    {
                                        bool _continueY = true;
                                        do
                                        {
                                            Console.Write("\nEnter the Y Coordinate> ");
                                            string _yValue = Console.ReadLine();

                                            if (_yValue.TryParse())
                                            {
                                                int _yInt = Convert.ToInt32(_yValue);

                                                if (_yInt > 0 && _yInt < 10)
                                                {
                                                    // The indexer to change the string
                                                    int indexer;

                                                    // The indexer to access the element from the element string
                                                    int indexer2;

                                                    // The x value will be transformed to a
                                                    int a = 0;

                                                    // The y value will be transformed to b
                                                    int b = 0;

                                                    // The b2 value is required to index the element
                                                    int b2 = 0;

                                                    // Transform x into a
                                                    for (int i = 1; i < _xInt; i++)
                                                    {
                                                        a = a + 2;
                                                    }

                                                    // Transform y int b
                                                    for (int i = 1; i < _yInt; i++)
                                                    {
                                                        b = b + 18;
                                                    }

                                                    // Transform y int b2
                                                    for (int i = 1; i < _yInt; i++)
                                                    {
                                                        b2 = b2 + 9;
                                                    }

                                                    // Add a and b to ascertain the indexer
                                                    indexer = a + b;

                                                    // Add _xInt and b2 to ascertain indexer2
                                                    indexer2 = _xInt + b2 - 1;

                                                    if (_elementList[indexer2].DisplayHint == false)
                                                    {
                                                        bool _userEntryInvalid = true;

                                                        do
                                                        {
                                                            if (_action == 1)
                                                            {
                                                                Console.Write("\nEnter a number from 1 through 9> ");
                                                                string _userEntry = Console.ReadLine();

                                                                if (_userEntry.TryParse())
                                                                {
                                                                    int _userInt = Convert.ToInt32(_userEntry);

                                                                    if (_userInt > 0 && _userInt < 10)
                                                                    {
                                                                        _elementSB.Remove(indexer, 1);
                                                                        _elementSB.Insert(indexer, _userEntry);
                                                                        Console.Clear();
                                                                        _continueX = false;
                                                                        _continueY = false;
                                                                        _userEntryInvalid = false;
                                                                    }
                                                                    else
                                                                    {
                                                                        InvalidCoordinate();
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    InvalidCoordinate();
                                                                }
                                                            }
                                                            else
                                                            {
                                                                _elementSB.Remove(indexer, 1);
                                                                _elementSB.Insert(indexer, "_");
                                                                Console.Clear();
                                                                _continueX = false;
                                                                _continueY = false;
                                                                _userEntryInvalid = false;

                                                            }
                                                        }
                                                        while (_userEntryInvalid);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("\nThis value is a hint provided by the system and cannot be changed.");
                                                        Console.WriteLine("Please try again.\n\n(Press Enter to Continue)");
                                                        Console.ReadLine();
                                                        break;
                                                    }
                                                }
                                                else
                                                {
                                                    InvalidCoordinate();
                                                }
                                            }
                                            else
                                            {
                                                InvalidCoordinate();
                                            }
                                        }
                                        while (_continueY == true);
                                    }
                                    else
                                    {
                                        InvalidCoordinate();
                                    }
                                }
                                else
                                {
                                    InvalidCoordinate();
                                }
                            }
                            while (_continueX == true);
                        }

                        // This action allows the user to reset the board
                        else if (_action == 3)
                        {
                            _elementSB.Clear();
                            foreach (Element element in _elementList)
                            {
                                if (element.DisplayHint == true)
                                {
                                    _elementSB.Append(element.ToString() + " ");
                                }
                                else
                                {
                                    _elementSB.Append("_ ");
                                }
                            }
                            Console.Clear();
                        }

                        else if (_action == 4)
                        {
                            //Comment these lines out to see the victory screen
                            //YouWin(_elementSB);
                            //_continue = false;

                            // Use the element string builder to create the users solution
                            string _userSolution = _elementSB.ToString();

                            // Determine if the user wins!
                            if (_solutionString.Equals(_userSolution))
                            {
                                YouWin(_elementSB);
                                _continue = false;
                            }
                            else
                            {
                                // If the solution is not correct the keeps the correct responses from the user
                                Console.WriteLine("\nClose but no cigar!\nTry again!\n\n(Press Enter to Continue)");
                                Console.ReadLine();
                                Console.WriteLine("Here, I'll help you out and show you were you're right.\n\n(Press Enter to Continue)");
                                Console.ReadLine();

                                // Turns the claimant's solution to a string
                                string _assistanceString = _elementSB.ToString();

                                // Turns the solution to a char array
                                char[] _solutionArray = _solutionString.ToCharArray();

                                // Turns the user's solution to a char array
                                char[] _assistanceArray = _assistanceString.ToCharArray();

                                // If the value in the user's char array is incorrect its converted to "_"
                                for (int i = 0; i < _assistanceString.Length; i++)
                                {
                                    if (_solutionArray[i] != _assistanceArray[i])
                                    {
                                        _assistanceArray[i] = '_';
                                    }

                                }

                                // Clears the user's response
                                _elementSB.Clear();

                                // Refills the element string builder with the corrected array
                                foreach (char a in _assistanceArray)
                                {
                                    _elementSB.Append(a);
                                }

                                Console.Clear();
                            }
                        }

                        else if (_action == 5)
                        {
                            Console.WriteLine("\nThanks for playing!\n\n(Press Enter to Exit)");
                            Console.ReadLine();
                            _continue = false;
                        }
                    }
                    else
                    {
                        InvalidAction();
                    }
                }
                else
                {
                    InvalidAction();
                }

            }
            while (_continue == true);
        }

        #region SudokuGenerator()

        // This method generates a random sudoku matrix
        public static List<List<int>> SudokuGenerator()
        {
            // The list of int lists that is returned by the method
            List<List<int>> result = new List<List<int>>();

            // create a range of nine numbers
            IEnumerable<int> _rangeOfNineNumbers = Enumerable.Range(1, 9);

            // create the first row
            List<int> _firstRow = new List<int>();

            foreach (int number in _rangeOfNineNumbers)
            {
                _firstRow.Add(number);
            }

            Shuffle(_firstRow);

            // Create the second row
            List<int> _secondRow = new List<int>();

            foreach (int number in _rangeOfNineNumbers)
            {
                _secondRow.Add(number);
            }

            do
            {
                Shuffle(_secondRow);
            }
            while (
                (_firstRow.Take(3).OrderBy(n => n).ContainsAnySimilarElements(_secondRow.Take(3).OrderBy(n => n))) ||
                (_firstRow.Skip(3).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_secondRow.Skip(3).Take(3).OrderBy(n => n))) ||
                (_firstRow.Skip(6).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_secondRow.Skip(6).Take(3).OrderBy(n => n)))
                );

            // Create the third row
            List<int> _thirdRow = new List<int>();

            foreach (int number in _rangeOfNineNumbers)
            {
                _thirdRow.Add(number);
            }

            do
            {
                Shuffle(_thirdRow);
            }
            while (
                (_firstRow.Take(3).OrderBy(n => n).ContainsAnySimilarElements(_thirdRow.Take(3).OrderBy(n => n))) ||
                (_secondRow.Take(3).OrderBy(n => n).ContainsAnySimilarElements(_thirdRow.Take(3).OrderBy(n => n))) ||
                (_firstRow.Skip(3).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_thirdRow.Skip(3).Take(3).OrderBy(n => n))) ||
                (_secondRow.Skip(3).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_thirdRow.Skip(3).Take(3).OrderBy(n => n))) ||
                (_firstRow.Skip(6).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_thirdRow.Skip(6).Take(3).OrderBy(n => n))) ||
                (_secondRow.Skip(6).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_thirdRow.Skip(6).Take(3).OrderBy(n => n)))
                );

            // Rows four through nine require references to the columns

            // Create the first column
            List<int> _firstColumn = new List<int>();

            _firstColumn.Add(_firstRow[0]);
            _firstColumn.Add(_secondRow[0]);
            _firstColumn.Add(_thirdRow[0]);

            // Create the second column
            List<int> _secondColumn = new List<int>();

            _secondColumn.Add(_firstRow[1]);
            _secondColumn.Add(_secondRow[1]);
            _secondColumn.Add(_thirdRow[1]);

            // Create the third column
            List<int> _thirdColumn = new List<int>();

            _thirdColumn.Add(_firstRow[2]);
            _thirdColumn.Add(_secondRow[2]);
            _thirdColumn.Add(_thirdRow[2]);

            // Create the fourth column
            List<int> _fourthColumn = new List<int>();

            _fourthColumn.Add(_firstRow[3]);
            _fourthColumn.Add(_secondRow[3]);
            _fourthColumn.Add(_thirdRow[3]);

            // Create the fifth column
            List<int> _fifthColumn = new List<int>();

            _fifthColumn.Add(_firstRow[4]);
            _fifthColumn.Add(_secondRow[4]);
            _fifthColumn.Add(_thirdRow[4]);

            // Create the sixth column
            List<int> _sixthColumn = new List<int>();

            _sixthColumn.Add(_firstRow[5]);
            _sixthColumn.Add(_secondRow[5]);
            _sixthColumn.Add(_thirdRow[5]);

            // Create the seventh column
            List<int> _seventhColumn = new List<int>();

            _seventhColumn.Add(_firstRow[6]);
            _seventhColumn.Add(_secondRow[6]);
            _seventhColumn.Add(_thirdRow[6]);

            // Create the eighth column
            List<int> _eighthColumn = new List<int>();

            _eighthColumn.Add(_firstRow[7]);
            _eighthColumn.Add(_secondRow[7]);
            _eighthColumn.Add(_thirdRow[7]);

            // Create the ninth column
            List<int> _ninthColumn = new List<int>();

            _ninthColumn.Add(_firstRow[8]);
            _ninthColumn.Add(_secondRow[8]);
            _ninthColumn.Add(_thirdRow[8]);

            // Create the fourth row
            List<int> _fourthRow = new List<int>();

            foreach (int number in _rangeOfNineNumbers)
            {
                _fourthRow.Add(number);
            }

            do
            {
                Shuffle(_fourthRow);
            }
            while (
                (_firstColumn.Contains(_fourthRow[0])) ||
                (_secondColumn.Contains(_fourthRow[1])) ||
                (_thirdColumn.Contains(_fourthRow[2])) ||
                (_fourthColumn.Contains(_fourthRow[3])) ||
                (_fifthColumn.Contains(_fourthRow[4])) ||
                (_sixthColumn.Contains(_fourthRow[5])) ||
                (_seventhColumn.Contains(_fourthRow[6])) ||
                (_eighthColumn.Contains(_fourthRow[7])) ||
                (_ninthColumn.Contains(_fourthRow[8]))
                );

            _firstColumn.Add(_fourthRow[0]);
            _secondColumn.Add(_fourthRow[1]);
            _thirdColumn.Add(_fourthRow[2]);
            _fourthColumn.Add(_fourthRow[3]);
            _fifthColumn.Add(_fourthRow[4]);
            _sixthColumn.Add(_fourthRow[5]);
            _seventhColumn.Add(_fourthRow[6]);
            _eighthColumn.Add(_fourthRow[7]);
            _ninthColumn.Add(_fourthRow[8]);

            // Create the fifth row
            List<int> _fifthRow = new List<int>();

            foreach (int number in _rangeOfNineNumbers)
            {
                _fifthRow.Add(number);
            }

            do
            {
                Shuffle(_fifthRow);
            }
            while (
                (_firstColumn.Contains(_fifthRow[0])) ||
                (_secondColumn.Contains(_fifthRow[1])) ||
                (_thirdColumn.Contains(_fifthRow[2])) ||
                (_fourthColumn.Contains(_fifthRow[3])) ||
                (_fifthColumn.Contains(_fifthRow[4])) ||
                (_sixthColumn.Contains(_fifthRow[5])) ||
                (_seventhColumn.Contains(_fifthRow[6])) ||
                (_eighthColumn.Contains(_fifthRow[7])) ||
                (_ninthColumn.Contains(_fifthRow[8])) ||
                (_fourthRow.Take(3).OrderBy(n => n).ContainsAnySimilarElements(_fifthRow.Take(3).OrderBy(n => n))) ||
                (_fourthRow.Skip(3).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_fifthRow.Skip(3).Take(3).OrderBy(n => n))) ||
                (_fourthRow.Skip(6).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_fifthRow.Skip(6).Take(3).OrderBy(n => n)))
                );

            _firstColumn.Add(_fifthRow[0]);
            _secondColumn.Add(_fifthRow[1]);
            _thirdColumn.Add(_fifthRow[2]);
            _fourthColumn.Add(_fifthRow[3]);
            _fifthColumn.Add(_fifthRow[4]);
            _sixthColumn.Add(_fifthRow[5]);
            _seventhColumn.Add(_fifthRow[6]);
            _eighthColumn.Add(_fifthRow[7]);
            _ninthColumn.Add(_fifthRow[8]);

            // Create the sixth row
            List<int> _sixthRow = new List<int>();

            foreach (int number in _rangeOfNineNumbers)
            {
                _sixthRow.Add(number);
            }

            do
            {
                Shuffle(_sixthRow);
            }
            while (
                (_firstColumn.Contains(_sixthRow[0])) ||
                (_secondColumn.Contains(_sixthRow[1])) ||
                (_thirdColumn.Contains(_sixthRow[2])) ||
                (_fourthColumn.Contains(_sixthRow[3])) ||
                (_fifthColumn.Contains(_sixthRow[4])) ||
                (_sixthColumn.Contains(_sixthRow[5])) ||
                (_seventhColumn.Contains(_sixthRow[6])) ||
                (_eighthColumn.Contains(_sixthRow[7])) ||
                (_ninthColumn.Contains(_sixthRow[8])) ||
                (_fourthRow.Take(3).OrderBy(n => n).ContainsAnySimilarElements(_sixthRow.Take(3).OrderBy(n => n))) ||
                (_fifthRow.Take(3).OrderBy(n => n).ContainsAnySimilarElements(_sixthRow.Take(3).OrderBy(n => n))) ||
                (_fourthRow.Skip(3).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_sixthRow.Skip(3).Take(3).OrderBy(n => n))) ||
                (_fifthRow.Skip(3).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_sixthRow.Skip(3).Take(3).OrderBy(n => n))) ||
                (_fourthRow.Skip(6).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_sixthRow.Skip(6).Take(3).OrderBy(n => n))) ||
                (_fifthRow.Skip(6).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_sixthRow.Skip(6).Take(3).OrderBy(n => n)))
                );

            _firstColumn.Add(_sixthRow[0]);
            _secondColumn.Add(_sixthRow[1]);
            _thirdColumn.Add(_sixthRow[2]);
            _fourthColumn.Add(_sixthRow[3]);
            _fifthColumn.Add(_sixthRow[4]);
            _sixthColumn.Add(_sixthRow[5]);
            _seventhColumn.Add(_sixthRow[6]);
            _eighthColumn.Add(_sixthRow[7]);
            _ninthColumn.Add(_sixthRow[8]);

            // Create the seventh row
            List<int> _seventhRow = new List<int>();

            foreach (int number in _rangeOfNineNumbers)
            {
                _seventhRow.Add(number);
            }

            do
            {
                Shuffle(_seventhRow);
            }
            while (
                (_firstColumn.Contains(_seventhRow[0])) ||
                (_secondColumn.Contains(_seventhRow[1])) ||
                (_thirdColumn.Contains(_seventhRow[2])) ||
                (_fourthColumn.Contains(_seventhRow[3])) ||
                (_fifthColumn.Contains(_seventhRow[4])) ||
                (_sixthColumn.Contains(_seventhRow[5])) ||
                (_seventhColumn.Contains(_seventhRow[6])) ||
                (_eighthColumn.Contains(_seventhRow[7])) ||
                (_ninthColumn.Contains(_seventhRow[8]))
                );

            _firstColumn.Add(_seventhRow[0]);
            _secondColumn.Add(_seventhRow[1]);
            _thirdColumn.Add(_seventhRow[2]);
            _fourthColumn.Add(_seventhRow[3]);
            _fifthColumn.Add(_seventhRow[4]);
            _sixthColumn.Add(_seventhRow[5]);
            _seventhColumn.Add(_seventhRow[6]);
            _eighthColumn.Add(_seventhRow[7]);
            _ninthColumn.Add(_seventhRow[8]);

            // Create the eighth row
            List<int> _eighthRow = new List<int>();

            foreach (int number in _rangeOfNineNumbers)
            {
                _eighthRow.Add(number);
            }

            do
            {
                Shuffle(_eighthRow);
            }
            while (
                (_firstColumn.Contains(_eighthRow[0])) ||
                (_secondColumn.Contains(_eighthRow[1])) ||
                (_thirdColumn.Contains(_eighthRow[2])) ||
                (_fourthColumn.Contains(_eighthRow[3])) ||
                (_fifthColumn.Contains(_eighthRow[4])) ||
                (_sixthColumn.Contains(_eighthRow[5])) ||
                (_seventhColumn.Contains(_eighthRow[6])) ||
                (_eighthColumn.Contains(_eighthRow[7])) ||
                (_ninthColumn.Contains(_eighthRow[8])) ||
                (_seventhRow.Take(3).OrderBy(n => n).ContainsAnySimilarElements(_eighthRow.Take(3).OrderBy(n => n))) ||
                (_seventhRow.Skip(3).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_eighthRow.Skip(3).Take(3).OrderBy(n => n))) ||
                (_seventhRow.Skip(6).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_eighthRow.Skip(6).Take(3).OrderBy(n => n)))
                );

            _firstColumn.Add(_eighthRow[0]);
            _secondColumn.Add(_eighthRow[1]);
            _thirdColumn.Add(_eighthRow[2]);
            _fourthColumn.Add(_eighthRow[3]);
            _fifthColumn.Add(_eighthRow[4]);
            _sixthColumn.Add(_eighthRow[5]);
            _seventhColumn.Add(_eighthRow[6]);
            _eighthColumn.Add(_eighthRow[7]);
            _ninthColumn.Add(_eighthRow[8]);

            // Create the nineth row
            List<int> _ninthRow = new List<int>();

            foreach (int number in _rangeOfNineNumbers)
            {
                _ninthRow.Add(number);
            }

            do
            {
                Shuffle(_ninthRow);
            }
            while (
                (_firstColumn.Contains(_ninthRow[0])) ||
                (_secondColumn.Contains(_ninthRow[1])) ||
                (_thirdColumn.Contains(_ninthRow[2])) ||
                (_fourthColumn.Contains(_ninthRow[3])) ||
                (_fifthColumn.Contains(_ninthRow[4])) ||
                (_sixthColumn.Contains(_ninthRow[5])) ||
                (_seventhColumn.Contains(_ninthRow[6])) ||
                (_eighthColumn.Contains(_ninthRow[7])) ||
                (_ninthColumn.Contains(_ninthRow[8])) ||
                (_seventhRow.Take(3).OrderBy(n => n).ContainsAnySimilarElements(_ninthRow.Take(3).OrderBy(n => n))) ||
                (_eighthRow.Take(3).OrderBy(n => n).ContainsAnySimilarElements(_ninthRow.Take(3).OrderBy(n => n))) ||
                (_seventhRow.Skip(3).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_ninthRow.Skip(3).Take(3).OrderBy(n => n))) ||
                (_eighthRow.Skip(3).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_ninthRow.Skip(3).Take(3).OrderBy(n => n))) ||
                (_seventhRow.Skip(6).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_ninthRow.Skip(6).Take(3).OrderBy(n => n))) ||
                (_eighthRow.Skip(6).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_ninthRow.Skip(6).Take(3).OrderBy(n => n)))
                );

            _firstColumn.Add(_ninthRow[0]);
            _secondColumn.Add(_ninthRow[1]);
            _thirdColumn.Add(_ninthRow[2]);
            _fourthColumn.Add(_ninthRow[3]);
            _fifthColumn.Add(_ninthRow[4]);
            _sixthColumn.Add(_ninthRow[5]);
            _seventhColumn.Add(_ninthRow[6]);
            _eighthColumn.Add(_ninthRow[7]);
            _ninthColumn.Add(_ninthRow[8]);

            // Add the rows to result
            result.Add(_firstRow);
            result.Add(_secondRow);
            result.Add(_thirdRow);
            result.Add(_fourthRow);
            result.Add(_fifthRow);
            result.Add(_sixthRow);
            result.Add(_seventhRow);
            result.Add(_eighthRow);
            result.Add(_ninthRow);

            // Return the list of int lists
            return result;
        }
        #endregion

        #region Sudoku Methods

        // Initiate a static random number generator
        private static Random _random = new Random();

        // This method shuffles elements in a list
        private static void Shuffle<T>(List<T> list)
        {
            var _randomShuffle = _random;

            for (int i = list.Count; i > 1; i--)
            {
                // Pick a random element to swap
                int j = _randomShuffle.Next(1);
                // Swap
                T tmp = list[j];
                list[j] = list[i - 1];
                list[i - 1] = tmp;
            }
        }

        // Convert string arrays to strings
        static string ConvertStringArrayToString(string[] array)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in array)
            {
                sb.Append(s);
            }

            return sb.ToString();
        }

        // This method displays the splash screen
        private static void SplashScreenDisplayed()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("\n\n                             *       *  *       *");
            sb.Append("\n                             **     **   *     *");
            sb.Append("\n                             * *   * *    *   *");
            sb.Append("\n                             *  * *  *     * *");
            sb.Append("\n                             *   *   *      *");
            sb.Append("\n                             *       *      *");
            sb.Append("\n                             *       *      *");
            sb.Append("\n                             *       *      *\n\n");
            sb.Append("       *****     *        *  ******       ****     *   *  *        *");
            sb.Append("\n      *     *    *        *  *     *     *    *    *  *   *        *");
            sb.Append("\n     *           *        *  *      *   *      *   * *    *        *");
            sb.Append("\n      ****       *        *  *      *  *        *  **     *        *");
            sb.Append("\n          ****   *        *  *      *  *        *  **     *        *");
            sb.Append("\n             *    *      *   *      *   *      *   * *     *      *");
            sb.Append("\n      *     *      *    *    *     *     *    *    *  *     *    *");
            sb.Append("\n       *****        ****     ******       ****     *   *     ****\n\n");
            sb.Append("     ______________________________________________________________________");
            sb.Append("\n     __________________________________________________________________");
            sb.Append("\n     ______________________________________________________________");
            sb.Append("\n     __________________________________________________________\n\n");
            sb.Append("     By: Joseph King\n     Copyright 2013\n\n     Version 1.0\n\n");
            sb.Append("                          (Press Enter to Continue)");

            Console.Clear();
            Console.WriteLine(sb.ToString());
            Console.ReadLine();
            Console.Clear();


        }

        // This method builds the introduction and instruction screen
        private static void SudokuInstructionsDisplayed()
        {
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();

            sb1.Append("Welcome to My Sudoku!\n\nMy Sudoku is a logic based, combinatorial number placement puzzle.  The\n");
            sb1.Append("objective is to fill a 9×9 grid with digits so that each column, each row,\n");
            sb1.Append("and each of the nine 3×3 sub-grids that compose the grid contain all of the\ndigits from 1 to 9.\n\n");
            sb1.Append("This program uses a console interface.  The interface will look like this:\n\n   My Sudoku\n\n");
            sb1.Append("   1 2 3 4 5 6 7 8 9\n\n1  _ 5 9 _ 4 _ 6 _ _\n2  _ _ 7 _ 5 _ _ 9 2\n3  2 _ _ _ _ 7 5 _ _\n");
            sb1.Append("4  _ 9 _ 1 _ _ 8 _ 4\n5  5 _ _ _ 9 _ 2 _ 7\n6  _ 6 _ _ _ _ 1 _ 9\n7  3 _ _ 7 2 _ 4 8 _\n");
            sb1.Append("8  _ 2 8 _ _ 6 _ _ _\n9  6 _ 4 _ 1 _ _ 2 3\n\n");
            sb1.Append("Would like to\n 1) Enter a value\n 2) Delete a value\n 3) Reset the board\n 4) Check your answer\n 5) Exit the Game\n\n");
            sb1.Append("Action>\n\nAt this point you can enter 1 to enter a value.  You will be asked to enter\n");
            sb1.Append("the x and y coordinates and the value.  The value will then be displayed\non the board.\n\n");
            sb1.Append("If you enter 2 you will be asked to enter the x and y coordinate for the\nthe value you would like to delete.  The value will then be deleted.\n\n");
            sb1.Append("(Press Enter to Continue)");
            sb2.Append("         This is the X-Axis\nT\nh\ni\ns\n\nt\nh\ne\n\nY\n\nA\nx\ni\ns\n\n");
            sb2.Append("Action 3 removes all answers you have submitted and returns the board to its\n");
            sb2.Append("original state.\n\n");
            sb2.Append("Once you feel you have completed the puzzle you can enter 4 and the game will\n");
            sb2.Append("verify if your answer is correct.  If so you win, if not the game continues.\n\n");
            sb2.Append("At anytime you may enter 5 to cancel and exit the game.\n\nGood Luck!\n\n(Press Enter to Continue)");

            Console.Clear();
            Console.WriteLine(sb1.ToString());
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(sb2.ToString());
            Console.ReadLine();
            Console.Clear();
        }

        // The method builds and displays the game board
        private static void GameBoard(StringBuilder sb)
        {
            StringBuilder _displaySB = new StringBuilder();

            _displaySB.Append("   My Sudoku\n\n   1 2 3 4 5 6 7 8 9\n");
            _displaySB.Append("\n1  " + sb.ToString(0, 17));
            _displaySB.Append("\n2  " + sb.ToString(18, 17));
            _displaySB.Append("\n3  " + sb.ToString(36, 17));
            _displaySB.Append("\n4  " + sb.ToString(54, 17));
            _displaySB.Append("\n5  " + sb.ToString(72, 17));
            _displaySB.Append("\n6  " + sb.ToString(90, 17));
            _displaySB.Append("\n7  " + sb.ToString(108, 17));
            _displaySB.Append("\n8  " + sb.ToString(126, 17));
            _displaySB.Append("\n9  " + sb.ToString(144, 17) + "\n\n");
            _displaySB.Append("Would like to\n 1) Enter a value\n 2) Delete a value\n 3) Reset the board\n 4) Check your answer\n 5) Exit the Game\n\n");
            _displaySB.Append("Action> ");

            string _displayString = _displaySB.ToString();

            Console.Write(_displaySB);
        }

        // This method is displayed if the user enters an invalid action
        private static void InvalidAction()
        {
            Console.WriteLine("\nResponse must be 1, 2, 3, 4, 5.");
            Console.WriteLine("Please try again.\n\n(Press Enter to Continue)");
            Console.ReadLine();
            Console.Clear();
        }

        // This method is displayed if user enters an invalid x value
        private static void InvalidCoordinate()
        {
            Console.WriteLine("\nYour response must be an integer 1 through 9.");
            Console.WriteLine("Please try again.\n\n(Press Enter to Continue)");
            Console.ReadLine();
        }

        // This method is displayed if the user wins!
        private static void YouWin(StringBuilder sb)
        {
            StringBuilder _youWinSB = new StringBuilder();
            StringBuilder _finalSolutionSB = new StringBuilder();

            _youWinSB.Append("\n\n\n\t\t       *       *    *****     *        *\n");
            _youWinSB.Append("\t\t        *     *    *     *    *        *\n");
            _youWinSB.Append("\t\t         *   *    *       *   *        *\n");
            _youWinSB.Append("\t\t          * *    *         *  *        *\n");
            _youWinSB.Append("\t\t           *     *         *  *        *\n");
            _youWinSB.Append("\t\t           *      *       *    *      *\n");
            _youWinSB.Append("\t\t           *       *     *      *    *\n");
            _youWinSB.Append("\t\t           *        *****        ****\n\n");
            _youWinSB.Append("\t\t*           *  ***********  *      *  **  **  **\n");
            _youWinSB.Append("\t\t*           *       *       **     *  **  **  **\n");
            _youWinSB.Append("\t\t*           *       *       * *    *  **  **  **\n");
            _youWinSB.Append("\t\t*           *       *       *  *   *  **  **  **\n");
            _youWinSB.Append("\t\t*     *     *       *       *   *  *  **  **  **\n");
            _youWinSB.Append("\t\t *   * *   *        *       *    * *\n");
            _youWinSB.Append("\t\t  * *   * *         *       *     **  **  **  **\n");
            _youWinSB.Append("\t\t   *     *     ***********  *      *  **  **  **\n");

            _finalSolutionSB.Append("\t" + sb.ToString(0, 17));
            _finalSolutionSB.Append("\n\t" + sb.ToString(18, 17));
            _finalSolutionSB.Append("\n\t" + sb.ToString(36, 17));
            _finalSolutionSB.Append("\n\t" + sb.ToString(54, 17));
            _finalSolutionSB.Append("\n\t" + sb.ToString(72, 17));
            _finalSolutionSB.Append("\n\t" + sb.ToString(90, 17));
            _finalSolutionSB.Append("\n\t" + sb.ToString(108, 17));
            _finalSolutionSB.Append("\n\t" + sb.ToString(126, 17));
            _finalSolutionSB.Append("\n\t" + sb.ToString(144, 17) + "\n\n");

            string _youWinString = _youWinSB.ToString();

            for (int i = 0; i < 25; i++)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine(_youWinString);

                Thread.Sleep(100);

                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine(_youWinString);

                Thread.Sleep(100);

                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(_youWinString);

                Thread.Sleep(100);

                Console.Clear();

            }
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("Congragulations! You won!\n\nThe solution was:\n\n");
            Console.WriteLine(_finalSolutionSB);

            Console.WriteLine("(Press Enter to Exit)");
            Console.ReadLine();

            Console.Clear();

            Console.WriteLine("¡Adios amigo!");

            Thread.Sleep(1000);
        }
        #endregion
    }
}
