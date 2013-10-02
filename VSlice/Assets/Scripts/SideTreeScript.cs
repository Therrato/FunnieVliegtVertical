using UnityEngine;
using System.Collections;

public class SideTreeScript : MonoBehaviour {
    public Material[] posibleMaterials;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Awake()
    {
        this.gameObject.renderer.material = posibleMaterials[Random.Range(0, posibleMaterials.Length)];
        this.gameObject.transform.rotation = new Quaternion(0f, Random.Range(0, 360), 0f, 0f);


    }
}