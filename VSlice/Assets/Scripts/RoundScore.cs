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
        int amountOfBananas = 0;
        int amountOfObstacles = 0;
        public int[] obstacleHitSortedByKind = new int[4]{0,0,0,0};
        DateTime roundStart;
        DateTime roundEnd;

        


        public RoundScore(List<LogEvent> _roundLog)
        {
            logsOfRound = _roundLog;

            foreach (LogEvent ev in logsOfRound)
            {
                if (ev.eventString == "STARTROUND") roundStart = ev.logTime;
                else if (ev.eventString == "ROUNDEND") roundEnd = ev.logTime;
                
                if (ev.eventString.Contains("HITOBJECT")){
                    allObstaclesHit++;

                }
                else if (ev.eventString.Contains("PASSEDOBJECT"))
                {
                    allObstaclesPassed++;
                }
                if (ev.eventString.Contains("OBJECT"))
                {
                    amountOfObstacles++;
                    if (ev.eventString.Contains("PASSEDOBJECT")) allObstaclesPassed++;
                    if (ev.eventString.Contains("HITOBJECT"))
                    {
                        allObstaclesHit++;
                        if (ev.eventString.Contains("BAMBOO")) obstacleHitSortedByKind[0]++;
                        if (ev.eventString.Contains("LEAF")) obstacleHitSortedByKind[1]++;
                        if (ev.eventString.Contains("ROCK")) obstacleHitSortedByKind[2]++;
                        if (ev.eventString.Contains("VINE")) obstacleHitSortedByKind[3]++;
                    }

                }


                if (ev.eventString.Contains("BANANA")){
                    amountOfBananas++;
                    if (ev.eventString == "BANANAMISSED") allBananasMissed++;
                    if (ev.eventString == "BANANAPICKUP") allBananasPickedUp++;
                    
                }
            }
            
        }

        public int getPickupRatio()
        {
            
            return allBananasPickedUp * (100/amountOfBananas);
        }
        public int getObstacleAvoidedRatio()
        {
            
            return allObstaclesPassed * (100/(allObstaclesHit + allObstaclesPassed));
        }
       

        public DateTime getStartTime()
        {
            return roundStart;
        }
    }
}