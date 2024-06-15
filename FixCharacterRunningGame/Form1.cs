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
        int position;

        //Game Properties
        Panel spritePanel;
        DateTime startTime = DateTime.Now;
        TimeSpan elapsed;
        int groundLevel = 220;
        int obstacleSpeed = 10;
        bool updateSpeed = true;

        //Game Score and Status
        bool gameOver = false;
        int score = 0;
        int highScore = 0;
        bool debug = false;

        //Obstacles
        List<Obstacle> obstacles = new List<Obstacle>();
        bool obstacleSpawned = true;

        //Players
        List<RobotBearCharacter> RobotBears = new List<RobotBearCharacter>();
        int numberOfPlayers = 3;
        int alivePlayers = 0;

        Random random = new Random();

        public Sky()
        {
            InitializeComponent();
            spritePanel = SpritePanelGenerator(this);
            this.Controls.Add(spritePanel);
            for (int i = 0; i < numberOfPlayers; i++)
            {
                RobotBears.Add(CreatePlayer("Tobias", 40 + (i*50), 220));
            }
            ResetGame();
        }

        private RobotBearCharacter CreatePlayer(string bearName, int xCoordinate, int yCoordinate)
        {
            RobotBearCharacter player = new RobotBearCharacter(bearName,xCoordinate,yCoordinate,groundLevel, obstacleSpeed, 20);
            spritePanel.Controls.Add(player.RobotBear);
            return player;
        }

        /// <summary>
        /// Generates Form for holding sprites, is transparent
        /// </summary>
        /// <param name="controlPanel"></param>
        /// <returns></returns>
        private Panel SpritePanelGenerator(Form controlPanel)
        {
            Panel panel = new Panel();
            panel.Size = controlPanel.Size;
            panel.Location = controlPanel.Location;
            panel.BackColor = Color.Transparent;
            return panel;
        }

        private void PlayerTimer_Tick(object sender, EventArgs e)
        {
            BearLocation1.Text = $"Bear[1] Location: {RobotBears[1]}";
            for (int i = 0; i < numberOfPlayers; i++)
            {
                UpdateLocationDebug(i);
                NewBearStatusJump.Text = $"New Bear Jump Satus: {RobotBears[0].JumpStatusGet()}";
                RobotBears[i].JumpLogic();
                if (i == numberOfPlayers-1)
                {
                    GameOverChecker(true);
                }
                else
                {
                    GameOverChecker(false);
                }
            }
        }

        /// <summary>
        /// Updates debug text for bear locations
        /// </summary>
        /// <param name="bearNumber"></param>
        private void UpdateLocationDebug(int bearNumber)
        {
            switch (bearNumber)
            {
                case 0:
                    BearLocation0.Text = $"Bear[0] Location: {RobotBears[0].RobotBear.Location}";
                    break;
                case 1:
                    BearLocation1.Text = $"Bear[1] Location: {RobotBears[1].RobotBear.Location}";
                    break;
                case 2:
                    BearLocation2.Text = $"Bear[2] Location: {RobotBears[2].RobotBear.Location}";
                    break;
                default:
                    break;
            }
        }
        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            elapsed = DateTime.Now - startTime;
            txtScore.Text = $"Score: {score}";

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

            foreach (Control objectChecked in spritePanel.Controls)
            {
                if (objectChecked is PictureBox && (string)objectChecked.Tag == "ObstaclesOOD")
                {
                    for (int i = 0; i < numberOfPlayers; i++)
                    {
                        HurtCheckerNew(objectChecked, RobotBears[i]);
                    }
                }
            }

            
            for (int i = 0; i<obstacles.Count; i++)
            {
                IncrementScore(obstacles[i]);
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
        /// Increments score if robot bear has jumped over obstacle
        /// </summary>
        /// <param name="obstacle">obstacle checked</param>
        private void IncrementScore(Obstacle obstacle)
        {
            if (obstacle.ObstacleSprite.Left < 60 && obstacle.CountedScoreYet)
            {
                score++;
                updateSpeed = true;
                obstacle.CountedScoreYet = false;
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
                if ((obstacleChecked.ObstacleSprite.Left < -10) || mode == "reset")
                {
                    obstacleChecked.ObstacleSprite.Dispose();
                    spritePanel.Controls.Remove(obstacleChecked.ObstacleSprite);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Spawns a random obstacle, createobstacle
        /// </summary>
        /// <param name="xCoordinate">x coordinate of obstacle</param>
        /// <param name="yCoordinate">y coordinate of obstacle</param>
        private Obstacle SpawnObstacle(int xCoordinate)
        {
            int randomObstacle = random.Next(0,3);
            Obstacle newObstacle = null;
            switch (randomObstacle)
            {
                case 0:
                    newObstacle = new FlyingEgg(xCoordinate, random.Next(100, 160), obstacleSpeed, 2, random.Next(1,30));
                    TestObstacleSpawner.Text = $"Spawned Eggy at: {newObstacle.ObstacleSprite.Location}";
                    break;
                case 1:
                    newObstacle = new PurpleHand(xCoordinate, 218, obstacleSpeed, 1, 1);
                    TestObstacleSpawner.Text = $"Spawned Handy at: {newObstacle.ObstacleSprite.Location}";
                    break;
                case 2:
                    newObstacle = new Umbrella(xCoordinate, 230, obstacleSpeed, 1, 1);
                    TestObstacleSpawner.Text = $"Spawned Umbrelly at: {newObstacle.ObstacleSprite.Location}";
                    break;
                default:
                    break;
            }
            if (newObstacle != null)
            {
                spritePanel.Controls.Add(newObstacle.ObstacleSprite);
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
        /// Checks to see if there are any players remaining, if not, stops game
        /// </summary>
        /// <param name="LastIn">Checks to see if the last bear checked to ensure all animations are played</param>
        private void GameOverChecker(bool LastIn)
        {
            if (alivePlayers == 0 && LastIn)
            {
                txtScore.Text += ", Press 'r' to reset";
                gameOver = true;
                if (highScore < score)
                {
                    highScore = score;
                    HighScore.Text = $"High Score: {highScore}";
                }
                PlayerTimer.Stop();
                gameTimer.Stop();
            }
        }
        /// <summary>
        /// Checks to see if the robot bear shares the same space as a checked obstacle. If it does, game is over.
        /// </summary>
        /// <param name="obstacle">Control checked</param>
        private bool HurtCheckerNew(Control obstacle, RobotBearCharacter bear)
        {
            if (bear.RobotBear.Bounds.IntersectsWith(obstacle.Bounds))
            {
                bear.Dead = true;
                alivePlayers--;
                return true;
            }
            return false;
        }

        private void keyIsDown(object sender, KeyEventArgs e)
        {

            for (int i = 0; i < numberOfPlayers; i++)
            {
                if (i == 0)
                {
                    if (e.KeyCode == Keys.Space && RobotBears[i].JumpingState == false)
                    {
                        RobotBears[i].JumpStatusSet(true);
                    }
                }
                else if (i == 1)
                {
                    if (e.KeyCode == Keys.W && RobotBears[i].JumpingState == false)
                    {
                        RobotBears[i].JumpStatusSet(true);
                    }
                }
                else if (i == 2)
                {
                    if (e.KeyCode == Keys.Up && RobotBears[i].JumpingState == false)
                    {
                        RobotBears[i].JumpStatusSet(true);
                    }
                }

            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                RobotBears[i].JumpStatusSet(false);
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
            score = 0;
            alivePlayers = numberOfPlayers;
            obstacleSpeed = 10;
            for (int i = 0;i < numberOfPlayers;i++)
            {
                RobotBears[i].ResetCharacter();
            }

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
            foreach (Control x in spritePanel.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "Obstacles")
                {
                    position = this.ClientSize.Width + random.Next(300, 800) + (x.Width * 10);
                    x.Left = position;
                }
            }
            
            PlayerTimer.Start();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void HighScore_Click(object sender, EventArgs e)
        {

        }

        private void txtScore_Click(object sender, EventArgs e)
        {

        }

        
    }
}
