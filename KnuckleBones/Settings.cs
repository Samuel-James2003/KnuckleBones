using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnuckleBones
{
    public partial class Settings : Form
    {
        bool changed = false;
        static public int col { get; set; } = 3;
        static public int row { get; set; } = 3;
        static public int dice { get; set; } = 1;

        private void btnDef_Click(object sender, EventArgs e)
        {
            Defaults();
            Close();
        }
 

        public Settings()
        {
            InitializeComponent();
            Defaults();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            col = tbCol.Value;
            row = tbRow.Value;
            dice = tbDice.Value;
            if (col!=3 || row !=3 || dice !=1)
            {
                changed = true;
            }
            Close();
        }
        private void Defaults()
        {
            col = 3;
            row = 3;
            dice = 1;
            
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (changed)
            {
                DialogResult result = MessageBox.Show("Are you sure you want " + "to change the settings?" + "\n\n" + "As changing these settings may make the game less pleaseant ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (result == DialogResult.No)
                {
                    Defaults();
                }
            }
            
        }
    }
}
