using UnityEngine;
using System.Collections;
using System;

public class StartUpPoseScript : MonoBehaviour {
    public GameObject handLeft;
    public GameObject handRight;
    public GameObject shoulderCenter;
    public GameObject countDownGO;
    public Texture2D[] countDownNumbers;
    public Texture2D[] display;
    public bool positionTimerStarted = false;
    public bool isDebug = false;
    public DateTime startTime;
  

	// Use this for initialization
	void Start () {
        handLeft = GameObject.Find("Hand_Left");
        handRight = GameObject.Find("Hand_Right");
        shoulderCenter = GameObject.Find("Shoulder_Center");
        countDownGO = GameObject.Find("CountDown");
        this.guiTexture.texture = display[0];
	}
	
	// Update is called once per frame
	void Update () {
        if (checkPosition()||isDebug)
        {
            countDown();
            this.guiTexture.texture = display[1];
        }
        else
        {
            takePosition();
            this.guiTexture.texture = display[0];
        }
	}

    private void takePosition()
    {
        positionTimerStarted = false;
        
    }

    private void countDown()
    {
        if (positionTimerStarted)
        {
            TimeSpan duration = DateTime.Now.Subtract(startTime);
            countDownGO.guiTexture.texture = null;
            if (duration.Seconds == 0)
            {
                countDownGO.guiTexture.texture = countDownNumbers[0];
                
            }
            else if (duration.Seconds == 1){
                countDownGO.guiTexture.texture = countDownNumbers[1];
                
            }
            else if (duration.Seconds == 2)
            {
                countDownGO.guiTexture.texture = countDownNumbers[2];
                
            }
            else if (duration.Seconds >= 3)
            {
                countDownGO.guiTexture.texture = null;
                GameObject.Find("World").GetComponent<SpawnWorldScript>().deActivatePose();
                Destroy(this.gameObject);
            }


        }
        else
        {
            //countDownGO.guiTexture.texture = null;
            positionTimerStarted = true;
            startTime = DateTime.Now;
        }
    }

    private bool checkPosition()
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
}
