using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    //Roy First Init 11-9-2013 02:04
    public class Stats
    {
       
        #region privates

        private int _bananas;
        private int _obstaclesPassed;
        private int _obstaclesHit;
        private int _feathersCollected;
        private int _figuresPassed;
        private int _tilesPassed;

        public int tilesPassed
        {
            get { return _tilesPassed; }
            set { _tilesPassed = value; }
        }
        
        public int duration;
  
        

        #endregion

        #region Publics

        
         public int figuresPassed
        {
            get { return _figuresPassed; }
            set { _figuresPassed = value; }
        }
        public int feathersCollected
        {
            get { return _feathersCollected; }
            set { _feathersCollected = value; }
        }
        public int obstaclesHit
        {
            get { return _obstaclesHit; }
            set { _obstaclesHit = value; }
        }
        public int obstaclesPassed
        {
            get { return _obstaclesPassed; }
            set { _obstaclesPassed = value; }
        }
        public int bananas
        {
            get { return _bananas; }
            set { _bananas = value; }
        }

        #endregion

      /// <summary>
      /// this well set the stats incase its needed for the goal
      /// </summary>
      /// <param name="bananasToCollect">amount of bananas needed to end level</param>
        /// <param name="oblstaclesToPass">amount of obstacles passed to end level</param>
        /// <param name="feathersToCollect">amount of Feathers needed to end level</param>
        /// <param name="figuresToPass">amount of Figures needed to end level</param>
        /// <param name="secondsToPlay">amount of set duration of the run</param>
        public Stats(int bananasToCollect,int oblstaclesToPass, int feathersToCollect, int figuresToPass,int secondsToPlay)
        {
            bananas = bananasToCollect;
            _obstaclesPassed = oblstaclesToPass;
            _feathersCollected = feathersToCollect;
            _figuresPassed = figuresToPass;
            duration = secondsToPlay;
        }

        public Stats()
        {

        }

 
        
    }
}
