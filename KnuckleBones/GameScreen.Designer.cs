﻿
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
            this.btnStart = new System.Windows.Forms.Button();
            this.TurnTimer = new System.Windows.Forms.Timer(this.components);
            this.p1score = new System.Windows.Forms.Label();
            this.p2score = new System.Windows.Forms.Label();
            this.bSkip = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(928, 102);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(106, 45);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_click);
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
            // bSkip
            // 
            this.bSkip.Location = new System.Drawing.Point(928, 153);
            this.bSkip.Name = "bSkip";
            this.bSkip.Size = new System.Drawing.Size(106, 46);
            this.bSkip.TabIndex = 10;
            this.bSkip.Text = "Skip";
            this.bSkip.UseVisualStyleBackColor = true;
            this.bSkip.Click += new System.EventHandler(this.bSkip_Click);
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1175, 752);
            this.Controls.Add(this.bSkip);
            this.Controls.Add(this.p2score);
            this.Controls.Add(this.p1score);
            this.Controls.Add(this.btnStart);
            this.Name = "GameScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameScreen_FormClosing);
            this.Load += new System.EventHandler(this.GameScreen_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer TurnTimer;
        private System.Windows.Forms.Label p1score;
        private System.Windows.Forms.Label p2score;
        private System.Windows.Forms.Button bSkip;
    }
}