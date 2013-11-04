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
            this.tilesPassed = playerGoals.tilesPassed;

        }

        public Goal(Stats playerGoals, int roundsLeft)
        {
            this.bananas = playerGoals.bananas;
            this.obstaclesPassed = playerGoals.obstaclesPassed;
            this.feathersCollected = playerGoals.feathersCollected;
            this.duration = playerGoals.duration;
            this.figuresPassed = playerGoals.figuresPassed;
            this.obstaclesHit = playerGoals.obstaclesHit;
            this.tilesPassed = playerGoals.tilesPassed;
            this.rounds = roundsLeft;
        }

        /// <summary>
        /// will check if all requerements for ending thelevel are met
        /// </summary>
        /// <param name="playerStats">give the current stats of the player</param>
        /// <returns>when true requeirements are met</returns>
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
            if (this.tilesPassed > playerStats.tilesPassed) return false;

            return true;
        }

        public bool nextLevel()
        {
            this.rounds--;
            if (this.rounds == 0) return false;
            else return true;

        }





        public int getPercentageReachedBananas(PlayerStats p)
        {
            return p.bananas * (this.bananas / 100);

        }
        /// <summary>
        ///  in case of 5 min mode
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int getBarInt(PlayerStats p)
        {
            return p.bananas;
        }
    }
    

}
