
namespace KnuckleBones
{
    partial class GameScreen
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
            this.tbposY = new System.Windows.Forms.Label();
            this.tbposX = new System.Windows.Forms.Label();
            this.p1score = new System.Windows.Forms.TextBox();
            this.p2score = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbposY
            // 
            this.tbposY.AutoSize = true;
            this.tbposY.Location = new System.Drawing.Point(1094, 72);
            this.tbposY.Name = "tbposY";
            this.tbposY.Size = new System.Drawing.Size(51, 20);
            this.tbposY.TabIndex = 3;
            this.tbposY.Text = "Pos Y";
            // 
            // tbposX
            // 
            this.tbposX.AutoSize = true;
            this.tbposX.Location = new System.Drawing.Point(1009, 72);
            this.tbposX.Name = "tbposX";
            this.tbposX.Size = new System.Drawing.Size(51, 20);
            this.tbposX.TabIndex = 4;
            this.tbposX.Text = "Pos X";
            // 
            // p1score
            // 
            this.p1score.Location = new System.Drawing.Point(994, 268);
            this.p1score.Name = "p1score";
            this.p1score.Size = new System.Drawing.Size(151, 26);
            this.p1score.TabIndex = 5;
            // 
            // p2score
            // 
            this.p2score.Location = new System.Drawing.Point(994, 321);
            this.p2score.Name = "p2score";
            this.p2score.Size = new System.Drawing.Size(151, 26);
            this.p2score.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1052, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 45);
            this.button1.TabIndex = 7;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1175, 752);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.p2score);
            this.Controls.Add(this.p1score);
            this.Controls.Add(this.tbposX);
            this.Controls.Add(this.tbposY);
            this.Name = "GameScreen";
            this.Text = "GameScreen";
            this.Load += new System.EventHandler(this.GameScreen_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GameScreen_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label tbposY;
        private System.Windows.Forms.Label tbposX;
        private System.Windows.Forms.TextBox p1score;
        private System.Windows.Forms.TextBox p2score;
        private System.Windows.Forms.Button button1;
    }
}