using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Events;

namespace Ex04.Menus.Test
{
    internal class EventsMainMenuGenerator
    {
        private readonly MainMenu r_MainMenu;
        public EventsMainMenuGenerator()
        {
            r_MainMenu = new MainMenu("Events Main Menu");
            createMenu();
        }
        public MainMenu MainMenu
        {
            get { return r_MainMenu; }
        }
        private void createMenu()
        {
            BranchItem showDateOrTime = getShowDateOrTimeLayer();
            BranchItem showVersionOrCountCapitalLetters = getShowVersionOrCountCapitalLettersLayer();

            r_MainMenu.AddSubItems(new List<MenuItem> { showDateOrTime, showVersionOrCountCapitalLetters });
        }
        private BranchItem getShowDateOrTimeLayer()
        {
            BranchItem showDateOrTime = new BranchItem("Show Date/Time");
            ActionItem showDateActionItem = new ActionItem("Show Date");
            ActionItem showTimeActionItem = new ActionItem("Show Time");

            showDateActionItem.Chosen += showDate_OnChosen;
            showTimeActionItem.Chosen += showTime_OnChosen;
            showDateOrTime.AddSubItems(new List<MenuItem> { showDateActionItem, showTimeActionItem });

            return showDateOrTime;
        }
        private BranchItem getShowVersionOrCountCapitalLettersLayer()
        {
            BranchItem showVersionOrCountCapitalLetters = new BranchItem("Show Version/Count Capitals");
            ActionItem showVersionActionItem = new ActionItem("Show Version");
            ActionItem showCapitalLettersInSentenceActionItem = new ActionItem("Count Capitals");

            showVersionActionItem.Chosen += showVersion_OnChosen;
            showCapitalLettersInSentenceActionItem.Chosen += countCapitals_OnChosen;
            showVersionOrCountCapitalLetters.AddSubItems(new List<MenuItem> { showVersionActionItem, showCapitalLettersInSentenceActionItem });

            return showVersionOrCountCapitalLetters;
        }
        private void showDate_OnChosen()
        {
            MenuActions.ShowDate();
        }
        private void showTime_OnChosen()
        {
            MenuActions.ShowTime();
        }
        private void showVersion_OnChosen()
        {
            MenuActions.ShowVersion();
        }
        private void countCapitals_OnChosen()
        {
            MenuActions.CountCapitals();
        }
    }
}
