using UnityEngine;
using System.Collections;
using Kinect;

public class FunnieMovementScript : MonoBehaviour {
	
	
	
	public GameObject handLeft;
	public GameObject handRight;
	
	float angle;
	
	
	// Use this for initialization
	void Start () 
	{
		Debug.Log((handRight.transform.position.x - handLeft.transform.position.x));
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		updatePosition();
		if((handRight.transform.position.y - handLeft.transform.position.y) != 0)
		{	
			
			this.gameObject.transform.eulerAngles = new Vector3(0,0,Mathf.Atan((handRight.transform.position.y - handLeft.transform.position.y)/(handRight.transform.position.x-handLeft.transform.position.x))*Mathf.Rad2Deg*-1);
			
			angle = Mathf.Atan((handRight.transform.position.y - handLeft.transform.position.y)/(handRight.transform.position.x-handLeft.transform.position.x))* Mathf.Rad2Deg;
			Debug.Log ("angle of arms "+angle);
			
		}
		else return;
		
	}
	
	void updatePosition()
	{
		this.gameObject.transform.parent.transform.Translate(angle/10*Time.deltaTime,0,0);
	}
}
