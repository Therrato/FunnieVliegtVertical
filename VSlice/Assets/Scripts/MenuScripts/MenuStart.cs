using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class MenuStart : MonoBehaviour 
{


    private MenuHandler menu;


	// Use this for initialization
	void Start () 
    {
        menu = GameObject.Find("menuHolder").GetComponent<MenuHandler>();
	}

    void OnTriggerStay()
    {
        menu.startCounter++;
    }

    void OnTriggerExit()
    {
        menu.startCounter = 0;
    }
    
}
