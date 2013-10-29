using UnityEngine;
using System.Collections;
using Kinect;
using System;

public class FunnieTutorialArmControllerScript : MonoBehaviour
{



    public GameObject handLeft;
    public GameObject handRight;
    public GameObject shoulderCenter;
    private float funniespeed = 35;
    private float funnieMaxSpeed = 40;
    private bool _hasFeather = false;
    private float featherExtraSpeed = 15;
    private float featherDuration = 2;
    private DateTime featherPickupTime;

    float angle;

    float heightDistance = 14f;


    // Use this for initialization
    void Awake()
    {
        handLeft = GameObject.Find("Hand_Left");
        handRight = GameObject.Find("Hand_Right");
        shoulderCenter = GameObject.Find("Shoulder_Center");
    }
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
            if (_hasFeather) checkFeatherDuration();
            increaseSpeed();
            updatePosition();
            if ((handRight.transform.position.y - handLeft.transform.position.y) != 0)
            {

                this.gameObject.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan((handRight.transform.position.y - handLeft.transform.position.y) / (handRight.transform.position.x - handLeft.transform.position.x)) * Mathf.Rad2Deg * -1);

                angle = Mathf.Atan((handRight.transform.position.y - handLeft.transform.position.y) /
                                    (handRight.transform.position.x - handLeft.transform.position.x)) * Mathf.Rad2Deg;
                //Debug.Log ("angle of arms "+angle);

            }
            else return;

    }

    private void checkFeatherDuration()
    {

        TimeSpan runtime = DateTime.Now.Subtract(featherPickupTime);
        if (runtime.Seconds > featherDuration) featherStoppedWorking();
    }

    void updatePosition()
    {
        this.gameObject.transform.parent.transform.Translate(((angle / 5 * Time.deltaTime) * funniespeed / 35), 0, 0);

        if (handRight.transform.position.y < shoulderCenter.transform.position.y - 0.1f && handLeft.transform.position.y < shoulderCenter.transform.position.y - 0.1f)
        {
            this.gameObject.transform.parent.transform.position = new Vector3(this.gameObject.transform.parent.transform.position.x,
                                                                                this.gameObject.transform.parent.transform.position.y - heightDistance * Time.deltaTime,
                                                                                this.gameObject.transform.parent.transform.position.z);

        }

        if (handRight.transform.position.y > shoulderCenter.transform.position.y + 0.1f && handLeft.transform.position.y > shoulderCenter.transform.position.y + 0.1f)
        {
            this.gameObject.transform.parent.transform.position = new Vector3(this.gameObject.transform.parent.transform.position.x,
                                                                                this.gameObject.transform.parent.transform.position.y + heightDistance * Time.deltaTime,
                                                                                this.gameObject.transform.parent.transform.position.z);

        }

        this.gameObject.transform.parent.transform.position = new Vector3(Mathf.Clamp(this.gameObject.transform.parent.transform.position.x, -18F, 18F),
                                                                            Mathf.Clamp(this.gameObject.transform.parent.transform.position.y, 2.0f, 27.0f),
                                                                            40);
    }

    public float getFunnieSpeed()
    {
        return funniespeed;
    }

    public void setFunnieSpeed()
    {
        funniespeed = 35;
    }

    public void increaseSpeed()
    {
        if (funnieMaxSpeed > funniespeed)
        {
            funniespeed += 0.5f * Time.deltaTime;
        }
    }

    public void CollectsFeather()
    {

        featherPickupTime = DateTime.Now;
        if (funniespeed + featherExtraSpeed >= funnieMaxSpeed + featherExtraSpeed)
        {
            funniespeed = funnieMaxSpeed + featherExtraSpeed;
        }
        else
        {
            funniespeed += featherExtraSpeed;
        }
        GameObject.Find("FeatherParticle").GetComponent<ParticleSystem>().Play();
        _hasFeather = true;
    }

    public void featherStoppedWorking()
    {
        if (funniespeed > funnieMaxSpeed)
        {
            funniespeed = funnieMaxSpeed;
        }
        GameObject.Find("FeatherParticle").GetComponent<ParticleSystem>().Stop();
        _hasFeather = false;
    }
    /// <summary>
    /// has the player optained a feather?
    /// </summary>
    /// <returns>true or false</returns>
    public bool hasFeather()
    {
        return _hasFeather;
    }

    public void pickupBanana()
    {
        GameObject.Find("BananaParticle").GetComponent<ParticleSystem>().Play();
    }
}
