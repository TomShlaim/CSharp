using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex02
{
    internal class Game
    {
        private Board m_Board;
        private List<Player> m_Players;
        int m_CurrentTurnPlayerIndex = 0;

        public Game(Board i_Board, List<Player> i_Players)
        {
            m_Board = i_Board;
            m_Players = i_Players;
        }

        public bool IsGameOver()
        {
            return isGameTied() || m_Board.HasSequence() ? true : false;
        }

        private bool isGameTied()
        {
            return m_Board.IsFullBoard();
        }

        public void PlayGame()
        {
            BoardAnimation.UpdateBoardDraw(m_Board);
            
            while(!IsGameOver())
            {
                Cell playerNextCell = getPlayerNextCell();

                m_Board.UpdateBoard(playerNextCell, m_Players[m_CurrentTurnPlayerIndex].Symbol);
                BoardAnimation.UpdateBoardDraw(m_Board);
                m_CurrentTurnPlayerIndex = getNextTurnPlayer();
            }
            if(isGameDecided())
            {
                List<Player> winningPlayers = getWinningPlayers();
                updateWinningPlayers(winningPlayers);
                UI.DisplayGameWinMessage(m_Players, winningPlayers);
            }
            else if(isGameTied())
            {
                UI.DisplayGameTieMessage(m_Players);
            }
        }

        public bool Rematch()
        {
            bool personPlayerWantsRematch = false;
            string personPlayerChosenAction;

            UI.DisplayRematchMessage();
            personPlayerChosenAction = Console.ReadLine();

            while(!GameValidator.IsValidRematchInput(personPlayerChosenAction))
            {
                personPlayerChosenAction = Console.ReadLine();
            }

            personPlayerWantsRematch = true;
            m_Board.ResetBoard();
            m_CurrentTurnPlayerIndex = 0;

            return personPlayerWantsRematch;
        }

        private bool isGameDecided()
        {
            return getWinningPlayers().Count() > 0; 
        }

        private List<Player> getWinningPlayers()
        {
            List<Player> winningPlayers = new List<Player>();
            eBoardSymbol losingSymbol = m_Board.GetSequenceSymbol();

            if (losingSymbol != eBoardSymbol.Blank)
            {
                foreach (Player player in m_Players)
                {
                    if (player.Symbol != losingSymbol)
                    {
                        winningPlayers.Add(player);
                    }
                }
            }
            return winningPlayers;
        }

        private void updateWinningPlayers(List<Player> i_WinningPlayers)
        {
            foreach (Player player in i_WinningPlayers)
            {
                player.Score += 1;
            }
        }

        private Cell getPlayerNextCell()
        {
            Player currentPlayingPlayer = m_Players[m_CurrentTurnPlayerIndex];
            Cell nextCell;

            if(currentPlayingPlayer.IsComputer)
            {
                nextCell = getComputerPlayerNextCell();
            }
            else
            {
                UI.QueryNextCellCell(currentPlayingPlayer);
                nextCell = getPersonPlayerNextCell();
            }

            return nextCell;
        }

        private Cell getPersonPlayerNextCell()
        {
            string personPlayerChosenCell = Console.ReadLine();

            while (!GameValidator.IsValidCell(personPlayerChosenCell, m_Board))
            {
                personPlayerChosenCell = Console.ReadLine();
            }

            return new Cell(personPlayerChosenCell);
        }

        private Cell getComputerPlayerNextCell()
        {
            LinkedList<Cell> boardEmptyCells = m_Board.EmptyCells;
            Random m_RandomLocationGenerator = new Random();
            int randomIndex = m_RandomLocationGenerator.Next(m_Board.EmptyCells.Count);

            return boardEmptyCells.ElementAt(randomIndex);
        }
        private int getNextTurnPlayer()
        {
            return (m_CurrentTurnPlayerIndex + 1) % m_Players.Count;
        }
    }
}
