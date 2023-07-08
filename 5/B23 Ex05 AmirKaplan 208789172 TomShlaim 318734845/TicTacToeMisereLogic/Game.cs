using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeMisereLogic
{
    public class Game
    {
        public event EventHandler<Cell> CellValueChanged;
        public event EventHandler<Player> GameDecided;
        public event EventHandler GameTied;
        public event EventHandler Restart;
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

            m_CurrentTurnPlayerIndex = randomGenerator.Next(i_PlayerNames.Count);
            m_Board = new Board(i_BoardSize);
            m_Players = new List<Player>();
            addPlayers(i_PlayerNames, i_PlayerNames.Count);
        }

        public List<Player> Players
        {
            get { return m_Players; }
        }
        protected virtual void OnCellValueChanged(Cell i_CellChanged)
        {
            CellValueChanged?.Invoke(this, i_CellChanged);
        }
        protected virtual void OnGameDecided(Player i_Winner)
        {
           GameDecided?.Invoke(this, i_Winner);
        }
        protected virtual void OnGameTied()
        {
            GameTied?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnRestart()
        {
            Restart?.Invoke(this, EventArgs.Empty);
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
            //BoardAnimation.UpdateBoardDraw(m_Board);

            while (!IsGameOver())
            {
                Cell playerNextCell = getPlayerNextCell();

               // m_Board.UpdateBoard(playerNextCell, m_Players[m_CurrentTurnPlayerIndex].Symbol);
                //BoardAnimation.UpdateBoardDraw(m_Board);
                m_CurrentTurnPlayerIndex = getNextTurnPlayer();
            }
            if (isGameDecided())
            {
                List<Player> winningPlayers = getWinningPlayers();
                updateWinningPlayers(winningPlayers);
               // UI.DisplayGameWinMessage(m_Players, winningPlayers);
            }
            else if (isGameTied())
            {
               // UI.DisplayGameTieMessage(m_Players);
            }
        }

        public bool Rematch()
        {
            bool personPlayerWantsRematch = false;
            string personPlayerChosenAction;

           // UI.DisplayRematchMessage();
            personPlayerChosenAction = Console.ReadLine();

         /*   while (!GameValidator.IsValidRematchInput(personPlayerChosenAction))
            {
                personPlayerChosenAction = Console.ReadLine();
            }*/

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

        public void setNextPlayerChoice(Cell i_Cell)
        {
            if (GameValidator.IsValidCell(i_Cell, m_Board))
            {
                i_Cell.Symbol = m_Players[m_CurrentTurnPlayerIndex].Symbol;
                m_Board.UpdateBoard(i_Cell);
                OnCellValueChanged(i_Cell);
                m_CurrentTurnPlayerIndex = getNextTurnPlayer();
            }
            else
            {
                throw new Exception("Invalid Cell !");
            }
        }

   
        private Cell getPlayerNextCell()
        {
            Player currentPlayingPlayer = m_Players[m_CurrentTurnPlayerIndex];
            Cell nextCell;

            if (currentPlayingPlayer.IsComputer)
            {
                nextCell = getComputerPlayerNextCell();
            }
            else
            {
               // UI.QueryNextCellCell(currentPlayingPlayer);
                nextCell = getPersonPlayerNextCell();
            }

            return nextCell;
        }

        private Cell getPersonPlayerNextCell()
        {
            string personPlayerChosenCell = Console.ReadLine();

           /* while (!GameValidator.IsValidCell(personPlayerChosenCell, m_Board))
            {
                personPlayerChosenCell = Console.ReadLine();
            }*/

            return new Cell(personPlayerChosenCell);
        }

        private Cell getComputerPlayerNextCell()
        {
            LinkedList<Cell> boardEmptyCells = m_Board.EmptyCells;
            Random m_RandomLocationGenerator = new Random();
            int randomIndex = m_RandomLocationGenerator.Next(m_Board.EmptyCells.Count);

            return boardEmptyCells.ElementAt(randomIndex);
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
