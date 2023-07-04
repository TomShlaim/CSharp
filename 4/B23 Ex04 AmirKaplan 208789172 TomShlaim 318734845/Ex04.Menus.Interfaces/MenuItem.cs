using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public abstract class MenuItem
    {
        private string m_Header;
        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();

        public MenuItem(string i_Header)
        {
            m_Header = i_Header;
        }
        public string Header
        {
            get { return m_Header; }
            set { m_Header = value; }
        }
        public List<MenuItem> MenuItems
        {
            get { return r_MenuItems; }
        }
        public abstract void DoChosenAction();
    }
}
