using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FixCharacterRunningGame
{
    public partial class Sky : Form
    {
        bool jumping = false;
        int jumpSpeed = 0;
        int force = 12;
        int score = 0;
        int obstacleSpeed = 3;
        Random random = new Random();
        int position;
        bool gameOver = false;
        string robotBearColour = "blue";

        public Sky()
        {
            InitializeComponent();
            ResetGame();
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            robotBear.Top += jumpSpeed;
            txtScore.Text = $"Score: {score}";

            // Handle jumping logic
            if (jumping && force > 0)
            {
                // Jump up
                jumpSpeed = -12;
                force -= 1;
            }
            else if (jumping && force <= 0)
            {
                // If force is depleted, stop jumping
                jumping = false;
            }
            else if (!jumping && robotBear.Top < 220)
            {
                // Fall down if not on the ground
                jumpSpeed = 12;
            }
            else
            {
                // Stop falling when on the ground
                jumpSpeed = 0;
                force = 12;
                robotBear.Top = 220;
            }

            if (robotBear.Top > 220 && jumping == false)
            {
                //Ensure that robotBear remains on ground level when not jumping
                force = 12;
                robotBear.Top = 220;
                jumpSpeed = 0;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "Obstacles")
                {
                    x.Left -= obstacleSpeed;

                    if (x.Left < 0)
                    {
                        // Respawn Obstacle
                        x.Left = this.ClientSize.Width + random.Next(100, 500) + (x.Width * 15);
                    }

                    //Increment score if robot bear has jumped over obstacle
                    if (x.Left + x.Width < robotBear.Left && x.Left + x.Width + obstacleSpeed >= robotBear.Left)
                    {
                        score++;
                    }

                    if (robotBear.Bounds.IntersectsWith(x.Bounds))
                    {
                        // Game over if the robot bear touches obstacle
                        gameTimer.Stop();
                        
                        txtScore.Text += ", Press 'r' to reset";
                        gameOver = true;

                        if (robotBearColour == "blue")
                        {
                            robotBear.Image = Properties.Resources.Dead;
                        }
                        else
                        {
                            robotBear.Image = Properties.Resources.DeadRed;
                        }
                    }
                }
            }

            if (score > 0 && score % 10 == 0)
            {
                obstacleSpeed += 1;
                score++; // Increment score to prevent continuous speed increase on same score
            }
        }

        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (jumping == true)
            {
                jumping = false;
            }

            if (e.KeyCode == Keys.R && gameOver == true)
            {
                ResetGame();

            }
        }

        /// <summary>
        /// Resets game properties
        /// </summary>
        private void ResetGame()
        {
            //Character Colour
            if (robotBearColour == "blue")
            {
                robotBearColour = "red";
                robotBear.Image = Properties.Resources.RunningRed;
            }
            else
            {
                robotBearColour = "blue";
                robotBear.Image = Properties.Resources.Running;
            }
            //Character Properties
            robotBear.Top = 220;
            Umbrella.Top = 230;
            PurpleHand.Top = 218;
            jumping = false;
            jumpSpeed = 0;
            force = 12;
            score = 0;
            //Obstacles
            obstacleSpeed = 10;
            //Game Information
            txtScore.Text = "Score: " + score;

            gameOver = false;

            foreach (Control x in this.Controls)
            {
                //Starting position of the obstacles
                if (x is PictureBox && (string)x.Tag == "Obstacles")
                {
                    position = this.ClientSize.Width + random.Next(300, 800) + (x.Width * 10);
                    x.Left = position;
                }
            }

            gameTimer.Start();
        }
    }
}
