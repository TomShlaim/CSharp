using System;

namespace Ex02
{
    internal class Program
    {
        public static void Main(string[] args) 
        {
            Board board = new Board(3);
            BoardAnimation.updateBoardDraw(board);
        }
    }
}
