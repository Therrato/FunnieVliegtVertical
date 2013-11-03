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



    public int displayNumber = 0;
    public Texture2D[] BetweenScreens;
    public Texture2D[] EndScreens;

    public bool timerStarted = false;
    public DateTime startcounttime;

    public FunnieMovementScript funnieArmController;
    public FunnieAltMovementScript funnieBodyController;

    public GameSettingsScript settings;

	// Use this for initialization
	void Start () {
        
		GatherBuildSettings();
        worldSpawner = GameObject.Find("World").GetComponent<SpawnWorldScript>();
        funnieArmController = GameObject.Find("ParrotContainer").GetComponent<FunnieMovementScript>();
        funnieBodyController = GameObject.Find("ParrotContainer").GetComponent<FunnieAltMovementScript>();
        settings = GameObject.Find("GameSettings").GetComponent<GameSettingsScript>();


        if (settings.controllerChoice == 1)
        {
            funnieBodyController.enabled = true;
            funnieArmController.enabled = false;
        }
        else
        {
            funnieBodyController.enabled = false;
            funnieArmController.enabled = true;
        }
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
                if (wait15Sec())
                {
                    Application.LoadLevel(1);

                }
                else
                {
                    if (playerStats.roundBananaRatio() >= 0) displayNumber = 0;
                    if (playerStats.roundBananaRatio() > 10) displayNumber = 1;
                    if (playerStats.roundBananaRatio() > 20) displayNumber = 2;
                    if (playerStats.roundBananaRatio() > 30) displayNumber = 3;
                    if (playerStats.roundBananaRatio() > 40) displayNumber = 4;

                    NormalGoal.rounds++;
                    fullScreen.guiTexture.texture = BetweenScreens[displayNumber]; 
                    // display wait round screen
                }

                
            }
            else
            {
                if (wait15Sec())
                {

                    Destroy(GameObject.Find("KinectPointMan"));
                    Destroy(GameObject.Find("KinectPrefab"));
                    Destroy(GameObject.Find("GameSettings"));
                    Application.LoadLevel(0);
                }
                else
                {
                    NormalGoal.rounds++;
                    if (!madeResults)
                    {
                        fullScreen.guiTexture.texture = goodScreen;
                        log = worldSpawner.log;
                        Result results = new Result(log);
                        int c = 0;
                        int[] ratios = new int[results.amountOfRounds*2];
                        foreach (RoundScore r in results.rounds)
                        {
                            ratios[(c * 2)] = r.getPickupRatio();
                            ratios[(c * 2) + 1] = r.getObstacleAvoidedRatio();
                            c++;
                        }
                        madeResults = true;
                        this.gameObject.GetComponent<mono_gmail>().mailStart(ratios,results.rounds[0].getStartTime(),results.totalAmountOfBananas(),results.totalAmountOfFeathers(),results.GetMostHitObstacle());
                       

                    }
                    else
                    {
                        if (playerStats.roundBananaRatio() >= 0) displayNumber = 0;
                        if (playerStats.roundBananaRatio() > 10) displayNumber = 1;
                        if (playerStats.roundBananaRatio() > 20) displayNumber = 2;
                        if (playerStats.roundBananaRatio() > 30) displayNumber = 3;
                        if (playerStats.roundBananaRatio() > 40) displayNumber = 4;

                        fullScreen.guiTexture.texture = EndScreens[displayNumber];
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
            if (DateTime.Now.Subtract(startcounttime).Seconds > 10)
            {
                return true;
            }

        }
        return false;
    }
}