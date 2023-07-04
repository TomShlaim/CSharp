using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02
{
    internal class UI
    {
        public static void DisplayGameInstructions()
        {
            string gameInstructions = String.Format(
@"Welcome to Reversed X Mix Drix!

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
7. If you would like to quit the game, just type 'Q'. 
"
);

            displayMessageToUser(gameInstructions);
        }

        public static void QueryBoardSize()
        {
            string boardSizeQuery = String.Format(
@"Please choose the game board size :
====================================="
);

            displayMessageToUser(boardSizeQuery);
        }

        public static void DisplayInvalidBoardSizeMessage()
        {
            string invalidBoardSizeMessage = String.Format(
@"Invalid board size! Board size should be between 3 and 9. Please try again :
=========================================================================================="
);

            displayMessageToUser(invalidBoardSizeMessage);
        }

        public static void QuerySingleOrMultiplayerGame()
        {
            string numOfPlayersQuery = String.Format(
@"Please choose the number of players :
======================================="
);

            displayMessageToUser(numOfPlayersQuery);
        }

        public static void QueryPlayerName(int i_PlayerIndex)
        {
            string playerNameQuery = String.Format(
@"Please enter player {0} name :
====================================="
, i_PlayerIndex);

            displayMessageToUser(playerNameQuery);
        }

        public static void GreetPlayer(Player i_Player)
        {
            string greetPlayerMessage = String.Format(
@"Hello, {0}! Your game symbol is {1}
====================================="
, i_Player.Name, DisplaySymbolAnimation(i_Player.Symbol));

            displayMessageToUser(greetPlayerMessage);
        }

        public static string DisplaySymbolAnimation(eBoardSymbol i_Symbol)
        {
            string symbol = null;
            switch(i_Symbol)
            {
                case eBoardSymbol.Ex:
                    symbol = "'X'";
                    break;
                case eBoardSymbol.Circle:
                    symbol = "'O'";
                    break;
                case eBoardSymbol.Blank:
                    symbol = "' '";
                    break;
            }

            return symbol;
        }

        public static void DisplayInvalidNumOfPlayersMessage()
        {
            string invalidNumOfPlayersMessage = String.Format(
@"Invalid number of players! Number of players should be bigger than 1. Please try again :
=========================================================================================="
);

            displayMessageToUser(invalidNumOfPlayersMessage);
        }

        public static void QueryNextCellCell(Player i_Player)
        {
            string nextCellQuery = String.Format(
@"{0}, Please choose the cell to put in your tool :
==================================================="
, i_Player.Name);

            displayMessageToUser(nextCellQuery);
        }

        public static void DisplayInvalidNameMessage()
        {
            string invalidNameMessage = String.Format(
@"Invalid name! Player's name should be at least 2 characters long and consist of english letters only. Please try again :
========================================================================================================="
);

            displayMessageToUser(invalidNameMessage);
        }

        public static void DisplayInvalidCellFormatMessage()
        {
            string invalidCellFormatMessage = String.Format(
@"Invalid cell format! Cell should be of the following format 'rowIndex,columnIndex'. Please try again :
========================================================================================================="
);

            displayMessageToUser(invalidCellFormatMessage);
        }

        public static void DisplayInvalidCellIndexesMessage()
        {
            string invalidCellIndexesMessage = String.Format(
@"Invalid cell indexes! Cell is out of bound. Please try again :
================================================================"
);

            displayMessageToUser(invalidCellIndexesMessage);
        }

        public static void DisplayCellAlreadyChosenMessage()
        {    
            string nextCellQuery = String.Format(
@"The cell you chose is alreday taken! Please try again :
========================================================="
);

            displayMessageToUser(nextCellQuery);           
        }

        public static void DisplayGameTieMessage(List<Player> i_Players)
        {
            string gameTieMessage = String.Format(
@"Game Over!
TIE
===========================
{0}
"
, getPointsStatusMessage(i_Players));

            displayMessageToUser(gameTieMessage);
        }

        public static void DisplayGameWinMessage(List<Player> i_Players, List<Player> i_WinningPlayers)
        {
            StringBuilder gameWinnersHeader = new StringBuilder();
            if(i_WinningPlayers.Count == 1)
            {
                gameWinnersHeader.Append(String.Format("The winner is : {0} ",i_WinningPlayers[0].Name));
            }
            else
            {
                gameWinnersHeader.Append("The winners are :");
                gameWinnersHeader.AppendLine();
                foreach (Player winningPlayer in i_WinningPlayers)
                {
                    gameWinnersHeader.Append(winningPlayer.Name);
                }
            }
            string gameWinMessage = String.Format(
@"Game Over!

{0}

===========================
{1}"
, gameWinnersHeader, getPointsStatusMessage(i_Players));

            displayMessageToUser(gameWinMessage);
        }

        private static StringBuilder getPointsStatusMessage(List<Player> i_Players)
        {
            StringBuilder pointsStatusMessage = new StringBuilder(String.Format(
@"This is the points status :
===========================
"));

            foreach (Player player in i_Players)
            {
                pointsStatusMessage.AppendLine(String.Format("{0} - {1} points", player.Name, player.Score));
            }

            return pointsStatusMessage;
        }

        public static void DisplayRematchMessage()
        {
            string rematchMessage = String.Format(
@"If you would like a rematch, please type 'Y' :
=============================================="
);

            displayMessageToUser(rematchMessage);
        }

        public static void DisplayInvalidRematchInputMessage()
        {
            string invalidRematchMessage = String.Format(
@"Invalid rematch input! Please try again :
==========================================="
);

            displayMessageToUser(invalidRematchMessage);
        }

            public static void DisplayQuitMessage()
        {
            displayMessageToUser("Thanks for playing, quitting the game...");
        }

        private static void displayMessageToUser(string i_message)
        {
            Console.WriteLine(i_message);
        }
    }
}

