using System;
using System.Collections.Generic;

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
            List<Player> players = new List<Player>();
            eBoardSymbol player1Symbol, player2Symbol;
            Random randSymbolGenerator = new Random();

            UI.displayGameInstructions();
            UI.queryBoardSize();
            setValidBoardSize(out boardSize);
            Board board = new Board(boardSize);

            UI.querySingleOrMultiplayerGame();
            setValidNumberOPlayers(out numOfPlayers);
            /*
             * Here there should be a generic function that knows how to add more than 2 players, instead of the logic below.
             * Moreover, I think we should present the player to its symbol with a special message ("Moshe - You game tool is blabla"). We can extend the UI library.
            */
            player1Symbol = (eBoardSymbol)randSymbolGenerator.Next(2);
            player2Symbol = (eBoardSymbol)(1 - ((int)player1Symbol));
            players.Add(new Player("Moshe", player1Symbol, false));
            if (numOfPlayers > 1)
            {
                players.Add(new Player("Yossi", player2Symbol, false));
            }
            else
            {
                players.Add(new Player("Computer", player2Symbol, true));
            }

            Game game = new Game(board, players);

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
    }
}
