using System;
using System.Windows.Forms;

namespace KnuckleBones
{
    public partial class Settings : Form
    {
        bool IsRuinningGame = false;
        static public int col { get; set; } = 3;
        static public int row { get; set; } = 3;
        static public int dice { get; set; } = 1;
        static public string p1Name { get; set; } = "Player1";
        static public string p2Name { get; set; } = "Player2";
        static public string hostName { get; set; } = "Samuel";
        static public bool isServer { get; set; }
        static public bool isMultplayer { get; set; }

        private void btnDef_Click(object sender, EventArgs e)
        {
            Defaults();
            Close();
        }


        public Settings()
        {
            InitializeComponent();
            Defaults();
            tbPName1.Text = p1Name;
            tbPName2.Text = p2Name;
            tbHostName.Text = hostName;
            lRow.Text = $"Row = {tbRow.Value}";
            lDice.Text = $"Dice = {tbDice.Value}";
            lCol.Text = $"Column = {tbCol.Value}";

        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            p1Name = tbPName1.Text;
            p2Name = tbPName2.Text;
            isServer = cbServer.Checked;
            isMultplayer = cbMultiplayer.Checked;
            col = tbCol.Value;
            row = tbRow.Value;
            dice = tbDice.Value;

            if (col != 3 || row != 3 || dice != 1)
            {
                IsRuinningGame = true;
            }
            Close();
        }
        private void Defaults()
        {
            col = 3; row = 3; dice = 1;
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsRuinningGame)
            {
                DialogResult result = MessageBox.Show("Are you sure you want " + "to change the settings?" + "\n\n" + "As changing these settings may make the game less pleaseant ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.No) Defaults();
            }

        }

        private void tbDice_ValueChanged(object sender, EventArgs e)
        {
            lDice.Text = $"Dice = {tbDice.Value}";
        }

        private void tbCol_ValueChanged(object sender, EventArgs e)
        {
            lCol.Text = $"Column = {tbCol.Value}";
        }

        private void tbRow_ValueChanged(object sender, EventArgs e)
        {
            lRow.Text = $"Row = {tbRow.Value}";
        }

        private void cbServer_CheckedChanged(object sender, EventArgs e)
        {
            if (cbServer.Checked)
                cbMultiplayer.Checked = true;
        }
    }
}
