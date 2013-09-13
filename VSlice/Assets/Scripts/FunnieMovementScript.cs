using UnityEngine;
using System.Collections;
using Kinect;

public class FunnieMovementScript : MonoBehaviour {
	
	
	
	public GameObject handLeft;
	public GameObject handRight;
	
	// Use this for initialization
	void Start () 
	{
		
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.gameObject.transform.rotation = new Quaternion(Mathf.Atan((handRight.transform.position.y - handLeft.transform.position.y)/(handRight.transform.position.x-handLeft.transform.position.x)),0f,0f,0f);
	}
}
