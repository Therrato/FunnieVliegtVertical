using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class PlayerStats :Stats
    {
        private DateTime beginTime;

        public PlayerStats()
        {
            setNewBeginTime();
        }

        public int calculateRunTime()
        {
            TimeSpan runtime = DateTime.Now.Subtract(beginTime);
            return runtime.Seconds;
        }

        public void setNewBeginTime()
        {
            beginTime = DateTime.Now;
        }

        public int roundBananaRatio()
        {
            return this.bananas*(100/(this.bananas+this.bananasMissed));
           
        }
    }
}
