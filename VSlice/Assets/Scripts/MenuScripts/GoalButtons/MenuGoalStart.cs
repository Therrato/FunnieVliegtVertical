using UnityEngine;
using System.Collections;

public class MenuGoalStart : MonoBehaviour 
{

    private MenuHandler menu;


	// Use this for initialization
	void Start () 
    {
        menu = GameObject.Find("menuHolder").GetComponent<MenuHandler>();
	}


    void OnTriggerStay()
    {
        menu.saveSettings++;
       // Debug.Log(menu.saveSettings);
    }

    void OnTriggerExit()
    {
        menu.saveSettings = 0;
    }

}
