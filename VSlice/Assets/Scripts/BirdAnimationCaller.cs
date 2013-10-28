using UnityEngine;
using System.Collections;

public class BirdAnimationCaller : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void bump()
    {
        this.gameObject.animation.Play("Bump");
    }

    public void flap()
    {
        this.gameObject.animation.Play("Flap");
    }
}