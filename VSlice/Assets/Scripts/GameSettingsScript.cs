using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class GameSettingsScript : MonoBehaviour 
{
	public LevelSettings availableResources;
	
	public bool bananaToggle;
    public bool obstacleToggle;
    public bool monkeyToggle;
    public bool figureToggle;
	
	// Use this for initialization
	void Awake()
	{
		DontDestroyOnLoad(this);
	}	
	

}
