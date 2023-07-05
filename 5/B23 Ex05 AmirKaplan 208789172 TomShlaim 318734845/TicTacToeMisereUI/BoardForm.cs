using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeMisereUI
{
    internal class BoardForm : Form
    {
        private int m_BoardSize;
        private CellButton[,] m_CellButtons;
        private Label m_LabelPlayer1;
        private Label m_LabelPlayer2;
        public BoardForm(int i_BoardSize, List<string> i_PlayerNames)
        {
            
            m_BoardSize = i_BoardSize;
            m_CellButtons = new CellButton[i_BoardSize, i_BoardSize];
            this.Size = new System.Drawing.Size(60 * i_BoardSize, 70 * i_BoardSize);
            for (int i = 0; i < i_BoardSize; i++) 
            {
                for (int j = 0; j < i_BoardSize; j++) 
                {
                    m_CellButtons[i, j] = new CellButton(i, j,52 * i + 7 , 52 * j + 7);
                    this.Controls.Add(m_CellButtons[i, j]);
                }
            }
            this.Text = "TicTacToeMisere";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void setGameBoard(int i_BoardSize)
        {
            TicTacToeMisereLogic.Board gameBoard = new TicTacToeMisereLogic.Board(i_BoardSize);
        }

        private void setPlayers(List<string> i_PlayerNames)
        {

        }

        private void initializeComponents() { }

    }
}
