using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System;

public class InitScript : MonoBehaviour {

    private Goal NormalGoal;
    public PlayerStats playerStats;
    public int runtime;
    public SpawnWorldScript worldSpawner;
    public LogSystem log;

    public bool madeResults = false;

    public GameObject fullScreen;
    public Texture2D waitScreen;
    public Texture2D goodScreen;

    public bool timerStarted = false;
    public DateTime startcounttime;

	// Use this for initialization
	void Start () {
		GatherBuildSettings();
        worldSpawner = GameObject.Find("World").GetComponent<SpawnWorldScript>();
        if (GameObject.Find("LogSys(Clone)") == null)
        {
           GameObject log = Instantiate(Resources.Load("LogSys")) as GameObject;
        }
       
	}
	
	// Update is called once per frame
	void Update () {
        if (!worldSpawner.goalReached)worldSpawner.setGoalReached(NormalGoal.isGoalReached(playerStats));
        if (worldSpawner.endTileReached)
        {
            if (NormalGoal.nextLevel())
            {
                Debug.Log(NormalGoal.rounds + " roundsLeft");
                if (wait15Sec())
                {
                    Application.LoadLevel(1);
                }
                else
                {
                    NormalGoal.rounds++;
                    fullScreen.guiTexture.texture = waitScreen;
                    // display wait round screen
                }

                
            }
            else
            {
                if (wait15Sec())
                {


                 
                    Application.LoadLevel(0);
                }
                else
                {
                    NormalGoal.rounds++;
                    if (!madeResults)
                    {
                        
                        Debug.Log("0 rounds left game should end");
                        log = worldSpawner.log;
                        Result results = new Result(log);
                        int c = 0;
                        foreach (RoundScore r in results.rounds)
                        {
                            Debug.Log(c + "banana pickupRatio : " + r.getPickupRatio() + " obstacle avoided Ratio : " + r.getObstacleAvoidedRatio());
                            c++;
                        }
                        madeResults = true;
                        this.gameObject.GetComponent<mono_gmail>().mailStart();

                    }
                    else
                    {
                        fullScreen.guiTexture.texture = goodScreen;
                        // goed gedaan screen
                    }
                }
            }
         
        }
	}
	
	void GatherBuildSettings(){
        NormalGoal = GameObject.Find("GameSettings").GetComponent<GameSettingsScript>().goalToreach;
        playerStats = new PlayerStats();
	}

    public int getRound()
    {
        return 5 - NormalGoal.rounds;
    }

    public bool wait15Sec()
    {
        if (timerStarted == false)
        {
            startcounttime = DateTime.Now;
            timerStarted = true;

        }
        else
        {
            if (DateTime.Now.Subtract(startcounttime).Seconds > 15)
            {
                return true;
            }

        }
        return false;
    }
}