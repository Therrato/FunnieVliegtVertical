using UnityEngine;
using System.Collections;
using System;

public class TutorialCheckScript : MonoBehaviour 
{
    public GameObject handLeft;
    public GameObject handRight;
    public GameObject shoulderCenter;
    private GameObject countDownGO;
    private GameObject pose;

    public Texture2D[] textures;
    public Texture2D[] countDownNumbers;


    //arm bools
    public bool armsStraight = false;
    public bool armsMoveLeft = false;
    public bool armsMoveRight = false;
    public bool armsUp = false;
    public bool armsDown = false;


    public bool positionTimerStarted = false;
    public bool isDebug = false;
    public DateTime startTime;
    public int depth;
	
	void Start () 
    {
        handLeft = GameObject.Find("Hand_Left");
        handRight = GameObject.Find("Hand_Right");
        shoulderCenter = GameObject.Find("Shoulder_Center");
        countDownGO = GameObject.Find("CountDown");
        pose = GameObject.Find("PoseTexture");

        depth = 1;
	}
	
	
	void Update () 
    {
        if (depth == 1)
        {
            if (checkPositionSTRAIGHT() || isDebug)
            {
                countDown();
                pose.guiTexture.texture = textures[1];
            }
            else
            {
                takePosition();
                pose.guiTexture.texture = textures[0];
            }
        }
        else if (depth == 2)
        {
            if (checkPositionLEFT() || isDebug)
            {
                countDown();
                pose.guiTexture.texture = textures[3];
            }
            else
            {
                takePosition();
                pose.guiTexture.texture = textures[2];
            }
        }
        else if (depth == 3)
        {
            if (checkPositionRIGHT() || isDebug)
            {
                countDown();
                pose.guiTexture.texture = textures[5];
            }
            else
            {
                takePosition();
                pose.guiTexture.texture = textures[4];
            }
        }

        else if (depth == 4)
        {
            if (checkPositionUP() || isDebug)
            {
                countDown();
                pose.guiTexture.texture = textures[7];
            }
            else
            {
                takePosition();
                pose.guiTexture.texture = textures[6];
            }
        }
        else if (depth == 5)
        {
            if (checkPositionDOWN() || isDebug)
            {
                countDown();
                pose.guiTexture.texture = textures[9];
            }
            else
            {
                takePosition();
                pose.guiTexture.texture = textures[8];
            }
        }
        else if (depth == 6)
        {
            Application.LoadLevel(0);
        }
	}

    private void takePosition()
    {
        positionTimerStarted = false;
        Debug.Log("Timer has stopped!");

    }

    private void countDown()
    {
        if (positionTimerStarted)
        {
            Debug.Log("Timer has started!");
            TimeSpan duration = DateTime.Now.Subtract(startTime);
            countDownGO.guiTexture.texture = null;
            if (duration.Seconds == 0)
            {
                countDownGO.guiTexture.texture = countDownNumbers[0];

            }
            else if (duration.Seconds == 1)
            {
                countDownGO.guiTexture.texture = countDownNumbers[1];

            }
            else if (duration.Seconds == 2)
            {
                countDownGO.guiTexture.texture = countDownNumbers[2];

            }
            else if (duration.Seconds >= 3)
            {
                countDownGO.guiTexture.texture = null;
                moveUp();
                isDebug = false;
            }
        }
        else
        {
            //countDownGO.guiTexture.texture = null;
            positionTimerStarted = true;
            startTime = DateTime.Now;
        }
    }

    public void moveUp()
    {
        depth += 1;
    }

    private bool checkPositionSTRAIGHT()
    {
        if (handRight.transform.position.y < shoulderCenter.transform.position.y - 0.08f && handLeft.transform.position.y < shoulderCenter.transform.position.y - 0.08f)
        {
            return false;
        }
        else if (handRight.transform.position.y > shoulderCenter.transform.position.y + 0.08f && handLeft.transform.position.y > shoulderCenter.transform.position.y + 0.08f)
        {
            return false;
        }
        float angle = Mathf.Atan((handRight.transform.position.y - handLeft.transform.position.y) / (handRight.transform.position.x - handLeft.transform.position.x)) * Mathf.Rad2Deg * -1;
        if (angle < 15 && angle > -15)
        {

            return true;
        }

        return false;

    }

    private bool checkPositionLEFT()
    {
        if (handRight.transform.position.y < shoulderCenter.transform.position.y - 0.08f && handLeft.transform.position.y < shoulderCenter.transform.position.y - 0.08f)
        {
            return false;
        }
        else if (handRight.transform.position.y > shoulderCenter.transform.position.y + 0.08f && handLeft.transform.position.y > shoulderCenter.transform.position.y + 0.08f)
        {
            return false;
        }
        float angle = Mathf.Atan((handRight.transform.position.y - handLeft.transform.position.y) / (handRight.transform.position.x - handLeft.transform.position.x)) * Mathf.Rad2Deg * -1;
        if (angle < 15)
        {

            return true;
        }

        return false;

    }

    private bool checkPositionRIGHT()
    {
        if (handRight.transform.position.y < shoulderCenter.transform.position.y - 0.08f && handLeft.transform.position.y < shoulderCenter.transform.position.y - 0.08f)
        {
            return false;
        }
        else if (handRight.transform.position.y > shoulderCenter.transform.position.y + 0.08f && handLeft.transform.position.y > shoulderCenter.transform.position.y + 0.08f)
        {
            return false;
        }
        float angle = Mathf.Atan((handRight.transform.position.y - handLeft.transform.position.y) / (handRight.transform.position.x - handLeft.transform.position.x)) * Mathf.Rad2Deg * -1;
        if (angle > -15)
        {

            return true;
        }

        return false;

    }

    private bool checkPositionUP()
    {
        if (handRight.transform.position.y < shoulderCenter.transform.position.y - 0.08f && handLeft.transform.position.y < shoulderCenter.transform.position.y - 0.08f)
        {
            return true;
        }
        else if (handRight.transform.position.y > shoulderCenter.transform.position.y + 0.08f && handLeft.transform.position.y > shoulderCenter.transform.position.y + 0.08f)
        {
            return false;
        }
        float angle = Mathf.Atan((handRight.transform.position.y - handLeft.transform.position.y) / (handRight.transform.position.x - handLeft.transform.position.x)) * Mathf.Rad2Deg * -1;
        if (angle > -15)
        {

            return false;
        }

        return false;

    }

    private bool checkPositionDOWN()
    {
        if (handRight.transform.position.y < shoulderCenter.transform.position.y - 0.08f && handLeft.transform.position.y < shoulderCenter.transform.position.y - 0.08f)
        {
            return false;
        }
        else if (handRight.transform.position.y > shoulderCenter.transform.position.y + 0.08f && handLeft.transform.position.y > shoulderCenter.transform.position.y + 0.08f)
        {
            return true;
        }
        float angle = Mathf.Atan((handRight.transform.position.y - handLeft.transform.position.y) / (handRight.transform.position.x - handLeft.transform.position.x)) * Mathf.Rad2Deg * -1;
        if (angle > -15)
        {

            return false;
        }

        return false;

    }
}
