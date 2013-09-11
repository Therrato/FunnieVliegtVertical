using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    //Roy First Init 11-9-2013 02:04
    class Stats
    {
        #region privates

        private int _bananas;
        private int _obstaclesPassed;
        private int _obstaclesHit;
        private int _feathersCollected;

  
        

        #endregion

        #region Publics

        public int duration;
        

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


        public Stats()
        {
            
        }

 
        
    }
}
