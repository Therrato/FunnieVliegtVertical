using UnityEngine;
using System.Collections;


public class ObjectScript : MonoBehaviour {
	
	
	public InitScript statHandler;
    public bool isFeather;
	public AudioClip bananaSound;
    private LogSystem log;
    private bool pickedUp = false;
   

    private static float pitch = 1;
	// Use this for initialization
	
	void Awake()
	{
        this.gameObject.transform.eulerAngles = new Vector3(this.gameObject.transform.eulerAngles.x,Random.Range(0,359), this.gameObject.transform.eulerAngles.z);
		statHandler = GameObject.Find ("InitHolder").GetComponent<InitScript>();
        
	}
	void Start () 
	{
        log = GameObject.Find("LogSys(Clone)").GetComponent<LogSystem>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        this.gameObject.transform.eulerAngles = new Vector3(this.gameObject.transform.eulerAngles.x, this.gameObject.transform.eulerAngles.y+3, this.gameObject.transform.eulerAngles.z);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.name == "BIRD")
		{
            pickedUp = true;
            if (isFeather)
            {
                other.transform.parent.GetComponent<FunnieMovementScript>().CollectsFeather();
                statHandler.playerStats.feathersCollected += 1;
                log.pushEvent("FEATHERPICKUP");
               
              
            }
            else
            {
                audio.pitch = pitch;
                AudioSource.PlayClipAtPoint(bananaSound, transform.position);
                pitch += 0.05f;
				Destroy(gameObject);
                other.transform.parent.GetComponent<FunnieMovementScript>().pickupBanana();
                statHandler.playerStats.bananas += 1;
                log.pushEvent("BANANAPICKUP");
                
            }
            Destroy(this.gameObject);
		}else return;
	}

    void OnDestroy()
    {
        if (!pickedUp)
        {
            if (isFeather)
            {
                log.pushEvent("FEATHERMISSED");
            }
            else
            {
               
                resetPitch();
                statHandler.playerStats.bananasMissed += 1;
                log.pushEvent("BANANAMISSED");
            }
        }
    }

    public void resetPitch()
    {
       
        pitch = 1;
    }
}
