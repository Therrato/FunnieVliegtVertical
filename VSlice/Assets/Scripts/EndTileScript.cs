using UnityEngine;
using System.Collections;

public class EndTileScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider coll)
    {
        Debug.Log("i hit something" + coll.name);
        if (coll.name == "BIRD")
        {
            this.gameObject.transform.parent.transform.parent.GetComponent<SpawnWorldScript>().endTileReached = true;
            Debug.Log("EndReached");
        }
    }
    
}
