using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FixCharacterRunningGame
{
    public class Obstacle
    {
        public PictureBox ObstacleSprite { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int ObstacleSpeed { get; set; }
        public int ObstacleSpeedSine { get; set; }
        public int ObstacleHeightSine { get; set; }
        public string ObstacleName { get; set; }
        public string ObstacleTag { get; set; }

        public DateTime startTime = DateTime.Now;

        public Obstacle(string obstacleName, int positionX, int positionY, int obstacleSpeed,int ObstacleSpeedSineEnter, int obstacleHeightSineEnter, string obstacleTag, Image obstacleSpriteFilePath)
        {
            ObstacleName = obstacleName;
            PositionX = positionX;
            PositionY = positionY;
            ObstacleSpeed = obstacleSpeed;
            ObstacleSpeedSine = ObstacleSpeedSineEnter;
            ObstacleHeightSine = obstacleHeightSineEnter;
            ObstacleTag = obstacleTag;

            ObstacleSprite = new PictureBox
            {
                BackColor = Color.Transparent,
                Tag = obstacleTag,
                Name = obstacleName,
                Image = obstacleSpriteFilePath,
                SizeMode = PictureBoxSizeMode.AutoSize,
                Location = new Point(positionX, positionY),
                Visible = true
            };
        }

        /// <summary>
        /// Moves generic obstacle at a given speed from right to left
        /// </summary>
        /// <param name="obstacleSpeede">Speed the obstacle is going at</param>
        public virtual void Movement(int obstacleSpeede)
        {
            if (ObstacleSprite == null) { return; }
            ObstacleSprite.Left -= (obstacleSpeede + 2);
        }

        /// <summary>
        /// Creates a box to check if robot bear has touched obstacleOOD, this to allow for hurtbox of obstacles to be modified
        /// </summary>
        public Rectangle HitBox()
        {
            int exclusionLeft = 0;
            int exclusionRight = 0;
            int exclusionTop = 0;
            int exclusionBottom = 0;

            int newX = ObstacleSprite.Bounds.Left + exclusionLeft;
            int newY = ObstacleSprite.Bounds.Top + exclusionTop;
            int newWidth = ObstacleSprite.Bounds.Width - exclusionLeft - exclusionRight;
            int newHeight = ObstacleSprite.Bounds.Height - exclusionTop - exclusionBottom;

            return new Rectangle(newX, newY, newWidth, newHeight);
        }
    }
}
