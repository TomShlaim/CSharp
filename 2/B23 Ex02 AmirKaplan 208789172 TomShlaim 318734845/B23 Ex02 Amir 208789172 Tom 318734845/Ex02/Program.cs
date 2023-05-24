using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Ex02
{
    internal class Program
    {
        public static void Main(string[] args) 
        {
           initProgram();
        }

        private static void initProgram()
        {
            int boardSize, numOfPlayers;
            Board board;
            List<Player> players = new List<Player>();

            UI.displayGameInstructions();
            UI.queryBoardSize();
            setValidBoardSize(out boardSize);
            board = new Board(boardSize);
            UI.querySingleOrMultiplayerGame();
            setValidNumberOPlayers(out numOfPlayers);
            addPlayers(players, numOfPlayers); 
            Game game = new Game(board, players);
            game.playGame();        
        }
        private static void addPlayers(List<Player> i_Players, int i_NumOfPlayers)
        {
            Random randIndexGenerator = new Random();
            List<eBoardSymbol> freeSymbols = Enum.GetValues(typeof(eBoardSymbol)).Cast<eBoardSymbol>().ToList();

            freeSymbols.Remove(eBoardSymbol.Blank);
            addPersonPlayer(i_Players, freeSymbols, randIndexGenerator);
            if (i_NumOfPlayers == 1)
            {
                addComputerPlayer(i_Players, freeSymbols, randIndexGenerator);
            }
            else
            {
                for(int i = 2; i <= i_NumOfPlayers; i++)
                {
                    addPersonPlayer(i_Players, freeSymbols, randIndexGenerator);
                }
            }
        }

        private static void updateFreeSymbols(List<eBoardSymbol> i_FreeSymbols, eBoardSymbol i_Symbol)
        {
            i_FreeSymbols.Remove(i_Symbol);
        }

        private static void addPersonPlayer(List<Player> i_Players, List<eBoardSymbol> i_FreeSymbols, Random i_RandIndexGenerator)
        {
            string playerName;
            eBoardSymbol playerSymbol;

            UI.queryPlayerName(Player.GetNumPlayersCreated() + 1);
            setValidPlayerName(out playerName);
            playerSymbol = i_FreeSymbols[i_RandIndexGenerator.Next(i_FreeSymbols.Count())];
            i_Players.Add(new Player(playerName, playerSymbol, false));
            updateFreeSymbols(i_FreeSymbols, playerSymbol);
            UI.greetPlayer(i_Players.Last());
            Program.pause(1000);
        }

        private static void addComputerPlayer(List<Player> i_Players, List<eBoardSymbol> i_FreeSymbols, Random i_RandIndexGenerator)
        {
            eBoardSymbol playerSymbol;

            playerSymbol = i_FreeSymbols[i_RandIndexGenerator.Next(i_FreeSymbols.Count())];
            i_Players.Add(new Player("Computer", playerSymbol, true));
            updateFreeSymbols(i_FreeSymbols, playerSymbol);
            Program.pause(1000);
        }
        private static void setValidBoardSize(out int o_BoardSize)
        {
            string currentUserInput = Console.ReadLine();

            while (!GameValidator.isValidBoardSize(currentUserInput))
            {
                currentUserInput = Console.ReadLine();
            }

            o_BoardSize = int.Parse(currentUserInput);
        }
        private static void setValidNumberOPlayers(out int o_NumberOfPlayers)
        {
            string currentUserInput = Console.ReadLine();

            while (!GameValidator.isValidNumberOfPlayers(currentUserInput))
            {

                currentUserInput = Console.ReadLine();
            }

            o_NumberOfPlayers = int.Parse(currentUserInput);
        }

        private static void setValidPlayerName(out string o_PlayerName)
        {
            o_PlayerName = Console.ReadLine();
            while (!GameValidator.isValidName(o_PlayerName))
            {
                UI.displayInvalidNameMessage();
                o_PlayerName = Console.ReadLine();
            }
        }
        internal static void exitProgramIfRequested(string i_UserInput)
        {
            if (GameValidator.isExitCommand(i_UserInput))
            {
                UI.displayQuitMessage();
                Program.pause(1000);
                Environment.Exit(0);
            }
        }
        internal static void pause(int i_MilliSeconds)
        {
            Thread.Sleep(i_MilliSeconds);
        }
    }
}
