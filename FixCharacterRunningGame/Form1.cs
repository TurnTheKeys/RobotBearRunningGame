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
        DateTime startTime = DateTime.Now;
        TimeSpan elapsed;
        int groundLevel = 220;
        int obstacleSpeed = 3;
        bool gameOver = false;
        int score = 0;
        bool debug = false;
        bool updateSpeed = true;

        //Obstacles
        List<Obstacle> obstacles = new List<Obstacle>();
        bool obstacleSpawned = true;

        Random random = new Random();

        public Sky()
        {
            InitializeComponent();
            ResetGame();
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            elapsed = DateTime.Now - startTime;
            robotBear.Top += jumpSpeed;
            txtScore.Text = $"Score: {score}";

            JumpLogic();
            DebugTextVisibilitiy();

            if (!obstacleSpawned && elapsed.TotalSeconds >= 0.5)
            {
                obstacles.Add(SpawnObstacle(random.Next(900, 1200)));
                obstacleSpawned = true;
                startTime = DateTime.Now;
            }
            else if (obstacleSpawned && elapsed.TotalSeconds >= 0.5)
            {
                obstacleSpawned = false;
                startTime = DateTime.Now;
            }

            foreach (Control objectChecked in this.Controls)
            {
                if (objectChecked is PictureBox && (string)objectChecked.Tag == "ObstaclesOOD")
                {
                    //ObstacleMovement(objectChecked);
                    RespawnObstacle(objectChecked);
                    IncrementScore(objectChecked);
                    HurtChecker(objectChecked);
                }
            }

            MovementDebug.Text = $"obstacle count is {obstacles.Count}";
            for (int i = obstacles.Count - 1; i >= 0; i--)
            {
                Obstacle obstacleEvil = obstacles[i];
                if (obstacleEvil == null) {  continue; }
                obstacleEvil.Movement(obstacleSpeed); // Update obstacle position
                if (DeleteObstacle(obstacleEvil, "Playing Game"))
                {
                    obstacles.RemoveAt(i);
                }
            }
            SpeedChangerChecker();
        }

        /// <summary>
        /// Moves obstacles across map
        /// </summary>
        /// <param name="obstacle">The obstacle to be moved</param>
        private void ObstacleMovement(Control obstacle)
        {
            switch (obstacle.Name)
            {
                case "flyingEgg":
                    // Flies in a wave pattern
                    if (score > 0)
                    {
                        robotCoordinatesDebug.Text = $"egg Coordinates: {obstacle.Location}";
                        int speedEgg = 2;
                        int heightEgg = 10;
                        obstacle.Left -= (obstacleSpeed+2);
                        obstacle.Top = (int)(Math.Sin((double)(obstacle.Left + obstacle.Width) / speedEgg) * heightEgg) + 200;
                    }
                    break;
                case "PurpleHand":
                    
                    //Changes speed
                    int speedHand = 1;
                    int heightHand = 1;
                    int variableSpeed = (int)(Math.Sin((double)(obstacle.Left + obstacle.Width) / speedHand) * heightHand);
                    obstacle.Left -= (obstacleSpeed + variableSpeed);
                    break;

                default:
                    obstacle.Left -= obstacleSpeed;
                    break;
            }
        }

        /// <summary>
        /// Code for robot bear jumping and hovering
        /// </summary>
        private void JumpLogic()
        {
            //robotCoordinatesDebug.Text = $"Coordinates: {robotBear.Location}";
            hoverDebug.Text = $"Hover: {hover}";
            fallSpeedDebug.Text = $"FallSpeed: {jumpSpeed}";
            forceDebug.Text = $"Force: {force}";

            if (maxHeight < robotBear.Top)
            {
                OnGround.Text = $"resumeRunning = {resumeRunning}";
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
            }
            else if (!jumping)
            {
                // Fall down if not on the ground
                debugHover.Text = $"Top: {robotBear.Top}, Falling";
                jumpSpeed = descentSpeed;
            }
            else
            {
                // Stop falling when on the ground
                debugHover.Text = $"Top: {robotBear.Top}, Grounded";
                jumpSpeed = 0;
                hover = false;
                hoverTimer = hoverTimerFull;
            }

            // Apply the jumpSpeed to the robotBear's position
            robotBear.Top += jumpSpeed;

            // Ensure the robotBear does not go below the ground level
            if (robotBear.Top >= groundLevel)
            {
                OnGround.Text = $"resumeRunning = {resumeRunning}";
                robotBear.Top = groundLevel;
                jumpSpeed = 0;
                force = forceFull;
                hover = false;
                hoverTimer = hoverTimerFull;
            }

            if (resumeRunning == true && (robotBear.Top == 60 || robotBear.Top == 80 || robotBear.Top == 220))
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
            if (obstacle.Left < -20)
            {
                // Respawn Obstacle
                obstacle.Left = this.ClientSize.Width + random.Next(100, 500) + (obstacle.Width * 15);
                random.Next(0, 5);
            }
        }

        /// <summary>
        /// Deletes Obstacle once off-screen
        /// </summary>
        /// <param name="obstacleChecked">obstacle to be checked</param>
        /// <param name="mode">Set to "reset" for game reset</param>
        /// <returns>True if obstacle is deleted, false otherwise</returns>
        private bool DeleteObstacle(Obstacle obstacleChecked, string mode)
        {
            if (obstacleChecked.ObstacleSprite != null || mode == "reset")
            {
                if ((obstacleChecked.ObstacleSprite.Left < -20) || mode == "reset")
                {
                    obstacleChecked.ObstacleSprite.Dispose();
                    this.Controls.Remove(obstacleChecked.ObstacleSprite);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Spawns a random obstacle
        /// </summary>
        /// <param name="xCoordinate">x coordinate of obstacle</param>
        /// <param name="yCoordinate">y coordinate of obstacle</param>
        private Obstacle SpawnObstacle(int xCoordinate)
        {
            int randomObstacle = random.Next(0,2);
            Obstacle newObstacle = null;
            switch (randomObstacle)
            {
                case 0:
                    newObstacle = new FlyingEgg(xCoordinate, random.Next(120, 190), obstacleSpeed, 2, random.Next(1,30));
                    TestObstacleSpawner.Text = $"Spawned Eggy at: {newObstacle.ObstacleSprite.Location}";
                    break;
                case 1:
                    newObstacle = new PurpleHand(xCoordinate, 218, obstacleSpeed, 1, 1);
                    TestObstacleSpawner.Text = $"Spawned Handy at: {newObstacle.ObstacleSprite.Location}";
                    break;
                default:
                    break;
            }
            if (newObstacle != null)
            {
                this.Controls.Add(newObstacle.ObstacleSprite);
            }
            return newObstacle;
        }

        /// <summary>
        /// Update speed based on score, increments every 5 points
        /// </summary>
        private void SpeedChangerChecker()
        {
            if (score > 0 && score % 5 == 0 && updateSpeed == true)
            {
                updateSpeed = false;
                obstacleSpeed += 1;
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
        /// Checks to see if the robot bear shares the same space as a checked obstacle. If it does, game is over.
        /// </summary>
        /// <param name="obstacle">Control checked</param>
        private void HurtCheckerOOJ(Obstacle obstacle)
        {
            if (obstacle.ObstacleSprite == null) { return; }
            if (robotBear.Bounds.IntersectsWith(obstacle.ObstacleSprite.Bounds))
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
                    default:
                        robotBear.Image = Properties.Resources.Running;
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
                    default:
                        robotBear.Image = Properties.Resources.RunningRed;
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


            foreach (Obstacle obstacleEvil in obstacles)
            {
                DeleteObstacle(obstacleEvil, "reset");
            }

            //Game Information
            txtScore.Text = "Score: " + score;
            startTime = DateTime.Now;
            elapsed = DateTime.Now - startTime;

            gameOver = false;

            //Starting position of the obstacles
            foreach (Control x in this.Controls)
            {
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

        private void flyingEgg_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
