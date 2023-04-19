using System;
using System.Windows.Forms;

namespace KnuckleBones
{
    public partial class StartScreen : Form
    {

        public StartScreen()
        {
            InitializeComponent();

        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            Hide();
            Form form = new GameScreen(Settings.dice, Settings.col, Settings.row, Settings.p1Name, Settings.p2Name);
            form.ShowDialog();
            Show();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                 "Players take turns rolling a single six-sided die " +
                "and placing it on their side of the board. Each player has their own 3x3 grid, " +
                "and their score is the total of all the dice currently placed there.\n\n" +
                "When one player has filled all nine slots on their board, " +
                "the game ends and the player with the highest score wins." +
                "\n\n" +
                "More information?"
                , "How to play"
                , MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("https://www.thegamer.com/cult-of-the-lamb-knucklebones-guide-dice-minigame-strategy-ratau-shrumy-klunko-bop-flinky/#:~:text=Players%20take%20turns%20rolling%20a,with%20the%20highest%20score%20wins."
                );
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            Form form = new Settings();
            form.ShowDialog();

        }
    }
}


