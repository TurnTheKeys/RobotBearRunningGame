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
            : base("flyingEggfresh", positionX, positionY, obstacleSpeed, ObstacleSpeedSineEnter, obstacleHeightSineEnter,  "ObstaclesOOD", Properties.Resources.FlyingEgg)
        {
        }

        public override void Movement(int obstacleSpeede)
        {
            ObstacleSprite.Left -= (obstacleSpeede + 2);
            ObstacleSprite.Top = (int)(Math.Sin((double)(ObstacleSprite.Left + ObstacleSprite.Width) / ObstacleSpeedSine) * ObstacleHeightSine) + 200;
        }
    } 
}
