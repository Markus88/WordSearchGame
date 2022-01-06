namespace WordSearchGame.Logic
{
    public class GameEngine
    {
        /// <summary>
        /// Denne fil er en modificeret version af filen fra: https://github.com/neetfreek/word-search-generator/blob/master/WordSearch/WordSearch.cs
        /// Vil have skrevet det selv, da det egentlig er den sjove del, men vil prøve at holde mig inde for de 3 timer.
        /// </summary>

        /*==============================================================================*
         *  1. Fields for setting and properties for safe access of word array and grid  *
         *   a. Fields set in HandleSetupWords(), HandleSetupGrid()                      *
         *   b. Properties used by this and other classes                                *
         *===============================================================================*/
        public string[] Words { get; private set; }
        public char[,] Grid { get; private set; }
        public char[,] WinningGrid  { get; private set; }
        private Settings _settings;

        public GameEngine()
        {
            _settings = new Settings();
        }

        /*==================================*
        *  2. Handle setup words to find    *
        *===================================*/
        public void HandleSetupWords(string words, int listSize)
        {
            Words = DataHandler.HandleListLoad(words, listSize);
        }

        /*======================================*
        *  3. Handle setup grid size, populate  *
        *=======================================*/
        public void HandleSetupGrid(int gridSize)
        {
            HandleSetupEmptyGrid(gridSize);
            PopulateGridWords(Words, Grid);

            WinningGrid = ShallowCopy(Grid);
            PopulateEmptyElements(Grid);
        }

        private char[,] ShallowCopy(char[,] toCopy)
        {
            var tempValue = new char[Words.Length, Words.Length];
            Array.Copy(toCopy, 0, tempValue, 0, toCopy.Length);
            return tempValue;
        }

        /*==============================*
        *  3.a. Handle setup empty grid *
        *===============================*/
        private void HandleSetupEmptyGrid(int gridSize)
        {
            // Declare, initialise with null () values, grids
            //int numCharsInWords = Helper.CountWordsCharactersAll(Words);
            //int lengthLongestWord = Helper.LongestWord(Words).Length;
            SetupEmptyGrid(gridSize);
        }

        private void SetupEmptyGrid(int numGridElements)
        {
            Grid = new char[numGridElements, numGridElements];
        }
        /*======================================*
        *  3.b. Handle populate grid with words *
        *=======================================*/
        private void PopulateGridWords(string[] words, char[,] grid)
        {
            var numberWordsToPlace = Helper.CountElements(words);

            // iterate Words to place
            for (var wordCurrent = 0; wordCurrent < numberWordsToPlace; wordCurrent++)
            {
                var wordPlaced = false;
                while (!wordPlaced)
                {
                    // Get random starting point for word
                    _settings.SetGridSize(Helper.Random(0, grid.GetLength(0) - 1), Helper.Random(0, grid.GetLength(1) - 1));
                    if (PlaceWordInGrid(_settings, words[wordCurrent], grid))
                    {
                        wordPlaced = true;
                    }
                }
            }
        }
        private bool PlaceWordInGrid(Settings pos, string word, char[,] grid)
        {
            var x = pos.GridRows;
            var y = pos.GridColumns;

            // elements represent placements options, 0 == left->right, 1 = right->left, etc. (in order presented below)
            var placementOptions = new int[8] { 9, 9, 9, 9, 9, 9, 9, 9 };
            var placementOption = 9;
            var haveOptions = false;

            for (var counter = 0; counter < word.Length; counter++)
            {
                // If point empty or point contains same letter word's current character
                if (grid[x, y] == '\0' | grid[x, y] == word[0])
                {
                    if (SpaceRight(word, pos, grid))
                    {
                        placementOptions[0] = 1;
                        haveOptions = true;
                    }
                    if (SpaceLeft(word, pos, grid))
                    {
                        placementOptions[1] = 2;
                        haveOptions = true;
                    }
                    if (SpaceDown(word, pos, grid))
                    {
                        placementOptions[2] = 3;
                        haveOptions = true;
                    }
                    if (SpaceUp(word, pos, grid))
                    {
                        placementOptions[3] = 4;
                        haveOptions = true;
                    }
                    if (SpaceUpRight(word, pos, grid))
                    {
                        placementOptions[4] = 5;
                        haveOptions = true;
                    }
                    if (SpaceDownRight(word, pos, grid))
                    {
                        placementOptions[5] = 6;
                        haveOptions = true;
                    }
                    if (SpaceUpLeft(word, pos, grid))
                    {
                        placementOptions[6] = 7;
                        haveOptions = true;
                    }
                    if (SpaceDownLeft(word, pos, grid))
                    {
                        placementOptions[7] = 8;
                        haveOptions = true;
                    }

                    if (haveOptions)
                    {
                        while (placementOption == 9)
                        {
                            placementOption = placementOptions[Helper.Random(0, placementOptions.Length - 1)];
                        }

                        switch (placementOption)
                        {
                            case 1:
                                PlaceWordRight(word, pos, grid);
                                break;
                            case 2:
                                PlaceWordLeft(word, pos, grid);
                                break;
                            case 3:
                                PlaceWordDown(word, pos, grid);
                                break;
                            case 4:
                                PlaceWordUp(word, pos, grid);
                                break;
                            case 5:
                                PlaceWordUpRight(word, pos, grid);
                                break;
                            case 6:
                                PlaceWordDownRight(word, pos, grid);
                                break;
                            case 7:
                                PlaceWordUpLeft(word, pos, grid);
                                break;
                            case 8:
                                PlaceWordDownLeft(word, pos, grid);
                                break;
                        }
                        return true;
                    }
                }
            }
            return false;
        }
        /*======================================*
        *  3.c. Populate empty grid elements    *
        *=======================================*/
        private void PopulateEmptyElements(char[,] grid)
        {
            for (var counterRow = 0; counterRow < grid.GetLength(0); counterRow++)
            {
                for (var counterCol = 0; counterCol < grid.GetLength(1); counterCol++)
                {
                    if (grid[counterRow, counterCol] == '\0')
                    {
                        grid[counterRow, counterCol] = Helper.Random('a', 'z');
                    }
                }
            }
        }

        /*==============================*
        *  4. Check words fit in grid   *
        *===============================*/
        private bool SpaceRight(string word, Settings pos, char[,] grid)
        {
            if ((grid.GetLength(0)) - pos.GridColumns >= word.Length)
            {
                // iterate right in row, checking each successive element empty or same as current char
                for (var counter = 0; counter < word.Length; counter++)
                {
                    if (grid[pos.GridRows, pos.GridColumns + counter] != '\0' && grid[pos.GridRows, pos.GridColumns + counter] != word[counter])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        } // check space left -> right
        private bool SpaceLeft(string word, Settings pos, char[,] grid)
        {
            if (pos.GridColumns >= word.Length - 1)
            {
                // iterate left in row, checking each successive element empty or same as current char
                for (var counter = 0; counter < word.Length; counter++)
                {
                    if (grid[pos.GridRows, pos.GridColumns - counter] != '\0' && grid[pos.GridRows, pos.GridColumns - counter] != word[counter])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        } // check space right -> left
        private bool SpaceDown(string word, Settings pos, char[,] grid)
        {
            if ((grid.GetLength(0)) - pos.GridRows >= word.Length)
            {
                // iterate right in row, checking each successive element empty or same as current char
                for (var counter = 0; counter < word.Length; counter++)
                {
                    if (grid[pos.GridRows + counter, pos.GridColumns] != '\0' && grid[pos.GridRows + counter, pos.GridColumns] != word[counter])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        } // check space up -> down
        private bool SpaceUp(string word, Settings pos, char[,] grid)
        {
            if (pos.GridRows >= word.Length - 1)
            {
                // iterate left in row, checking each successive element empty or same as current char
                for (var counter = 0; counter < word.Length; counter++)
                {
                    if (grid[pos.GridRows - counter, pos.GridColumns] != '\0' && grid[pos.GridRows - counter, pos.GridColumns] != word[counter])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        } // check space down -> up
        private bool SpaceUpRight(string word, Settings pos, char[,] grid)
        {
            if ((grid.GetLength(0)) - pos.GridColumns >= word.Length && // if space right
                (pos.GridRows >= word.Length - 1)) // if space up
            {
                // iterate right in row, checking each successive element empty or same as current char
                for (var counter = 0; counter < word.Length; counter++)
                {
                    if (grid[pos.GridRows - counter, pos.GridColumns + counter] != '\0' && grid[pos.GridRows - counter, pos.GridColumns + counter] != word[counter])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        } // check space diagonal left -> up right
        private bool SpaceDownRight(string word, Settings pos, char[,] grid)
        {
            if ((grid.GetLength(0)) - pos.GridColumns >= word.Length && // if space right
                (grid.GetLength(1)) - pos.GridRows >= word.Length) // if space down
            {
                // iterate right in row, checking each successive element empty or same as current char
                for (var counter = 0; counter < word.Length; counter++)
                {
                    if (grid[pos.GridRows + counter, pos.GridColumns + counter] != '\0' && grid[pos.GridRows + counter, pos.GridColumns + counter] != word[counter])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        } // check space diagonal left -> down right
        private bool SpaceUpLeft(string word, Settings pos, char[,] grid)
        {
            if (pos.GridRows >= word.Length - 1 && // if space up
                pos.GridColumns >= word.Length - 1) // if space left
            {
                // iterate right in row, checking each successive element empty or same as current char
                for (var counter = 0; counter < word.Length; counter++)
                {
                    if (grid[pos.GridRows - counter, pos.GridColumns - counter] != '\0' && grid[pos.GridRows - counter, pos.GridColumns - counter] != word[counter])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        } // check space diagonal left -> up right
        private bool SpaceDownLeft(string word, Settings pos, char[,] grid)
        {
            if ((grid.GetLength(0)) - pos.GridRows >= word.Length && // if space down
                pos.GridColumns >= word.Length - 1) // if space left
            {
                // iterate right in row, checking each successive element empty or same as current char
                for (var counter = 0; counter < word.Length; counter++)
                {
                    if (grid[pos.GridRows + counter, pos.GridColumns - counter] != '\0' && grid[pos.GridRows + counter, pos.GridColumns - counter] != word[counter])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        } // check space diagonal left -> up right

        /*==============================*
        *  5. Word placement in grid    *
        *===============================*/
        private void PlaceWordRight(string word, Settings pos, char[,] grid)
        {
            for (var counter = 0; counter < word.Length; counter++)
            {
                grid[pos.GridRows, pos.GridColumns + counter] = word[counter];
            }
        } // place word left -> right
        private void PlaceWordLeft(string word, Settings pos, char[,] grid)
        {
            for (var counter = 0; counter < word.Length; counter++)
            {
                grid[pos.GridRows, pos.GridColumns - counter] = word[counter];
            }
        } // place word right -> left
        private void PlaceWordDown(string word, Settings pos, char[,] grid)
        {
            for (var counter = 0; counter < word.Length; counter++)
            {
                grid[pos.GridRows + counter, pos.GridColumns] = word[counter];
            }
        } // place word up -> down
        private void PlaceWordUp(string word, Settings pos, char[,] grid)
        {
            for (var counter = 0; counter < word.Length; counter++)
            {
                grid[pos.GridRows - counter, pos.GridColumns] = word[counter];
            }
        } // place word down -> up
        private void PlaceWordUpRight(string word, Settings pos, char[,] grid)
        {
            for (var counter = 0; counter < word.Length; counter++)
            {
                grid[pos.GridRows - counter, pos.GridColumns + counter] = word[counter];
            }
        } // place word diagonal left -> up right
        private void PlaceWordDownRight(string word, Settings pos, char[,] grid)
        {
            for (var counter = 0; counter < word.Length; counter++)
            {
                grid[pos.GridRows + counter, pos.GridColumns + counter] = word[counter];
            }
        } // place word diagonal left -> down right
        private void PlaceWordUpLeft(string word, Settings pos, char[,] grid)
        {
            for (var counter = 0; counter < word.Length; counter++)
            {
                grid[pos.GridRows - counter, pos.GridColumns - counter] = word[counter];
            }
        } // place word diagonal left -> up left
        private void PlaceWordDownLeft(string word, Settings pos, char[,] grid)
        {
            for (var counter = 0; counter < word.Length; counter++)
            {
                grid[pos.GridRows + counter, pos.GridColumns - counter] = word[counter];
            }
        } // place word diagonal left -> down left
    }
}
