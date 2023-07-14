using System;
using System.Collections.Generic;
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
            textBoxPlayer2.Text = textBoxPlayer2.Enabled ? "[Computer]" : string.Empty;
            textBoxPlayer2.Enabled = !textBoxPlayer2.Enabled;
        }

        private void numericUpDownRows_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownCols.Value = numericUpDownRows.Value;
        }

        private void numericUpDownCols_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownRows.Value = numericUpDownCols.Value;
        }   

        private void buttonStart_Click(object sender, EventArgs e)
        {
            int boardSize = (int)numericUpDownCols.Value;
            List<string> playerNames = new List<string> { textBoxPlayer1.Text };

            if (checkBoxPlayer2.Checked) 
            {
                playerNames.Add(textBoxPlayer2.Text);
            }

            DialogResult = DialogResult.OK;
            Hide();

            GameForm ticTacToeMisereGame = new GameForm(boardSize, playerNames);

            ticTacToeMisereGame.ShowDialog();
            Close();
        }
    }
}
