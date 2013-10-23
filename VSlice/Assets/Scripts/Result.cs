using System;
using System.Collections.Generic;
using Assets.Scripts;

public class Result
{
    public float overAllObstacleHitRatio;
    public float overAllBananaRatio;
    public int amountOfRounds = 0;
    public List<LogEvent> data= new List<LogEvent>();
    public List<RoundScore> rounds = new List<RoundScore>();
    
    

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
                amountOfRounds++;
                currentRound.Add(a);
            }
        }
    }

    public int totalAmountOfBananas()
    {
        int taob = 0;
            foreach (RoundScore r in rounds){
                taob += r.getAmountOfBananasCollectedInRound();
            }
        return taob;
    }

    public int totalAmountOfFeathers()
    {
        int taof = 0;
        foreach (RoundScore r in rounds)
        {
            taof += r.getAmountOfFeathersCollectedInRound();
        }
        return taof;
    }

    public string GetMostHitObstacle()
    {
        int[] HitSortedByKind = new int[4]{0,0,0,0};
            

        foreach ( RoundScore r in rounds){
            HitSortedByKind[0]+=r.obstacleHitSortedByKind[0]; 
            HitSortedByKind[1]+=r.obstacleHitSortedByKind[1]; 
            HitSortedByKind[2]+=r.obstacleHitSortedByKind[2]; 
            HitSortedByKind[3]+=r.obstacleHitSortedByKind[3]; 
            }

        int MostHitted=0;
        int val = 0;
        for (int i = 0; i <HitSortedByKind.Length;i++){
            if (val < HitSortedByKind[i])
            {
                val = HitSortedByKind[i];
                MostHitted = i;
            }
        }

        if (MostHitted == 0) return "de bamboo plant";
        if (MostHitted == 1) return "het bananenblad";
        if (MostHitted == 2) return "de steen";
        if (MostHitted == 3) return "de liaan";

        return "niets geraakt";
        }
            
   }

