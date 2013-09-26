using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class MenuCredits : MonoBehaviour
{


    private MenuHandler menu;


    // Use this for initialization
    void Start()
    {
        menu = GameObject.Find("menuHolder").GetComponent<MenuHandler>();
    }

    void OnTriggerEnter()
    {
        //Debug.Log("Entering CREDITS Trigger");

    }

    void OnTriggerStay()
    {
        menu.creditsCounter++;
    }

    void OnTriggerExit()
    {
       // Debug.Log("Leaving CREDITS Trigger");
        menu.creditsCounter = 0;
    }

}