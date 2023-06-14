using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class InterfaceMainMenuGenerator : IActionItemChosenListener
    {
        private readonly MainMenu r_MainMenu;
        public InterfaceMainMenuGenerator() {
            r_MainMenu = new MainMenu("Interface Main Menu");
            createMenu();
        }
        public MainMenu MainMenu
        {
            get { return r_MainMenu; }
        }
        private void createMenu()
        {
            //I need to split this function
            BranchItem showDateOrTime = new BranchItem("Show Date/Time");
            ActionItem showDateActionItem = new ActionItem("Show Date", MenuActions.eMenuAction.ShowDate);
            ActionItem showTimeActionItem = new ActionItem("Show Time", MenuActions.eMenuAction.ShowTime);

            showDateOrTime.AddSubItems(new List<MenuItem> { showDateActionItem, showTimeActionItem });

            BranchItem showVersionOrCountCapitalLetters = new BranchItem("Show Version/Count Capitals");
            ActionItem showVersionActionItem = new ActionItem("Show Version", MenuActions.eMenuAction.ShowVersion);
            ActionItem showCapitalLettersInSentenceActionItem = new ActionItem("Count Capitals", MenuActions.eMenuAction.CountCapitals);

            showVersionOrCountCapitalLetters.AddSubItems(new List<MenuItem> { showVersionActionItem, showCapitalLettersInSentenceActionItem });

            r_MainMenu.AddSubItems(new List<MenuItem> { showDateOrTime, showVersionOrCountCapitalLetters });

        }
        public void ReportActionItemWasChosen(Enum i_Action)
        {
            if (i_Action is MenuActions.eMenuAction i_MenuAction)
            {
                doTheChosenAction(i_MenuAction);
            }
        }
        private void doTheChosenAction(MenuActions.eMenuAction i_Action)
        {
            switch (i_Action)
            {
                case MenuActions.eMenuAction.ShowDate:
                    MenuActions.ShowDate();
                    break;
                case MenuActions.eMenuAction.ShowTime:
                    MenuActions.ShowTime();
                    break;
                case MenuActions.eMenuAction.ShowVersion:
                    MenuActions.ShowVersion();
                    break;
                case MenuActions.eMenuAction.CountCapitals:
                    MenuActions.CountCapitals();
                    break;
            }
        }
    }
}
