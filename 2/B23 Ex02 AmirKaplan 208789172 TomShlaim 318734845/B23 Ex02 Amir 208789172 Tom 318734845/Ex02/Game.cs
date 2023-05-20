using System;
using System.Collections.Generic;

namespace Ex02
{
    internal class Game
    {
        private Board m_board;
        private List<Object> m_players;
        int m_currentTurnPlayerIndex = 0;

        public Game(Board i_board, List<Object> i_players)
        {
            m_board = i_board;
            m_players = i_players;
        }
        public bool isGameOver()
        {
            return isGameTied() || m_board.hasSequence() ? true : false;
        }
        private bool isGameTied()
        {
            return m_board.isFullBoard();
        }
        public object getWinningPlayer()
        {
            BoardSymbol losingSymbol = m_board.getSequenceSymbol();
            object winningPlayer = null;

            foreach(Object player in m_players)
            {
                if(player.GetType() == typeof(PersonPlayer))
                {
                    if (((PersonPlayer)player).Symbol != losingSymbol)
                    {
                        winningPlayer = player;
                    }
                }
                else
                {
                    if (((ComputerPlayer)player).Symbol != losingSymbol)
                    {
                        winningPlayer = player;
                    }
                }
            }
            return winningPlayer;
        }
        public void startGame()
        {
            BoardAnimation.updateBoardDraw(m_board);
            
            while(!isGameOver())
            {
                string location = "";

                if (m_players[m_currentTurnPlayerIndex].GetType() == typeof(PersonPlayer))
                {
                    UI.queryNextCellLocation();
                    location = Console.ReadLine();
                    //Game validator logic here
                }
                else
                {
                    //Get location from computer
                }

                int locationRowIndex = Board.parseCellLocation(location, true);
                int locationColumnIndex = Board.parseCellLocation(location, false);

                //m_board.updateBoard(locationRowIndex, locationColumnIndex);
                BoardAnimation.updateBoardDraw(m_board);
                m_currentTurnPlayerIndex = 1 - m_currentTurnPlayerIndex;
            }
            if(isGameTied())
            {
                UI.displayTieGameMessage(m_players);
            }
            else
            {
                UI.displayRematchMessage();
                string doRematch = Console.ReadLine();
                //Game validator logic here;
                //If retry else quit?
                m_board.resetBoard();
                startGame();
            }
        }
        public void quitGame()
        {
            UI.displayQuitMessage();
            Console.ReadLine();
        }
    }
}
