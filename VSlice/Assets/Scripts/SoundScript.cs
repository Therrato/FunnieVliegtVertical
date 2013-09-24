using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour {
	
	public AudioClip collectingSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other){
		if(other.name == "BIRD") {
			print ("test");
				AudioSource.PlayClipAtPoint(collectingSound, transform.position);
				Destroy (gameObject);
		}
	}
}
