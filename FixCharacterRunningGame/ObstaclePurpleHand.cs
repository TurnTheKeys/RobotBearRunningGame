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

        /// <summary>
        /// Moves purple hand from right to left of screen, speed of obstacle changes based on sine wave
        /// </summary>
        /// <param name="obstacleSpeede">Base speed of obstacle</param>
        public override void Movement(int obstacleSpeede)
        {
            //Manipulate elapsedTime to reduce eraticness of movement path
            //Use Obstaclespeede to change speed (make things more difficult)
            double elapsedTime = ((DateTime.Now - startTime).TotalSeconds) * (obstacleSpeede / 2);

            if (ObstacleSprite == null) { return; }
            int variableSpeed = (int)(Math.Sin((double)(elapsedTime + ObstacleSprite.Width) / ObstacleSpeedSine) * ObstacleHeightSine);
            ObstacleSprite.Left -= (obstacleSpeede + variableSpeed);
        }
    } 
}
