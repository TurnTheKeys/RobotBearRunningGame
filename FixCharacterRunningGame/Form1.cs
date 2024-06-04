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
        // Character Design
        string robotBearColour = "red";
        bool resumeRunning = true;

        //Jump Properties
        int force = 12;
        bool jumping = false;
        int jumpSpeed = 0;
        bool hover = false;
        int hoverTimer = 10;
        int position;

        //Jump Settings
        int ascentSpeed = -10;
        int descentSpeed = 12;
        int forceFull = 12;
        int forceDecrement = 2;
        int hoverTimerFull = 4;
        int maxHeight = 80;

        //Game Properties and Status
        int groundLevel = 220;
        int obstacleSpeed = 3;
        bool gameOver = false;
        int score = 0;
        bool debug = false;
        bool updateSpeed = true;

        Random random = new Random();

        public Sky()
        {
            InitializeComponent();
            ResetGame();
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            robotBear.Top += jumpSpeed;
            txtScore.Text = $"Score: {score}";

            JumpLogic();
            DebugTextVisibilitiy();

            foreach (Control objectChecked in this.Controls)
            {
                if (objectChecked is PictureBox && (string)objectChecked.Tag == "Obstacles")
                {
                    objectChecked.Left -= obstacleSpeed;

                    RespawnObstacle(objectChecked);
                    IncrementScore(objectChecked);
                    HurtChecker(objectChecked);
                }
            }
            SpeedChanger();
        }


        /// <summary>
        /// Code for robot bear jumping and hovering
        /// </summary>
        private void JumpLogic()
        {
            hoverDebug.Text = $"Hover: {hover}";
            fallSpeedDebug.Text = $"FallSpeed: {jumpSpeed}";
            forceDebug.Text = $"Force: {force}";

            if (maxHeight < robotBear.Top)
            {
                OnGround.Text = $"resumeRunning = {resumeRunning}, On Ground: yes,";
                if (jumping && force > 0)
                {    
                    debugHover.Text = $"Top: {robotBear.Top}, Jump";
                    // Jump up
                    jumpSpeed = ascentSpeed;
                    force -= forceDecrement;
                    SpriteSwitcher(robotBearColour, "jumping");
                    resumeRunning = true;
                }
            }
            else if (jumping && force <= 0 && hover == false)
            {
                // If force is depleted, stop jumping and start hovering
                debugHover.Text = $"Top: {robotBear.Top}, Switch to hover";
                jumping = false;
                hover = true;
                
            }
            else if (hover && hoverTimer > 0)
            {
                // Maintain position while hovering
                debugHover.Text = $"Top: {robotBear.Top}, Hovering";
                force--;
                hoverTimer--;
                jumpSpeed = 0; 
            }
            else if (hover && hoverTimer <= 0)
            {
                //Stop hovering and start falling
                debugHover.Text = $"Top: {robotBear.Top}, Finish Hovering";
                hover = false; 
                jumpSpeed = descentSpeed;
                SpriteSwitcher(robotBearColour, "falling");
            }
            else if (!jumping)
            {
                // Fall down if not on the ground
                debugHover.Text = $"Top: {robotBear.Top}, Falling";
                jumpSpeed = descentSpeed;
                SpriteSwitcher(robotBearColour, "falling");

            }
            else
            {
                // Stop falling when on the ground
                debugHover.Text = $"Top: {robotBear.Top}, Grounded";
                jumpSpeed = 0;
                //force = forceFull;
                hover = false;

                hoverTimer = hoverTimerFull;
                
            }

            // Apply the jumpSpeed to the robotBear's position
            robotBear.Top += jumpSpeed;

            // Ensure the robotBear does not go below the ground level
            if (robotBear.Top >= groundLevel)
            {
                //debugHover.Text = $"Top: {robotBear.Top}, Ground Check";
                OnGround.Text = $"resumeRunning = {resumeRunning}, On Ground: yes,";
                robotBear.Top = groundLevel;
                jumpSpeed = 0;
                force = forceFull;
                hover = false;
                hoverTimer = hoverTimerFull;
            }

            if (resumeRunning == true && robotBear.Top == 60 || robotBear.Top == 80)
            {
                SpriteSwitcher(robotBearColour, "running");
                resumeRunning = false;
            }
        }


        /// <summary>
        /// Increments score if robot bear has jumped over obstacle
        /// </summary>
        /// <param name="obstacle">obstacle checked</param>
        private void IncrementScore(Control obstacle)
        {
            if (obstacle.Left + obstacle.Width < robotBear.Left && obstacle.Left + obstacle.Width + obstacleSpeed >= robotBear.Left)
            {
                score++;
                updateSpeed = true;
            }
        }

        /// <summary>
        /// Moves object to right out of view to 'respawn' object
        /// </summary>
        /// <param name="obstacle">Obstacle to be respawned</param>
        private void RespawnObstacle(Control obstacle)
        {
            if (obstacle.Left < 0)
            {
                // Respawn Obstacle
                obstacle.Left = this.ClientSize.Width + random.Next(100, 500) + (obstacle.Width * 15);
            }
        }

        /// <summary>
        /// Updates speed of obstacles based on score, increments every 5 points
        /// </summary>
        private void SpeedChanger()
        {
            if (score > 0 && score % 5 == 0 && updateSpeed == true)
            {
                score++; // Increment score to prevent continuous speed increase on same score
                updateSpeed = false;
            }
        }

        /// <summary>
        /// Checks to see if the robot bear shares the same space as a checked obstacle. If it does, game is over.
        /// </summary>
        /// <param name="obstacle">Control checked</param>
        private void HurtChecker(Control obstacle)
        {
            if (robotBear.Bounds.IntersectsWith(obstacle.Bounds))
            {
                // Game over if the robot bear touches obstacle
                gameTimer.Stop();

                txtScore.Text += ", Press 'r' to reset";
                gameOver = true;

                SpriteSwitcher(robotBearColour, "dead");
            }
        }

        /// <summary>
        /// Switches sprites based on colour, currently have 'running', 'jumping', 'falling', 'dead'
        /// </summary>
        /// <param name="colour">colour of robot bear</param>
        /// <param name="type">sprite type</param>
        private void SpriteSwitcher(string colour, string type)
        {
            if (colour == "blue")
            {
                switch(type)
                {
                    case ("running"):
                        robotBear.Image = Properties.Resources.Running;
                        break;
                    case ("jumping"):
                        robotBear.Image = Properties.Resources.Jump;
                        break;
                    case ("falling"):
                        robotBear.Image = Properties.Resources.Fallen;
                        break;
                    case ("dead"):
                        robotBear.Image = Properties.Resources.Dead;
                        break;
                }
            }
            else if (colour == "red")
            {
                switch (type)
                {
                    case ("running"):
                        robotBear.Image = Properties.Resources.RunningRed;
                        break;
                    case ("jumping"):
                        robotBear.Image = Properties.Resources.JumpRed;
                        break;
                    case ("falling"):
                        robotBear.Image = Properties.Resources.FallenRed;
                        break;
                    case ("dead"):
                        robotBear.Image = Properties.Resources.DeadRed;
                        break;
                }
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

            if (e.KeyCode == Keys.D)
            {
                if (debug == false)
                {
                    debug = true;
                }
                else
                {
                    debug = false;
                }
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
                SpriteSwitcher(robotBearColour, "running");
            }
            else
            {
                robotBearColour = "blue";
                SpriteSwitcher(robotBearColour, "running");
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

        /// <summary>
        /// Sets the visibility of the debug text
        /// </summary>
        private void DebugTextVisibilitiy()
        {
            foreach (Control x in this.Controls)
            {
                if (x is Label && (string)x.Tag == "debugTxt")
                {
                    x.Visible = debug; // Show or hide the label based on the debug flag
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
