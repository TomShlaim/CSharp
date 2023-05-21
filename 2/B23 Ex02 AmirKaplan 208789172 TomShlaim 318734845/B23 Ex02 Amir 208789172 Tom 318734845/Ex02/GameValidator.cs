using System;
using System.Collections.Generic;

namespace Ex02
{
    internal class GameValidator
    {
        private const int minBoardSize = 3;
        private const int maxBoardSize = 9;
        private const int minNumOfPlayers = 1;
        private const int maxNumOfPlayers = 2;

        private static void setValidBoardSize(out int o_BoardSize)
        {
            string currentUserInput = Console.ReadLine();

            while (!isValidBoardSize(currentUserInput))
            {
                currentUserInput = Console.ReadLine();
            }

            o_BoardSize = int.Parse(currentUserInput);
        }

        public static bool isValidBoardSize(string i_CurrentUserInput)
        {
            bool isValidBoardSize = true;
            int boardSize;

            if (!int.TryParse(i_CurrentUserInput, out boardSize))
            {
                UI.displayInvalidBoardSizeMessage();
                isValidBoardSize = false;
            }
            else if (boardSize < minBoardSize || boardSize > maxBoardSize)
            {
                UI.displayInvalidBoardSizeMessage();
                isValidBoardSize = false;
            }

            return isValidBoardSize;
        }

        private static void setValidNumberOPlayers(out int o_NumberOfPlayers)
        {
            string currentUserInput = Console.ReadLine();

            while (!isValidNumberOfPlayers(currentUserInput))
            {
                currentUserInput = Console.ReadLine();
            }

            o_NumberOfPlayers = int.Parse(currentUserInput);
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
            else if (numOfPlayers < minNumOfPlayers || numOfPlayers > maxNumOfPlayers)
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
            else if(rowIndex >= i_Board.BoardMatrix.GetLength(0) || rowIndex < 0 || columnIndex >= i_Board.BoardMatrix.GetLength(1)
                || columnIndex < 0)
            {
                UI.displayInvalidCellIndexesMessage();
                isValidCell = false;
            }
            else if (i_Board.BoardMatrix[rowIndex, columnIndex] != eBoardSymbol.Blank)
            {
                UI.displayCellAlreadyChosenMessage();
                isValidCell = false;
            }

            return isValidCell;          
        }

        public static bool isValidRematchInput(string i_RematchMessage)
        {
            bool isValidRematchInput = true;

            if(!i_RematchMessage.Equals("Y") || !i_RematchMessage.Equals("Q"))
            {
                UI.displayInvalidRematchInputMessage();
                isValidRematchInput = false;
            }

            return isValidRematchInput;
        }

    }
}





