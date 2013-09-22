using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class InitScript : MonoBehaviour {

    private Goal NormalGoal;
    public PlayerStats playerStats;
    public int runtime;
    public SpawnWorldScript worldSpawner;
	// Use this for initialization
	void Start () {
		GatherBuildSettings();
        worldSpawner = GameObject.Find("World").GetComponent<SpawnWorldScript>();
       
	}
	
	// Update is called once per frame
	void Update () {
        if (!worldSpawner.goalReached)worldSpawner.setGoalReached(NormalGoal.isGoalReached(playerStats));
	}
	
	void GatherBuildSettings(){
        NormalGoal = new Goal();
        playerStats = new PlayerStats();
	}
}