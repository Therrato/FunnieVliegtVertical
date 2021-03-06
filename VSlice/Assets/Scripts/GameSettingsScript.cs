using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class GameSettingsScript : MonoBehaviour 
{
	public LevelSettings availableResources;
    public ItemSpawner itemSpawner;
	
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

    private string bananaText = "10";
    private string feathersText = "5";
    private string timeText = "45";

    public int controllerChoice = 0;
	private int controllerOverride = 0;
    private string controllerText = "1";

    public int settingsDifficulty = 0;
	private int difficultyOverride = 0;
    private string settingsText = "1";

    public bool sendEmail = true;
    public string emailAddress = "jeroen.van.dragt@gmail.com";
    private string mail;

    public bool onDepth = false;
    public bool onSettingsDepth = false;
    //public int roundsLeft;
    public Goal goalToreach = new Goal();

    public Transform[] goals;
    public Transform[] settings;
    public Camera camera;

    public Vector3 screenPos1;
    public Vector3 screenPos2;
    public Vector3 screenPos3;

    public Vector3 settingsPos1;
    public Vector3 settingsPos2;
    public Vector3 settingsPos3;
    public Vector3 settingsPos4;

    public GUISkin customSkin;


	
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
        goalToreach = new Goal(new Stats(bannanasGoal,obstaclesPassedGoal,feathersGoal,figuresPassedGoal,timeGoal),1);

    }
    public void create5Minute()
    {
       
        goalToreach = new Goal(new Stats(),5);

    }

    void Update()
    {
        int.TryParse(settingsText, out difficultyOverride);
        int.TryParse(controllerText, out controllerOverride);
        int.TryParse(bananaText, out bannanasGoal);
        int.TryParse(feathersText, out feathersGoal);
        int.TryParse(timeText, out timeGoal);
		
		if(difficultyOverride == 1)
		{
			settingsDifficulty = 0;
		}
		else if(difficultyOverride == 2)
		{
			settingsDifficulty = 1;
		}
		else if(difficultyOverride == 3)
		{
			settingsDifficulty = 2;
		}


        if (controllerOverride == 1)
        {
            controllerChoice = 0;
        }
        else if (controllerOverride == 2)
        {
            controllerChoice = 1;
        }

        //settingsDifficulty = int.Parse("" + settingsText) - 1;
        //controllerChoice = int.Parse("" + controllerText) - 1;
        
        settingsDifficulty = Mathf.Clamp(settingsDifficulty, 0, 2);
		difficultyOverride = Mathf.Clamp(difficultyOverride, 1, 3);
        controllerOverride = Mathf.Clamp(controllerOverride, 1, 2);
		controllerChoice = Mathf.Clamp(controllerChoice, 0, 1);
        timeGoal = Mathf.Clamp(timeGoal, 0, 300);
        feathersGoal = Mathf.Clamp(feathersGoal, 0, 50);
        bannanasGoal = Mathf.Clamp(bannanasGoal, 0, 50);


        if (sendEmail)
        {
            mail = "Ja";
        }
        else
        {
            mail = "Nee";
        }

        
        if (onDepth)
        {
            //Get Position of the Object
            screenPos1 = camera.WorldToScreenPoint(goals[0].position);
            screenPos2 = camera.WorldToScreenPoint(goals[1].position);
            screenPos3 = camera.WorldToScreenPoint(goals[2].position);

                
            screenPos1.y = Screen.height - (screenPos1.y + 1);
            screenPos2.y = Screen.height - (screenPos2.y + 1);
            screenPos3.y = Screen.height - (screenPos3.y + 1);
        }

        if (onSettingsDepth)
        {
            //Get Position of the Object
            settingsPos1 = camera.WorldToScreenPoint(settings[0].position);
            settingsPos2 = camera.WorldToScreenPoint(settings[1].position);
            settingsPos3 = camera.WorldToScreenPoint(settings[2].position);
            settingsPos4 = camera.WorldToScreenPoint(settings[3].position);
            //Get inverse of y-position 
            settingsPos1.y = Screen.height - (settingsPos1.y + 1);
            settingsPos2.y = Screen.height - (settingsPos2.y + 1);
            settingsPos3.y = Screen.height - (settingsPos3.y + 1);
            settingsPos4.y = Screen.height - (settingsPos4.y + 1);
        }

        if (Application.loadedLevel == 0)
        {
            return;
        }
        else if (Application.loadedLevel == 1)
        {
            itemSpawner = GameObject.Find("World").GetComponent<ItemSpawner>();
            itemSpawner.dificulty = settingsDifficulty;
        }
    }

    public void OnGUI()
    {
        GUI.skin = customSkin;
        if (onDepth)
        {

            /*Vector3 screenPos1 = camera.WorldToScreenPoint(goals[0].position);
            Vector3 screenPos2 = camera.WorldToScreenPoint(goals[1].position);
            Vector3 screenPos3 = camera.WorldToScreenPoint(goals[2].position);*/

            GUI.depth = 0;
            bananaText = GUI.TextField(new Rect((Screen.width / 2)-32.5f, screenPos1.y - 25, 75, 75), bananaText);
            feathersText = GUI.TextField(new Rect((Screen.width / 2) - 32.5f, screenPos2.y - 25, 75, 75), feathersText);
            timeText = GUI.TextField(new Rect((Screen.width / 2) - 32.5f, screenPos3.y - 25, 75, 75), timeText);
        }

        if (onSettingsDepth)
        {
            GUI.depth = 0;
            emailAddress = GUI.TextField(new Rect(settingsPos4.x, settingsPos4.y, 400, 75), emailAddress);
            controllerText = GUI.TextField(new Rect(settingsPos1.x, settingsPos1.y, 75, 75), controllerText);
            settingsText = GUI.TextField(new Rect(settingsPos2.x, settingsPos2.y, 75, 75), settingsText);
          //  GUI.Label(new Rect(settingsPos3.x, settingsPos3.y, 200, 200), "" + mail);
            if(GUI.Button(new Rect(settingsPos3.x, settingsPos3.y, 165, 100), "" + mail))
            {
                sendEmail = !sendEmail;
            }
        }

    }


    


}
