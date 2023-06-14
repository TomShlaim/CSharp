using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class BranchItem : MenuItem
    {
        public BranchItem(string i_Header) : base(i_Header, false) {}

        public BranchItem(string i_Header, bool r_IsRoot) : base(i_Header, r_IsRoot)
        {
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
            string exitOrBackHeader = IsRoot ? "Exit" : "Back";

            return getMenuOption(exitOrBackHeader, 0);
        }
        private string getMenuOption(string i_Header, int i_MenuIndex)
        {
            return string.Format("{0}.   {1}", i_MenuIndex, i_Header);
        }
        private string getChooseActionMessage()
        {
            return string.Format("Please enter your choice (1-{0} or 0 to exit):",MenuItems.Count);
        }
    }
}
