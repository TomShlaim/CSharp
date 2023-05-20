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

        public static void setValidBoardSize(out int o_BoardSize)
        {
            string currentUserInput = Console.ReadLine();

            while (!isValidBoardSize(currentUserInput))
            {
                UI.displayInvalidBoardSizeMessage();
                currentUserInput = Console.ReadLine();
            }

            o_BoardSize = int.Parse(currentUserInput);
        }

        private static bool isValidBoardSize(string i_CurrentUserInput)
        {
            bool isValidBoardSize = true;
            int boardSize;

            if (!int.TryParse(i_CurrentUserInput, out boardSize))
            {
                isValidBoardSize = false;
            }
            else if (boardSize < minBoardSize || boardSize > maxBoardSize)
            {
                isValidBoardSize = false;
            }

            return isValidBoardSize;
        }

        public static void setValidNumberOPlayers(out int o_NumberOfPlayers)
        {
            string currentUserInput = Console.ReadLine();

            while (!isValidNumberOfPlayers(currentUserInput)
            {
                UI.displayInvalidNumOfPlayersMessage();
                currentUserInput = Console.ReadLine();
            }

            o_NumberOfPlayers = int.Parse(currentUserInput);
        }

        private static bool isValidNumberOfPlayers(string i_CurrentUserInput)
        {
            bool isValidNumOfPlayers = true;
            int numOfPlayers;

            if (!int.TryParse(i_CurrentUserInput, out numOfPlayers))
            {
                isValidNumOfPlayers = false;
            }
            else if (numOfPlayers < minNumOfPlayers || numOfPlayers > maxNumOfPlayers)
            {
                isValidNumOfPlayers = false;
            }

            return isValidNumOfPlayers;
        }

        public static void setValidLocation(out string o_Location, Board i_Board)
        {
            string currentUserInput = Console.ReadLine();
            int exitCode;
            while(!isValidLocation(currentUserInput,i_Board, out exitCode))
            {
                if (exitCode == 1)
                {
                    UI.displayInvalidLocationFormatMessage();
                }
                else if(exitCode == 2)
                {
                    UI.displayInvalidLocationIndexesMessage();
                }
                else
                {
                    UI.displayCellAlreadyChosenMessage();
                }
                currentUserInput = Console.ReadLine();
            }

            o_Location = currentUserInput;
        }

        private static bool isValidLocation(string i_CurrentUserInput, Board i_Board, out int o_ExitCode) 
        {
           bool isValidLocation = true;
           int rowIndex, columnIndex;

            o_ExitCode = 0;
            if(i_CurrentUserInput.Length != 3)
            {
                o_ExitCode = 1;
                isValidLocation = false;
            }
            else if(i_CurrentUserInput[1] != ',' || !int.TryParse(i_CurrentUserInput[0].ToString(), out rowIndex)
                     || !int.TryParse(i_CurrentUserInput[2].ToString(), out columnIndex))
            {
                o_ExitCode = 1;
                isValidLocation = false;
            }
            else if(rowIndex >= i_Board.BoardMatrix.GetLength(0) || rowIndex < 0 || columnIndex >= i_Board.BoardMatrix.GetLength(1)
                || columnIndex < 0)
            {
                o_ExitCode = 2;
                isValidLocation = false;
            }
            else if (i_Board.BoardMatrix[rowIndex, columnIndex] != BoardSymbol.Blank)
            {
                o_ExitCode = 3;
                isValidLocation = false;
            }

            return isValidLocation;          
        }

        public static void setValidRematchInput (ref string io_RematchMessage)
        {

            while(!io_RematchMessage.Equals("Y") || !io_RematchMessage.Equals("Q"))
            {
                UI.displayInvalidRematchInputMessage();

            }
            
        }

    }
}





