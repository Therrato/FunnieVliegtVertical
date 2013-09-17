using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class TileScript : MonoBehaviour {
    public int row = 3;
    public int depthRow = 10;
    public int height = 3; 
    public bool[,,] spaceUsed = new bool[3,3,10];
    private FunnieMovementScript funnie;

	// Use this for initialization
	void Start () {
        funnie = GameObject.Find("ParrotContainer").GetComponent<FunnieMovementScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (this.transform.position.z >= 100){
			this.gameObject.transform.parent.GetComponent<SpawnWorldScript>().spawnNewTile(this.gameObject);
		}
						this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,this.gameObject.transform.position.z+(funnie.getFunnieSpeed()*Time.deltaTime));
	}

    void Awake() {


    }


    public void fillInTileWithObstacles(LevelSettings generate)
    {
        for (int i =0; i<10;i++){

            if (generate.obstacles)
            {
                if (Random.Range(0, 5) == 4)
                {
                    int positionSpot = Random.Range(0, 3);
                    if (!spaceUsed[positionSpot, 0, i] && !spaceUsed[positionSpot, 1, i] && !spaceUsed[positionSpot, 2, i])
                    {
                        GameObject instance = Instantiate(Resources.Load("Bamboo")) as GameObject;
                        instance.transform.parent = this.transform;
                        
                        instance.transform.position = new Vector3(positionSpot * 20 - 20, 0f , i * 10.0f + this.transform.position.z - 50);

                    }
                }
            }
       }
       
    }


    public void fillInTileWithBananas(LevelSettings generate)
    {
        if (generate.bananas)
        {
            int prevposx = Random.Range(0,3);
            int prevposy = Random.Range(0,3);
            for (int i = 0; i < depthRow; i++)
            {
                GameObject instance = Instantiate(Resources.Load("Banana")) as GameObject;
                instance.transform.parent = this.transform;
                int moveXBy = Random.Range(0, 3) - 1 ;
                int moveYBy = Random.Range(0, 3) - 1;
                Debug.Log("move x with " + moveXBy + " move y with " + moveYBy);
                if (moveXBy + prevposx > 0 && moveXBy + prevposx < 3 && moveYBy + prevposy > 0 && moveYBy + prevposy < 3)
                {

                    instance.transform.position = new Vector3((moveXBy + prevposx) * 20 - 20, 10 * ((moveYBy + prevposy)) + 5.5f, i * 10.0f + this.transform.position.z - 50);
                   prevposx =  moveXBy+prevposx;

                }
                else if (moveXBy + prevposx > 0 && moveXBy + prevposx < 3 )
                {

                    instance.transform.position = new Vector3((moveXBy + prevposx) * 20 - 20, prevposy * 10f + 5.5f, i * 10.0f + this.transform.position.z - 50);
                    prevposx = moveXBy + prevposx;

                }
                else if (moveYBy + prevposy > 0 && moveYBy + prevposy < 3)
                {
                    instance.transform.position = new Vector3(prevposx * 20 - 20, 5 * ((moveYBy + prevposy)) + 5.5f  , i * 10.0f + this.transform.position.z - 50);
                    prevposy = moveYBy + prevposy;
                }
                else
                {
                    instance.transform.position = new Vector3(prevposx * 20 - 20, prevposy * 10f + 5.5f, i * 10.0f + this.transform.position.z - 50);
                }
                Debug.Log("was: "+spaceUsed[prevposx, prevposy, i]);
                spaceUsed[prevposx, prevposy, i] = true;
                Debug.Log("isNow: " + spaceUsed[prevposx, prevposy, i]);
            }
        }
    }
}
