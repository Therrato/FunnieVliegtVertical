using UnityEngine;
using System.Collections;


public class ObjectScript : MonoBehaviour {
	
	
	public InitScript statHandler;
	// Use this for initialization
	
	void Awake()
	{
		statHandler = GameObject.Find ("InitHolder").GetComponent<InitScript>();
	}
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.name == "BIRD")
		{
			Debug.Log (other.name + " lol");
			statHandler.playerStats.bananas += 1;
			Debug.Log(statHandler.playerStats.bananas);
			Destroy(this.gameObject);	
		}else return;
	}
}
