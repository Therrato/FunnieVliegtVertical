using UnityEngine;
using System.Collections;

public class BlobShadowDistance : MonoBehaviour 
{

    private GameObject player;
    public int distance;
    

	// Use this for initialization
	void Start () 
    {
        player = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () 
    {
        float distanceBetweenObjects = Vector3.Distance(player.transform.position,this.transform.position);

        if (distanceBetweenObjects < distance)
        {
            GetComponent<Projector>().enabled = true;
        }
        else
        {
            GetComponent<Projector>().enabled = false;
        }
	}
}
