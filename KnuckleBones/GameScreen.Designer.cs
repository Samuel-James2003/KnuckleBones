
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.TurnTimer = new System.Windows.Forms.Timer(this.components);
            this.p1score = new System.Windows.Forms.Label();
            this.p2score = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(928, 102);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 45);
            this.button1.TabIndex = 7;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TurnTimer
            // 
            this.TurnTimer.Tick += new System.EventHandler(this.GameTurn);
            // 
            // p1score
            // 
            this.p1score.AutoSize = true;
            this.p1score.Location = new System.Drawing.Point(924, 38);
            this.p1score.Name = "p1score";
            this.p1score.Size = new System.Drawing.Size(110, 20);
            this.p1score.TabIndex = 8;
            this.p1score.Text = "Score player 1";
            // 
            // p2score
            // 
            this.p2score.AutoSize = true;
            this.p2score.Location = new System.Drawing.Point(924, 79);
            this.p2score.Name = "p2score";
            this.p2score.Size = new System.Drawing.Size(110, 20);
            this.p2score.TabIndex = 9;
            this.p2score.Text = "Score player 2";
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1175, 752);
            this.Controls.Add(this.p2score);
            this.Controls.Add(this.p1score);
            this.Controls.Add(this.button1);
            this.Name = "GameScreen";
            this.Text = "GameScreen";
            this.Load += new System.EventHandler(this.GameScreen_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer TurnTimer;
        private System.Windows.Forms.Label p1score;
        private System.Windows.Forms.Label p2score;
    }
}