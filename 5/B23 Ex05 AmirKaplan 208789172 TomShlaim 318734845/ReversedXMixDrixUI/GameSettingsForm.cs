using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeMisereUI

{
    public partial class GameSettingsForm : Form
    {
        public GameSettingsForm()
        {
            InitializeComponent();
        }

        private void checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.textBoxPlayer2.Enabled) 
            {
                this.textBoxPlayer2.Enabled = false;
                this.textBoxPlayer2.Text = "[Computer]";
            }
            else
            {
                this.textBoxPlayer2.Enabled = true;
                this.textBoxPlayer2.Text = string.Empty;
            }
        }

        private void numericUpDownRows_ValueChanged(object sender, EventArgs e)
        {
            this.numericUpDownCols.Value = numericUpDownRows.Value;
        }

        private void numericUpDownCols_ValueChanged(object sender, EventArgs e)
        {
            this.numericUpDownRows.Value = numericUpDownCols.Value;
        }
    }
}
