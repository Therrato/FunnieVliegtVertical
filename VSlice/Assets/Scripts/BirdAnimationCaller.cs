using UnityEngine;
using System.Collections;

public class BirdAnimationCaller : MonoBehaviour
{
    public int durationForNextFlap = 0;

    // Use this for initialization
    void Start()
    {
        calculateNextFlap();
    }

 

    void calculateNextFlap()
    {
        durationForNextFlap = Random.Range(600, 800);
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

    public void Hit()
    {
        this.gameObject.animation.Play("Hit");
    }

    public void flap()
    {
        //Debug.Log("flap");
        this.gameObject.animation.Play("Flap");
    }
}