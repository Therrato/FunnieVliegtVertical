using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class Goal : Stats
    {
       

        public Goal()
        {
            this.duration = 45;
        }

        public Goal(Stats playerGoals){
            this.bananas = playerGoals.bananas;
            this.obstaclesPassed = playerGoals.obstaclesPassed;
            this.feathersCollected = playerGoals.feathersCollected;
            this.duration = playerGoals.duration;
            this.figuresPassed = playerGoals.figuresPassed;
            this.obstaclesHit = playerGoals.obstaclesHit;

        }


        public bool isGoalReached(PlayerStats playerStats)
        {
            if (this.duration != 0)
            {
                if (this.duration > playerStats.calculateRunTime()) return false;
            }
            if (this.bananas > playerStats.bananas) return false;
            if (this.feathersCollected > playerStats.feathersCollected) return false;
            if (this.figuresPassed > playerStats.figuresPassed) return false;
            if (this.obstaclesHit > playerStats.obstaclesHit) return false;
            if (this.obstaclesPassed > playerStats.obstaclesPassed) return false;

            return true;
        }

        


    }
    

}
