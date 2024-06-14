using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FixCharacterRunningGame
{
    public class RobotBearCharacter
    {
        // Character Properties
        public PictureBox RobotBear { get; set; }
        string RobotBearColour = "red";
        bool ResumeRunning = true;
        public bool Dead = false;
        Random Random = new Random();

        //Jump Properties
        public bool JumpingState = false;
        int JumpSpeed = 0;
        bool Hover = false;
        int HoverTimer = 10;
        string statusJump = "";

        //Jump Settings
        int AscentSpeed = -10;
        int DescentSpeed = 14;
        int RemainingJump = 12;
        int RemainingJumpFull = 12;
        int RemainingJumpDecrement = 2;
        int HoverTimerFull = 4;
        int MaxHeight = 80;

        //From Game
        int GroundLevel = 220;
        int GameSpeed = 1;
        int GameInterval = 20;

        //Original Settings
        Point OriginalLocation;
        int OriginalRemainingJump = 12;

        /// <summary>
        /// Sets jumping status of character
        /// </summary>
        /// <returns>Status of jump</returns>
        public void JumpStatusSet(bool status)
        {
            JumpingState = status;
        }
        /// <summary>
        /// returns jumping status of character
        /// </summary>
        /// <returns>Status of jump</returns>
        public bool JumpStatusGet()
        {
            return JumpingState;
        }

        public RobotBearCharacter(string bearName,int positionX, int positionY, int GroundLevel, int gameSpeed, int gameInterval)
        {
            GameSpeed = gameSpeed;
            GameInterval = gameInterval;
            RobotBear = new PictureBox
            {
                BackColor = Color.Transparent,
                Tag = "Player",
                Name = bearName,
                SizeMode = PictureBoxSizeMode.AutoSize,
                Location = new Point(positionX, positionY),
                Visible = true
            };
            ColourSelector(Random.Next(-1, 2));
            SpriteSwitcher(RobotBearColour, "running");
            OriginalLocation = RobotBear.Location;
            OriginalRemainingJump = RemainingJump;
        }

        /// <summary>
        /// Selects colour based on given number
        /// </summary>
        /// <param name="colourOption"></param>
        private void ColourSelector(int colourOption)
        {
            switch (colourOption)
            {
                case 0:
                    RobotBearColour = "blue";
                    break;
                case 1:
                    RobotBearColour = "red";
                    break;
                default:
                    RobotBearColour = "blue";
                    break;
            }
        }

        /// <summary>
        /// Resets Character to default
        /// </summary>
        public void ResetCharacter()
        {
            RobotBear.Location = OriginalLocation;
            Dead = false;
            SpriteSwitcher(RobotBearColour, "running");
            RobotBear.Location = OriginalLocation;
            JumpingState = false;
            JumpSpeed = 0;
            RemainingJump = OriginalRemainingJump;
        }

        /// <summary>
        /// Code for robot bear jumping and hovering
        /// </summary>
        /// <returns>Current Jump Status</returns>
        public string JumpLogic()
        {
            statusJump = JumpingState.ToString();
            if (Dead)
            {
                RemovalFromScreen();
                return statusJump;
            }

            if (MaxHeight < RobotBear.Top)
            {
                if (JumpingState && RemainingJump > 0)
                {
                    // Jump up
                    statusJump = "Jumping";
                    JumpSpeed = AscentSpeed;
                    RemainingJump -= RemainingJumpDecrement;
                    SpriteSwitcher(RobotBearColour, "jumping");
                    ResumeRunning = true;
                }
            }
            else if (JumpingState && RemainingJump <= 0 && Hover == false)
            {
                // If RemainingJump is depleted, stop JumpingState and start Hovering
                statusJump = "Switch to Hovering";
                JumpingState = false;
                Hover = true;

            }
            else if (Hover && HoverTimer > 0)
            {
                // Maintain Position while Hovering
                statusJump = "Hovering";
                RemainingJump--;
                HoverTimer--;
                JumpSpeed = 0;
            }
            else if (Hover && HoverTimer <= 0)
            {
                //Stop Hovering and start falling
                statusJump = "Switch to Falling";
                Hover = false;
                JumpSpeed = DescentSpeed;
            }
            else if (!JumpingState)
            {
                // Fall down if not on the ground
                statusJump = "Falling";
                JumpSpeed = DescentSpeed;
            }
            else
            {
                // Stop falling when on the ground
                statusJump = "Grounded";
                JumpSpeed = 0;
                Hover = false;
                HoverTimer = HoverTimerFull;
            }

            // Apply the JumpSpeed to the RobotBear's Position
            RobotBear.Top += JumpSpeed;

            // Ensure the RobotBear does not go below the ground level
            if (RobotBear.Top >= GroundLevel)
            {
                //statusJump = "Grounded";
                RobotBear.Top = GroundLevel;
                JumpSpeed = 0;
                RemainingJump = RemainingJumpFull;
                Hover = false;
                HoverTimer = HoverTimerFull;
            }

            if (ResumeRunning == true && (RobotBear.Top == 60 || RobotBear.Top == 80 || RobotBear.Top == 220))
            {
                SpriteSwitcher(RobotBearColour, "running");
                ResumeRunning = false;
            }
            return statusJump;
        }

        /// <summary>
        /// Removes dead robot from screen
        /// </summary>
        private void RemovalFromScreen()
        {
            SpriteSwitcher(RobotBearColour, "dead");
            RobotBear.Left -= (GameSpeed * GameInterval)/3;
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
                switch (type)
                {
                    case ("running"):
                        RobotBear.Image = Properties.Resources.Running;
                        break;
                    case ("jumping"):
                        RobotBear.Image = Properties.Resources.Jump;
                        break;
                    case ("falling"):
                        RobotBear.Image = Properties.Resources.Fallen;
                        break;
                    case ("dead"):
                        RobotBear.Image = Properties.Resources.Dead;
                        break;
                    default:
                        RobotBear.Image = Properties.Resources.Running;
                        break;
                }
            }
            else if (colour == "red")
            {
                switch (type)
                {
                    case ("running"):
                        RobotBear.Image = Properties.Resources.RunningRed;
                        break;
                    case ("jumping"):
                        RobotBear.Image = Properties.Resources.JumpRed;
                        break;
                    case ("falling"):
                        RobotBear.Image = Properties.Resources.FallenRed;
                        break;
                    case ("dead"):
                        RobotBear.Image = Properties.Resources.DeadRed;
                        break;
                    default:
                        RobotBear.Image = Properties.Resources.RunningRed;
                        break;

                }
            }
        }

    }
}
