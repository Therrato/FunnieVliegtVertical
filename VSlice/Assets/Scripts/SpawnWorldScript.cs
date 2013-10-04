using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class SpawnWorldScript : MonoBehaviour {
	public GameObject[] tiles;
	public int tilesSpawned=0;
	public GameObject[] spawnedTiles;

    public bool goalReached;
    public bool endTileSpawned;
    public bool endTileReached;
    public GameObject endTile;

    public LevelSettings availableResources;

    public InitScript statHandler;

	// Use this for initialization
    public void Awake()
    {
        LevelSettings buildableResources = GameObject.Find("GameSettings").GetComponent<GameSettingsScript>().availableResources;
        availableResources = new LevelSettings(buildableResources.bananas,buildableResources.obstacles,buildableResources.monkeys,buildableResources.figures,new Goal());
		//availableResources = new LevelSettings(true,true,true,true, new Goal());
        statHandler = GameObject.Find("InitHolder").GetComponent<InitScript>();
    }

	void Start () {
		for (int i =0; i<spawnedTiles.Length;i++){
			//GameObject newTile =  (GameObject)Instantiate(tiles[Random.Range(0,tiles.Length)]);// start if multiple tiles
            GameObject newTile = (GameObject)Instantiate(tiles[0]);
			newTile.transform.position = new Vector3(0,0,i*-100+50);
			newTile.transform.parent = this.gameObject.transform;
			spawnedTiles[i] = newTile;
            if (i > 2)
            {

                newTile.GetComponent<TileScript>().fillInTileWithObstacles(availableResources); 
            }
            
			tilesSpawned++;
		}
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	

	
	}
	
	public void spawnNewTile(GameObject oldTile){
			Destroy(oldTile);
            if (!goalReached)
            {
                GameObject newTile = (GameObject)Instantiate(tiles[Random.Range(0, tiles.Length)]);
                newTile.transform.position = new Vector3(0, 0, spawnedTiles[spawnedTiles.Length - 1].transform.position.z - 100);
                newTile.transform.parent = this.gameObject.transform;
                tilesSpawned++;
                ClearSpace();
                spawnedTiles[spawnedTiles.Length - 1] = newTile;
                newTile.GetComponent<TileScript>().fillInTileWithObstacles(availableResources);

                statHandler.playerStats.tilesPassed = tilesSpawned - 4;
            }
            else
            {
                if (!endTileSpawned)
                {
                    GameObject theEndTile = (GameObject)Instantiate(endTile);
                    theEndTile.transform.position = new Vector3(0, 0, spawnedTiles[spawnedTiles.Length - 1].transform.position.z - 100);
                    theEndTile.transform.parent = this.gameObject.transform;
                    tilesSpawned++;
                    ClearSpace();
                    spawnedTiles[spawnedTiles.Length - 1] = theEndTile;
                    endTileSpawned = true;
                }
                else ClearSpace();
            }
           
	}
	
	void ClearSpace(){
	for (int i = 0; i< spawnedTiles.Length -1; i++){
			spawnedTiles[i] = spawnedTiles[i+1];	
			
		}
		spawnedTiles[spawnedTiles.Length-1] = null;
	}

    public void setGoalReached(bool setTo)
    {
        goalReached = setTo;
    }
		
}
