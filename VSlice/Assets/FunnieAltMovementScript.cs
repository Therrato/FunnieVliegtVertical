using UnityEngine;
using System.Collections;
using Kinect;
using System;

public class FunnieAltMovementScript : MonoBehaviour 
{
    public GameObject handLeft;
    public GameObject handRight;
    public GameObject shoulderCenter;

    private float funniespeed = 35;
    private float funnieMaxSpeed = 40;
    private bool _hasFeather = false;
    private float featherExtraSpeed = 15;
    private float featherDuration = 2;
    private DateTime featherPickupTime;


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
        if (!GameObject.Find("World").GetComponent<SpawnWorldScript>().poseActive)
        {
            if (_hasFeather) checkFeatherDuration();
            increaseSpeed();
            checkPosition();

        }
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

        //This checks if the player is squatting
        if (shoulderCenter.transform.position.y < 0.6f)
        {
            this.gameObject.transform.parent.transform.position = new Vector3(  this.gameObject.transform.parent.transform.position.x, 
                                                                                5, 
                                                                                this.gameObject.transform.parent.transform.position.z);
        }
    }

    private void checkFeatherDuration()
    {

        TimeSpan runtime = DateTime.Now.Subtract(featherPickupTime);
        if (runtime.Seconds > featherDuration) featherStoppedWorking();
    }

    public float getFunnieSpeed()
    {
        return funniespeed;
    }

    public void setFunnieSpeed()
    {
        funniespeed = 35;
    }

    public void increaseSpeed()
    {
        if (funnieMaxSpeed > funniespeed)
        {
            funniespeed += 0.5f * Time.deltaTime;
        }
    }

    public void CollectsFeather()
    {

        featherPickupTime = DateTime.Now;
        if (funniespeed + featherExtraSpeed >= funnieMaxSpeed + featherExtraSpeed)
        {
            funniespeed = funnieMaxSpeed + featherExtraSpeed;
        }
        else
        {
            funniespeed += featherExtraSpeed;
        }
        GameObject.Find("FeatherParticle").GetComponent<ParticleSystem>().Play();
        _hasFeather = true;
    }

    public void featherStoppedWorking()
    {
        if (funniespeed > funnieMaxSpeed)
        {
            funniespeed = funnieMaxSpeed;
        }
        GameObject.Find("FeatherParticle").GetComponent<ParticleSystem>().Stop();
        _hasFeather = false;
    }
    /// <summary>
    /// has the player optained a feather?
    /// </summary>
    /// <returns>true or false</returns>
    public bool hasFeather()
    {
        return _hasFeather;
    }

    public void pickupBanana()
    {
        GameObject.Find("BananaParticle").GetComponent<ParticleSystem>().Play();
    }
}
