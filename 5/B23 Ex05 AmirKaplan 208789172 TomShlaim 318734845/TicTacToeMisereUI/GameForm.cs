using System;
using System.Collections.Generic;
using System.Drawing;
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
        private List<PlayerLabel> m_LabelPlayers;
        private const int k_CellSepartorSize = 10;

        public GameForm(int i_BoardSize, List<string> i_PlayerNames)
        {
            m_BoardSize = i_BoardSize;
            r_TicTacToeMisereGame = new Game(i_BoardSize, i_PlayerNames);
            m_LabelPlayers = new List<PlayerLabel>();
            initializeComponents();
            bool isComputerStarting = r_TicTacToeMisereGame.Players[r_TicTacToeMisereGame.CurrentTurnPlayerIndex].IsComputer;

            if(isComputerStarting) 
            {
                r_TicTacToeMisereGame.SetComputerPlayerNextChoice();
            }
        }
        private void initializeComponents()
        {
            createGameForm();
        }

        private void createGameForm()
        {
            createBoard();
            setFormSettings();
            setGameEvents();
            setPlayersLabelsAndEvents();
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
        }
        private void setFormSettings()
        {
            int formWidth = CellButton.CellButtonSize * (m_BoardSize + 1) - k_CellSepartorSize * 2;
            int formHeight = CellButton.CellButtonSize * (m_BoardSize + 1) + 20;

            Text = "TicTacToeMisere";
            Size = new Size(formWidth, formHeight);
            Font = new Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void setGameEvents()
        {
            r_TicTacToeMisereGame.GameDecided += game_GameDecided;
            r_TicTacToeMisereGame.GameTied += game_GameTied;
        }
        private void setPlayersLabelsAndEvents()
        {
            setPlayerLabelList();
            integratePlayerLabelsWithTheBoard();
        }
        private void integratePlayerLabelsWithTheBoard()
        {
            int startingPlayerIdx = r_TicTacToeMisereGame.CurrentTurnPlayerIndex;
            int counter = 0;

            foreach (PlayerLabel playerLabel in m_LabelPlayers)
            {
                FontStyle fontStyle = startingPlayerIdx == counter ?
                                      FontStyle.Bold :
                                      FontStyle.Regular;

                playerLabel.Font = new Font("Microsoft Sans Serif", 6F, fontStyle, GraphicsUnit.Point, ((byte)(0)));
                r_TicTacToeMisereGame.MoveCompleted += playerLabel.game_MoveCompleted;
                Controls.Add(playerLabel);
                counter++;
            }
        }
        private void setPlayerLabelList()
        {
            Point playerALocation = new Point(k_CellSepartorSize, Location.Y + ClientSize.Height - 20);
            Point playerBLocation = new Point((m_BoardSize - 2) * (CellButton.CellButtonSize) + k_CellSepartorSize, playerALocation.Y);

            m_LabelPlayers.Add(getPlayerLabel(playerALocation, r_TicTacToeMisereGame.Players[0]));
            m_LabelPlayers.Add(getPlayerLabel(playerBLocation, r_TicTacToeMisereGame.Players[1]));
        }
        private PlayerLabel getPlayerLabel(Point i_Location, Player i_Player)
        {
            PlayerLabel playerLabel = new PlayerLabel
            {
                Location = i_Location,
                Text = string.Format("{0}: {1}", i_Player.Name, i_Player.Score)
            };
            ;
            playerLabel.Width = CellButton.CellButtonSize * 2 + 2;

            return playerLabel;
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
