using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class MenuBack : MonoBehaviour 
{


    private MenuHandler menu;


	// Use this for initialization
	void Start () 
    {
        menu = GameObject.Find("menuHolder").GetComponent<MenuHandler>();
	}

    void OnTriggerEnter()
    {
        //Debug.Log("Entering BACK Trigger");

    }

    void OnTriggerStay()
    {
        menu.backCounter++;
    }

    void OnTriggerExit()
    {
        //Debug.Log("Leaving BACK Trigger");
        menu.backCounter = 0;
    }
    
}
