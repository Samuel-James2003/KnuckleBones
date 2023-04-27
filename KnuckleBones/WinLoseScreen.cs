using System;
using System.Windows.Forms;

namespace KnuckleBones
{
    public partial class WinLoseScreen : Form
    {
        bool isTied = false;
        string pName, WinText;
        int score;
        GameScreen gameScreen;

        public WinLoseScreen(int score, string pName, System.Drawing.Color color, GameScreen gameScreen)
        {
            this.gameScreen = gameScreen;
            InitializeComponent();
            this.score = score;
            this.pName = pName;
            BackColor = color;
        }

        public WinLoseScreen(int score, string names, string _, GameScreen gameScreen)
        {
            this.gameScreen = gameScreen;
            InitializeComponent();
            this.score = score;
            pName = names;
            isTied = true;
        }

        private void winnerBox_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void WinLoseScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            gameScreen.Close();
        }

        private void WinLoseScreen_Load(object sender, EventArgs e)
        {
            if (!isTied)
            {
                WinText = "The winner is " + pName +
                    "\n\n\nCongratulations on your victory in the video game! Your skill," +
                    " determination, and perseverance have paid off, " +
                    "and you have emerged as the champion. Well done!"
                    + "\n the score is... " + score;
                winnerBox.Text = WinText;

            }
            else if (isTied)
            {
                WinText = "Well played! A draw in a video game is a testament to both players' abilities and shows how evenly matched they are." +
                    " You both should be proud of your performance and the effort you put into the game. " +
                    "Great job!"
                    + "\nWith a score of " + score;
                winnerBox.Text = WinText;

            }
        }
    }
}
