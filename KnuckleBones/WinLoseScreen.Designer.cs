
namespace KnuckleBones
{
    partial class WinLoseScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.winnerBox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // winnerBox
            // 
            this.winnerBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winnerBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winnerBox.ForeColor = System.Drawing.Color.Black;
            this.winnerBox.Location = new System.Drawing.Point(0, 0);
            this.winnerBox.Name = "winnerBox";
            this.winnerBox.Size = new System.Drawing.Size(1472, 765);
            this.winnerBox.TabIndex = 0;
            this.winnerBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.winnerBox.Click += new System.EventHandler(this.winnerBox_Click);
            // 
            // WinLoseScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1472, 765);
            this.Controls.Add(this.winnerBox);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Name = "WinLoseScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinLoseScreen";
            this.Load += new System.EventHandler(this.WinLoseScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label winnerBox;
    }
}