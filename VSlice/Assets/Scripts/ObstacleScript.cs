using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class ObstacleScript : MonoBehaviour {

    public ObstacleOccupation ocupies;
    public int laneswide;
    public int lanesHigh;
    public int lanesDeep;


	// Use this for initialization
	void Start () {
        ocupies = new ObstacleOccupation(laneswide, lanesHigh, lanesDeep);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider coll)
    {
        Debug.Log(coll.name);
      //  if (coll.name)
    }
}
