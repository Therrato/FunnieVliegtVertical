using System;
using System.Collections.Generic;
using Assets.Scripts;

public class Result
{
    public float overAllObstacleHitRatio;
    public float overAllBananaRatio;
    public List<LogEvent> data= new List<LogEvent>();
    public List<List<LogEvent>> rounds = new List<List<LogEvent>>();
    

    /*
	public Result()
	{

	}*/ 

    public Result(LogSystem LogOfGame)
    {
        data = LogOfGame.getLogList();
        fillInTables();
        
    }

    public void fillInTables(){
        // canot do this;
        foreach (LogEvent a in data)
        {
            rounds[a.roundNumber].Add(a);
        }
    }

    public int correctionCheck()
    {
        int count = 0 ;
        foreach (List<LogEvent> check in rounds)
        {
            count++;
        }
        return count;
        
    }

}
