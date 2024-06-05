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

        /// <summary>
        /// Moves flying egg from right to left of screen in a sine wave pattern based on time elapsed
        /// </summary>
        /// <param name="obstacleSpeede">movement of eff from to left of screen</param>
        public override void Movement(int obstacleSpeede)
        {
            //Manipulate elapsedTime to reduce eraticness of movement path
            //Use Obstaclespeede to change speed (make things more difficult)
            double elapsedTime = ((DateTime.Now - startTime).TotalSeconds)*(obstacleSpeede/2);

            if (ObstacleSprite == null) { return; }
            ObstacleSprite.Left -= (obstacleSpeede + 2);

            double sineValue = Math.Sin((double)(elapsedTime) / ObstacleSpeedSine);
            ObstacleSprite.Top = (int)(sineValue * ObstacleHeightSine) + PositionY;
        }
    } 
}
