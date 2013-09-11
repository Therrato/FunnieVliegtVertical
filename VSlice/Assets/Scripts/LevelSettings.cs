using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace Assets.Scripts
{
    
    public class LevelSettings
    {
        // if true they can be used
        public bool bananas;
        public bool obstacles;
        public bool monkeys;
        public bool figures;

        public Goal gameGoal;
        
        //
        // allow banana's by setting true;
        //
        public LevelSettings(bool bannanaOn, bool obstacleOn, bool monkeysOn,bool figuresOn, Goal playerGoal )
        {
            bananas = bannanaOn;
            obstacles = obstacleOn;
            monkeys = monkeysOn;
            figures = figuresOn;

            
        }

    }
}
