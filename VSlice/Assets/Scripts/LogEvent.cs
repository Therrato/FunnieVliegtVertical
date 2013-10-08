using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class LogEvent
    {
        public int roundNumber;
        public DateTime logTime;
        public string eventString;

        /// <summary>
        /// create the event
        /// </summary>
        /// <param name="_round">current round</param>
        /// <param name="_event">what happened</param>
        public LogEvent(int _round, string _event)
        {
            this.roundNumber = _round;
            this.eventString = _event;
            logTime = DateTime.Now;
        }


    }
}
