using UnityEngine;
using System.Collections;
using Kinect;
using System;

public class FunnieAltMovementScript : MonoBehaviour 
{
    public GameObject handLeft;
    public GameObject handRight;
    public GameObject shoulderCenter;

    float heightDistance = 14f;

    void Awake()
    {
        handLeft = GameObject.Find("Hand_Left");
        handRight = GameObject.Find("Hand_Right");
        shoulderCenter = GameObject.Find("Shoulder_Center");
    }

	void Start () 
    {
	    
	}
	
	void Update () 
    {
        checkPosition();
        //Debug.Log(  "shoulderCenter X position: " + shoulderCenter.transform.position.x);
	}

    void checkPosition()
    {
        
        //this checks if the player stepped to the left
        if (shoulderCenter.transform.position.x > -2.0f && shoulderCenter.transform.position.x < -0.5f)
        {
            this.gameObject.transform.parent.transform.position = new Vector3(15, this.gameObject.transform.parent.transform.position.y, this.gameObject.transform.parent.transform.position.z);
            Debug.Log("Player is on the left!");
        }

        //this checks if the player is in the middle
        if (shoulderCenter.transform.position.x > -0.3f && shoulderCenter.transform.position.x < 0.3f)
        {
            this.gameObject.transform.parent.transform.position = new Vector3(0, this.gameObject.transform.parent.transform.position.y, this.gameObject.transform.parent.transform.position.z);
            Debug.Log("Player is in the middle!");
        }

        //this check if the played stepped to the right
        if (shoulderCenter.transform.position.x > 0.5f && shoulderCenter.transform.position.x < 2.0f)
        {
            this.gameObject.transform.parent.transform.position = new Vector3(-15, this.gameObject.transform.parent.transform.position.y, this.gameObject.transform.parent.transform.position.z);
            Debug.Log("Player is on the right!");
        }

        Debug.Log("Hand right Y position: " + handRight.transform.position.y + ", Hand left Y position: " + handLeft.transform.position.y + ", Shoulder center Y position: " + shoulderCenter.transform.position.y);

        //this moves the player up
        if (handRight.transform.position.y > shoulderCenter.transform.position.y + 0.1f && handLeft.transform.position.y > shoulderCenter.transform.position.y + 0.1f)
        {
           
            this.gameObject.transform.parent.transform.position = new Vector3(  this.gameObject.transform.parent.transform.position.x,
                                                                                25.0f, 
                                                                                this.gameObject.transform.parent.transform.position.z);
        }
        else
        {
            this.gameObject.transform.parent.transform.position = new Vector3(  this.gameObject.transform.parent.transform.position.x,
                                                                                15.0f,
                                                                                this.gameObject.transform.parent.transform.position.z);
        }

        if (shoulderCenter.transform.position.y < 0.6f)
        {
            this.gameObject.transform.parent.transform.position = new Vector3(  this.gameObject.transform.parent.transform.position.x, 
                                                                                5, 
                                                                                this.gameObject.transform.parent.transform.position.z);
        }
    }
}
