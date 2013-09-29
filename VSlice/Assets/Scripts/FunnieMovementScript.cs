using UnityEngine;
using System.Collections;
using Kinect;
using System;

public class FunnieMovementScript : MonoBehaviour {
	
	
	
	public GameObject handLeft;
	public GameObject handRight;
	public GameObject shoulderCenter;
    private float funniespeed = 35;
    private float funnieMaxSpeed = 80;
    private bool _hasFeather = false;
    private float featherExtraSpeed = 5;
    private float featherDuration = 5;
    private DateTime featherPickupTime;

	float angle;
	
    float heightDistance = 8f;
	
	
	// Use this for initialization
	void Start () 
	{
		Debug.Log((handRight.transform.position.x - handLeft.transform.position.x));
		
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (_hasFeather)checkFeatherDuration();
        increaseSpeed();
		updatePosition();
		if((handRight.transform.position.y - handLeft.transform.position.y) != 0)
		{	
			
			this.gameObject.transform.eulerAngles = new Vector3(0,0,Mathf.Atan((handRight.transform.position.y - handLeft.transform.position.y)/(handRight.transform.position.x-handLeft.transform.position.x))*Mathf.Rad2Deg*-1);
			
			angle = Mathf.Atan((handRight.transform.position.y - handLeft.transform.position.y)/
								(handRight.transform.position.x-handLeft.transform.position.x))* Mathf.Rad2Deg;
			//Debug.Log ("angle of arms "+angle);
			
		}
		else return;
		
	}

    private void checkFeatherDuration()
    {

        TimeSpan runtime = DateTime.Now.Subtract(featherPickupTime);
        if (runtime.Seconds > featherDuration) featherStoppedWorking();
    }
	
	void updatePosition()
	{
		this.gameObject.transform.parent.transform.Translate(angle/8*Time.deltaTime,0,0);
		
		if(handRight.transform.position.y < shoulderCenter.transform.position.y-0.1f&& handLeft.transform.position.y < shoulderCenter.transform.position.y-0.1f)
		{
			this.gameObject.transform.parent.transform.position = new Vector3(	this.gameObject.transform.parent.transform.position.x,
																				this.gameObject.transform.parent.transform.position.y - heightDistance * Time.deltaTime,
																				this.gameObject.transform.parent.transform.position.z);
			
		}
		
		if(handRight.transform.position.y > shoulderCenter.transform.position.y+0.1f && handLeft.transform.position.y > shoulderCenter.transform.position.y+0.1f)
		{
			this.gameObject.transform.parent.transform.position = new Vector3(	this.gameObject.transform.parent.transform.position.x,
                                                                                this.gameObject.transform.parent.transform.position.y + heightDistance * Time.deltaTime,
																				this.gameObject.transform.parent.transform.position.z);
			
		}
		
		this.gameObject.transform.parent.transform.position = new Vector3(	Mathf.Clamp(this.gameObject.transform.parent.transform.position.x, -13.0F, 13.0F),
																			Mathf.Clamp(this.gameObject.transform.parent.transform.position.y, 2.0f, 25.0f), 
																			40);		
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

        _hasFeather = true;
    }

    public void featherStoppedWorking()
    {
        if (funniespeed > funnieMaxSpeed)
        {
            funniespeed = funnieMaxSpeed;
        }
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
}
