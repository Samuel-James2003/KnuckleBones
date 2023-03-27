using System;
using System.Windows.Forms;

namespace KnuckleBones
{
    public partial class WinLoseScreen : Form
    {
        string isTied = "No", pName, WinText;
        int score;
        public WinLoseScreen(int score, string pName)
        {
            InitializeComponent();
            this.score = score;
            this.pName = pName;

        }

        public WinLoseScreen(int score, string names, string _)
        {
            InitializeComponent();
            this.score = score;
            pName = names;
            this.isTied = "Yes";

        }

        private void WinLoseScreen_Load(object sender, EventArgs e)
        {
            if (isTied == "No")
            {
                WinText = "The winner is " + pName +
                    "\n\n\nCongratulations on your victory in the video game! Your skill," +
                    " determination, and perseverance have paid off, " +
                    "and you have emerged as the champion. Well done!"
                    + "\n the score is... " + score;
                winnerBox.Text = WinText;

            }

            else if (isTied == "Yes")
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
