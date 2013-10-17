using System;
using System.Collections.Generic;
using Assets.Scripts;

namespace Assets.Scripts
{
    public class RoundScore
    {
        List<LogEvent> logsOfRound;
        int allBananasPickedUp = 0;
        int allBananasMissed = 0;
        int allObstaclesHit = 0;
        int allObstaclesPassed = 0;
        DateTime roundStart;
        DateTime roundEnd;

        


        public RoundScore(List<LogEvent> _roundLog)
        {
            logsOfRound = _roundLog;

            foreach (LogEvent ev in logsOfRound)
            {
                if (ev.eventString == "STARTROUND") roundStart = ev.logTime;
                else if (ev.eventString == "ROUNDEND") roundEnd = ev.logTime;
                else if (ev.eventString.Contains("HITOBJECT")){
                    allObstaclesHit++;

                }
                else if (ev.eventString.Contains("PASSEDOBJECT"))
                {
                    allObstaclesPassed++;
                }
                else if (ev.eventString.Contains("MISSED")){
                    if (ev.eventString == "BANANAMISSED") allBananasMissed++;
                    
                }
                else if (ev.eventString.Contains("PICKUP"))
                {
                    if (ev.eventString == "BANANAPICKUP") allBananasPickedUp++;

                }
            }
            
        }

        public float getPickupRatio()
        {
            return 100.0f;
            //return allBananasPickedUp / (allBananasMissed + allBananasPickedUp / 100);
        }
        public float getObstacleAvoidedRatio()
        {
            return 132.0f;
            //return allObstaclesPassed / (allObstaclesHit + allObstaclesPassed / 100);
        }
    }
}