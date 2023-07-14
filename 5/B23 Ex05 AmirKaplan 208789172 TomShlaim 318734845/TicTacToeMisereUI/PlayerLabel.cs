using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeMisereLogic;

namespace TicTacToeMisereUI
{
    internal class PlayerLabel: Label
    {
        public PlayerLabel() : base()
        {
            
        }
        internal void game_MoveCompleted(object sender, EventArgs e)
        {
                Font = Font.Style == System.Drawing.FontStyle.Bold ? 
                new System.Drawing.Font(Font, System.Drawing.FontStyle.Regular) :
                new System.Drawing.Font(Font, System.Drawing.FontStyle.Bold);
        }
    }
}
