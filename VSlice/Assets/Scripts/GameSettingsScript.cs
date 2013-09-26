using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class GameSettingsScript : MonoBehaviour 
{
	public LevelSettings availableResources;
	
	public bool bananaToggle = true;
    public bool obstacleToggle = true;
    public bool monkeyToggle;
    public bool figureToggle;

    // goal information
    public int bannanasGoal;
    public int figuresPassedGoal;
    public int obstaclesPassedGoal;
    public int timeGoal;
    public int feathersGoal;
    public Goal goalToreach = new Goal();


	
	// Use this for initialization
	void Awake()
	{
        timeGoal = 45;
		DontDestroyOnLoad(this);
	}	
	
	public void instantiateNewLevelSettings()
	{
		availableResources = new LevelSettings(bananaToggle,obstacleToggle,monkeyToggle,figureToggle, goalToreach);	
	}
    /// <summary>
    /// run this function to create a store the added values to the goal.
    /// </summary>
    public void createNewGoal()
    {
        goalToreach = new Goal(new Stats(bannanasGoal,obstaclesPassedGoal,feathersGoal,figuresPassedGoal,timeGoal));
        
       

    }

}
