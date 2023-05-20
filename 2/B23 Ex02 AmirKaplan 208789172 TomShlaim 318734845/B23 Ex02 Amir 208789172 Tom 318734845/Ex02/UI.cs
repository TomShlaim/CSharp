using System;
using System.Collections.Generic;

namespace Ex02
{
    internal class UI
    {
        public static void displayGameInstructions()
        {
            string gameInstructions = string.Format(
@"Welcome to the X Mix Drix game!
Those are the game instructions :
=================================

1. You will set the game board size (3-9).
2. You will decide if you want to play single player or multi player.
3. You will be given a tool (X/O)
4. On your turn, you will be able to choose a location to set your tool on the board. 
   In order to set a location, just type : 'rowIndex,columnIndex'. For example, if you want to set your tool on [1,1], just type 1,1 when asked.
5. The game will end if :
    a. The board is full
    b. A player has a sequence of its tool (In this case, this player is the loser).
6. In case the game ended, you'll have the ability to rematch.
7. If you would like to quit the game, just type Q. 
"
);
            displayMessageToUser(gameInstructions);
        }
        public static void queryBoardSize()
        {
            string boardSizeQuery = string.Format(
@"Please choose the game board size :
=====================================
"
);
            displayMessageToUser(boardSizeQuery);
        }
        public static void displayInvalidBoardSizeMessage()
        {
            displayMessageToUser("Invalid board size! Board size should be between 3 and 9");
        }
        public static void querySingleOrMultiplayerGame()
        {
            string numOfPlayersQuery = string.Format(
@"Please choose the number of players :
=======================================
"
);
            displayMessageToUser(numOfPlayersQuery);
        }
        public static void displayInvalidNumOfPlayersMessage()
        {
            displayMessageToUser("Invalid number of players! Number of players should be 1 or 2");
        }
        public static void queryNextCellLocation()
        {
            string nextLocationQuery = string.Format(
@"Please choose the location to put in your tool :
===================================================
"
);
            displayMessageToUser(nextLocationQuery);
        }
        public static void displayInvalidLocationFormatMessage()
        {
            displayMessageToUser("Invalid location format! Location should be of the following format 'rowIndex,columnIndex'");
        }
        public static void displayInvalidLocationIndexesMessage()
        {
            displayMessageToUser("Invalid location indexes! Location is out of bound");
        }
        public static void displayCellAlreadyChosenMessage()
        {    
            string nextLocationQuery = string.Format(
@"The cell you chose is alreday taken! Please try again :
=========================================================
"
);
            displayMessageToUser(nextLocationQuery);           
        }
        public static void displayWinningGameMessage(Object winningPlayer)
        {

        }
        public static void displayTieGameMessage(List<Object> players)
        {

        }
        public static void displayRematchMessage()
        {
            string rematchMessage = string.Format(
@"If you would like a rematch, please type Y :
==============================================
"
);
            displayMessageToUser(rematchMessage);
        }
        public static void displayInvalidRematchInputMessage()
        {
            string nextLocationQuery = string.Format(
@"Invalid rematch input! Please try again :
===========================================
"
);
        }
            public static void displayQuitMessage()
        {
            displayMessageToUser("Thanks for playing, quitting the game...");
        }
        public static void displayMessageToUser(string i_message)
        {
            Console.WriteLine(i_message);
        }
    }
}

