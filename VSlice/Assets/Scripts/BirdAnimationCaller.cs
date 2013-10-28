using UnityEngine;
using System.Collections;

public class BirdAnimationCaller : MonoBehaviour
{
    public int durationForNextFlap = 0;

    // Use this for initialization
    void Start()
    {
        
    }

 

    void calculateNextFlap()
    {
        durationForNextFlap = Random.Range(1000, 1300);
    }

    // Update is called once per frame
    void Update()
    {

        if (durationForNextFlap < 0) 
        {
            calculateNextFlap();
            flap();

        }
        durationForNextFlap--;

    }

    public void bump()
    {
        this.gameObject.animation.Play("Bump");
    }

    public void flap()
    {
        Debug.Log("flap");
       // this.gameObject.animation.Play("Flap");
    }
}