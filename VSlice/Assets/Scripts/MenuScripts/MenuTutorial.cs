using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class MenuTutorial : MonoBehaviour
{


    private MenuHandler menu;


    // Use this for initialization
    void Start()
    {
        menu = GameObject.Find("menuHolder").GetComponent<MenuHandler>();
    }

    void OnTriggerStay()
    {
        menu.tutorialCounter++;
    }

    void OnTriggerExit()
    {
        menu.tutorialCounter = 0;
    }

}