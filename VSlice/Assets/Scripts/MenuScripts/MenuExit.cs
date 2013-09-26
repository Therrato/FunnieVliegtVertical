using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class MenuExit : MonoBehaviour
{


    private MenuHandler menu;


    // Use this for initialization
    void Start()
    {
        menu = GameObject.Find("menuHolder").GetComponent<MenuHandler>();
    }

    void OnTriggerEnter()
    {

    }

    void OnTriggerStay()
    {
        menu.exitCounter++;
    }

    void OnTriggerExit()
    {
        menu.exitCounter = 0;
    }

}