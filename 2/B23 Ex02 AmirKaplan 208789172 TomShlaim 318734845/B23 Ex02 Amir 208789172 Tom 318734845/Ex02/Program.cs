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
            List<Object> players = new List<Object>();
            Board board;
            BoardSymbol player1Symbol, player2Symbol;
            Random randSymbolGenerator = new Random();

            UI.displayGameInstructions();
            UI.queryBoardSize();
            GameValidator.setValidBoardSize(out boardSize);
            board = new Board(boardSize);
            UI.querySingleOrMultiplayerGame();
            GameValidator.setValidNumberOPlayers(out numOfPlayers);
            player1Symbol = (BoardSymbol)randSymbolGenerator.Next(2);
            player2Symbol = (BoardSymbol)(1 - ((int)player1Symbol));
            players.Add(new PersonPlayer("Moshe", player1Symbol));
            if (numOfPlayers > 1)
            {
                players.Add(new PersonPlayer("Yossi", player2Symbol));
            }
            else
            {
                players.Add(new ComputerPlayer(player2Symbol, boardSize));
            }

            Game game = new Game(board, players);
            game.startGame();        
        }
    }
}
