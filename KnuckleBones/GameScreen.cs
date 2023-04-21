using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace KnuckleBones
{
    public partial class GameScreen : Form
    {
        #region Variables
        int col, row, dice, pos = 1, defWidth = 100, defHeight = 30, offset, waythrough = 0;
        int[] dicelist;
        Player player1, player2;
        Color cFond;
        Pen pen;
        bool top = true, isAllowed = false;
        Graphics g;
        List<Player> players = new List<Player>();
        #endregion

        public GameScreen(int numDice, int numCol, int numRow)
        {
            dice = numDice;
            col = numCol;
            row = numRow;
            dicelist = new int[dice];
            offset = defHeight * (row + 3);
            pen = new Pen(Color.Black, 1);
            InitializeComponent();
            player1 = new Player(col, row);
            player2 = new Player(col, row);
            player2.Offset = offset;
            players.Add(player1);
            players.Add(player2);
        }

        #region Bases
        void ClearScreen()
        {
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                    for (int c = 0; c < 7; c++)
                        DrawStringInRectangle(j * defWidth, i * defHeight, false, c, cFond);
        }
        void GameBackGround()
        {
            g = CreateGraphics();
            Draw(0, 0, defWidth, defHeight, row, col);
            Draw(col * defWidth, row * defHeight / 2, defHeight, defHeight, dice, 1);

            Draw(0, offset, defWidth, defHeight, row, col);
            Draw(col * defWidth, offset + row * defHeight / 2, defHeight, defHeight, dice, 1);
            g.Dispose();
        }
        void ReFill()
        {
            ClearScreen();
            GameBackGround();
            foreach (Player player in players)
            {
                for (int i = 0; i < col; i++)
                    for (int j = 0; j < row; j++)
                    {
                        int value = player.GameMatrix[i, j];
                        if (value > 0 && player.Offset == 0)
                        {
                            DrawStringInRectangle(j * defWidth, i * defHeight, false, value);
                        }
                        else if (value > 0 && player.Offset != 0)
                        {
                            DrawStringInRectangle(j * defWidth, i * defHeight + offset, false, value);
                        }


                    }
            }

        }
        void ShowScores()
        {
            string P1 = "Player 1 = " + player1.Score.ToString(), P2 = "Player 2 = " + player2.Score.ToString();
            
        }
        int RandomDice()
        {
            var rnd = new Random();
            int number = rnd.Next(1, 7);
            return number;
        }
        void Swap()
        {
            pos = 1;
            top = !top;

        }
        private bool AddValueToGameMatrix()
        {
            if (waythrough >= dice)
            {
                isAllowed = false;
                return false;
            }

            if (top)
            {
                HighlightColumn(pos, 0, 0, defWidth, defHeight, row, cFond);
                player1.AddValue(pos, dicelist[waythrough]);
                EmptyDicelist(false);
            }
            else
            {
                HighlightColumn(pos, 0, offset, defWidth, defHeight, row, cFond);
                player2.AddValue(pos, dicelist[waythrough]);
                EmptyDicelist(true);
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
        #endregion

        #region Drawings
        void Draw(int startX, int startY, int rectangleWidth, int rectangleHeight, int rows, int colmns)
        {
            g = CreateGraphics();
            for (int i = 0; i < rows; i++)
            {
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
        void DrawString(int x, int y, string drawString, Color color)
        {
            Graphics formGraphics = CreateGraphics();
            Font drawFont = new Font("Arial", 10);
            SolidBrush drawBrush = new SolidBrush(color);
            StringFormat drawFormat = new StringFormat();

            formGraphics.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);

            drawFont.Dispose();
            drawBrush.Dispose();
            formGraphics.Dispose();
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
        void Turn(Player player)
        {
            waythrough = 0;
            dicelist.Initialize();
            bool isOffset = true;
            if (player.isFull())
                GameOver();

            if (player.Offset == 0)
                isOffset = false;

            for (int i = 0; i < dice; i++)
            {
                dicelist[i] = RandomDice();
                DrawDicesInRectangle(isOffset, dicelist[i], i);
                isAllowed = true;
            }
            Swap();
        }
        void GameOver()
        {
            isAllowed = false;
            if (player1.Score > player2.Score)
            {
                //player one wins
            }
            else if (player1.Score == player2.Score)
            {
                //tie
            }
            else
            {
                //player 3 wins
            }

        }
        #endregion

        #region Events
        private void GameScreen_Load(object sender, EventArgs e)
        {
            cFond = Color.FromArgb(192, 255, 192);

        }
        private void GameScreen_MouseMove(object sender, MouseEventArgs e)
        {
            tbposX.Text = "Pos X " + Cursor.Position.X.ToString();
            tbposY.Text = "Pos Y " + Cursor.Position.Y.ToString();
        }
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {

            GameBackGround();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (isAllowed)
            {
                GameBackGround();

                if (keyData == Keys.Left)
                {
                    HighlightLeft();
                }
                else if (keyData == Keys.Right)
                {
                    HighlightRight();

                }
                else if (keyData == Keys.Enter)
                {

                    if (!AddValueToGameMatrix())
                    {
                        Swap();
                        
                        return base.ProcessCmdKey(ref msg, keyData);
                    }
                    waythrough++;
                }
                ReFill();
            }

            return base.ProcessCmdKey(ref msg, keyData);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            //while (true)
            //{
            //    foreach (var player in players)
            //    {
            //        Turn(player);
            //        ReFill();
            //        ShowScores();
            //        if (player.isFull()) 
            //            break;
            //    }
            //    if (player1.isFull())
            //        break;
            //    if (player2.isFull())
            //        break;
            //}

            foreach (var player in players)
            {
                Turn(player);
                ReFill();
                ShowScores();
                if (player.isFull())
                    break;
            }

            button1_Click(sender, e);
            if (player1.isFull())
                Close();
            if (player2.isFull())
                Close();


        }
        #endregion
    }
}
