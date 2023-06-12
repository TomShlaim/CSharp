using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    internal class MenuItem
    {
        private readonly int r_Id;
        private readonly List<MenuItem> m_MenuItems = new List<MenuItem>();
        private readonly List<ILeafMenuItemClickListener> m_LeafMenuItemClickListeners = new List<ILeafMenuItemClickListener>();

        public MenuItem(int i_Id)
        {
            r_Id = i_Id;
        }
        public MenuItem(int i_Id, List<MenuItem> i_MenuItems)
        {
            m_MenuItems.AddRange(i_MenuItems);
        }
       private bool IsLeafMenuItem()
        {
            return m_MenuItems.Count == 0;
        }
        public void Show()
        {

        }
        public void AddListener(ILeafMenuItemClickListener i_LeafMenuItemClickListener)
        {
            m_LeafMenuItemClickListeners.Add(i_LeafMenuItemClickListener);
        }
        public void RemoveListener(ILeafMenuItemClickListener i_LeafMenuItemClickListener)
        {
            m_LeafMenuItemClickListeners.Remove(i_LeafMenuItemClickListener);
        }
        public void doWhenWasClicked()
        {
            if (this.IsLeafMenuItem())
            {
                notifyLeafMenuItemClickListeners();    
            }
            else
            {
                Show();
            }
        }
        private void notifyLeafMenuItemClickListeners()
        {
            foreach(ILeafMenuItemClickListener leafMenuItemClickListener in m_LeafMenuItemClickListeners)
            {
                leafMenuItemClickListener.ReportLeafMenuItemWasClick(r_Id);
            }
        }
    }
}
