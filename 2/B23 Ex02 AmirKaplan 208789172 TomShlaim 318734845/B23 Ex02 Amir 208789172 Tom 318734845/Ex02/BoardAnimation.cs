using System;
using System.Linq.Expressions;
using System.Text;

namespace Ex02
{
    internal class BoardAnimation
    {
        private const int k_cellWidthSize = 5;
        private const char k_cellSeparator = '|';
        private const char k_lineSeparator = '=';
        private static void clearBoard()
        {
            Ex02.ConsoleUtils.Screen.Clear();
        }
        private static void drawBoard(Board i_board)
        {
            BoardSymbol[,] boardMatrix = i_board.BoardMatrix;
            StringBuilder boardAnimation = new StringBuilder();
            
            boardAnimation.Append(getBoardColumnsHeader(boardMatrix));
            boardAnimation.AppendLine();
            boardAnimation.Append(getBoardRows(boardMatrix));
            Console.WriteLine(boardAnimation);
        }
        private static StringBuilder getBoardRows(BoardSymbol[,] i_boardMatrix)
        {
            int boardNumOfRows = i_boardMatrix.GetLength(0);
            int boardNumOfColumns = i_boardMatrix.GetLength(1);
            StringBuilder boardsRow = new StringBuilder();

            for (int i = 0; i < boardNumOfRows; i++)
            {
                boardsRow.Append(getBoardRow(i_boardMatrix, i, boardNumOfColumns));
                boardsRow.AppendLine();
                boardsRow.Append(getLineSeparator(boardNumOfColumns));
                boardsRow.AppendLine();
            }

            return boardsRow;
        }
        private static StringBuilder getBoardRow(BoardSymbol[,] i_boardMatrix, int i_rowIndex, int i_boardNumOfColumns)
        {
            StringBuilder boardRow = new StringBuilder((i_rowIndex + 1).ToString());
            string spaceInCell = new string(' ', k_cellWidthSize);

            for (int j = 0; j < i_boardNumOfColumns; j++)
            {
                switch (i_boardMatrix[i_rowIndex,j])
                {
                    case BoardSymbol.Blank:
                        boardRow.AppendFormat("{0}{1}", k_cellSeparator, new String(' ', k_cellWidthSize));
                        break;
                    case BoardSymbol.Ex:
                        boardRow.AppendFormat("{0}{1}", k_cellSeparator, String.Format("{0}{1}{2}", spaceInCell, 'X', spaceInCell));
                        break;
                    case BoardSymbol.Circle:
                        boardRow.AppendFormat("{0}{1}", k_cellSeparator, String.Format("{0}{1}{2}", spaceInCell, 'O', spaceInCell));
                        break;
                }
            }

            boardRow.Append(k_cellSeparator);

            return boardRow;
        }
        private static StringBuilder getLineSeparator(int i_boardNumOfColumns)
        {
            StringBuilder lineSeparator = new StringBuilder(new string(' ', k_cellWidthSize - 3));

            lineSeparator.Append(k_lineSeparator, (i_boardNumOfColumns + 1) * k_cellWidthSize);

            return lineSeparator;
        }
        private static StringBuilder getBoardColumnsHeader(BoardSymbol[,] i_boardMatrix) 
        {
            int boardNumOfColumns = i_boardMatrix.GetLength(1);

            StringBuilder columnsHeader = new StringBuilder(new string(' ', k_cellWidthSize - 2));

            for (int i = 0; i < boardNumOfColumns; i++)
            {
                columnsHeader.AppendFormat("{0}{1}", i + 1, new String(' ', k_cellWidthSize));
            }

            return columnsHeader;
        }
        public static void updateBoardDraw(Board i_board) 
        {
            clearBoard();
            drawBoard(i_board);
        }

    }
}
