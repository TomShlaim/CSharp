using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex04.Menus.Events
{
    public class ActionItem : MenuItem
    {
        public event Action Chosen;

        public ActionItem(string i_Header) : base(i_Header)
        {
        }
        public override void DoChosenAction()
        {
            Console.Clear();
            OnChosen();
            Thread.Sleep(2000);
        }
        private void OnChosen()
        {
            if (Chosen != null)
            {
                Chosen.Invoke();
            }
        }
    }
}
