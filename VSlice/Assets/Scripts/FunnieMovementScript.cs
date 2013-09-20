using UnityEngine;
using System.Collections;
using Kinect;

public class FunnieMovementScript : MonoBehaviour {
	
	
	
	public GameObject handLeft;
	public GameObject handRight;
	public GameObject shoulderCenter;
    private float funniespeed = 35;

	float angle;
	
	float distance = 5f;
	
	
	// Use this for initialization
	void Start () 
	{
		Debug.Log((handRight.transform.position.x - handLeft.transform.position.x));
		
	}
	
	// Update is called once per frame
	void Update () 
	{
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
	
	void updatePosition()
	{
			
		
		this.gameObject.transform.parent.transform.Translate(angle/8*Time.deltaTime,0,0);
		
		if(handRight.transform.position.y < shoulderCenter.transform.position.y-0.1f&& handLeft.transform.position.y < shoulderCenter.transform.position.y-0.1f)
		{
			this.gameObject.transform.parent.transform.position = new Vector3(	this.gameObject.transform.parent.transform.position.x,
																				this.gameObject.transform.parent.transform.position.y - distance * Time.deltaTime,
																				this.gameObject.transform.parent.transform.position.z);
			
		}
		
		if(handRight.transform.position.y > shoulderCenter.transform.position.y+0.1f && handLeft.transform.position.y > shoulderCenter.transform.position.y+0.1f)
		{
			this.gameObject.transform.parent.transform.position = new Vector3(	this.gameObject.transform.parent.transform.position.x,
																				this.gameObject.transform.parent.transform.position.y + distance * Time.deltaTime,
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

        funniespeed += 0.5f *Time.deltaTime;

    }
}
