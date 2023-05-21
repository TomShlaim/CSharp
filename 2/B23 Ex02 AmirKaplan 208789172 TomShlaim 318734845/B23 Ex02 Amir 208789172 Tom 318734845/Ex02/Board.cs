﻿using System.Collections.Generic;

namespace Ex02
{
    internal class Board
    {

        private eBoardSymbol[,] m_BoardMatrix;
        private LinkedList<Cell> m_EmptyCells;

        public Board(int i_BoardSize)
        {
            m_BoardMatrix = new eBoardSymbol[i_BoardSize, i_BoardSize];
            m_EmptyCells = new LinkedList<Cell>();
            resetMatrixAndEmptyCells();
        }
        public eBoardSymbol[,] BoardMatrix
        {
            get
            {
                return m_BoardMatrix;
            }
        }
        public LinkedList<Cell> EmptyCells
        {
            get
            {
                return m_EmptyCells;
            }
        }
        public bool isFullBoard()
        {
            int boardSize = m_BoardMatrix.GetLength(0);
            int numOfOccupuiedCells = boardSize * boardSize - m_EmptyCells.Count;

            return numOfOccupuiedCells == boardSize * boardSize;
        }
        public void updateBoard(Cell i_Cell, eBoardSymbol i_BoardSymbol)
        {
            int rowIndex = i_Cell.Row, columnIndex = i_Cell.Column;

            m_BoardMatrix[rowIndex, columnIndex] = i_BoardSymbol;
            m_EmptyCells.Remove(new Cell(rowIndex, columnIndex));
        }
        public void resetBoard()
        {
            resetMatrixAndEmptyCells();
        }
        private void resetMatrixAndEmptyCells()
        {
            int boardSize = m_BoardMatrix.GetLength(0);

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    m_BoardMatrix[i, j] = eBoardSymbol.Blank;
                    m_EmptyCells.AddLast(new Cell(i, j));
                }
            }
        }
        public bool hasSequence()
        {
            return getSequenceSymbol() != eBoardSymbol.Blank;
        }
        public eBoardSymbol getSequenceSymbol()
        {
            eBoardSymbol sequenceSymbol = eBoardSymbol.Blank;
            int boardSize = m_BoardMatrix.GetLength(0);

            if (indexOfSequenceInPrimaryDiagonal() > -1)
            {
                sequenceSymbol = m_BoardMatrix[0, 0];
            }
            else if (indexOfSequenceInSecondaryDiagonal() > -1)
            {
                sequenceSymbol = m_BoardMatrix[0, boardSize - 1];
            }
            else
            {
                int rowSequenceIndex = indexOfSequenceInRow();

                if(rowSequenceIndex > -1)
                {
                    sequenceSymbol = m_BoardMatrix[rowSequenceIndex, 0];
                }
                else
                {
                    int columnSequenceIndex = indexOfSequenceInColumn();

                    sequenceSymbol = m_BoardMatrix[0, columnSequenceIndex];
                }
            }

            return sequenceSymbol;
        }
        private int indexOfSequenceInPrimaryDiagonal()
        {
            int indexOfSequence = -1;
            int boardSize = m_BoardMatrix.GetLength(0);

            for (int i = 0; i < boardSize - 1; i++)
            {
                if(m_BoardMatrix[i, i] != m_BoardMatrix[i + 1, i + 1])
                {
                    indexOfSequence = -1;
                    break;
                }
            }

            return indexOfSequence;
        }
        private int indexOfSequenceInSecondaryDiagonal()
        {
            int indexOfSequence = -1;
            int boardSize = m_BoardMatrix.GetLength(0);

            for (int i = 0; i < boardSize - 1; i++)
            {
                if(m_BoardMatrix[i, boardSize - 1 - i] != m_BoardMatrix[i + 1, boardSize - 2 - i])
                {
                    indexOfSequence = -1;
                    break;
                }
            }

            return indexOfSequence;
        }
        private int indexOfSequenceInRow()
        {
            int indexOfSequence = -1;
            int boardSize = m_BoardMatrix.GetLength(0);

            for (int i = 0; i < boardSize; i++)
            {
                bool indexOfSequenceInSpecificRow = true;
                for (int j = 0; j < boardSize - 1; j++)
                {
                    if(m_BoardMatrix[i, j] != m_BoardMatrix[i, j + 1])
                    {
                        indexOfSequenceInSpecificRow = false;
                    }
                }
                if(indexOfSequenceInSpecificRow)
                {
                    indexOfSequence = i;
                }
            }

            return indexOfSequence;
        }
        private int indexOfSequenceInColumn()
        {
            int indexOfSequence = -1;
            int boardSize = m_BoardMatrix.GetLength(0);

            for (int j = 0; j < boardSize; j++)
            {
                bool indexOfSequenceInSpecificColumn = true;
                for (int i = 0; i < boardSize - 1; i++)
                {
                    if (m_BoardMatrix[i, j] != m_BoardMatrix[i + 1, j])
                    {
                        indexOfSequenceInSpecificColumn = false;
                    }
                }
                if (indexOfSequenceInSpecificColumn)
                {
                    indexOfSequence = j;
                }
            }

            return indexOfSequence;
        }
    }
}
