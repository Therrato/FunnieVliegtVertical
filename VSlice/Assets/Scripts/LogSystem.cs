using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;

public class LogSystem : MonoBehaviour {
    private List<LogEvent> loggedEvents = new List<LogEvent>();
    private InitScript gameInfo;
    

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        gameInfo = GameObject.Find("InitHolder").GetComponent<InitScript>();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        /*
        int count = 0;
        foreach (LogEvent a in loggedEvents)
        {
            count++;
        }
        Debug.Log(" ammont of logs" +count);
	*/
	}

    public void pushEvent(string logCode)
    {
        Debug.Log(logCode);
        loggedEvents.Add(new LogEvent(gameInfo.getRound(), logCode));
    }

    public List<LogEvent> getLogList()
    {
        return loggedEvents;
    }
}
