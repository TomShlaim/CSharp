using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeMisereLogic
{
    public struct Cell
    {
        private int m_Row;
        private int m_Column;

        public Cell(int i_Row, int i_Column)
        {
            m_Row = i_Row;
            m_Column = i_Column;
        }

        public Cell(string i_Cell)
        {
            List<string> cellIndexes = i_Cell.Split(',').ToList<string>();

            m_Row = int.Parse(cellIndexes[0]) - 1;
            m_Column = int.Parse(cellIndexes[1]) - 1;
        }

        public int Row
        {
            get
            {
                return m_Row;
            }
        }

        public int Column
        {
            get
            {
                return m_Column;
            }
        }
    }
}
