using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeMisereLogic;

namespace TicTacToeMisereUI
{
    internal class BoardForm : Form
    {
        public readonly TicTacToeMisereLogic.Game r_TicTacToeMisereGame;
        private int m_BoardSize;
        private CellButton[,] m_CellButtons;
        private Label m_LabelPlayer1;
        private Label m_LabelPlayer2;
        public BoardForm(int i_BoardSize, List<string> i_PlayerNames)
        {

            m_BoardSize = i_BoardSize;
            r_TicTacToeMisereGame = new TicTacToeMisereLogic.Game(i_BoardSize, i_PlayerNames);
            initializeComponents();
        }

        private void initializeComponents()
        {
            int formWidth, formHeight, startingPlayerIdx = r_TicTacToeMisereGame.getNextTurnPlayer();
            m_CellButtons = new CellButton[m_BoardSize, m_BoardSize];
           /* this.Size = new System.Drawing.Size(60 * m_BoardSize, 70 * m_BoardSize);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           */
     
            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    m_CellButtons[i, j] = new CellButton(i, j, 52 * j + 7, 52 * i + 7);
                    this.Controls.Add(m_CellButtons[i, j]);
                    m_CellButtons[i, j].Click += this.cellButton_Click;
                    r_TicTacToeMisereGame.CellValueChanged += m_CellButtons[i, j].game_CellValueChanged;
                }
            }

            formWidth = (m_CellButtons[0, m_BoardSize - 1].Location.X + m_CellButtons[0, m_BoardSize - 1].Width + 21) - (m_CellButtons[0, 0].Location.X - 7);
            formHeight = (m_CellButtons[m_BoardSize - 1, 0].Location.Y + m_CellButtons[m_BoardSize - 1, 0].Height + 80) - (m_CellButtons[0, 0].Location.Y - 7);
            this.Size = new System.Drawing.Size(formWidth, formHeight);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

           /* TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Bottom;
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;*/

            // LabelPlayer1
            m_LabelPlayer1 = new Label();
            //m_LabelPlayer1.Dock = DockStyle.Fill;
            m_LabelPlayer1.Location = new System.Drawing.Point(this.Location.X + this.Width / 5, this.Location.Y + this.ClientSize.Height - 30);
            //m_LabelPlayer1.Anchor = AnchorStyles.Bottom;
            // m_LabelPlayer1.Size = new System.Drawing.Size(91, 31);
            //m_LabelPlayer1.TabIndex = 10;
            m_LabelPlayer1.Text = string.Format("{0}: {1}", r_TicTacToeMisereGame.Players[0].Name, r_TicTacToeMisereGame.Players[0].Score);
            //m_LabelPlayer1.TextAlign = System.Drawing.ContentAlignment.BottomRight;

            // LabelPlayer2
            m_LabelPlayer2 = new Label();
            //m_LabelPlayer2.Dock = DockStyle.Fill;
            m_LabelPlayer2.Location = new System.Drawing.Point(this.Location.X + this.Width * 3 / 5, m_LabelPlayer1.Location.Y);
            // m_LabelPlayer2.Anchor = AnchorStyles.Bottom;
            //  m_LabelPlayer2.Size = new System.Drawing.Size(91, 31);
            //m_LabelPlayer1.TabIndex = 10;
            m_LabelPlayer2.Text = string.Format("{0}: {1}", r_TicTacToeMisereGame.Players[1].Name, r_TicTacToeMisereGame.Players[1].Score);
            //m_LabelPlayer1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;

            if (startingPlayerIdx == 0)
            {
                m_LabelPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                m_LabelPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
            else
            {
                m_LabelPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                m_LabelPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
            //tableLayoutPanel.Controls.Add(m_LabelPlayer1, 0, 0);
            // tableLayoutPanel.Controls.Add(m_LabelPlayer2, 1, 0);


            // this.Controls.Add(tableLayoutPanel);

            this.Controls.Add(m_LabelPlayer1);
            // this.Controls.Add(m_LabelScorePlayer1);
            this.Controls.Add(m_LabelPlayer2);
            //this.Controls.Add(m_LabelScorePlayer2);


            this.Text = "TicTacToeMisere";
            this.StartPosition = FormStartPosition.CenterScreen;
            r_TicTacToeMisereGame.GameDecided += this.game_GameDecided;
            r_TicTacToeMisereGame.GameTied += this.game_GameTied;
        }

        private void game_GameDecided(object sender, Player i_WinnerPlayer)
        {

        }

        private void game_GameTied(object sender, EventArgs e)
        {

        }

        private void game_Restart(object sender, EventArgs e)
        {

        }


        private void cellButton_Click(object sender, EventArgs e)
        {
            CellButton cellButton = sender as CellButton;
            Cell cell = new Cell(cellButton.Row, cellButton.Column);
            r_TicTacToeMisereGame.setNextPlayerChoice(cell);
            if (r_TicTacToeMisereGame.getNextTurnPlayer() == 0)
            {
                m_LabelPlayer1.Font = new System.Drawing.Font(m_LabelPlayer1.Font, System.Drawing.FontStyle.Bold);
                m_LabelPlayer2.Font = new System.Drawing.Font(m_LabelPlayer2.Font, System.Drawing.FontStyle.Regular);
            }
            else
            {
                m_LabelPlayer2.Font = new System.Drawing.Font(m_LabelPlayer2.Font, System.Drawing.FontStyle.Bold);
                m_LabelPlayer1.Font = new System.Drawing.Font(m_LabelPlayer1.Font, System.Drawing.FontStyle.Regular);
            }
        }

    }
}
