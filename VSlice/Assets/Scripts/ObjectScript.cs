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
        this.gameObject.transform.eulerAngles = new Vector3(this.gameObject.transform.eulerAngles.x, this.gameObject.transform.eulerAngles.y+3, this.gameObject.transform.eulerAngles.z);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.name == "BIRD")
		{
			//Debug.Log (other.name + " lol");
			statHandler.playerStats.bananas += 1;
			//Debug.Log(statHandler.playerStats.bananas);
			Destroy(this.gameObject);	
		}else return;
	}
}
