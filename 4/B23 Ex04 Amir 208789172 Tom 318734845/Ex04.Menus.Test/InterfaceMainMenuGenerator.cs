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
        private enum eMenuAction
        {
            ShowDate,
            ShowTime,
            ShowVersion,
            CountCapitals
        }
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
            BranchItem showDateOrTime = getShowDateOrTimeLayer();
            BranchItem showVersionOrCountCapitalLetters = getShowVersionOrCountCapitalLettersLayer();

            r_MainMenu.AddSubItems(new List<MenuItem> { showDateOrTime, showVersionOrCountCapitalLetters });
        }
        private BranchItem getShowDateOrTimeLayer()
        {
            BranchItem showDateOrTime = new BranchItem("Show Date/Time");
            ActionItem showDateActionItem = new ActionItem("Show Date", eMenuAction.ShowDate);
            ActionItem showTimeActionItem = new ActionItem("Show Time", eMenuAction.ShowTime);

            showDateActionItem.AddListener(this);
            showTimeActionItem.AddListener(this);
            showDateOrTime.AddSubItems(new List<MenuItem> { showDateActionItem, showTimeActionItem });
  
            return showDateOrTime;
        }
        private BranchItem getShowVersionOrCountCapitalLettersLayer()
        {
            BranchItem showVersionOrCountCapitalLetters = new BranchItem("Show Version/Count Capitals");
            ActionItem showVersionActionItem = new ActionItem("Show Version", eMenuAction.ShowVersion);
            ActionItem showCapitalLettersInSentenceActionItem = new ActionItem("Count Capitals", eMenuAction.CountCapitals);

            showVersionActionItem.AddListener(this);
            showCapitalLettersInSentenceActionItem.AddListener(this);
            showVersionOrCountCapitalLetters.AddSubItems(new List<MenuItem> { showVersionActionItem, showCapitalLettersInSentenceActionItem });

            return showVersionOrCountCapitalLetters;
        }
        public void ReportActionItemWasChosen(Enum i_Action)
        {
            if (i_Action is eMenuAction i_MenuAction)
            {
                doTheChosenAction(i_MenuAction);
            }
        }
        private void doTheChosenAction(eMenuAction i_Action)
        {
            switch (i_Action)
            {
                case eMenuAction.ShowDate:
                    MenuActions.ShowDate();
                    break;
                case eMenuAction.ShowTime:
                    MenuActions.ShowTime();
                    break;
                case eMenuAction.ShowVersion:
                    MenuActions.ShowVersion();
                    break;
                case eMenuAction.CountCapitals:
                    MenuActions.CountCapitals();
                    break;
            }
        }
    }
}
