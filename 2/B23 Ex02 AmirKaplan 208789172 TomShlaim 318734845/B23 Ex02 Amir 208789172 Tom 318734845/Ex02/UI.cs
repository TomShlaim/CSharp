using System;
using System.Collections.Generic;
using System.Text;

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
4. On your turn, you will be able to choose a cell to set your tool on the board. 
   In order to set a cell, just type : 'rowIndex,columnIndex'. For example, if you want to set your tool on [1,1], just type 1,1 when asked.
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
        public static void queryNextCellCell()
        {
            string nextCellQuery = string.Format(
@"Please choose the cell to put in your tool :
===================================================
"
);

            displayMessageToUser(nextCellQuery);
        }
        public static void displayInvalidCellFormatMessage()
        {
            displayMessageToUser("Invalid cell format! Cell should be of the following format 'rowIndex,columnIndex'");
        }
        public static void displayInvalidCellIndexesMessage()
        {
            displayMessageToUser("Invalid cell indexes! Cocation is out of bound");
        }
        public static void displayCellAlreadyChosenMessage()
        {    
            string nextCellQuery = string.Format(
@"The cell you chose is alreday taken! Please try again :
=========================================================
"
);

            displayMessageToUser(nextCellQuery);           
        }
        public static void displayGameFinishedMessage(List<Player> i_Players, bool i_IsTie)
        {
            string gameFinishedMessage = getGameFinishedHeaderMessage(i_Players, i_IsTie) + getPointsStatusMessage(i_Players);

            displayMessageToUser(gameFinishedMessage);
        }
        private static string getGameFinishedHeaderMessage(List<Player> i_Players, bool i_IsTie)
        {
            string gameResultMessage = i_IsTie ? "Tie" : i_Players.Count == 1 ? "The winner is : " : "The winners are : ";
            string gameFinsihedHeaderMessage = string.Format(
@"Game Over!
============
{0}
"
, gameResultMessage);

            return gameFinsihedHeaderMessage;
        }
        private static StringBuilder getPointsStatusMessage(List<Player> i_Players)
        {
            StringBuilder pointsStatusMessage = new StringBuilder(string.Format("This is the points status :" +
                "==========================="));

            foreach (Player player in i_Players)
            {
                pointsStatusMessage.AppendLine(String.Format("{0} - {1} points", player.Name, 'O', player.Score));
            }

            return pointsStatusMessage;
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
            string invalidRematchMessage = string.Format(
@"Invalid rematch input! Please try again :
===========================================
"
);

            displayMessageToUser(invalidRematchMessage);
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

