using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeMisereLogic
{
    internal class GameValidator
    {
        private const int k_MinNumOfPlayers = 1;
        private const int k_MaxNumOfPlayers = 2;

        public static bool IsValidCell(Cell i_Cell, Board i_Board)
        {
            bool isValidCell = true;
            int rowIndex = i_Cell.Row, columnIndex = i_Cell.Column;


            if (rowIndex >= i_Board.BoardMatrix.GetLength(0) || rowIndex < 0 || columnIndex >= i_Board.BoardMatrix.GetLength(1)
                || columnIndex < 0)
            {
                isValidCell = false;
            }
            else if (i_Board.BoardMatrix[rowIndex, columnIndex] != eBoardSymbol.Blank)
            {
                isValidCell = false;
            }

            return isValidCell;
        }

        public static bool IsValidRematchInput(string i_CurrentUserInput)
        {
            bool isValidRematchInput = true;

            //Program.ExitProgramIfRequested(i_CurrentUserInput);
            if (!i_CurrentUserInput.Equals("Y"))
            {
                //UI.DisplayInvalidRematchInputMessage();
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
