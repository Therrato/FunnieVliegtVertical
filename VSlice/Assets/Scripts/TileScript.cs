using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class TileScript : MonoBehaviour {
    public FunnieMovementScript funnie;
    public SpawnWorldScript world;

	// Use this for initialization
	void Start () {
        funnie = GameObject.Find("ParrotContainer").GetComponent<FunnieMovementScript>();
        world = this.gameObject.transform.parent.GetComponent<SpawnWorldScript>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (!world.poseActive)
        if (this.transform.position.z >= 100)
        {
            world.spawnNewTile(this.gameObject);
        }
        else
        {
            if (!world.endTileReached)
            {
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z + (funnie.getFunnieSpeed() * Time.deltaTime));
            }
        }
	}

    void Awake() {


    }


    public void fillInTileWithObstacles(LevelSettings generate)
    {
        this.gameObject.transform.parent.GetComponent<ItemSpawner>().fillThisTile(this.gameObject, generate);
    }

}
