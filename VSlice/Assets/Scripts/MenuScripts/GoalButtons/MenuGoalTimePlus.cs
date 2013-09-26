using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class MenuGoalTimePlus : MonoBehaviour
{

    private GameSettingsScript gameSettings;
    private float lastUpdate;
    private bool touch;

    // Use this for initialization
    void Start()
    {
        gameSettings = GameObject.Find("GameSettings").GetComponent<GameSettingsScript>();
    }

    void Update()
    {
        if (touch)
        {

            if (Time.time - lastUpdate >= 1f)
            {
                gameSettings.timeGoal += 5;
                Debug.Log("Time goal: " + gameSettings.timeGoal);
                lastUpdate = Time.time;
            }
        }
    }

    // Update is called once per frame
    void OnTriggerEnter()
    {
        touch = true;
    }

    void OnTriggerExit()
    {
        touch = false;
    }
}
