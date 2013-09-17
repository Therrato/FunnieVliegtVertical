using UnityEngine;
using System.Collections;


public class ObjectScript : MonoBehaviour {
	
	
	private InitScript statHandler;
	// Use this for initialization
	void Start () 
	{
		statHandler = GameObject.Find ("InitHolder").GetComponent<InitScript>();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		statHandler.playerStats.bananas += 1;
		Debug.Log(statHandler.playerStats.bananas);
		Destroy(this.gameObject);	
	}
}
