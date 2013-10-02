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
        this.gameObject.transform.Rotate(new Vector3(0f, Random.Range(0, 360), 0f));
        this.gameObject.transform.localScale = new Vector3((1 + Random.value/3), (1 + Random.value/3), (1 + Random.value/3));


    }
}