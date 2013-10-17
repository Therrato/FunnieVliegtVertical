using System;
using System.Collections.Generic;
using Assets.Scripts;

public class Result
{
    public float overAllObstacleHitRatio;
    public float overAllBananaRatio;
    public List<LogEvent> data= new List<LogEvent>();
    public List<RoundScore> rounds = new List<RoundScore>();
    
    

    /*
	public Result()
	{

	}*/ 

    public Result(LogSystem LogOfGame)
    {
        data = LogOfGame.getLogList();
        calculateRoundScores();
        
        
    }

    public void calculateRoundScores()
    {
        List<LogEvent> currentRound = new List<LogEvent>();
        int lastRoundNumber = 0;
        foreach (LogEvent a in data)
        {
            if (lastRoundNumber == a.roundNumber)
            {
                currentRound.Add(a);
            }
            if ( a.eventString == "ROUNDEND")
            {
                rounds.Add(new RoundScore(currentRound));
                currentRound = new List<LogEvent>();
                lastRoundNumber++;
                currentRound.Add(a);
            }
        }


    }
    


    

}
