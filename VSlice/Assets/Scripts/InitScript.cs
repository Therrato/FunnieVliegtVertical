using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class InitScript : MonoBehaviour {

    private Goal NormalGoal;
    public PlayerStats playerStats;
    public int runtime;
    public SpawnWorldScript worldSpawner;
    public LogSystem log;
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
                Application.LoadLevel(1);
            }
            else
            {
                Debug.Log("0 rounds left game should end");
                log = worldSpawner.log;
                Result results = new Result(log);
                Debug.Log(results.correctionCheck());

                Application.LoadLevel(0);
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
}