using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class MenuHelp : MonoBehaviour
{


    private MenuHandler menu;


    // Use this for initialization
    void Start()
    {
        menu = GameObject.Find("menuHolder").GetComponent<MenuHandler>();
    }

    void OnTriggerEnter()
    {
        //Debug.Log("Entering HELP Trigger");

    }

    void OnTriggerStay()
    {
        menu.helpCounter++;
    }

    void OnTriggerExit()
    {
        //Debug.Log("Leaving HELP Trigger");
        menu.helpCounter = 0;
    }

}