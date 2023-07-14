using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TicTacToeMisereLogic;

namespace TicTacToeMisereUI
{
    internal class GameForm : Form
    {
 
        public readonly Game r_TicTacToeMisereGame;
        private int m_BoardSize;
        private CellButton[,] m_CellButtons;
        private PlayerLabel[] m_LabelPlayers;

        public GameForm(int i_BoardSize, List<string> i_PlayerNames)
        {
            m_BoardSize = i_BoardSize;
            r_TicTacToeMisereGame = new Game(i_BoardSize, i_PlayerNames);
            initializeComponents();
            bool isComputerStarting = r_TicTacToeMisereGame.Players[r_TicTacToeMisereGame.CurrentTurnPlayerIndex].IsComputer;

            if(isComputerStarting) 
            {
                r_TicTacToeMisereGame.SetComputerPlayerNextChoice();
            }
        }
        private void initializeComponents()
        {
            int formWidth, formHeight, startingPlayerIdx = r_TicTacToeMisereGame.CurrentTurnPlayerIndex;

            m_CellButtons = new CellButton[m_BoardSize, m_BoardSize];
            m_LabelPlayers = new PlayerLabel[2];
     
            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    m_CellButtons[i, j] = new CellButton(i, j, 52 * j + 7, 52 * i + 7);
                    Controls.Add(m_CellButtons[i, j]);
                    m_CellButtons[i, j].Click += cellButton_Click;
                    r_TicTacToeMisereGame.CellOccupied += m_CellButtons[i, j].game_CellOccupied;
                }
            }

            formWidth = (m_CellButtons[0, m_BoardSize - 1].Location.X + m_CellButtons[0, m_BoardSize - 1].Width + 21) - (m_CellButtons[0, 0].Location.X - 7);
            formHeight = (m_CellButtons[m_BoardSize - 1, 0].Location.Y + m_CellButtons[m_BoardSize - 1, 0].Height + 80) - (m_CellButtons[0, 0].Location.Y - 7);
            Size = new System.Drawing.Size(formWidth, formHeight);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            /* TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
             tableLayoutPanel.Dock = DockStyle.Bottom;
             tableLayoutPanel.ColumnCount = 2;
             tableLayoutPanel.AutoSize = true;
             tableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            */

            // LabelPlayer1:
            m_LabelPlayers[0] = new PlayerLabel();
            m_LabelPlayers[0].Location = new System.Drawing.Point(Location.X + Width / 5, Location.Y + ClientSize.Height - 30);
            //m_LabelPlayer1.Anchor = AnchorStyles.Bottom;
            // m_LabelPlayer1.Size = new System.Drawing.Size(91, 31);
            //m_LabelPlayer1.TabIndex = 10;
            m_LabelPlayers[0].Text = string.Format("{0}: {1}", r_TicTacToeMisereGame.Players[0].Name, r_TicTacToeMisereGame.Players[0].Score);
            //m_LabelPlayer1.TextAlign = System.Drawing.ContentAlignment.BottomRight;

            // LabelPlayer2:
            m_LabelPlayers[1] = new PlayerLabel();
            m_LabelPlayers[1].Location = new System.Drawing.Point(Location.X + Width * 3 / 5, m_LabelPlayers[0].Location.Y);
            // m_LabelPlayer2.Anchor = AnchorStyles.Bottom;
            //  m_LabelPlayer2.Size = new System.Drawing.Size(91, 31);
            //m_LabelPlayer1.TabIndex = 10;
            m_LabelPlayers[1].Text = string.Format("{0}: {1}", r_TicTacToeMisereGame.Players[1].Name, r_TicTacToeMisereGame.Players[1].Score);
            //m_LabelPlayer1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;

            for(int i = 0; i < m_LabelPlayers.Length; i++)
            {
                System.Drawing.FontStyle fontStyle = startingPlayerIdx == i ? 
                    System.Drawing.FontStyle.Bold : 
                    System.Drawing.FontStyle.Regular;
                m_LabelPlayers[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, fontStyle, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                r_TicTacToeMisereGame.MoveCompleted += m_LabelPlayers[i].game_MoveCompleted;
                Controls.Add(m_LabelPlayers[i]);
            }

            Text = "TicTacToeMisere";
            StartPosition = FormStartPosition.CenterScreen;
            r_TicTacToeMisereGame.GameDecided += game_GameDecided;
            r_TicTacToeMisereGame.GameTied += game_GameTied;
        }


        private void game_GameDecided(object sender, int i_WinnerPlayerIdx)
        {
            MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;

            updatePlayerLabelText(i_WinnerPlayerIdx);

            DialogResult result = MessageBox.Show(string.Format(
@"The winner is {0}!
Would you like to play another round?", r_TicTacToeMisereGame.Players[i_WinnerPlayerIdx].Name), "A Win!", messageBoxButtons);

            if (result == DialogResult.No)
            {
                Close();
            }
            else if (result == DialogResult.Yes)
            {
                r_TicTacToeMisereGame.Rematch();
                clearBoard();    
            }
        }

        private void game_GameTied(object sender, EventArgs e)
        {
            MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(string.Format(
@"A Tie!
Would you like to play another round?"), "A Tie!", messageBoxButtons);

            if (result == DialogResult.No)
            {
                Close();
            }
            else if (result == DialogResult.Yes)
            {
                r_TicTacToeMisereGame.Rematch();
                clearBoard();
            }
        }
        private void cellButton_Click(object sender, EventArgs e)
        {
            CellButton cellButton = sender as CellButton;
            Cell chosenCell = new Cell(cellButton.Row, cellButton.Column);

            r_TicTacToeMisereGame.SetPersonPlayerNextChoice(chosenCell);
            bool isCurrentPlayerComputer = r_TicTacToeMisereGame.Players[r_TicTacToeMisereGame.CurrentTurnPlayerIndex].IsComputer;

            if (isCurrentPlayerComputer)
            {
                r_TicTacToeMisereGame.SetComputerPlayerNextChoice();
            }
        }

        private void clearBoard()
        {
            List<CellButton> cellButtons = m_CellButtons.Cast<CellButton>().ToList();

            foreach (CellButton cellButton in cellButtons)
            {
                cellButton.Text = string.Empty;
                cellButton.Enabled = true;
            }
        }
        private void updatePlayerLabelText(int i_LabelIdx)
        {
            m_LabelPlayers[i_LabelIdx].Text = string.Format(
                "{0}: {1}", r_TicTacToeMisereGame.Players[i_LabelIdx].Name, r_TicTacToeMisereGame.Players[i_LabelIdx].Score);
        }

    }
}
