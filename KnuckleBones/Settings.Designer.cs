
namespace KnuckleBones
{
    partial class Settings
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
            this.btnDone = new System.Windows.Forms.Button();
            this.btnDef = new System.Windows.Forms.Button();
            this.Buttons = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lMultiplayerSection = new System.Windows.Forms.Label();
            this.tbHostName = new System.Windows.Forms.TextBox();
            this.lNames = new System.Windows.Forms.Label();
            this.tbPName2 = new System.Windows.Forms.TextBox();
            this.tbPName1 = new System.Windows.Forms.TextBox();
            this.lRow = new System.Windows.Forms.Label();
            this.lCol = new System.Windows.Forms.Label();
            this.lDice = new System.Windows.Forms.Label();
            this.tbRow = new System.Windows.Forms.TrackBar();
            this.tbCol = new System.Windows.Forms.TrackBar();
            this.tbDice = new System.Windows.Forms.TrackBar();
            this.cbServer = new System.Windows.Forms.CheckBox();
            this.cbMultiplayer = new System.Windows.Forms.CheckBox();
            this.lHostName = new System.Windows.Forms.Label();
            this.Buttons.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDice)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDone
            // 
            this.btnDone.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDone.Location = new System.Drawing.Point(3, 22);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(220, 55);
            this.btnDone.TabIndex = 6;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnDef
            // 
            this.btnDef.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDef.Location = new System.Drawing.Point(494, 22);
            this.btnDef.Name = "btnDef";
            this.btnDef.Size = new System.Drawing.Size(220, 55);
            this.btnDef.TabIndex = 7;
            this.btnDef.Text = "Defaults";
            this.btnDef.UseVisualStyleBackColor = true;
            this.btnDef.Click += new System.EventHandler(this.btnDef_Click);
            // 
            // Buttons
            // 
            this.Buttons.Controls.Add(this.btnDone);
            this.Buttons.Controls.Add(this.btnDef);
            this.Buttons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Buttons.Location = new System.Drawing.Point(0, 686);
            this.Buttons.Name = "Buttons";
            this.Buttons.Size = new System.Drawing.Size(717, 80);
            this.Buttons.TabIndex = 9;
            this.Buttons.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(711, 47);
            this.label1.TabIndex = 22;
            this.label1.Text = "Settings";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(717, 72);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lHostName);
            this.groupBox2.Controls.Add(this.cbMultiplayer);
            this.groupBox2.Controls.Add(this.cbServer);
            this.groupBox2.Controls.Add(this.lMultiplayerSection);
            this.groupBox2.Controls.Add(this.tbHostName);
            this.groupBox2.Controls.Add(this.lNames);
            this.groupBox2.Controls.Add(this.tbPName2);
            this.groupBox2.Controls.Add(this.tbPName1);
            this.groupBox2.Controls.Add(this.lRow);
            this.groupBox2.Controls.Add(this.lCol);
            this.groupBox2.Controls.Add(this.lDice);
            this.groupBox2.Controls.Add(this.tbRow);
            this.groupBox2.Controls.Add(this.tbCol);
            this.groupBox2.Controls.Add(this.tbDice);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(717, 614);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            // 
            // lMultiplayerSection
            // 
            this.lMultiplayerSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMultiplayerSection.Location = new System.Drawing.Point(497, 464);
            this.lMultiplayerSection.Name = "lMultiplayerSection";
            this.lMultiplayerSection.Size = new System.Drawing.Size(217, 29);
            this.lMultiplayerSection.TabIndex = 32;
            this.lMultiplayerSection.Text = "Multiplayer";
            this.lMultiplayerSection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbHostName
            // 
            this.tbHostName.Location = new System.Drawing.Point(491, 552);
            this.tbHostName.Name = "tbHostName";
            this.tbHostName.Size = new System.Drawing.Size(220, 26);
            this.tbHostName.TabIndex = 31;
            // 
            // lNames
            // 
            this.lNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNames.Location = new System.Drawing.Point(3, 477);
            this.lNames.Name = "lNames";
            this.lNames.Size = new System.Drawing.Size(220, 29);
            this.lNames.TabIndex = 30;
            this.lNames.Text = "Player Names";
            this.lNames.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbPName2
            // 
            this.tbPName2.Location = new System.Drawing.Point(0, 558);
            this.tbPName2.Name = "tbPName2";
            this.tbPName2.Size = new System.Drawing.Size(220, 26);
            this.tbPName2.TabIndex = 29;
            // 
            // tbPName1
            // 
            this.tbPName1.Location = new System.Drawing.Point(3, 526);
            this.tbPName1.Name = "tbPName1";
            this.tbPName1.Size = new System.Drawing.Size(220, 26);
            this.tbPName1.TabIndex = 28;
            // 
            // lRow
            // 
            this.lRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRow.Location = new System.Drawing.Point(3, 360);
            this.lRow.Name = "lRow";
            this.lRow.Size = new System.Drawing.Size(711, 29);
            this.lRow.TabIndex = 27;
            this.lRow.Text = "Rows";
            this.lRow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lCol
            // 
            this.lCol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCol.Location = new System.Drawing.Point(3, 187);
            this.lCol.Name = "lCol";
            this.lCol.Size = new System.Drawing.Size(714, 40);
            this.lCol.TabIndex = 26;
            this.lCol.Text = "Columns";
            this.lCol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lDice
            // 
            this.lDice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDice.Location = new System.Drawing.Point(3, 46);
            this.lDice.Name = "lDice";
            this.lDice.Size = new System.Drawing.Size(714, 34);
            this.lDice.TabIndex = 25;
            this.lDice.Text = "Dice";
            this.lDice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbRow
            // 
            this.tbRow.Location = new System.Drawing.Point(3, 392);
            this.tbRow.Maximum = 5;
            this.tbRow.Minimum = 2;
            this.tbRow.Name = "tbRow";
            this.tbRow.Size = new System.Drawing.Size(714, 69);
            this.tbRow.TabIndex = 24;
            this.tbRow.Value = 3;
            this.tbRow.ValueChanged += new System.EventHandler(this.tbRow_ValueChanged);
            // 
            // tbCol
            // 
            this.tbCol.Location = new System.Drawing.Point(3, 230);
            this.tbCol.Maximum = 5;
            this.tbCol.Minimum = 2;
            this.tbCol.Name = "tbCol";
            this.tbCol.Size = new System.Drawing.Size(714, 69);
            this.tbCol.TabIndex = 23;
            this.tbCol.Value = 3;
            this.tbCol.ValueChanged += new System.EventHandler(this.tbCol_ValueChanged);
            // 
            // tbDice
            // 
            this.tbDice.Location = new System.Drawing.Point(3, 83);
            this.tbDice.Maximum = 3;
            this.tbDice.Minimum = 1;
            this.tbDice.Name = "tbDice";
            this.tbDice.Size = new System.Drawing.Size(714, 69);
            this.tbDice.TabIndex = 22;
            this.tbDice.Value = 1;
            this.tbDice.ValueChanged += new System.EventHandler(this.tbDice_ValueChanged);
            // 
            // cbServer
            // 
            this.cbServer.AutoSize = true;
            this.cbServer.Location = new System.Drawing.Point(494, 584);
            this.cbServer.Name = "cbServer";
            this.cbServer.Size = new System.Drawing.Size(129, 24);
            this.cbServer.TabIndex = 33;
            this.cbServer.Text = "Server toggle";
            this.cbServer.UseVisualStyleBackColor = true;
            this.cbServer.CheckedChanged += new System.EventHandler(this.cbServer_CheckedChanged);
            // 
            // cbMultiplayer
            // 
            this.cbMultiplayer.AutoSize = true;
            this.cbMultiplayer.Location = new System.Drawing.Point(494, 496);
            this.cbMultiplayer.Name = "cbMultiplayer";
            this.cbMultiplayer.Size = new System.Drawing.Size(110, 24);
            this.cbMultiplayer.TabIndex = 34;
            this.cbMultiplayer.Text = "Multiplayer";
            this.cbMultiplayer.UseVisualStyleBackColor = true;
            this.cbMultiplayer.CheckedChanged += new System.EventHandler(this.cbMultiplayer_CheckedChanged);
            // 
            // lHostName
            // 
            this.lHostName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lHostName.Location = new System.Drawing.Point(494, 520);
            this.lHostName.Name = "lHostName";
            this.lHostName.Size = new System.Drawing.Size(217, 29);
            this.lHostName.TabIndex = 35;
            this.lHostName.Text = "Host Name";
            this.lHostName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 766);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Buttons);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.Buttons.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnDef;
        private System.Windows.Forms.GroupBox Buttons;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lRow;
        private System.Windows.Forms.Label lCol;
        private System.Windows.Forms.Label lDice;
        private System.Windows.Forms.TrackBar tbRow;
        private System.Windows.Forms.TrackBar tbCol;
        private System.Windows.Forms.TrackBar tbDice;
        private System.Windows.Forms.Label lNames;
        private System.Windows.Forms.TextBox tbPName2;
        private System.Windows.Forms.TextBox tbPName1;
        private System.Windows.Forms.Label lMultiplayerSection;
        private System.Windows.Forms.TextBox tbHostName;
        private System.Windows.Forms.CheckBox cbServer;
        private System.Windows.Forms.Label lHostName;
        private System.Windows.Forms.CheckBox cbMultiplayer;
    }
}