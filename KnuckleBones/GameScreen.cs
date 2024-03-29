﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace KnuckleBones
{
    public partial class GameScreen : Form
    {
        #region Variables
        int col, row, dice, pos = 1, defWidth = 100, defHeight = 30, offset, waythrough = 0;
        int[] dicelist;
        Player player1, player2, currentplayer;
        Color cFond;
        Pen pen;
        bool top = true, isAllowed = false, tick1 = true, gameEnded = false, saveable = false;
        Graphics g;
        List<Player> players = new List<Player>();
        Random random = new Random();

        #endregion

        public GameScreen(int numDice, int numCol, int numRow, string p1Name, string p2Name)
        {

            dice = numDice;
            col = numCol;
            row = numRow;
            dicelist = new int[dice];
            offset = defHeight * (row + 3);
            pen = new Pen(Color.Black, 1);
            InitializeComponent();
            player1 = new Player(col, row, p1Name);
            player2 = new Player(col, row, offset, p2Name);
            players.Add(player1);
            players.Add(player2);
            currentplayer = player1;


        }

        public GameScreen(string Filename)
        {

            string currentplayername = "";
            using (var sr = new StreamReader(Filename))
            {
                currentplayername = sr.ReadLine();
                dice = int.Parse(sr.ReadLine());
                col = int.Parse(sr.ReadLine());
                row = int.Parse(sr.ReadLine());
                top = bool.Parse(sr.ReadLine());
                string input = sr.ReadLine();
                dicelist = new int[dice];
                for (int i = 0; i < dice; i++)
                {
                    dicelist[i] = input[i] - '0';
                }
                waythrough = int.Parse(sr.ReadLine());
                players = new List<Player>();
                for (int i = 0; i < 2; i++)
                {
                    var name = sr.ReadLine();
                    var offset = int.Parse(sr.ReadLine());
                    var power = bool.Parse(sr.ReadLine());
                    var matrix = new int[row, col];
                    char[] tmplist = sr.ReadLine().ToCharArray();
                    int f = 0;
                    for (int r = 0; r < row; r++)
                        for (int c = 0; c < col; c++)
                        {
                            matrix[r, c] = int.Parse(tmplist[f].ToString());
                            f++;
                        }

                    players.Add(new Player(col, row, offset, name, matrix)
                    {
                        UsedPower = power
                    });
                }
            }

            offset = defHeight * (row + 3);
            pen = new Pen(Color.Black, 1);
            InitializeComponent();

            player1 = players[0];
            player2 = players[1];
            if (currentplayername == player1.Name)
            {
                currentplayer = player1;

                for (int i = 0; i < dice; i++)
                {

                    DrawDicesInRectangle(false, dicelist[i], i);
                    isAllowed = true;
                }
            }
            else
            {
                currentplayer = player2;
                for (int i = 0; i < dice; i++)
                {
                    DrawDicesInRectangle(true, dicelist[i], i);
                    isAllowed = true;
                }
            }
            bSkip.Visible = btnStart.Visible = false;
            ReFill();
            Turns(currentplayer, dicelist);


        }

        #region Methods

        #region Bases
        void ClearScreen()
        {
            if (!gameEnded)
            {
                for (int i = 0; i < row; i++)
                    for (int j = 0; j < col; j++)
                        for (int c = 0; c < 9; c++)
                        {
                            DrawStringInRectangle(j * defWidth, i * defHeight, false, c, cFond);
                            DrawStringInRectangle(j * defWidth, i * defHeight + offset, false, c, cFond);
                        }
            }

        }
        void GameBackGround()
        {
            if (!gameEnded)
            {
                g = CreateGraphics();
                Draw(0, 0, defWidth, defHeight, row, col);
                Draw(col * defWidth, row * defHeight / 2, defHeight, defHeight, dice, 1);

                Draw(0, offset, defWidth, defHeight, row, col);
                Draw(col * defWidth, offset + row * defHeight / 2, defHeight, defHeight, dice, 1);
                g.Dispose();
            }

        }
        void ReFill()
        {
            if (!gameEnded)
            {
                ClearScreen();
                GameBackGround();
                foreach (Player player in players)
                {
                    for (int c = 0; c < col; c++)
                        for (int r = 0; r < row; r++)
                        {
                            int value = player.GameMatrix[r, c], x = c * defWidth, y = r * defHeight;
                            if (value > 0)
                            {
                                DrawStringInRectangle(x, y + player.Offset, false, value);
                            }
                        }

                }
            }


        }
        void ShowScores()
        {
            string P1 = player1.Name + " = " + player1.Score.ToString(), P2 = player2.Name + " = " + player2.Score.ToString();
            p1score.Text = P1;
            p2score.Text = P2;
        }
        int RandomDice()
        {
            return random.Next(1, 7);
        }
        void Swap()
        {
            ReFill();
            waythrough = 0;
            dicelist.Initialize();
            pos = 1;
            top = !top;

        }
        bool IsGameOver()
        {
            if (gameEnded)
            {
                return true;
            }

            foreach (var player in players)
                if (player.isFull())
                {
                    GameOver();
                    return true;
                }
            return false;
        }
        private bool AddValueToGameMatrix()
        {
            if (top)
            {
                if (!player1.isFull(pos))
                {
                    HighlightColumn(pos, 0, 0, defWidth, defHeight, row, cFond);
                    player1.AddValue(pos, dicelist[waythrough]);
                    player2.CheckRemove(pos, dicelist[waythrough]);
                    EmptyDicelist(false);
                    IsGameOver();
                }
                else
                    waythrough--;
            }
            else
            {
                if (!player2.isFull(pos))
                {
                    HighlightColumn(pos, 0, offset, defWidth, defHeight, row, cFond);
                    player2.AddValue(pos, dicelist[waythrough]);
                    player1.CheckRemove(pos, dicelist[waythrough]);
                    EmptyDicelist(true);
                    IsGameOver();
                }
                else
                    waythrough--;
            }
            if (waythrough >= dice - 1)
            {
                IsGameOver();
                isAllowed = false;
                return false;
            }
            return true;
        }
        private void HighlightRight()
        {
            if (pos < col - 1)
            {
                if (top)
                {
                    HighlightColumn(pos, 0, 0, defWidth, defHeight, row, cFond);
                    pos++;
                    HighlightColumn(pos, 0, 0, defWidth, defHeight, row, Color.PapayaWhip);
                }

                else
                {
                    HighlightColumn(pos, 0, offset, defWidth, defHeight, row, cFond);
                    pos++;
                    HighlightColumn(pos, 0, offset, defWidth, defHeight, row, Color.PapayaWhip);
                }

            }
        }
        private void HighlightLeft()
        {
            if (pos > 0)
            {
                if (top)
                {
                    HighlightColumn(pos, 0, 0, defWidth, defHeight, row, cFond);
                    pos--;
                    HighlightColumn(pos, 0, 0, defWidth, defHeight, row, Color.PapayaWhip);
                }

                else
                {
                    HighlightColumn(pos, 0, offset, defWidth, defHeight, row, cFond);
                    pos--;
                    HighlightColumn(pos, 0, offset, defWidth, defHeight, row, Color.PapayaWhip);
                }
            }
        }
        void EmptyDicelist(bool isOffset)
        {
            EraseDicesInRectangle(isOffset, waythrough);
            dicelist[waythrough] = 0;
        }
        void WinnerIs(Player player, Color color)
        {
            Hide();
            Form form = new WinLoseScreen(player.Score, player.Name, color, this);
            form.ShowDialog();

        }
        void Tie()
        {
            Hide();
            Form form = new WinLoseScreen(player1.Score, player1.Name + " " + player2.Name, "No", this);
            form.ShowDialog();

        }
        #endregion

        #region Drawings
        void Draw(int startX, int startY, int rectangleWidth, int rectangleHeight, int rows, int colmns)
        {
            g = CreateGraphics();
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < colmns; j++)
                {
                    int x = startX + j * rectangleWidth;
                    int y = startY + i * rectangleHeight;
                    g.DrawLine(pen, x, y, x + rectangleWidth, y);
                    g.DrawLine(pen, x + rectangleWidth, y, x + rectangleWidth, y + rectangleHeight);
                    g.DrawLine(pen, x + rectangleWidth, y + rectangleHeight, x, y + rectangleHeight);
                    g.DrawLine(pen, x, y + rectangleHeight, x, y);
                }
        }
        void DrawString(int x, int y, string drawString, Color color)
        {
            if (!gameEnded)
            {
                g = CreateGraphics();
                Font drawFont = new Font("Arial", 10);
                SolidBrush drawBrush = new SolidBrush(color);
                StringFormat drawFormat = new StringFormat();

                g.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);

                drawFont.Dispose();
                drawBrush.Dispose();
                g.Dispose();
            }

        }
        void DrawString(int x, int y, int drawString)
        {
            g = CreateGraphics();
            Font drawFont = new Font("Arial", 10);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            StringFormat drawFormat = new StringFormat();

            g.DrawString(drawString.ToString(), drawFont, drawBrush, x, y, drawFormat);

            drawFont.Dispose();
            drawBrush.Dispose();
            g.Dispose();
        }
        void HighlightColumn(int colIndex, int startX, int startY, int rectangleWidth, int rectangleHeight, int rows, Color color)
        {
            g = CreateGraphics();
            int x = startX + colIndex * rectangleWidth;
            for (int i = 0; i < rows; i++)
            {
                int y = startY + i * rectangleHeight;
                g.FillRectangle(new SolidBrush(color),
                    new Rectangle(x, y, rectangleWidth - 1, rectangleHeight - 1));
            }
        }
        void DrawStringInRectangle(int x, int y, bool isDice, int text)
        {
            int textY;
            int textX;
            if (isDice)
            {
                textX = x + 30 / 2;
                textY = y + 30 / 2;
            }
            else
            {
                textX = x + defWidth / 2;
                textY = y + defHeight / 4;
            }

            DrawString(textX, textY, text);
        }

        private void bCheat_Click(object sender, EventArgs e)
        {
            int.TryParse(tbCheat.Text, out int cheatnum);
            if (!currentplayer.isFull(pos) && cheatnum <= 6 && cheatnum >= 1)
            {
                if (currentplayer.Offset > 0)
                {
                    EraseDicesInRectangle(false, waythrough);
                    player2.UsedPower = true;
                    dicelist[0] = cheatnum;

                }
                else
                {
                    EraseDicesInRectangle(true, waythrough);
                    player1.UsedPower = true;
                    dicelist[0] = cheatnum;
                }
                var senders = new object();

                var es = new PaintEventArgs(g, new Rectangle());
                GameScreen_Paint(senders, es);
                bCheat.Visible = tbCheat.Visible = false;
            }
        }
        private void tbCheat_TextChanged(object sender, EventArgs e)
        {
            bCheat.Visible = true;
        }
        void DrawStringInRectangle(int x, int y, bool isDice, int text, Color color)
        {
            int textY;
            int textX;
            if (isDice)
            {
                textX = x + 30 / 2;
                textY = y + 30 / 2;
            }
            else
            {
                textX = x + defWidth / 2;
                textY = y + defHeight / 4;
            }

            DrawString(textX, textY, text.ToString(), color);
        }
        void DrawDicesInRectangle(bool isOffset, int text, int i)
        {
            int x = col * defWidth + 10, y = row * defHeight / 2 + i * defHeight + 5;

            if (isOffset)
                y += offset;

            DrawString(x, y, text);

        }
        void EraseDicesInRectangle(bool isOffset, int b)
        {
            int x = col * defWidth + 10, y = row * defHeight / 2 + b * defHeight + 5;

            if (isOffset)
                y += offset;
            for (int i = 0; i < 10; i++)
            {
                DrawString(x, y, i.ToString(), cFond);
            }

        }
        #endregion

        #region Gamestates
        private void TurnTimer_Tick(object sender, EventArgs e)
        {
            if (!gameEnded)
            {
                lSave.ForeColor = Color.Black;
                if (tick1)
                {
                    Turns(player1);

                    lSave.Text = "Not Saveable";
                    saveable = false;
                }
                else
                {
                    Turns(player2);
                    lSave.Text = "Saveable";
                    saveable = true;
                }

                IsGameOver();
                ReFill();
                tick1 = !tick1;


            }
        }
        void Turns(Player player)
        {

            TurnTimer.Enabled = false;
            bool isOffset = true;
            IsGameOver();
            currentplayer = player;
            if (!player.UsedPower)
                lPower.Text = $"{player.Name} Turn Power Set";
            else
                lPower.Text = $"{player.Name} Turn Power used";

            if (player.Offset == 0)
                isOffset = false;

            for (int i = 0; i < dice; i++)
            {
                dicelist[i] = RandomDice();
                DrawDicesInRectangle(isOffset, dicelist[i], i);
                isAllowed = true;
            }
            ShowScores();
            IsGameOver();

        }

        void Turns(Player player, int[] dices)
        {
            TurnTimer.Enabled = false;
            bool isOffset = true;
            IsGameOver();
            currentplayer = player;
            if (!player.UsedPower)
                lPower.Text = $"{player.Name} Turn Power Set";
            else
                lPower.Text = $"{player.Name} Turn Power used";

            if (player.Offset == 0)
                isOffset = false;

            for (int i = 0; i < dice; i++)
            {
                DrawDicesInRectangle(isOffset, dices[i], i);
                isAllowed = true;
            }
            ShowScores();
            IsGameOver();
        }
        void GameOver()
        {
            isAllowed = TurnTimer.Enabled = false;
            gameEnded = true;

            if (player1.Score > player2.Score)
                WinnerIs(player1, Color.LightBlue);

            else if (player1.Score == player2.Score)
                Tie();

            else
                WinnerIs(player2, Color.Pink);
        }
        #endregion

        #region Events
        private void GameScreen_Load(object sender, EventArgs e)
        {
            cFond = Color.FromArgb(192, 255, 192);
        }
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            GameBackGround();
            ReFill();
            if (currentplayer.Offset > 0)
            {

                for (int i = 0; i < dice; i++)
                {
                    if (dicelist[i] > 0)
                    {
                        EraseDicesInRectangle(true, waythrough);
                        DrawDicesInRectangle(true, dicelist[i], i);
                    }

                }
            }
            if (currentplayer.Offset == 0)
            {
                for (int i = 0; i < dice; i++)
                {
                    if (dicelist[i] > 0)
                    {
                        EraseDicesInRectangle(true, waythrough);
                        DrawDicesInRectangle(false, dicelist[i], i);
                    }
                }
            }



        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (isAllowed)
            {
                if (keyData == Keys.Left)
                {
                    HighlightLeft();
                }
                else if (keyData == Keys.Right)
                {
                    HighlightRight();
                }
                else if (keyData == Keys.S && saveable)
                {
                    using (var sw = new StreamWriter("Save.txt"))
                    {
                        sw.WriteLine($"{currentplayer.Name}\n{dice}\n{col}\n{row}\n{top}");
                        sw.WriteLine(string.Join("", dicelist));
                        sw.WriteLine(waythrough);
                        foreach (var player in players)
                        {
                            sw.WriteLine($"{player.Name}\n{player.Offset}\n{player.UsedPower}");
                            for (int r = 0; r < row; r++)
                            {
                                for (int c = 0; c < col; c++)
                                {
                                    sw.Write(player.GameMatrix[r, c]);
                                }
                            }
                            sw.WriteLine();
                        }
                    }
                    lSave.Text = "Saved!!";
                    lSave.ForeColor = Color.DarkGreen;
                }
                else if (keyData == Keys.S && !saveable)
                {
                    lSave.Text = "NOT SAVEABLE!!!";
                    lSave.ForeColor = Color.Red;
                }
                else if (keyData == Keys.C)
                {
                    if (!currentplayer.UsedPower)
                    {
                        tbCheat.Visible = true;

                    }
                }
                else if (keyData == Keys.Enter || keyData == Keys.Space)
                {
                    if (!AddValueToGameMatrix())
                    {
                        Swap();
                        TurnTimer.Enabled = true;
                        return base.ProcessCmdKey(ref msg, keyData);
                    }
                    waythrough++;
                }
                ReFill();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void btnStart_click(object sender, EventArgs e)
        {
            btnStart.Visible = false;
            bSkip.Visible = false;
            TurnTimer.Enabled = true;
        }
        private void bSkip_Click(object sender, EventArgs e)
        {
            player1.AddValue(0, 4);
            player1.AddValue(1, 4);
            player1.AddValue(2, 4);
            player1.AddValue(0, 1);
            player1.AddValue(1, 1);
            player1.AddValue(2, 1);
            player1.AddValue(0, 4);
            player1.AddValue(1, 4);


            player2.AddValue(1, 1);
            player2.AddValue(2, 1);
            player2.AddValue(0, 4);
            player2.AddValue(1, 5);
            player2.AddValue(2, 4);
            player2.AddValue(0, 6);
            player2.AddValue(1, 2);
            player2.AddValue(2, 1);

            btnStart.Visible = false;
            bSkip.Visible = false;
            TurnTimer.Enabled = true;
        }
        private void GameScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }


        #endregion

        #endregion
    }
}
