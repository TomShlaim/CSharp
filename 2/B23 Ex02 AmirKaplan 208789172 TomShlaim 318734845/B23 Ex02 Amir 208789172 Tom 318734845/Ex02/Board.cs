using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
        public bool hasSequence()
        {
            return getSequenceSymbol() != BoardSymbol.Blank;
        }
        public BoardSymbol getSequenceSymbol()
        {
            BoardSymbol sequenceSymbol = BoardSymbol.Blank;
            int boardSize = m_boardMatrix.GetLength(0);

            if (hasSequenceInPrimaryDiagonal() > -1)
            {
                sequenceSymbol = m_boardMatrix[0, 0];
            }
            else if (hasSequenceInSecondaryDiagonal() > -1)
            {
                sequenceSymbol = m_boardMatrix[0, boardSize - 1];
            }
            else
            {
                int rowSequenceIndex = hasSequenceInRow();

                if(rowSequenceIndex > -1)
                {
                    sequenceSymbol = m_boardMatrix[rowSequenceIndex, 0];
                }
                else
                {
                    int columnSequenceIndex = hasSequenceInColumn();

                    sequenceSymbol = m_boardMatrix[0, columnSequenceIndex];
                }
            }

            return sequenceSymbol;
        }
        private int hasSequenceInPrimaryDiagonal()
        {
            int hasSequence = 1;
            int boardSize = m_boardMatrix.GetLength(0);

            for (int i = 0; i < boardSize - 1; i++)
            {
                if(m_boardMatrix[i, i] != m_boardMatrix[i + 1, i + 1])
                {
                    hasSequence = -1;
                    break;
                }
            }

            return hasSequence;
        }
        private int hasSequenceInSecondaryDiagonal()
        {
            int hasSequence =-1;
            int boardSize = m_boardMatrix.GetLength(0);

            for (int i = 0; i < boardSize - 1; i++)
            {
                if(m_boardMatrix[i, boardSize - 1 - i] != m_boardMatrix[i + 1, boardSize - 2 - i])
                {
                    hasSequence = -1;
                    break;
                }
            }

            return hasSequence;
        }
        private int hasSequenceInRow()
        {
            int hasSequence = -1;
            int boardSize = m_boardMatrix.GetLength(0);

            for (int i = 0; i < boardSize; i++)
            {
                bool hasSequenceInSpecificRow = true;
                for (int j = 0; j < boardSize - 1; j++)
                {
                    if(m_boardMatrix[i, j] != m_boardMatrix[i, j + 1])
                    {
                        hasSequenceInSpecificRow = false;
                    }
                }
                if(hasSequenceInSpecificRow)
                {
                    hasSequence = i;
                }
            }

            return hasSequence;
        }
        private int hasSequenceInColumn()
        {
            int hasSequence = -1;
            int boardSize = m_boardMatrix.GetLength(0);

            for (int j = 0; j < boardSize; j++)
            {
                bool hasSequenceInSpecificColumn = true;
                for (int i = 0; i < boardSize - 1; i++)
                {
                    if (m_boardMatrix[i, j] != m_boardMatrix[i + 1, j])
                    {
                        hasSequenceInSpecificColumn = false;
                    }
                }
                if (hasSequenceInSpecificColumn)
                {
                    hasSequence = j;
                }
            }

            return hasSequence;
        }
        public static int parseCellLocation(string i_location, bool i_getRowIndex)
        {
            List<string> locationIndexes = i_location.Split(',').ToList<string>();

            return i_getRowIndex ? int.Parse(locationIndexes[0]) : int.Parse(locationIndexes[1]);
        }
    }
}
