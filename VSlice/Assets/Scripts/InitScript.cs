using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class InitScript : MonoBehaviour {

    private Goal NormalGoal;
    public PlayerStats playerStats;
    public int runtime;
	// Use this for initialization
	void Start () {
		GatherBuildSettings();
       
	}
	
	// Update is called once per frame
	void Update () {
        runtime = playerStats.calculateRunTime();
        if (NormalGoal.isGoalReached(playerStats)) Debug.Log("45 sec expired");
	}
	
	void GatherBuildSettings(){
        NormalGoal = new Goal();
        playerStats = new PlayerStats();
	}
}
