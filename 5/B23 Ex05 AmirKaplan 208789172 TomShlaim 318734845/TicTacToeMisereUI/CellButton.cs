using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeMisereUI
{
    internal class CellButton : Button
    {
        private int m_Row;
        private int m_Column;

        public CellButton(int i_Row, int i_Column, int i_Xval, int i_Yval)
        {
            //this.Margin = new Padding(16);
            this.Location = new System.Drawing.Point(i_Xval, i_Yval);
            this.Size = new System.Drawing.Size(50, 50);
            m_Row = i_Row;
            m_Column = i_Column;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

        }
    }
}
