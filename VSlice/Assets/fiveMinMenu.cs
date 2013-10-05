using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class fiveMinMenu : MonoBehaviour
{


    private MenuHandler menu;


    // Use this for initialization
    void Start()
    {
        menu = GameObject.Find("menuHolder").GetComponent<MenuHandler>();
    }

    void OnTriggerStay()
    {
        menu.minutesModeCounter++;
    }

    void OnTriggerExit()
    {
        menu.minutesModeCounter = 0;
    }

}