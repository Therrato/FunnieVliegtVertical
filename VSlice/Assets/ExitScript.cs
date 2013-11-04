using UnityEngine;
using System.Collections;
using System;

public class ExitScript : MonoBehaviour {
    DateTime start;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (DateTime.Now.Subtract(start).Seconds > 15)
        {
            Destroy(GameObject.Find("KinectPointMan"));
            Destroy(GameObject.Find("KinectPrefab"));
            Destroy(GameObject.Find("GameSettings"));
            Application.LoadLevel(0);
        }
	}

    void Awake()
    {
        start = DateTime.Now;
    }
}
