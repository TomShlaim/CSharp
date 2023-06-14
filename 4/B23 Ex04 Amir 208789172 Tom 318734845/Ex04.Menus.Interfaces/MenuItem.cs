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
        private readonly bool r_IsRoot;
        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();

        public MenuItem(string i_Header, bool r_IsRoot)
        {
            m_Header = i_Header;
            this.r_IsRoot = r_IsRoot;
        }
        public string Header
        {
            get { return m_Header; }
            set { m_Header = value; }
        }
        public bool IsRoot
        {
            get { return r_IsRoot; }
        }

        public List<MenuItem> MenuItems
        {
            get { return r_MenuItems; }
        }

        // Maybe move this method to 'BranchItem' ? Because this method is irrelevant to 'ActionItem'
        public void AddSubItems(List<MenuItem> i_MenuItems)
        {
            r_MenuItems.AddRange(i_MenuItems);
        }

        public abstract void DoAction();
    }
}
