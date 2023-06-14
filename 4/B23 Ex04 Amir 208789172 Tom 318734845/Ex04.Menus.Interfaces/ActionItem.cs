using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class ActionItem : MenuItem
    {
        private readonly List<IActionItemChosenListener> m_ActionItemChosenListeners = new List<IActionItemChosenListener>();
        private Enum m_Action;

        public ActionItem(string i_Header, Enum i_Action) : base(i_Header) 
        {
            m_Action = i_Action;
        }

        public void AddListener(IActionItemChosenListener i_LeafMenuItemClickListener)
        {
            m_ActionItemChosenListeners.Add(i_LeafMenuItemClickListener);
        }
        public void RemoveListener(IActionItemChosenListener i_LeafMenuItemClickListener)
        {
            m_ActionItemChosenListeners.Remove(i_LeafMenuItemClickListener);
        }

        public override void DoChosenAction()
        {
            Console.Clear();
            doWhenWasChosen();
            Thread.Sleep(2000);
        }
        private void doWhenWasChosen()
        {
            notifyLeafMenuItemClickListeners();
        }
        private void notifyLeafMenuItemClickListeners()
        {
            foreach (IActionItemChosenListener actionItemChosenListener in m_ActionItemChosenListeners)
            {
                actionItemChosenListener.ReportActionItemWasChosen(m_Action);
            }
        }
    }
}
