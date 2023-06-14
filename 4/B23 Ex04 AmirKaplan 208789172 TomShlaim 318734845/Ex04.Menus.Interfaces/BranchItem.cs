using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class BranchItem : MenuItem
    {
        public BranchItem(string i_Header) : base(i_Header) {}

        public override void DoChosenAction()
        {
            int chosenOptionIndex = chooseOption();

            while (chosenOptionIndex != 0)
            {
                this.MenuItems[chosenOptionIndex - 1].DoChosenAction();
                chosenOptionIndex = chooseOption();
            }

            return;
        }
        private int chooseOption()
        {
            Console.Clear();
            this.Show();
            int chosenOptionIndex = getChosenOptionIndex();

            return chosenOptionIndex;
        }
        public void AddSubItems(List<MenuItem> i_MenuItems)
        {
            MenuItems.AddRange(i_MenuItems);
        }
        private int getChosenOptionIndex()
        {
            string chosenOption = Console.ReadLine();

            while (!MenuValidator.IsValidOption(chosenOption, MenuItems.Count))
            {
                chosenOption = Console.ReadLine();
            }
  
            return int.Parse(chosenOption);
        }

        public void Show()
        {
            string menuDisplay = string.Format(
@"{0}
{1}
{2}", getHeader(), getMenuOptions(), getChooseActionMessage());

            Console.WriteLine(menuDisplay);
        }
        private string getHeader()
        {
            string separator = new string('=', Header.Length);
            string header = string.Format(
@"{0}
{1}",Header, separator);

            return header;
        }
        private string getMenuOptions()
        {
            StringBuilder menuOptions = new StringBuilder();
            int menuItemIndex = 1;

            foreach (MenuItem item in MenuItems) 
            {
                menuOptions.AppendLine(getMenuOption(item.Header, menuItemIndex));
                menuItemIndex++;
            }

            menuOptions.AppendLine(getExitOrBackOption());

            return menuOptions.ToString();
        }
        private string getExitOrBackOption()
        {
            string exitOrBackHeader = this is MainMenu ? "Exit" : "Back";

            return getMenuOption(exitOrBackHeader, 0);
        }
        private string getMenuOption(string i_Header, int i_MenuIndex)
        {
            return string.Format("{0}.   {1}", i_MenuIndex, i_Header);
        }
        private string getChooseActionMessage()
        {
            string exitOrBack = this is MainMenu ? "exit" : "go back";

            return string.Format("Please enter your choice (1-{0} or 0 to {1}):",MenuItems.Count, exitOrBack);
        }
    }
}
