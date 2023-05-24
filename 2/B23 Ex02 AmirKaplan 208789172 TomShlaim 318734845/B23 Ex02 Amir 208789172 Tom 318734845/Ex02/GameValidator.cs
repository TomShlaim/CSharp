using System;
using System.Collections.Generic;

namespace Ex02
{
    internal class GameValidator
    {
        private const int k_MinBoardSize = 3;
        private const int k_MaxBoardSize = 9;
        private const int k_MinNumOfPlayers = 1;
        private const int k_MaxNumOfPlayers = 2;

        public static bool IsValidBoardSize(string i_CurrentUserInput)
        {
            bool isValidBoardSize = true;
            int boardSize;

            Program.ExitProgramIfRequested(i_CurrentUserInput);
            if (!int.TryParse(i_CurrentUserInput, out boardSize))
            {
                UI.DisplayInvalidBoardSizeMessage();
                isValidBoardSize = false;
            }
            else if (boardSize < k_MinBoardSize || boardSize > k_MaxBoardSize)
            {
                UI.DisplayInvalidBoardSizeMessage();
                isValidBoardSize = false;
            }

            return isValidBoardSize;
        }

        public static bool IsValidNumberOfPlayers(string i_CurrentUserInput)
        {
            bool isValidNumOfPlayers = true;
            int numOfPlayers;

            Program.ExitProgramIfRequested(i_CurrentUserInput);
            if (!int.TryParse(i_CurrentUserInput, out numOfPlayers))
            {
                UI.DisplayInvalidNumOfPlayersMessage();
                isValidNumOfPlayers = false;
            }
            else if (numOfPlayers < k_MinNumOfPlayers || numOfPlayers > k_MaxNumOfPlayers)
            {
                UI.DisplayInvalidNumOfPlayersMessage();
                isValidNumOfPlayers = false;
            }

            return isValidNumOfPlayers;
        }

        public static bool IsValidName(string i_CurrentUserInput)
        {
            bool isValidName = true;

            Program.ExitProgramIfRequested(i_CurrentUserInput);
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

        public static bool IsValidCell(string i_CurrentUserInput, Board i_Board) 
        {
           bool isValidCell = true;
           int rowIndex, columnIndex;

            Program.ExitProgramIfRequested(i_CurrentUserInput);
            if(i_CurrentUserInput.Length != 3)
            {
                UI.DisplayInvalidCellFormatMessage();
                isValidCell = false;
            }
            else if(i_CurrentUserInput[1] != ',' || !int.TryParse(i_CurrentUserInput[0].ToString(), out rowIndex)
                     || !int.TryParse(i_CurrentUserInput[2].ToString(), out columnIndex))
            {
                UI.DisplayInvalidCellFormatMessage();
                isValidCell = false;
            }
            else if(rowIndex > i_Board.BoardMatrix.GetLength(0) || rowIndex <= 0 || columnIndex > i_Board.BoardMatrix.GetLength(1)
                || columnIndex <= 0)
            {
                UI.DisplayInvalidCellIndexesMessage();
                isValidCell = false;
            }
            else if (i_Board.BoardMatrix[rowIndex - 1, columnIndex - 1] != eBoardSymbol.Blank)
            {
                UI.DisplayCellAlreadyChosenMessage();
                isValidCell = false;
            }

            return isValidCell;          
        }

        public static bool IsValidRematchInput(string i_CurrentUserInput)
        {
            bool isValidRematchInput = true;

            Program.ExitProgramIfRequested(i_CurrentUserInput);
            if (!i_CurrentUserInput.Equals("Y"))
            {
                UI.DisplayInvalidRematchInputMessage();
                isValidRematchInput = false;
            }

            return isValidRematchInput;
        }

        public static bool IsExitCommand(string i_UserInput) 
        {
            return i_UserInput.Equals("Q");
        }

    }
}





