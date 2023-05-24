using System;
using System.Collections.Generic;

namespace Ex02
{
    internal class GameValidator
    {
        private const int k_MinBoardSize = 3;
        private const int k_MaxBoardSize = 9;
        private const int k_MinNumOfPlayers = 1;
        //I think there shouldn't be max in our case, what do you think (this will require change iv validator)?
        private const int k_MaxNumOfPlayers = 2;

        public static bool isValidBoardSize(string i_CurrentUserInput)
        {
            bool isValidBoardSize = true;
            int boardSize;

            Program.exitProgramIfRequested(i_CurrentUserInput);
            if (!int.TryParse(i_CurrentUserInput, out boardSize))
            {
                UI.displayInvalidBoardSizeMessage();
                isValidBoardSize = false;
            }
            else if (boardSize < k_MinBoardSize || boardSize > k_MaxBoardSize)
            {
                UI.displayInvalidBoardSizeMessage();
                isValidBoardSize = false;
            }

            return isValidBoardSize;
        }
        public static bool isValidNumberOfPlayers(string i_CurrentUserInput)
        {
            bool isValidNumOfPlayers = true;
            int numOfPlayers;

            Program.exitProgramIfRequested(i_CurrentUserInput);
            if (!int.TryParse(i_CurrentUserInput, out numOfPlayers))
            {
                UI.displayInvalidNumOfPlayersMessage();
                isValidNumOfPlayers = false;
            }
            else if (numOfPlayers < k_MinNumOfPlayers || numOfPlayers > k_MaxNumOfPlayers)
            {
                UI.displayInvalidNumOfPlayersMessage();
                isValidNumOfPlayers = false;
            }

            return isValidNumOfPlayers;
        }

        public static bool isValidName(string i_CurrentUserInput)
        {
            bool isValidName = true;

            Program.exitProgramIfRequested(i_CurrentUserInput);
            if (i_CurrentUserInput.Length < 2)
            {
                isValidName = false;
            }
            else
            {
                foreach (char character in i_CurrentUserInput)
                {
                    if (!char.IsLetter(character))
                    {
                        isValidName = false;
                        break;
                    }
                }
            }

            return isValidName;
        }

        public static bool isValidCell(string i_CurrentUserInput, Board i_Board) 
        {
           bool isValidCell = true;
           int rowIndex, columnIndex;

            Program.exitProgramIfRequested(i_CurrentUserInput);
            if(i_CurrentUserInput.Length != 3)
            {
                UI.displayInvalidCellFormatMessage();
                isValidCell = false;
            }
            else if(i_CurrentUserInput[1] != ',' || !int.TryParse(i_CurrentUserInput[0].ToString(), out rowIndex)
                     || !int.TryParse(i_CurrentUserInput[2].ToString(), out columnIndex))
            {
                UI.displayInvalidCellFormatMessage();
                isValidCell = false;
            }
            else if(rowIndex > i_Board.BoardMatrix.GetLength(0) || rowIndex <= 0 || columnIndex > i_Board.BoardMatrix.GetLength(1)
                || columnIndex <= 0)
            {
                UI.displayInvalidCellIndexesMessage();
                isValidCell = false;
            }
            else if (i_Board.BoardMatrix[rowIndex - 1, columnIndex - 1] != eBoardSymbol.Blank)
            {
                UI.displayCellAlreadyChosenMessage();
                isValidCell = false;
            }

            return isValidCell;          
        }

        public static bool isValidRematchInput(string i_CurrentUserInput)
        {
            bool isValidRematchInput = true;

            Program.exitProgramIfRequested(i_CurrentUserInput);
            if (!i_CurrentUserInput.Equals("Y"))
            {
                UI.displayInvalidRematchInputMessage();
                isValidRematchInput = false;
            }

            return isValidRematchInput;
        }

        public static bool isExitCommand(string i_UserInput) 
        {
            return i_UserInput.Equals("Q");
        }

    }
}





