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

        public Obstacle(string obstacleName, int positionX, int positionY, int obstacleSpeed,int ObstacleSpeedSineEnter, int obstacleHeightSineEnter, string obstacleTag, string obstacleSpriteFilePath)
        {
            ObstacleName = obstacleName;
            PositionX = positionX;
            PositionY = positionY;
            ObstacleSpeed = obstacleSpeed;
            ObstacleSpeedSine = ObstacleSpeedSineEnter;
            ObstacleHeightSine = obstacleHeightSineEnter;
            ObstacleTag = obstacleTag;

            ObstacleSprite = new PictureBox();
            ObstacleSprite.BackColor = Color.Transparent;
            ObstacleSprite.Tag = obstacleTag;
            ObstacleSprite.Name = obstacleName;
            ObstacleSprite.Image = Image.FromFile(obstacleSpriteFilePath);
            ObstacleSprite.Location = new Point(positionX, positionY);
        }

        public virtual void Movement(int score)
        {
            ObstacleSprite.Left -= ObstacleSpeed;
        }

    }
}
