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
        private const int k_CellSepartorSize = 10;

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
            createBoard();
            setPlayersLabels();
        }

        private void createBoard()
        {
            m_CellButtons = new CellButton[m_BoardSize, m_BoardSize];

            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    m_CellButtons[i, j] = new CellButton(i, j, CellButton.CellButtonSize * j + k_CellSepartorSize, CellButton.CellButtonSize * i + k_CellSepartorSize);
                    Controls.Add(m_CellButtons[i, j]);
                    m_CellButtons[i, j].Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    m_CellButtons[i, j].Click += cellButton_Click;
                    r_TicTacToeMisereGame.CellOccupied += m_CellButtons[i, j].game_CellOccupied;
                }
            }

            int formWidth = CellButton.CellButtonSize * (m_BoardSize + 1) - k_CellSepartorSize - 5;
            int formHeight = CellButton.CellButtonSize * (m_BoardSize + 1) + 20; 

            Text = "TicTacToeMisere";
            Size = new System.Drawing.Size(formWidth, formHeight);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            FormBorderStyle = FormBorderStyle.FixedSingle;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            r_TicTacToeMisereGame.GameDecided += game_GameDecided;
            r_TicTacToeMisereGame.GameTied += game_GameTied;
        }
        private void setPlayersLabels()
        {
            m_LabelPlayers = new PlayerLabel[2];

            m_LabelPlayers[0] = new PlayerLabel();
            m_LabelPlayers[0].Location = new System.Drawing.Point(k_CellSepartorSize, Location.Y + ClientSize.Height - 20);
            m_LabelPlayers[0].Text = string.Format("{0}: {1}", r_TicTacToeMisereGame.Players[0].Name, r_TicTacToeMisereGame.Players[0].Score);

            m_LabelPlayers[1] = new PlayerLabel();
            m_LabelPlayers[1].Location = new System.Drawing.Point((m_BoardSize - 2) * (CellButton.CellButtonSize), m_LabelPlayers[0].Location.Y);
            m_LabelPlayers[1].Text = string.Format("{0}: {1}", r_TicTacToeMisereGame.Players[1].Name, r_TicTacToeMisereGame.Players[1].Score);

            int startingPlayerIdx = r_TicTacToeMisereGame.CurrentTurnPlayerIndex;

            for (int i = 0; i < m_LabelPlayers.Length; i++)
            {
                System.Drawing.FontStyle fontStyle = startingPlayerIdx == i ?
                    System.Drawing.FontStyle.Bold :
                    System.Drawing.FontStyle.Regular;
                m_LabelPlayers[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 6.875F, fontStyle, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                m_LabelPlayers[i].Width = CellButton.CellButtonSize * 2;
                r_TicTacToeMisereGame.MoveCompleted += m_LabelPlayers[i].game_MoveCompleted;
                Controls.Add(m_LabelPlayers[i]);
            }
        }
        private void game_GameDecided(object sender, int i_WinnerPlayerIdx)
        {
            updatePlayerLabelText(i_WinnerPlayerIdx);
            showGameFinishedDialog(string.Format(
@"The winner is {0}!
Would you like to play another round?", r_TicTacToeMisereGame.Players[i_WinnerPlayerIdx].Name), "A Win!");
        }

        private void game_GameTied(object sender, EventArgs e)
        {
            showGameFinishedDialog(string.Format(
@"A Tie!
Would you like to play another round?"), "A Tie!");
        }
        private void showGameFinishedDialog(string i_GameFinishedMessage, string i_GameResult)
        {
            MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(i_GameFinishedMessage, i_GameResult, messageBoxButtons);

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
