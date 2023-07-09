using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToeMisereLogic
{
    public class Game
    {
        public event EventHandler<Cell> CellOccupied;
        public event EventHandler<int> GameDecided;
        public event EventHandler GameTied;
        public event EventHandler MoveCompleted;
        private Board m_Board;
        private List<Player> m_Players;
        private int m_CurrentTurnPlayerIndex;

        public Game(int i_BoardSize, List<string> i_PlayerNames)
        {
            initGame(i_BoardSize, i_PlayerNames);
        }
        private void initGame(int i_BoardSize, List<string> i_PlayerNames)
        {
            Random randomGenerator = new Random();

            m_Board = new Board(i_BoardSize);
            m_Players = new List<Player>();
            addPlayers(i_PlayerNames, i_PlayerNames.Count);
            m_CurrentTurnPlayerIndex = randomGenerator.Next(this.Players.Count);
        }

        public List<Player> Players
        {
            get { return m_Players; }
        }

        public int CurrentTurnPlayerIndex
        {
            get { return m_CurrentTurnPlayerIndex; }
        }

        protected virtual void OnCellOccupied(Cell i_CellOccupied)
        {
            CellOccupied?.Invoke(this, i_CellOccupied);
        }
        protected virtual void OnGameDecided(int i_winningPlayerIdx)
        {
           GameDecided?.Invoke(this, i_winningPlayerIdx);
        }
        protected virtual void OnGameTied()
        {
            GameTied?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnMoveCompleted()
        {
            MoveCompleted?.Invoke(this, EventArgs.Empty);
        }

        public bool IsGameOver()
        {
            return isGameTied() || m_Board.HasSequence() ? true : false;
        }

        private bool isGameTied()
        {
            return m_Board.IsFullBoard();
        }

        public void Rematch()
        {
            m_Board.ResetBoard();
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

        public void SetPersonPlayerNextChoice(Cell i_Cell)
        {
            if (GameValidator.IsValidCell(i_Cell, m_Board))
            {
                updateCell(i_Cell);
            }
            else
            {
                throw new Exception("Invalid Cell !");
            }
        }

        public void SetComputerPlayerNextChoice()
        {
            LinkedList<Cell> boardEmptyCells = m_Board.EmptyCells;
            Random m_RandomLocationGenerator = new Random();
            int randomIndex = m_RandomLocationGenerator.Next(m_Board.EmptyCells.Count);

            updateCell(boardEmptyCells.ElementAt(randomIndex));
        }

        private void updateCell(Cell i_Cell)
        {
            i_Cell.Symbol = m_Players[m_CurrentTurnPlayerIndex].Symbol;
            m_Board.UpdateBoard(i_Cell);
            OnCellOccupied(i_Cell);
            if (IsGameOver())
            {
                if (isGameDecided())
                {
                    List<Player> winningPlayers = getWinningPlayers();
                    updateWinningPlayers(winningPlayers);
                    OnGameDecided(m_Players.FindIndex(player => player.Name == winningPlayers[0].Name));
                }
                else
                {
                    OnGameTied();
                }
            }
            m_CurrentTurnPlayerIndex = getNextTurnPlayer();
            OnMoveCompleted();
        }

        public int getNextTurnPlayer()
        {
            return (m_CurrentTurnPlayerIndex + 1) % m_Players.Count;
        }

        private void addPlayers(List<string> i_PlayerNames, int i_NumOfPlayers)
        {
            Random randIndexGenerator = new Random();
            List<eBoardSymbol> freeSymbols = Enum.GetValues(typeof(eBoardSymbol)).Cast<eBoardSymbol>().ToList();

            freeSymbols.Remove(eBoardSymbol.Blank);
            addPersonPlayer(i_PlayerNames[0], freeSymbols, randIndexGenerator);
            if (i_NumOfPlayers == 1)
            {
                addComputerPlayer(freeSymbols, randIndexGenerator);
            }
            else
            {
                for (int i = 2; i <= i_NumOfPlayers; i++)
                {
                    addPersonPlayer(i_PlayerNames[i - 1], freeSymbols, randIndexGenerator);
                }
            }
        }

        private static void updateFreeSymbols(List<eBoardSymbol> i_FreeSymbols, eBoardSymbol i_Symbol)
        {
            i_FreeSymbols.Remove(i_Symbol);
        }

        private void addPersonPlayer(string i_PlayerName, List<eBoardSymbol> i_FreeSymbols, Random i_RandIndexGenerator)
        {
            eBoardSymbol playerSymbol;

            playerSymbol = i_FreeSymbols[i_RandIndexGenerator.Next(i_FreeSymbols.Count())];
            m_Players.Add(new Player(i_PlayerName, playerSymbol, false));
            updateFreeSymbols(i_FreeSymbols, playerSymbol);
        }

        private void addComputerPlayer(List<eBoardSymbol> i_FreeSymbols, Random i_RandIndexGenerator)
        {
            eBoardSymbol playerSymbol;

            playerSymbol = i_FreeSymbols[i_RandIndexGenerator.Next(i_FreeSymbols.Count())];
            m_Players.Add(new Player("Computer", playerSymbol, true));
            updateFreeSymbols(i_FreeSymbols, playerSymbol);
        }     
    }
}
