using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixCharacterRunningGame
{
    public class PurpleHand : Obstacle
    {
        public PurpleHand(int positionX, int positionY, int obstacleSpeed, int ObstacleSpeedSineEnter, int obstacleHeightSineEnter)
            : base("purpleHandfresh", positionX, positionY, obstacleSpeed, ObstacleSpeedSineEnter, obstacleHeightSineEnter, "ObstaclesOOD", Properties.Resources.obstacle_1)
        {
        }

        public override void Movement(int obstacleSpeede)
        {
            int variableSpeed = (int)(Math.Sin((double)(ObstacleSprite.Left + ObstacleSprite.Width) / ObstacleSpeedSine) * ObstacleHeightSine);
            ObstacleSprite.Left -= (obstacleSpeede + variableSpeed);
            ObstacleSprite.Left -= (obstacleSpeede + 2);
        }
    } 
}
