using UnityEngine;
using System.Collections;
using Kinect;

public class FunnieMovementScript : MonoBehaviour {
	
	
	
	public GameObject handLeft;
	public GameObject handRight;
	
	
	// Use this for initialization
	void Start () 
	{
		Debug.Log((handRight.transform.position.x - handLeft.transform.position.x));
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if((handRight.transform.position.y - handLeft.transform.position.y) != 0)
		{	
			
			this.gameObject.transform.eulerAngles = new Vector3(0,0,Mathf.Atan((handRight.transform.position.y - handLeft.transform.position.y)/(handRight.transform.position.x-handLeft.transform.position.x))*Mathf.Rad2Deg*-1);
			Debug.Log ("angle of arms "+Mathf.Atan((handRight.transform.position.y - handLeft.transform.position.y)/(handRight.transform.position.x-handLeft.transform.position.x))* Mathf.Rad2Deg);
			
		}
		else return;
	}
}
