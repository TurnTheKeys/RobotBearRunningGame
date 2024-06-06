using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixCharacterRunningGame
{
    public class Umbrella : Obstacle
    {
        public Umbrella(int positionX, int positionY, int obstacleSpeed, int ObstacleSpeedSineEnter, int obstacleHeightSineEnter)
            : base("purpleHandfresh", positionX, positionY, obstacleSpeed, ObstacleSpeedSineEnter, obstacleHeightSineEnter, "ObstaclesOOD", Properties.Resources.obstacle_2)
        {
        }

        /// <summary>
        /// Moves umbrella from right to left of screen
        /// </summary>
        /// <param name="obstacleSpeede">Base speed of obstacle</param>
        public override void Movement(int obstacleSpeede)
        {
            //Manipulate elapsedTime to reduce eraticness of movement path
            //Use Obstaclespeede to change speed (make things more difficult)

            if (ObstacleSprite == null) { return; }

            ObstacleSprite.Left -= obstacleSpeede;
        }

    } 
}
