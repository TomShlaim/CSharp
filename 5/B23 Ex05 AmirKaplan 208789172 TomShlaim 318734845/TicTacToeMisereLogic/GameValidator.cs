using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeMisereLogic
{
    internal class GameValidator
    {
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
    }
}
