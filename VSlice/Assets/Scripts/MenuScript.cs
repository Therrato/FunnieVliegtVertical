using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class MenuScript : MonoBehaviour 
{
	
	public LevelSettings availableResources;
	public GameSettingsScript gameSettings;
	
	//private Rect figureButton;
	//private Rect monkeyButton;	
	private Rect tutorialButton;
	private Rect fiveMinButton;
	private Rect choiceButton;
	private Rect saveSelectionButton;
	
	
	public bool bananaToggle;
    public bool obstacleToggle;
    public bool monkeyToggle;
    public bool figureToggle;

    public int menuDepth;
	
	
	void Awake()
	{
		
	}
	
	void Start () 
	{
		gameSettings = GameObject.Find ("GameSettings").GetComponent<GameSettingsScript>();
		
		//figureButton = new Rect(Screen.width / 2 + 300, Screen.height / 2 - 100, 200, 200);
		//monkeyButton = new Rect(Screen.width / 2 + 100, Screen.height / 2 - 100, 200, 200);
		tutorialButton = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200);
        fiveMinButton = new Rect(Screen.width / 2 - 300, Screen.height / 2 - 100, 200, 200);
		choiceButton = new Rect(Screen.width / 2 - 500, Screen.height / 2 - 100, 200, 200);
		saveSelectionButton = new Rect(Screen.width / 2 - 100, Screen.height / 2 + 200, 200, 200);
		Debug.Log ("Initiated");
	
    }


	void OnGUI () 
	{
        switch (menuDepth)
        {
            case 0:

                if(GUI.Button(new Rect(800,350,550,150), "",GUIStyle.none))
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

                if(GUI.Button(tutorialButton, "Tutorial Mode"))
			    {
				    Debug.Log ("The Tutorial Mode button is pressed!");	
			    }
			
			    if(GUI.Button(fiveMinButton, "5 Minute Mode"))
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

        }		
	}
}
