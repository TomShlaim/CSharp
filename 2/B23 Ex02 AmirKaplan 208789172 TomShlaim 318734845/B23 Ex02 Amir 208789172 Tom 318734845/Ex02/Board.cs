using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex02
{
    internal class Board
    {
        private BoardSymbol[,] m_boardMatrix;
        private int m_numOfOccupuiedCells = 0;

        public Board(int i_boardSize)
        {
            m_boardMatrix = new BoardSymbol[i_boardSize, i_boardSize];
            resetMatrix();
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
            m_boardMatrix[i_rowIndex,i_columnIndex] = i_boardSymbol;
            m_numOfOccupuiedCells++;
        }
        public void resetBoard()
        {
            resetMatrix();
            m_numOfOccupuiedCells = 0;
        }
        private void resetMatrix()
        {
            for (int i = 0; i < m_boardMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < m_boardMatrix.GetLength(1); j++)
                {
                    m_boardMatrix[i, j] = BoardSymbol.Blank;
                }
            }
        }
        private static int parseCellLocation(string i_location, bool i_getRowIndex)
        {
            List<string> locationIndexes = i_location.Split(',').ToList<string>();

            return i_getRowIndex ? int.Parse(locationIndexes[0]) : int.Parse(locationIndexes[1]);
        }
    }
}
