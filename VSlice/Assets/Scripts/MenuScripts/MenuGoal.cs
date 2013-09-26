using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class MenuGoal : MonoBehaviour
{


    private MenuHandler menu;


    // Use this for initialization
    void Start()
    {
        menu = GameObject.Find("menuHolder").GetComponent<MenuHandler>();
    }

    void OnTriggerStay()
    {
        menu.goalCounter++;
    }

    void OnTriggerExit()
    {
        menu.goalCounter = 0;
    }

}