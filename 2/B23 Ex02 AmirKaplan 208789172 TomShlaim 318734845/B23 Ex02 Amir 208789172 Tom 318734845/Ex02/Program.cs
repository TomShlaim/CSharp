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
            //Maybe sleep here? the last greeting isn't showed
            game.playGame();        
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

        //I would split this function logic to some sub functions, even if they are one line : getFreeSymbols, updateFreeSymbols, addPersonPlayer, addComputerPlayer  
        private static void addPlayers(List<Player> i_Players, int i_NumOfPlayers)
        {
            string currentPlayerName;
            eBoardSymbol currentPlayerSymbol;
            Random randIndexGenerator = new Random();
            List<eBoardSymbol> freeSymbols = Enum.GetValues(typeof(eBoardSymbol)).Cast<eBoardSymbol>().ToList();

            //addPersonPlayer 
            freeSymbols.Remove(eBoardSymbol.Blank);
            UI.queryPlayerName(1);
            setValidPlayerName(out currentPlayerName);
            currentPlayerSymbol = freeSymbols[randIndexGenerator.Next(freeSymbols.Count())];
            i_Players.Add(new Player(currentPlayerName, currentPlayerSymbol, false));
            freeSymbols.Remove(currentPlayerSymbol);
            UI.greetPlayer(i_Players.Last());
            if (i_NumOfPlayers == 1)
            {
                //addComputerPlayer
                currentPlayerSymbol = freeSymbols[randIndexGenerator.Next(freeSymbols.Count())];
                i_Players.Add(new Player("Computer", currentPlayerSymbol, true));
                freeSymbols.Remove(currentPlayerSymbol);
            }
            else
            {
                for(int i = 2; i <= i_NumOfPlayers; i++)
                {
                    //AddPersonPlayer
                    UI.queryPlayerName(i);
                    setValidPlayerName(out currentPlayerName);
                    currentPlayerSymbol = freeSymbols[randIndexGenerator.Next(freeSymbols.Count())];
                    i_Players.Add(new Player(currentPlayerName, currentPlayerSymbol, false));
                    freeSymbols.Remove(currentPlayerSymbol);
                    UI.greetPlayer(i_Players.Last());
                }
            }
        }

        internal static void exitProgramIfRequested (string i_UserInput)
        {
            if (GameValidator.isExitCommand(i_UserInput))
            {
                UI.displayQuitMessage();
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }
    }
}
