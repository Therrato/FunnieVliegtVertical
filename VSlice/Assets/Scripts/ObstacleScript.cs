using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class ObstacleScript : MonoBehaviour {

    public ObstacleOccupation ocupies;
    public int laneswide;
    public int lanesHigh;
    public int lanesDeep;
	
	public FunnieMovementScript funnie;


	// Use this for initialization
    void Awake()
    {
        ocupies = new ObstacleOccupation(laneswide, lanesHigh, lanesDeep);
    }
	void Start () {
        //ocupies = new ObstacleOccupation(laneswide, lanesHigh, lanesDeep);
		funnie = GameObject.Find ("ParrotContainer").GetComponent<FunnieMovementScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
       	if(other.name == "BIRD")
		{
			funnie.setFunnieSpeed();
			Destroy(this.gameObject);	
		}else return;
    }
}
