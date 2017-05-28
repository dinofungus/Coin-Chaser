using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoinChaser.Properties;

namespace CoinChaser
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        private int playerX = 100;
        private int playerY = 100;

        private int coinX;
        private int coinY;

        private int score = 0;

        Panel game = new Panel();


        public Form1()
        {
            
                      
            game.Parent = this;
            game.Top = 60;
            game.Left = 20;
            game.Height = 220;
            game.Width = 240;
            
            InitializeComponent();
            lblScore.Text = "Score: " + score;
            NewCoin();
            
            label1.BringToFront();
            game.Show();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = game.CreateGraphics();
            graphics.Clear(Color.Blue);

            SolidBrush brush = new SolidBrush(Color.Red);
            graphics.FillRectangle(brush, playerX, playerY, 20, 20);

            brush = new SolidBrush(Color.Gold);
            graphics.FillRectangle(brush, coinX, coinY, 20, 20);

            brush.Dispose();
            graphics.Dispose();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            game.BringToFront();
            if (e.KeyCode == Keys.Up)
            {
                if (playerY > 0) playerY -= 20;
            }
            if (e.KeyCode == Keys.Down)
            {
                if (playerY < game.Height - 20) playerY += 20;
            }
            if (e.KeyCode == Keys.Left)
            {
                if (playerX > 0) playerX -= 20;
            }
            if (e.KeyCode == Keys.Right)
            {
                if (playerX < game.Width - 20) playerX += 20;
            }

            if(coinX == playerX && coinY == playerY)
            {
                
                NewCoin();
                System.Media.SoundPlayer coinPlayer = new System.Media.SoundPlayer(Properties.Resources.coin);
                coinPlayer.Play();
                coinPlayer.Dispose();
                score++;
                lblScore.Text = "Score: " + score;
            }
            else
            {
                System.Media.SoundPlayer movePlayer = new System.Media.SoundPlayer(Properties.Resources.move);
                movePlayer.Play();
                movePlayer.Dispose();
            }
            
            Form1_Paint(this, null);

        }
        private void NewCoin()
        {
            do
            {
                coinX = random.Next(1, game.Width / 20) * 20;
                coinY = random.Next(1, game.Height / 20) * 20;
            } while (coinX == playerX && coinY == playerY);
            Form1_Paint(this, null);
        }
    }
}
