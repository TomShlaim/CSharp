using System;

namespace Ex02
{
    internal class Program
    {
        public static void Main(string[] args) 
        {
            Board board = new Board(5);
            BoardAnimation.updateBoardDraw(board);
            UI.queryBoardSize();
            UI.displayGameInstructions();
            UI.queryBoardSize();
        }
    }
}
