using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class MenuHandler : MonoBehaviour 
{

    public int startCounter = 0;
    public int goalCounter = 0;
    public int minutesModeCounter = 0;
    public int helpCounter = 0;
    public int creditsCounter = 0;
    public int exitCounter = 0;

    public int saveSettings = 0;

    public int backCounter = 0;

    public LevelSettings availableResources;
    public GameSettingsScript gameSettings;

    public int menuDepth;

	// Use this for initialization
	void Start ()
    {
        gameSettings = GameObject.Find("GameSettings").GetComponent<GameSettingsScript>();
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        depthChecker();
        if (startCounter > 100)
        {
            menuDepth = 1;
            startCounter = 0;
        }

        if (goalCounter > 100)
        {
            menuDepth = 2;
            goalCounter = 0;
        }

        if (creditsCounter > 100)
        {
            menuDepth = 3;
            creditsCounter = 0;
        }

        if (helpCounter > 100)
        {
            menuDepth = 4;
            helpCounter = 0;
        }

        if (exitCounter > 100)
        {
            Application.Quit();
        }

        if (backCounter > 100)
        {
            if (menuDepth == 3 || menuDepth == 4)
            {
                menuDepth = 0;
            }
            else
            {
                menuDepth -= 1;
            }
            
            backCounter = 0;
        }

        if (saveSettings > 100)
        {
            startGame();
        }

        if (minutesModeCounter > 100)
        {
            start5MinuteMode();
        }


	}

    void startGame()
    {
        // set goal mode  1 round
        gameSettings.createNewGoal();
        gameSettings.instantiateNewLevelSettings();
        Debug.Log("Load level");
        Application.LoadLevel(1);
    }

    void start5MinuteMode()
    {
        // start 5 minute mode, 
    }


    void depthChecker()
    {
        switch (menuDepth)
        {
            case 0:

               this.transform.position = new Vector3(0, 0, 0);

                break;
            case 1:

                this.transform.position = new Vector3(100, 0, 0);

                break;

            case 2:

                this.transform.position = new Vector3(200, 0, 0);

                break;
            case 3:

                this.transform.position = new Vector3(0, 100, 0);

                break;

            case 4:

                this.transform.position = new Vector3(0, 200, 0);

                break;
        }
    }
}
