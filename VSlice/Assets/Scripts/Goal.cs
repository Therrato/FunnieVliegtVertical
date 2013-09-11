using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class Goal : Stats
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

        }

        public bool isGoalReached(PlayerStats playerStats)
        {
            if (this.duration != 0)
            {
                if (this.duration < playerStats.calculateRunTime()) return true;
            }

            return false;
        }

        


    }
    

}
