using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class MenuScript : MonoBehaviour 
{
	
	public LevelSettings availableResources;
	public GameSettingsScript gameSettings;

    public GameObject menuHolder;
	
	//private Rect figureButton;
	//private Rect monkeyButton;	
	private Rect tutorialButton;
    private Rect startButton;
	private Rect fiveMinButton;
	private Rect choiceButton;
	private Rect saveSelectionButton;
	
	
	public bool bananaToggle;
    public bool obstacleToggle;
    public bool monkeyToggle;
    public bool figureToggle;

    public int menuDepth;

    private int startCounter = 0;
    private int exitCounter = 0;

   
	
	
	void Awake()
	{
		
	}
	
	void Start () 
	{
		gameSettings = GameObject.Find ("GameSettings").GetComponent<GameSettingsScript>();
        menuHolder = GameObject.Find("menuHolder");

		/*
		//figureButton = new Rect(Screen.width / 2 + 300, Screen.height / 2 - 100, 200, 200);
		//monkeyButton = new Rect(Screen.width / 2 + 100, Screen.height / 2 - 100, 200, 200);
		tutorialButton = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200);
        startButton = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 550, 150);
        fiveMinButton = new Rect(Screen.width / 2 - 300, Screen.height / 2 - 100, 200, 200);
		choiceButton = new Rect(Screen.width / 2 - 500, Screen.height / 2 - 100, 200, 200);
		saveSelectionButton = new Rect(Screen.width / 2 - 100, Screen.height / 2 + 200, 200, 200);
		Debug.Log ("Initiated");
	    */
    }

    void Update()
    {
        depthChecker();

        if (startCounter > 100)
        {
            menuDepth += 1;
            startCounter = 0;
        }

        if (exitCounter > 100)
        {
            Application.Quit();
        }

        Debug.Log("Start counter: " + startCounter);
    }

    void depthChecker()
    {
        switch (menuDepth)
        {
            case 0:

                menuHolder.transform.position = new Vector3(0,0,0);

                break;
            case 1:

                menuHolder.transform.position = new Vector3(100, 0, 0);

                break;
        }
    }


    void OnTriggerStay(Collider collision)
    {
        if (this.name == "StartButton")
        {
           startCounter++;
        }

        if (this.name == "ExitButton")
        {
            exitCounter++;
        }
       

    }
    void OnTriggerExit(Collider collision)
    {
        if (this.name == "StartButton")
        {
            startCounter = 0;
        }

        if (this.name == "ExitButton")
        {
            exitCounter = 0;
        }
    }


	void OnGUI () 
	{
       /* switch (menuDepth)
        {
            case 0:

                if(GUI.Button(startButton, ""))
			    {
                    menuDepth = 1;
			    }
			
			   // if(GUI.Button(fiveMinButton, "5 Minute Mode"))
			  //  {
				//    Debug.Log ("The 5 Minute Mode button is pressed!");	
			   // }
			
			   // if(GUI.Button(choiceButton, "Goal Mode"))
			  //  {
			//	    Debug.Log ("The Choice Mode button is pressed!");
				//    menuDepth = 2;
			//    }	

                break;

            case 1:

                if (GUI.Button(tutorialButton, "Tutorial Mode / N/A"))
			    {
				    Debug.Log ("The Tutorial Mode button is pressed!");	
			    }
			
			    if(GUI.Button(fiveMinButton, "5 Minute Mode / N/A"))
			    {
				    Debug.Log ("The 5 Minute Mode button is pressed!");	
			    }

                if (GUI.Button(choiceButton, "Goal Mode"))
			    {
				    Debug.Log ("The Choice Mode button is pressed!");
				    menuDepth = 2;
			    }	

                break;

            case 2:

                if(GUI.Button(fiveMinButton, "Banana's?"))
			    {
				    gameSettings.bananaToggle = !gameSettings.bananaToggle;
				    Debug.Log ("Banana toggle = " + gameSettings.bananaToggle);
			    }
			
			    if(GUI.Button(choiceButton, "Obstacles?"))
			    {
				    gameSettings.obstacleToggle = !gameSettings.obstacleToggle;
				    Debug.Log ("Obstacle toggle = " + gameSettings.obstacleToggle);
			    }
			 
			    //if(GUI.Button(monkeyButton, "Monkeys?"))
			    //{
			    //	gameSettings.monkeyToggle = !gameSettings.obstacleToggle;
			    //	Debug.Log ("Monkey toggle = " + gameSettings.monkeyToggle);
			    //}
			
			    //if(GUI.Button(figureButton, "Figures?"))
			    //{
			    //    gameSettings.figureToggle = !gameSettings.figureToggle;
			    //    Debug.Log ("Figure toggle = " + gameSettings.figureToggle);
		    	//}
			
			    if(GUI.Button(saveSelectionButton, "Save selection"))
			    {
				    gameSettings.instantiateNewLevelSettings();
				    Application.LoadLevel(1);
			    }

                break;

            case 3:



                break;

        }	*/	
	}
}
