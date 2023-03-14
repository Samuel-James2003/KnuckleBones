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

        int col, row, dice, pos = 1, defWidth = 100, defHeight = 30, offset;
        Player player1, player2;
        Color cFond;
        Pen pen;
        bool top = true;
        Graphics g;
        List<Player> players = new List<Player>();

        public GameScreen(int numDice, int numCol, int numRow)
        {
            dice = numDice;
            col = numCol;
            row = numRow;
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
            Draw(col * defWidth, row * defHeight / 2, 30, 30, dice, 1);

            Draw(0, offset, defWidth, defHeight, row, col);
            Draw(col * defWidth, offset + row * defHeight / 2, 30, 30, dice, 1);
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
            p1score.Text = P1;
            p2score.Text = P2;
        }
        int RandomDice()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 7);
            return number;
        }
        void Swap()
        {
            pos = 1;
            top = !top;

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
        #endregion

        #region Gamestates
        void Turn(Player player)
        {
            if (player.isFull())
            {
                GameOver();
            }

            for (int i = 0; i < dice; i++)
            {

                DrawStringInRectangle(col * defWidth, row * defHeight / 2, true, RandomDice());

            }
        }
        void GameOver()
        {
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
            GameBackGround();
            if (keyData == Keys.Left)
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
            else if (keyData == Keys.Right)
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
            else if (keyData == Keys.Enter)
            {
                if (top)
                {
                    HighlightColumn(pos, 0, 0, defWidth, defHeight, row, cFond);
                    player1.AddValue(pos, RandomDice());
                }
                else
                {
                    HighlightColumn(pos, 0, offset, defWidth, defHeight, row, cFond);
                    player2.AddValue(pos, RandomDice());
                }
            }
            ReFill();
            return base.ProcessCmdKey(ref msg, keyData);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            ReFill();
            player1.AddValue(0, 4);
            player1.AddValue(0, 4);
            player2.AddValue(1, 2);
            ReFill();
            ShowScores();
            Swap();
        }
        #endregion
    }
}
