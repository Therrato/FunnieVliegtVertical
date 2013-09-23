using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class ItemSpawner : MonoBehaviour {
    public GameObject[] bottomLaneOnly;
    public GameObject[] twoWideBotOnly;
    public GameObject[] fullWidthBotLane;
    public GameObject[] allPlaces;
    public GameObject[] pickupFruits;
    public GameObject[] pickupPowerUps;
    public GameObject[] sideOnlyAllheight;

    public int row = 3;
    public int depthRow = 10;
    public int height = 3; 

    public bool[, ,] spaceUsed = new bool[3, 3, 10];

    public FlyLane lastSpawnedBanana = new FlyLane(0,0);  
    public int bananasLeftToSpawn = 0;
    
    

    
    public GameObject[] fullScreen;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    /// <summary>
    /// will fill the tile with pickups
    /// </summary>
    /// <param name="tileToFill">the position where the objects will be spawned in</param>
    /// <param name="settings">rules for the spawner</param>

    public void fillThisTile(GameObject tileToFill,LevelSettings generate){
        spaceUsed = new bool[3, 3, 10];
        for (int i = 0; i < depthRow; i++)
        {
            if (generate.obstacles) createObstacles(tileToFill,i);
            if (generate.bananas) createPickUps(tileToFill,i);
            if (generate.figures) createPowerUps();
        }
    }

    public void createObstacles(GameObject tileToFill,int i)
    {
        if (Random.Range(0, 7) == 1)
        {
            int type = Random.Range(0, 4); 
            if (type == 1){// spawn botlane only
                Debug.Log("Try To Spawn");
                int lanePos = Random.Range(0,3);
                GameObject toPlaceObstacle = Instantiate(bottomLaneOnly[Random.Range(0, bottomLaneOnly.Length)]) as GameObject;
                int[] takesUp = toPlaceObstacle.GetComponent<ObstacleScript>().ocupies.getOccupation();
                bool canPlace = true;
                for (int j = 0; j < 3; j++)
                {
                    if (spaceUsed[lanePos, j, i]) canPlace = false;
                }
                if (canPlace)
                {
                    
                    toPlaceObstacle.transform.parent = tileToFill.transform;
                    toPlaceObstacle.transform.position = new Vector3((lanePos - 1) * 20 - 10, 0f, i * 10.0f + tileToFill.transform.position.z - 50);
                    for (int j = 0; j < takesUp[1]; j++)
                    {
                        spaceUsed[lanePos, j, i] = true;
                    }
                }
                else
                {
                    Debug.Log("failed To Spawn");
                    Destroy(toPlaceObstacle);
                }
            }
            if (type == 2) // side only all height
            {
                Debug.Log("Try To Spawn side only");
                int laneHeight = Random.Range(0, 3);
                GameObject toPlaceObstacle = Instantiate(sideOnlyAllheight[Random.Range(0,sideOnlyAllheight.Length)]) as GameObject;
                int[] takesUp = toPlaceObstacle.GetComponent<ObstacleScript>().ocupies.getOccupation();
                bool canPlace = true;
                int lanePos;
                if (Random.Range(0, 2) == 0)
                {
                    lanePos = 0;
                    for (int w = 0; w < takesUp[0]; w++)
                    {

                        if (spaceUsed[w, laneHeight, i]) canPlace = false;
                    }
                }
                else
                {
                    lanePos = 2;
                    for (int w = -takesUp[0]; w >0; w++)
                    {

                        if (spaceUsed[w, laneHeight, i]) canPlace = false;
                    }
                }
                if (canPlace)
                {

                    toPlaceObstacle.transform.parent = tileToFill.transform;
                    toPlaceObstacle.transform.position = new Vector3((lanePos - 1) * 20, laneHeight*10, i * 10.0f + tileToFill.transform.position.z - 50);
                    if (lanePos == 2) toPlaceObstacle.transform.Rotate(new Vector3(0, 180, 0));
                    spaceUsed[lanePos, laneHeight, i] = true;
                    spaceUsed[1, lanePos, i]=true;

                }
                else
                {
                    Debug.Log("failed To Spawn");
                    Destroy(toPlaceObstacle);
                }

            }
            if (type ==3) // spawn full width
            {
                Debug.Log("Try To Spawn full width");
                GameObject toPlaceObstacle = Instantiate(fullWidthBotLane[Random.Range(0, fullWidthBotLane.Length)]) as GameObject;
                int[] takesUp = toPlaceObstacle.GetComponent<ObstacleScript>().ocupies.getOccupation();
                bool canPlace = true;
                for (int j = 0; j < takesUp[0]; j++)
                {
                    for (int h = 0; h < takesUp[1]; h++)
                    if (spaceUsed[j, h, i]) canPlace = false;
                }
                if (canPlace)
                {

                    toPlaceObstacle.transform.parent = tileToFill.transform;
                    toPlaceObstacle.transform.position = new Vector3((1 - 1) * 20 - 10, 0f, i * 10.0f + tileToFill.transform.position.z - 50);
                    for (int j = 0; j < 3; j++)
                    {
                       spaceUsed[j, 0, i] = true;
                    }
                }
                else
                {
                    Debug.Log("failed To Spawn");
                    Destroy(toPlaceObstacle);
                }
            }
        
        }
        
        

    }
    /// <summary>
    /// fills tile with bananas
    /// </summary>
    /// <param name="tileToFill">tile to fill</param>
    /// <param name="i">row position</param>
    public void createPickUps(GameObject tileToFill, int i)
    {
        if (bananasLeftToSpawn == 0)
        {
            if (Random.Range(0, 4) == 0)
            {
                bananasLeftToSpawn = Random.Range(3, 9);
                lastSpawnedBanana.x = Random.Range(0, 3) - 1;
                lastSpawnedBanana.y = Random.Range(0, 3) - 1;

            }
        }
        else
        {
            bananasLeftToSpawn--;
            if (!spaceUsed[lastSpawnedBanana.x + 1, lastSpawnedBanana.y + 1, i]) // if there is place
            {
                GameObject newPicKup;
                if (Random.Range(0, 10) == 1)
                {
                   newPicKup = Instantiate(pickupFruits[1]) as GameObject;

                }
                else { 
                    newPicKup = Instantiate(pickupFruits[0]) as GameObject; 
                }
                newPicKup.transform.parent = tileToFill.transform;
                newPicKup.transform.position = new Vector3(lastSpawnedBanana.x * 20f, lastSpawnedBanana.y * 10f + 15f, i * 10f + tileToFill.transform.position.z);
                spaceUsed[lastSpawnedBanana.x + 1, lastSpawnedBanana.y + 1, i] = true;
                
            }
            else  // calculate new startpoint for line
            {
                lastSpawnedBanana.x = Random.Range(0, 3) - 1;
                lastSpawnedBanana.y = Random.Range(0, 3) - 1;
            }
            
        }
    }

    public void createPowerUps()
    {

    }
}
