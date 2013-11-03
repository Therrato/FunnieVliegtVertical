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
    public int tutorialCounter = 0;

    public int saveSettings = 0;

    public int backCounter = 0;

    public LevelSettings availableResources;
    public GameSettingsScript gameSettings;

    public MenuMovement cursor;

    public GUITexture backgroundHolder;
    public Texture2D startScreen;
    public Texture2D gamemodeScreen;
    public Texture2D choiceScreen;
    public Texture2D creditScreen;
    public Texture2D helpScreen;

    public int menuDepth;


   
	// Use this for initialization
	void Start ()
    {
        gameSettings = GameObject.Find("GameSettings").GetComponent<GameSettingsScript>();
        backgroundHolder = GameObject.Find("Background").GetComponent<GUITexture>();
        cursor = GameObject.Find("HandPointer").GetComponent<MenuMovement>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        cursorCheck();
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

        if (tutorialCounter > 100)
        {
            Application.LoadLevel(2);
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

    void cursorCheck()
    {

        if (startCounter <= 25 &&
            goalCounter <= 25 &&
            minutesModeCounter <= 25 &&
            helpCounter <= 25 &&
            creditsCounter <= 25 &&
            exitCounter <= 25 &&
            backCounter <= 25 &&
            tutorialCounter <= 25 &&
            saveSettings <= 25)
        {
            cursor.aTexture = cursor.emptyCursor;

            return;
        }

        if (startCounter <= 50 && 
            goalCounter <= 50 && 
            minutesModeCounter <= 50 && 
            helpCounter <= 50 && 
            creditsCounter <= 50 &&
            exitCounter <= 50 &&
            backCounter <= 50 &&
            tutorialCounter <= 50 &&
            saveSettings <= 50)
        {
            cursor.aTexture = cursor.phase1Cursor;
            return;
        }
        if (startCounter <= 75 &&
            goalCounter <= 75 &&
            minutesModeCounter <= 75&&
            helpCounter <= 75 &&
            creditsCounter <= 75 &&
            exitCounter <= 75 &&
            backCounter <= 75 &&
            tutorialCounter <= 75 &&
            saveSettings <= 75)
        {
            cursor.aTexture = cursor.phase2Cursor;
            return;
        }
        if (startCounter <= 100 &&
            goalCounter <= 100 &&
            minutesModeCounter <= 100 &&
            helpCounter <= 100 &&
            creditsCounter <= 100 &&
            exitCounter <= 100 &&
            backCounter <= 100 &&
            tutorialCounter <= 100 &&
            saveSettings <= 100)
        {
            cursor.aTexture = cursor.phase3Cursor;
            return;
        }


    }

    void startGame()
    {
        // set goal mode  1 round
        gameSettings.onDepth = false;
        gameSettings.onSettingsDepth = false;
        gameSettings.createNewGoal();
        gameSettings.instantiateNewLevelSettings();
        Debug.Log("Load Goal mode");
        Application.LoadLevel(1);
    }

    void start5MinuteMode()
    {
        gameSettings.create5Minute();
        gameSettings.instantiateNewLevelSettings();
        
        Debug.Log("Load 5min");
        Application.LoadLevel(1);

    }


    void depthChecker()
    {
        switch (menuDepth)
        {
            case 0:

                this.transform.position = new Vector3(0, 0, 0);
                backgroundHolder.guiTexture.texture = startScreen;
                gameSettings.onDepth = false;
                gameSettings.onSettingsDepth = false;
                break;
            case 1:

                this.transform.position = new Vector3(100, 0, 0);
                backgroundHolder.guiTexture.texture = gamemodeScreen;
                gameSettings.onDepth = false;
                gameSettings.onSettingsDepth = false;
                break;

            case 2:

                this.transform.position = new Vector3(200, 0, 0);
                backgroundHolder.guiTexture.texture = choiceScreen;
                gameSettings.onDepth = true;
                gameSettings.onSettingsDepth = false;

                break;
            case 3:

                this.transform.position = new Vector3(0, 100, 0);
                backgroundHolder.guiTexture.texture = creditScreen;
                gameSettings.onDepth = false;
                gameSettings.onSettingsDepth = false;
                break;

            case 4:

                this.transform.position = new Vector3(0, 200, 0);
                backgroundHolder.guiTexture.texture = helpScreen;
                gameSettings.onDepth = false;
                gameSettings.onSettingsDepth = true;
                break;
        }
    }
}
