using UnityEngine;
using System.Collections;

public class ShadowHandler : MonoBehaviour
{
    public Transform shadow;
    public Transform player;

    private float characterHeight = 0.0f;
    private float initialY = 0.0f;
    private float groundHeight = 0.0f;

    void Start()
    {
        initialY = shadow.transform.position.y;
        characterHeight = player.transform.position.y;
    }

    void LateUpdate()
    {
        Vector3 pos = shadow.transform.position;
        pos.y = groundHeight + initialY - (transform.position.y - groundHeight);
        shadow.transform.position = pos;

        RaycastHit hit;
        int groundLayers = 1 << 10; // put here the layer where the ground/platforms are
        if (Physics.Raycast(-Vector3.left, transform.position + new Vector3(0, characterHeight, 0), out hit, Mathf.Infinity, groundLayers))
        {
            groundHeight = hit.point.y;
        }
    }
}