using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;

public class LogSystem : MonoBehaviour {
    private List<LogEvent> loggedEvents; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void pushEvent(LogEvent newEvent)
    {
        loggedEvents.Add(newEvent);
    }

    public List<LogEvent> getLogList()
    {
        return loggedEvents;
    }
}
