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
        public bool isGameOver()
        {
            return isGameTied() || m_Board.hasSequence() ? true : false;
        }
        private bool isGameTied()
        {
            return m_Board.isFullBoard();
        }
        public void playGame()
        {
            BoardAnimation.updateBoardDraw(m_Board);
            
            while(!isGameOver())
            {
                Cell playerNextCell = getPlayerNextCell();

                m_Board.updateBoard(playerNextCell, m_Players[m_CurrentTurnPlayerIndex].Symbol);
                BoardAnimation.updateBoardDraw(m_Board);
                m_CurrentTurnPlayerIndex = getNextTurnPlayer();
            }
            if(isGameTied())
            {
                UI.displayGameTieMessage(m_Players);
            }
            else
            {
                List<Player> winningPlayers = getWinningPlayers();
                updateWinningPlayers(winningPlayers);
                UI.displayGameWinMessage(m_Players,winningPlayers);
            }
            rematchOrQuitGame();
        }
        private void rematchOrQuitGame()
        {
            UI.displayRematchMessage();

            string personPlayerChosenAction = Console.ReadLine();

            while(!GameValidator.isValidRematchInput(personPlayerChosenAction))
            {
                personPlayerChosenAction = Console.ReadLine();
            }

            if(personPlayerChosenAction == "Y")
            {
                m_Board.resetBoard();
                playGame();
            }
            else
            {
                quitGame();
            }
        }
        private void quitGame()
        {
            UI.displayQuitMessage();
            Console.ReadLine();
        }
        private List<Player> getWinningPlayers()
        {
            List<Player> winningPlayers = new List<Player>();
            eBoardSymbol losingSymbol = m_Board.getSequenceSymbol();

            foreach (Player player in m_Players)
            {
                if (player.Symbol != losingSymbol)
                {
                    winningPlayers.Add(player);
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
                UI.queryNextCellCell(currentPlayingPlayer);
                nextCell = getPersonPlayerNextCell();
            }

            return nextCell;
        }
        private Cell getPersonPlayerNextCell()
        {
            string personPlayerChosenCell = Console.ReadLine();

            while (!GameValidator.isValidCell(personPlayerChosenCell, m_Board))
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
