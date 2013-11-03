using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class IngameMusicScript : MonoBehaviour 
{
    public SpawnWorldScript world;
    public AudioSource ingame;
    public AudioSource winning;

    private bool endReached = false;


	// Use this for initialization
	void Start () 
    {
        ingame.enabled = true;
        winning.enabled = false;
    }

    void Awake()
    {
        world = GameObject.Find("World").GetComponent<SpawnWorldScript>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        if(world.endTileReached)
        {
            if (!endReached)
            {
                Activate();
                endReached = true;
            }
        }
	}

    void Activate()
    {
        ingame.enabled = false;
        winning.enabled = true;
    }
}
