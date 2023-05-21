using System;
using System.Linq.Expressions;
using System.Text;

namespace Ex02
{
    internal class BoardAnimation
    {
        private const int k_CellWidthSize = 5;
        private const char k_CellSeparator = '|';
        private const char k_LineSeparator = '=';
        private static void clearBoard()
        {
            Ex02.ConsoleUtils.Screen.Clear();
        }
        private static void drawBoard(Board i_Board)
        {
            eBoardSymbol[,] boardMatrix = i_Board.BoardMatrix;
            StringBuilder boardAnimation = new StringBuilder();
            
            boardAnimation.Append(getBoardColumnsHeader(boardMatrix));
            boardAnimation.AppendLine();
            boardAnimation.Append(getBoardRows(boardMatrix));
            Console.WriteLine(boardAnimation);
        }
        private static StringBuilder getBoardRows(eBoardSymbol[,] i_BoardMatrix)
        {
            int boardNumOfRows = i_BoardMatrix.GetLength(0);
            int boardNumOfColumns = i_BoardMatrix.GetLength(1);
            StringBuilder boardsRow = new StringBuilder();

            for (int i = 0; i < boardNumOfRows; i++)
            {
                boardsRow.Append(getBoardRow(i_BoardMatrix, i, boardNumOfColumns));
                boardsRow.AppendLine();
                boardsRow.Append(getLineSeparator(boardNumOfColumns));
                boardsRow.AppendLine();
            }

            return boardsRow;
        }
        private static StringBuilder getBoardRow(eBoardSymbol[,] i_BoardMatrix, int i_RowIndex, int i_BoardNumOfColumns)
        {
            StringBuilder boardRow = new StringBuilder((i_RowIndex + 1).ToString());
            string spaceInCell = new string(' ', k_CellWidthSize);

            for (int j = 0; j < i_BoardNumOfColumns; j++)
            {
                switch (i_BoardMatrix[i_RowIndex,j])
                {
                    case eBoardSymbol.Blank:
                        boardRow.AppendFormat("{0}{1}", k_CellSeparator, new String(' ', k_CellWidthSize));
                        break;
                    case eBoardSymbol.Ex:
                        boardRow.AppendFormat("{0}{1}", k_CellSeparator, String.Format("{0}{1}{2}", spaceInCell, 'X', spaceInCell));
                        break;
                    case eBoardSymbol.Circle:
                        boardRow.AppendFormat("{0}{1}", k_CellSeparator, String.Format("{0}{1}{2}", spaceInCell, 'O', spaceInCell));
                        break;
                }
            }

            boardRow.Append(k_CellSeparator);

            return boardRow;
        }
        private static StringBuilder getLineSeparator(int i_BoardNumOfColumns)
        {
            StringBuilder lineSeparator = new StringBuilder(new string(' ', k_CellWidthSize - 4));

            lineSeparator.Append(k_LineSeparator, (i_BoardNumOfColumns) * (k_CellWidthSize + 1) + 1);

            return lineSeparator;
        }
        private static StringBuilder getBoardColumnsHeader(eBoardSymbol[,] i_BoardMatrix) 
        {
            int boardNumOfColumns = i_BoardMatrix.GetLength(1);

            StringBuilder columnsHeader = new StringBuilder(new string(' ', k_CellWidthSize - 2));

            for (int i = 0; i < boardNumOfColumns; i++)
            {
                columnsHeader.AppendFormat("{0}{1}", i + 1, new String(' ', k_CellWidthSize));
            }

            return columnsHeader;
        }
        public static void updateBoardDraw(Board i_Board) 
        {
            clearBoard();
            drawBoard(i_Board);
        }

    }
}
