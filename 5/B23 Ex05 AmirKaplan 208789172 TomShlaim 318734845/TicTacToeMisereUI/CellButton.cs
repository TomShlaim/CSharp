using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeMisereLogic;

namespace TicTacToeMisereUI
{
    internal class CellButton : Button
    {
        private int m_Row;
        private int m_Column;

        public CellButton(int i_Row, int i_Column, int i_Xval, int i_Yval)
        {
            Location = new System.Drawing.Point(i_Xval, i_Yval);
            Size = new System.Drawing.Size(50, 50);
            m_Row = i_Row;
            m_Column = i_Column;  
        }

        public int Row {
            get { return m_Row; }
        }

        public int Column { 
            get { return m_Column; } 
        }

        internal void game_CellOccupied(object sender, Cell i_CellOccupied)
        {
            if (m_Row == i_CellOccupied.Row && m_Column == i_CellOccupied.Column)
            {
                Text = ((char)i_CellOccupied.Symbol).ToString();
                Enabled = false;
            }

        }
    }
}
