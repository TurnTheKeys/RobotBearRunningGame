using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixCharacterRunningGame
{
    public class FlyingEgg : Obstacle
    {
        public FlyingEgg(int positionX, int positionY, int obstacleSpeed, int ObstacleSpeedSineEnter, int obstacleHeightSineEnter)
            : base("flyingEgg", positionX, positionY, obstacleSpeed, ObstacleSpeedSineEnter, obstacleHeightSineEnter,  "Obstacles", "path_to_your_image_file")
        {
        }

        public override void Movement(int score)
        {
            if (score > 10)
            {
                ObstacleSprite.Left -= (ObstacleSpeed + 2);
                ObstacleSprite.Top = (int)(Math.Sin((double)(ObstacleSprite.Left + ObstacleSprite.Width) / ObstacleSpeedSine) * ObstacleHeightSine) + 200;
            }
        }
    } 
}
