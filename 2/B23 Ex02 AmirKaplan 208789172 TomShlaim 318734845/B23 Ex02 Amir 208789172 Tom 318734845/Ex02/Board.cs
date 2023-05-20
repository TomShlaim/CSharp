using System;

namespace Ex02
{
    internal class Board
    {
        private BoardSymbol[,] m_boardMatrix;
        private int m_numOfOccupuiedCells = 0;

        Board(int i_boardSize)
        {
            m_boardMatrix = new BoardSymbol[i_boardSize, i_boardSize];
            for (int i = 0; i < m_boardMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < m_boardMatrix.GetLength(1); j++)
                {
                    m_boardMatrix[i, j] = BoardSymbol.Blank;
                }
            }
        }
        public BoardSymbol[,] BoardMatrix
        {
            get
            {
                return m_boardMatrix;
            }
        }
        public bool isFullBoard()
        {
            return m_numOfOccupuiedCells == m_boardMatrix.GetLength(0) * m_boardMatrix.GetLength(1);
        }
        public void updateBoard(int i_rowIndex, int i_columnIndex, BoardSymbol i_boardSymbol)
        {

        }
        public void resetBoard()
        {

        }
        //parseLocation?

    }
}
