using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class TileScript : MonoBehaviour {
    public int row = 3;
    public int depthRow = 10;
    public int height = 3; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (this.transform.position.z >= 100){
			this.gameObject.transform.parent.GetComponent<SpawnWorldScript>().spawnNewTile(this.gameObject);
		}
						this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,this.gameObject.transform.position.z+50f*Time.deltaTime);
	}

    void Awake() {


    }


    public void fillInTileWithObstacles(LevelSettings generate)
    {
        if (generate.obstacles)
        {

        }
       
    }

    public void fillInTileWithBananas(LevelSettings generate)
    {
        if (generate.bananas)
        {
            int prevpos = Random.RandomRange(0,3);
            for (int i = 0; i < depthRow; i++)
            {
                GameObject instance = Instantiate(Resources.Load("Banana")) as GameObject;
                instance.transform.parent = this.transform;
                int newpos = Random.RandomRange(0, 2) - 1 ;
                if (newpos + prevpos > 0 && newpos + prevpos < 3)
                {
                    
                    instance.transform.position = new Vector3((newpos + prevpos) * 20 - 20, 0.0f, i * 10.0f + this.transform.position.z - 50);
                   prevpos =  newpos+prevpos;

                }
                else
                {
                    instance.transform.position = new Vector3(prevpos * 20 - 20, 0.0f, i * 10.0f + this.transform.position.z -50);
                }
            }
        }
    }
}
