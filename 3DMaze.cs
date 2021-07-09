﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KTANE_Solver
{
    class _3DMaze : Module
    {
        char[,] grid;
        public _3DMaze(Bomb bomb, StreamWriter logFileWriter) : base(bomb, logFileWriter)
        { 
            
        }

        /// <summary>
        /// Initializes the grid depending on the three letters found
        /// </summary>
        private void CreateGrid(List<char> characters)
        {
            if (characters.Contains('A') && characters.Contains('B') && characters.Contains('C'))
            {
                grid = new char[,]
                {
                    {'!', '!', '!', '!', '!', '.', '!', '.', '!', '.', '!', '!', '!', '!', '!', '.'},
                    {'!', '?', '.', '?', '!', '?', '.', '?', '!', '?', '.', 'A', '.', '?', '!', '?'},
                    {'!', '.', '!', '.', '!', '.', '!', '.', '!', '!', '!', '.', '!', '.', '!', '.'},
                    {'!', '?', '.', '*', '!', 'A', '.', '?', '.', '?', '!', '?', '.', '?', '.', 'B'},
                    {'!', '.', '!', '!', '!', '.', '!', '!', '!', '!', '!', '!', '!', '.', '!', '.'},
                    {'.', 'A', '.', '?', '.', '?', '!', 'B', '.', '?', '.', 'C', '.', '?', '!', '?'},
                    {'!', '.', '!', '.', '!', '!', '!', '.', '!', '.', '!', '.', '!', '!', '!', '!'},
                    {'.', '?', '!', 'C', '.', '?', '!', '?', '.', '*', '!', '?', '!', '?', '.', 'B'},
                    {'!', '!', '!', '.', '!', '.', '!', '!', '!', '!', '!', '.', '!', '.', '!', '!'},
                    {'.', '?', '!', '?', '.', '?', '!', '?', '.', 'A', '.', '?', '.', '?', '!', '?'},
                    {'!', '.', '!', '.', '!', '.',  '!', '.', '!', '.', '!', '!' ,'!', '.', '!','.'},
                    {'.', '?', '!', 'B', '!', '?', '.', 'C', '.', '?', '!', '?', '.', 'B', '.', '?'},
                    {'!', '.', '!', '.', '!', '!', '!', '!', '!', '.', '!', '.', '!', '!', '!', '.'},
                    {'.', '*', '!', '?', '.', 'C', '.', '?', '!', '?', '!', '?', '.', '?', '!', '?'},
                    {'!', '!', '!', '!', '!', '.', '!', '.', '!', '!', '!', '.', '!', '.', '!', '!'},
                    {'.', '?', '.', '?', '!', '?', '.', '?', '!', 'A', '!', '?', '.', 'C',  '.','?'}
                };
            }

            else if (characters.Contains('A') && characters.Contains('B') && characters.Contains('D'))
            {
                grid = new char[,]
                {
                    {'!','!','!','.','!','!','!','.','!','.','!','.','!','!','!','!'},
                    {'!','A','.','?','.','?','.','B','.','?','.','?','!','A','.','*'},
                    {'!','.','!','!','!','!','!','.','!','.','!','!','!','.','!','.'},
                    {'!','?','!','?','.','D','.','?','.','?','!','?','.','?','.','?'},
                    {'!','.','!','.','!','.','!','!','!','!','!','.','!','!','!','.'},
                    {'.','?','.','?','.','?','!','?','.','?','.','D','.','?','!','B'},
                    {'!','.','!','.','!','!','!','.','!','.','!','.','!','.','!','.'},
                    {'!','?','!','A','.','?','.','B','.','?','!','?','.','?','.','?'},
                    {'!','!','!','!','!','!','!','.','!','.','!','!','!','!','!','.'},
                    {'!','?','.','?','.','*','!','?','.','?','.','?','.','A','!','?'},
                    {'!','.','!','.','!','.','!','!','!','.','!','!','!','.','!','.'},
                    {'!','D','.','?','.','?','!','?','.','A','!','?','.','?','.','?'},
                    {'!','!','!','.','!','.','!','.','!','.','!','.','!','.','!','!'},
                    {'.','?','!','?','.','B','.','?','.','?','!','D','.','?','!','?'},
                    {'!','.','!','.','!','.','!','!','!','!','!','.','!','.','!','.'},
                    {'.','?','.','D','.','?','!','?','.','*','!','?','!','?','!','B'}
                };
            }

            else if (characters.Contains('A') && characters.Contains('B') && characters.Contains('H'))
            {
                grid = new char[,]
                {
                    {'!','!','!','!','!','!','!','.','!','!','!','.','!','!','!','!'},
                    {'!','B','.','?','.','?','!','?','.','?','.','A','.','?','.','H'},
                    {'!','.','!','!','!','!','!','!','!','!','!','.','!','.','!','.'},
                    {'.','*','!','?','.','H','.','?','.','?','.','?','.','?','!','?'},
                    {'!','!','!','.','!','.','!','.','!','!','!','!','!','.','!','!'},
                    {'.','B','.','?','!','?','!','?','.','B','.','?','!','?','!','?'},
                    {'!','.','!','!','!','.','!','!','!','.','!','.','!','.','!','.'},
                    {'!','?','!','?','.','?','!','?','.','*','!','?','.','H','!','A'},
                    {'!','.','!','.','!','.','!','.','!','!','!','.','!','.','!','.'},
                    {'!','?','!','A','.','?','!','H','.','?','.','?','!','?','.','?'},
                    {'!','.','!','.','!','!','!','!','!','.','!','!','!','.','!','.'},
                    {'!','?','!','?','!','?','.','?','.','A','.','?','.','B','.','?'},
                    {'!','.','!','.','!','!','!','.','!','!','!','.','!','!','!','.'},
                    {'.','?','.','B','.','?','!','?','.','?','!','*','.','?','!','?'},
                    {'.','?','.','B','.','?','!','?','.','?','!','*','.','?','!','?'},
                    {'!','.','!','!','!','!','!','.','!','.','!','.','!','.','!','.'},
                    {'.','A','.','?','.','?','.','H','.','?','.','?','.','?','!','?'}
                };
            }

            else if (characters.Contains('A') && characters.Contains('C') && characters.Contains('D'))
            {
                grid = new char[,]
                {
                    {'!',   '!',    '!',    '.',    '!',    '!',    '!',    '!',    '!',    '!',    '!',    '.',    '!',    '!',    '!',    '!' },
                    {'.',   '?',    '.',    '?',    '.',    '?',    '.',    '?',    '!',    '?',    '.',    '?',    '.',    '?',    '.',    '?' },
                    {'!',   '.',    '!',    '!',    '!',    '!',    '!',    '.',    '!',    '.',    '!',    '!',    '!',    '!',    '!',    '.' },
                    {'!',   '?',    '!',    '?',    '.',    'C',    '.',    '?',    '!',    'D',    '!',    '*',    '.',    '?',    '.',    'C' },
                    {'!',   '.',    '!',    '.',    '!',    '.',    '!',    '.',    '!',    '.',    '!',    '!',    '!',    '!',    '!',    '!' },
                    {'.',   '?',    '!',    '*',    '!',    '?',    '!',    '?',    '.',    '?',    '.',    'C',    '!',    '?',    '.',    '?' },
                    {'!',   '.',    '!',    '!',    '!',    '.',    '!',    '.',    '!',    '.',    '!',    '.',    '!',    '.',    '!',    '.' },
                    {'!',   '?',    '.',    'A',    '.',    '?',    '!',    '?',    '!',    '?',    '.',    '?',    '.',    '?',    '!',    '?' },
                    {'!',   '!',    '!',    '!',    '!',    '!',    '!',    '.',    '!',    '!',    '!',    '!',    '!',    '!',    '!',    '.' },
                    {'!',   'D',    '.',    '?',    '.',    '?',    '.',    'C',    '!',    '?',    '.',    'D',    '.',    '?',    '!',    '?' },
                    {'!',   '.',    '!',    '!',    '!',    '!',    '!',    '.',    '!',    '.',    '!',    '!',    '!',    '.',    '!',    '.' },
                    {'.',   '?',    '!',    '?',    '!',    'A',    '.',    '?',    '.',    '?',    '!',    '*',    '.',    '?',    '!',    '?' },
                    {'!',   '.',    '!',    '.',    '!',    '.',    '!',    '!',    '!',    '.',    '!',    '!',    '!',    '!',    '!',    '.' },
                    {'.',   '?',    '!',    '?',    '.',    '?',    '!',    'A',    '.',    '?',    '.',    '?',    '.',    'D',    '.',    '?' },
                    {'!',   '.',    '!',    '!',    '!',    '!',    '!',    '.',    '!',    '.',    '!',    '!',    '!',    '.',    '!',    '.' },
                    {'!',   'A',    '.',    '?',    '.',    '?',    '.',    '?',    '.',    '?',    '.',    'C',    '!',    '?',    '.',    '?' }

                };
            }

            else if (characters.Contains('A') && characters.Contains('C') && characters.Contains('H'))
            {
                grid = new char[,]
                {
                    {'!','.','!','.','!','!','!','!','!','!','!','!','!','.','!','.'},
                    {'!','H','.','?','.','C','.','?','.','?','!','?','!','A','.','?' },
                    {'!','!','!','!','!','.','!','!','!','.','!','.','!','.','!','.' },
                    {'!','*','.','?','.','?','!','?','.','H','.','?','.','?','!','?' },
                    {'!','.','!','!','!','!','!','.','!','.','!','!','!','!','!','.' },
                    {'.','?','!','?','.','?','!','?','.','?','!','?','.','*','!','C' },
                    {'!','.','!','.','!','.','!','.','!','.','!','.','!','.','!','.' },
                    {'!','?','.','A','.','?','.','?','.','?','.','H','.','?','!','?' },
                    {'!','.','!','!','!','.','!','.','!','.','!','!','!','.','!','.' },
                    {'!','C','!','?','.','H','.','?','.','C','.','?','.','A','.','?' },
                    {'!','.','!','.','!','.','!','.','!','.','!','.','!','.','!','!' },
                    {'.','?','!','*','.','?','!','?','.','?','!','?','.','?','!','A' },
                    {'!','!','!','!','!','!','!','.','!','.','!','.','!','!','!','.' },
                    {'!','?','.','?','.','?','!','C','.','?','!','H','.','?','.','?' },
                    {'!','.','!','!','!','.','!','!','!','!','!','.','!','!','!','!' },
                    {'.','?','!','?','.','A','.','?','.','?','.','?','!','?','.','?' }

                };
            }

            else if (characters.Contains('A') && characters.Contains('D') && characters.Contains('H'))
            {
                grid = new char[,]
                {
                    {'!','.','!','!','!','!','!','!','!','.','!','!','!','.','!','!' },
                    {'!','D','.','?','!','D','.','?','.','?','!','*','.','?','.','?' },
                    {'!','.','!','.','!','.','!','.','!','!','!','!','!','!','!','.' },
                    {'!','?','!','?','!','?','!','?','.','H','.','?','.','?','.','A' },
                    {'!','.','!','.','!','.','!','.','!','.','!','!','!','!','!','!' },
                    {'!','?','!','*','.','H','!','?','!','?','.','?','.','A','.','?' },
                    {'!','.','!','!','!','.','!','.','!','!','!','!','!','.','!','.' },
                    {'!','A','!','?','!','?','!','D','.','?','.','?','.','?','.','?' },
                    {'!','.','!','.','!','!','!','!','!','.','!','!','!','.','!','!' },
                    {'.','?','.','?','.','?','.','?','.','H','!','D','.','?','!','?' },
                    {'!','!','!','!','!','!','!','.','!','.','!','.','!','.','!','.' },
                    {'!','*','.','?','.','H','.','?','!','?','!','?','!','?','.','A' },
                    {'!','.','!','!','!','!','!','.','!','.','!','.','!','.','!','.' },
                    {'.','D','.','?','.','?','!','?','!','?','!','?','!','?','!','?' },
                    {'!','!','!','!','!','.','!','.','!','!','!','.','!','.','!','.' },
                    {'!','?','.','?','.','?','.','A','.','?','!','H','.','?','!','?' }

                };
            }

            else if (characters.Contains('B') && characters.Contains('C') && characters.Contains('D'))
            {
                grid = new char[,]
                {
                    {'!','.','!','!','!','.','!','!','!','!','!','!','!','!','!','.'},
                    {'!','?','.','?','!','?','!','?','.','?','.','B','.','?','.','?'},
                    {'!','.','!','!','!','!','!','.','!','!','!','.','!','!','!','!'},
                    {'.','C','.','?','.','D','.','?','!','?','.','?','!','*','.','?'},
                    {'!','.','!','!','!','!','!','.','!','.','!','!','!','.','!','.'},
                    {'!','?','!','*','!','?','.','B','!','?','.','?','.','C','.','?'},
                    {'!','!','!','.','!','.','!','.','!','.','!','!','!','!','!','!'},
                    {'.','?','.','C','.','?','.','?','!','?','.','?','.','B','.','?'},
                    {'!','!','!','.','!','!','!','!','!','.','!','.','!','!','!','!'},
                    {'.','?','.','?','!','?','.','?','.','C','.','?','!','?','.','D'},
                    {'!','!','!','.','!','.','!','!','!','!','!','.','!','.','!','!'},
                    {'.','B','.','?','.','?','!','?','.','?','.','D','.','?','!','.'},
                    {'!','.','!','!','!','!','!','.','!','.','!','.','!','!','!','.'},
                    {'.','?','.','C','.','?','.','?','.','*','!','?','!','D','.','?'},
                    {'!','!','!','.','!','!','!','!','!','!','!','.','!','.','!','!'},
                    {'.','D','.','?','!','?','.','B','.','?','.','?','.','?','!','?'}

                };
            }

            else if (characters.Contains('B') && characters.Contains('C') && characters.Contains('D'))
            {
                grid = new char[,]
                {
                    {'!','!','!','.','!','!','!','!','!','.','!','.','!','!','!','!' },
                    {'!','C','.','?','.','?','.','?','.','H','!','?','.','?','.','?' },
                    {'!','.','!','!','!','.','!','!','!','.','!','!','!','.','!','!' },
                    {'.','?','!','?','.','C','.','?','!','?','.','?','.','?','.','H' },
                    {'!','!','!','.','!','!','!','.','!','!','!','!','!','.','!','.' },
                    {'.','?','!','?','!','*','!','?','!','B','.','?','.','?','!','?' },
                    {'!','.','!','.','!','.','!','.','!','.','!','!','!','!','!','.' },
                    {'!','B','.','?','.','?','.','H','!','*','.','?','.','?','.','?' },
                    {'!','.','!','!','!','!','!','!','!','!','!','!','!','!','!','.' },
                    {'!','?','.','H','.','?','.','?','!','?','.','B','.','?','.','C' },
                    {'!','.','!','.','!','!','!','.','!','.','!','.','!','!','!','.' },
                    {'.','?','!','?','!','?','.','*','!','?','!','?','.','?','!','?' },
                    {'!','!','!','.','!','.','!','!','!','.','!','!','!','.','!','.' },
                    {'.','?','!','?','!','B','.','?','!','C','.','?','.','?','!','?' },
                    {'!','.','!','.','!','.','!','.','!','.','!','!','!','!','!','.' },
                    {'.','?','.','C','.','?','!','?','.','?','.','H','!','?','.','B' }
                };
            }

            else if (characters.Contains('B') && characters.Contains('D') && characters.Contains('H'))
            {
                grid = new char[,]
                {
                    {'!','.','!','!','!','!','!','.','!','.','!','.','!','.','!','!'},
                    {'.','?','!','?','!','D','.','?','!','B','.','?','.','?','.','H'},
                    {'!','.','!','.','!','.','!','!','!','.','!','.','!','.','!','!'},
                    {'!','?','!','?','.','?','!','*','.','?','!','?','!','D','!','?'},
                    {'!','!','!','!','!','.','!','!','!','!','!','.','!','.','!','.'},
                    {'.','?','.','?','.','H','.','?','.','*','!','?','!','?','.','B'},
                    {'!','!','!','!','!','.','!','!','!','!','!','.','!','!','!','!'},
                    {'.','D','.','?','!','?','.','?','.','?','.','B','.','?','.','?'},
                    {'!','.','!','.','!','.','!','!','!','.','!','.','!','!','!','!'},
                    {'.','?','.','?','!','?','!','?','.','D','!','?','.','?','.','H'},
                    {'!','!','!','.','!','.','!','.','!','.','!','.','!','.','!','.'},
                    {'!','?','.','?','.','B','.','?','!','?','!','?','!','?','.','?'},
                    {'!','.','!','!','!','!','!','.','!','!','!','!','!','.','!','.'},
                    {'!','?','!','?','.','?','.','H','.','?','.','?','.','H','.','*'},
                    {'!','.','!','!','!','.','!','.','!','!','!','!','!','!','!','!'},
                    {'.','D','.','?','.','?','!','?','!','?','.','B','!','?','.','?'}
                };
            }

            else
            {
                grid = new char[,]
                {
                    {'!','.','!','!','!','.','!','!','!','!','!','.','!','!','!','.'},
                    {'!','?','!','?','.','H','.','?','!','?','.','D','.','?','!','?'},
                    {'!','.','!','.','!','!','!','.','!','.','!','!','!','.','!','.'},
                    {'!','?','!','?','!','?','!','?','.','C',' ','*','!','?','!','?'},
                    {'!','.','!','.','!','.','!','.','!','.','!','.','!','.','!','.'},
                    {'.','?','.','?','!','?','.','H','.','?','.','?','!','?','.','D'},
                    {'!','.','!','.','!','.','!','.','!','.','!','.','!','!','!','.'},
                    {'.','H','.','?','!','?','!','?','!','?',' ','D','.','?','.','?'},
                    {'!','.','!','!','!','.','!','.','!','.','!','.','!','!','!','.'},
                    {'!','?','.','?','.','C','!','?','!','?',' ','?','.','?','.','?'},
                    {'!','.','!','!','!','!','!','.','!','.','!','!','!','!','!','.'},
                    {'!','C','.','?','.','?','.','D','!','?','.','C','.','?','.','H'},
                    {'!','.','!','!','!','.','!','!','!','!','!','.','!','!','!','.'},
                    {'!','*','!','D','.','?','.','?','.','H','.','?','.','*','!','?'},
                    {'!','!','!','.','!','!','!','.','!','.','!','!','!','.','!','!'},
                    {'.','?','.','?','!','?','.','?','!','?',' ','?','.','?','.','C'}
                };
            }

        }

        /// <summary>
        /// Finds the user location given at least two letter spots with ? meaning blank
        ///
        /// </summary>
        /// <param name="spots">where the user has gone</param>
        /// <returns>the coordinates of where the user currently is.
        ///          Last data is the direction the user is facing
        ///          0 is north
        ///          1 is east
        ///          2 is south
        ///          3 is west.
        ///If there happens to be a -1, then the spots were invalid</returns>
        private int[] FindLocation(List<char> spots)
        {
            //If any of the spots contain N,E,S, or W convert them to *
            for (int i = 0; i < spots.Count; i++)
            {
                if (spots[i] == 'N' || spots[i] == 'E' || spots[i] == 'S' || spots[i] == 'W')
                {
                    spots[i] = '*';
                }
            }

            //find a location that starts with the first spot

            //if the spot can't be found, return -1
            for (int row = 0; row < 16; row++)
            {
                for (int column = 0; column < 16; column++)
                {
                    if (grid[row, column] == spots[0])
                    {
                        //if the spot can be found, then find the 
                        //last spot of the spots [length - 1] * 2 spaces away

                        //tells if the path is wrong
                        bool invalidPath = false;

                        //start north
                        {
                            //if row becomes negative, add 16 til postive

                            int tempRow = row - ((spots.Count - 1) * 2);

                            if (tempRow < 0)
                            {
                                tempRow += 16;
                            }

                            if (grid[tempRow, column] == spots[spots.Count - 1])
                            {
                                //if the end is correct, the make sure there are no
                                //walls in between the start and end

                                tempRow = row - 1;

                                if (tempRow < 0)
                                {
                                    tempRow += 16;
                                }

                                int endRow = row - ((spots.Count - 1) * 2);

                                if (endRow < 0)
                                {
                                    endRow += 16;
                                }

                                bool noWalls = true;

                                do
                                {
                                    if (grid[tempRow, column] == '!')
                                    {
                                        noWalls = false;
                                        invalidPath = true;
                                        break;
                                    }

                                    tempRow--;

                                    if (tempRow < 0)
                                    {
                                        tempRow += 16;
                                    }
                                }
                                while (tempRow != endRow);

                                if (noWalls)
                                {
                                    //if no walls have been found, then make sure each spot is correct

                                    while (tempRow != endRow && !invalidPath)
                                    {
                                        for (int i = 0; i < spots.Count; i++)
                                        {
                                            tempRow = row - (2 * i);

                                            if (tempRow < 0)
                                            {
                                                tempRow += 16;
                                            }

                                            if (grid[tempRow, column] != spots[i])
                                            {
                                                invalidPath = true;
                                                break;
                                            }
                                        }
                                    }

                                    //reaching this point means the user's location has been found and is point north
                                    if (!invalidPath)
                                    {
                                        return new int[] { endRow, column, 0 };
                                    }
                                }
                            }
                        }

                        //if this point is reached, that means north wasn't the correct way, try going east
                        {
                            invalidPath = false;

                            
                            //if row becomes negative, add 16 til postive

                            int tempColumn = column - ((spots.Count - 1) * 2);

                            if (tempColumn < 0)
                            {
                                tempColumn += 16;
                            }

                            if (grid[row, tempColumn] == spots[spots.Count - 1])
                            {
                                //if the end is correct, then make sure there are no
                                //walls in between the start and end

                                tempColumn = column - 1;

                                if (tempColumn < 0)
                                {
                                    tempColumn += 16;
                                }

                                int endColumn = column - ((spots.Count - 1) * 2);

                                if (endColumn < 0)
                                {
                                    endColumn += 16;
                                }

                                bool noWalls = true;

                                do
                                {
                                    if (grid[row, tempColumn] == '!')
                                    {
                                        noWalls = false;
                                        invalidPath = true;
                                        break;
                                    }

                                    tempColumn--;

                                    if (tempColumn < 0)
                                    {
                                        tempColumn += 16;
                                    }
                                }
                                while (tempColumn != endColumn);

                                if (noWalls)
                                {
                                    //if no walls have been found, then make sure each spot is correct

                                    while (tempColumn != endColumn && !invalidPath)
                                    {
                                        for (int i = 0; i < spots.Count; i++)
                                        {
                                            tempColumn = column - (2 * i);

                                            if (tempColumn < 0)
                                            {
                                                tempColumn += 16;
                                            }

                                            if (grid[row, tempColumn] != spots[i])
                                            {
                                                invalidPath = true;
                                                break;
                                            }
                                        }
                                    }

                                    //reaching this point means the user's location has been found and is point west
                                    if (!invalidPath)
                                    {
                                        return new int[] { row, endColumn, 1 };
                                    }
                                }
                            }
                            
                        }

                        //if this point is reached, that means west wasn't the correct way, try going south
                        {
                            //if row too high, subract 16 til between 0-15

                            int tempRow = row + ((spots.Count - 1) * 2);

                            if (tempRow > 15)
                            {
                                tempRow -= 16;
                            }

                            if (grid[tempRow, column] == spots[spots.Count - 1])
                            {
                                //if the end is correct, the make sure there are no
                                //walls in between the start and end

                                tempRow = row + 1;

                                if (tempRow > 15)
                                {
                                    tempRow -= 16;
                                }

                                int endRow = row + ((spots.Count - 1) * 2);

                                if (endRow > 15)
                                {
                                    endRow -= 16;
                                }

                                bool noWalls = true;

                                do
                                {
                                    if (grid[tempRow, column] == '!')
                                    {
                                        noWalls = false;
                                        invalidPath = true;
                                        break;
                                    }

                                    tempRow++;

                                    if (tempRow > 15)
                                    {
                                        tempRow -= 16;
                                    }
                                }
                                while (tempRow != endRow);

                                if (noWalls)
                                {
                                    //if no walls have been found, then make sure each spot is correct

                                    while (tempRow != endRow && !invalidPath)
                                    {
                                        for (int i = 0; i < spots.Count; i++)
                                        {
                                            tempRow = row + (2 * i);

                                            if (tempRow > 15)
                                            {
                                                tempRow -= 16;
                                            }

                                            if (grid[tempRow, column] != spots[i])
                                            {
                                                invalidPath = true;
                                                break;
                                            }
                                        }
                                    }

                                    //reaching this point means the user's location has been found and is point south
                                    if (!invalidPath)
                                    {
                                        return new int[] { endRow, column, 2 };
                                    }
                                }
                            }
                        }

                        //if this point is reached, that means north wasn't the correct way, try going west
                        {
                            invalidPath = false;


                            //if row becomes negative, add 16 til postive

                            int tempColumn = column + ((spots.Count - 1) * 2);

                            if (tempColumn > 15)
                            {
                                tempColumn -= 16;
                            }

                            if (grid[row, tempColumn] == spots[spots.Count - 1])
                            {
                                //if the end is correct, then make sure there are no
                                //walls in between the start and end

                                tempColumn = column + 1;

                                if (tempColumn > 15)
                                {
                                    tempColumn -= 16;
                                }

                                int endColumn = column + ((spots.Count - 1) * 2);

                                if (endColumn > 15)
                                {
                                    endColumn -= 16;
                                }

                                bool noWalls = true;

                                do
                                {
                                    if (grid[row, tempColumn] == '!')
                                    {
                                        noWalls = false;
                                        invalidPath = true;
                                        break;
                                    }

                                    tempColumn--;

                                    if (tempColumn > 15)
                                    {
                                        tempColumn -= 16;
                                    }
                                }
                                while (tempColumn != endColumn);

                                if (noWalls)
                                {
                                    //if no walls have been found, then make sure each spot is correct

                                    while (tempColumn != endColumn && !invalidPath)
                                    {
                                        for (int i = 0; i < spots.Count; i++)
                                        {
                                            tempColumn = column + (2 * i);

                                            if (tempColumn > 15)
                                            {
                                                tempColumn -= 16;
                                            }

                                            if (grid[row, tempColumn] != spots[i])
                                            {
                                                invalidPath = true;
                                                break;
                                            }
                                        }
                                    }

                                    //reaching this point means the user's location has been found and is point west
                                    if (!invalidPath)
                                    {
                                        return new int[] { row, endColumn, 3 };
                                    }
                                }
                            }

                        }

                        //if this point is reached, then this is not the correct starting spot, moving on to the next one
                    }

                    else
                    {
                        continue;
                    }

                }
            }

            //if this point is reached that means the user's spots were invalid
            return new int[] { -1 };
        }
    }
}
