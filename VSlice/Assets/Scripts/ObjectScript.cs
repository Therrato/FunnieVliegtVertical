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
            if (isFeather)
            {
                other.transform.parent.GetComponent<FunnieMovementScript>().CollectsFeather();
                statHandler.playerStats.feathersCollected += 1;
                log.pushEvent("FEATHER");
               
              
            }
            else
            {
                audio.pitch = pitch;
                AudioSource.PlayClipAtPoint(bananaSound, transform.position);
                pitch += 0.05f;
                Debug.Log("Audio Pitch: "+audio.pitch + ", variable pitch: " + pitch);
				//if(audio.pitch == 1.0) {
					//audio.pitch = 0.1;				
				//} else 
					//bananaSound.pitch = 1;
					Destroy(gameObject); 		
				
                statHandler.playerStats.bananas += 1;
                log.pushEvent("BANANA");
                
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
                // reset bananapitch here
                log.pushEvent("BANANAMISSED");
            }
        }
    }
}
