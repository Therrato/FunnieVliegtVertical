using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class ObstacleScript : MonoBehaviour
{
    #region Documentation
    /*
     * 
     * 
     * 
     * 
     * 
     * 
     */
    #endregion


    public ObstacleOccupation ocupies;
    public int laneswide;
    public int lanesHigh;
    public int lanesDeep;
    private LogSystem log;
	
	public FunnieMovementScript funnie;
    public InitScript statHandler;

    private bool hit = false;
	
	


	// Use this for initialization
    void Awake()
    {
        ocupies = new ObstacleOccupation(laneswide, lanesHigh, lanesDeep);
        statHandler = GameObject.Find("InitHolder").GetComponent<InitScript>();
        
    }
	void Start () {
		log = GameObject.Find("LogSys(Clone)").GetComponent<LogSystem>();
        funnie = GameObject.Find ("ParrotContainer").GetComponent<FunnieMovementScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
       	if(other.name == "BIRD")
		{
            if (!funnie.hasFeather())
            {

                funnie.setFunnieSpeed();
                statHandler.playerStats.obstaclesHit += 1;
                hit = true;
                Destroy(this.gameObject);
            }
            else
            {
                // funnie goest trough obstacle
                
                
                Destroy(this.gameObject);
				
				
            }

		}else return;
    }

    void OnDestroy()
    {
        if (!hit)
        {
            statHandler.playerStats.obstaclesPassed += 1;
            log.pushEvent("PASSEDOBJECT");
        }
        else
        {
            log.pushEvent("HITOBJECT");
        }

    }
}
