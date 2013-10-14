using UnityEngine;
using System.Collections;

public class visualCountDownScript : MonoBehaviour {

    public Material[] displayNumbers;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    /// <summary>
    /// displays the number that you would like to see
    /// </summary>
    /// <param name="displayNumber"></param>
    public void setToNumber(int displayNumber)
    {
        this.gameObject.renderer.material = displayNumbers[displayNumber - 1];
    }

    public void countdownDone()
    {
        Destroy(this.gameObject);
    }
}
