using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class PlayerStats :Stats
    {
        private DateTime beginTime;

        public PlayerStats()
        {
            beginTime = DateTime.Now;
        }

        public int calculateRunTime()
        {
            TimeSpan runtime = DateTime.Now.Subtract(beginTime);
            return runtime.Seconds;
        }
    }
}
