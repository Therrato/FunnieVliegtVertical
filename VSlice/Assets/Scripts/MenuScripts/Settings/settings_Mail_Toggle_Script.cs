using UnityEngine;
using System.Collections;

public class settings_Mail_Toggle_Script : MonoBehaviour
{
    private GameSettingsScript gameSettings;
    private float lastUpdate;
    private bool touch;

    // Use this for initialization
    void Start()
    {
        gameSettings = GameObject.Find("GameSettings").GetComponent<GameSettingsScript>();
    }

    void Update()
    {
        if (touch)
        {

            if (Time.time - lastUpdate >= 1f)
            {
                gameSettings.sendEmail = !gameSettings.sendEmail;
                Debug.Log(gameSettings.sendEmail);
                lastUpdate = Time.time;
            }
        }
        if (gameSettings.sendEmail)
        {
            renderer.material.shader = Shader.Find("Diffuse");
            renderer.material.SetColor("_Color", Color.green);
        }
        else
        {
            renderer.material.shader = Shader.Find("Diffuse");
            renderer.material.SetColor("_Color", Color.red);
        }
    }

    // Update is called once per frame
    void OnTriggerEnter()
    {
        touch = true;
    }

    void OnTriggerExit()
    {
        touch = false;
    }
}