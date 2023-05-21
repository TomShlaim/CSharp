using System;
using System.Collections.Generic;

namespace Ex02
{
    internal class GameValidator
    {
        private const int k_MinBoardSize = 3;
        private const int k_MaxBoardSize = 9;
        private const int k_MinNumOfPlayers = 1;

        public static bool isValidBoardSize(string i_CurrentUserInput)
        {
            bool isValidBoardSize = true;
            int boardSize;

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

            if (!int.TryParse(i_CurrentUserInput, out numOfPlayers))
            {
                UI.displayInvalidNumOfPlayersMessage();
                isValidNumOfPlayers = false;
            }
            else if (numOfPlayers < k_MinNumOfPlayers)
            {
                UI.displayInvalidNumOfPlayersMessage();
                isValidNumOfPlayers = false;
            }

            return isValidNumOfPlayers;
        }
        public static bool isValidCell(string i_CurrentUserInput, Board i_Board) 
        {
           bool isValidCell = true;
           int rowIndex, columnIndex;

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
            else if(rowIndex > i_Board.BoardMatrix.GetLength(0) || rowIndex < 0 || columnIndex > i_Board.BoardMatrix.GetLength(1)
                || columnIndex < 0)
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

        public static bool isValidRematchInput(string i_RematchMessage)
        {
            bool isValidRematchInput = true;

            if(!i_RematchMessage.Equals("Y") && !i_RematchMessage.Equals("Q"))
            {
                UI.displayInvalidRematchInputMessage();
                isValidRematchInput = false;
            }

            return isValidRematchInput;
        }

    }
}





