using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class TileScript : MonoBehaviour {
    public FunnieMovementScript funnie;

	// Use this for initialization
	void Start () {
        funnie = GameObject.Find("ParrotContainer").GetComponent<FunnieMovementScript>();
	}
	
	// Update is called once per frame
	void LateUpdate () {

        if (this.transform.position.z >= 100)
        {
            this.gameObject.transform.parent.GetComponent<SpawnWorldScript>().spawnNewTile(this.gameObject);
        }
        else
        {
            if (!this.gameObject.transform.parent.GetComponent<SpawnWorldScript>().endTileReached)this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z + (funnie.getFunnieSpeed() * Time.deltaTime));
        }
	}

    void Awake() {


    }


    public void fillInTileWithObstacles(LevelSettings generate)
    {
        this.gameObject.transform.parent.GetComponent<ItemSpawner>().fillThisTile(this.gameObject, generate);
    }

}
