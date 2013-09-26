using UnityEngine;
using System.Collections;

public class MenuMovement : MonoBehaviour
{
    #region public

    public GameObject handRight;
    public Camera myCam;
    public Vector3 objPos;
    public Texture2D aTexture;

    public GameObject parent;

    public int texWidth = 75;
    public int texHeight = 75;

    public bool followMouse;

    #endregion

    #region privates

    private int depth = 5;
    private Vector2 mousePos;
    private Vector3 wantedPos;
    


    #endregion

    // Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
        mousePos = Input.mousePosition;
        wantedPos = myCam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, depth));

        

        if (!followMouse)
        {
            this.transform.position = new Vector3(handRight.transform.position.x, handRight.transform.position.y,0);
            objPos = myCam.WorldToScreenPoint(handRight.transform.position);
        }
        else
        {
            this.transform.position = wantedPos;
        }
	}

    void OnGUI()
    {
        if (!followMouse)
        {
            GUI.DrawTexture(new Rect(objPos.x - (texWidth / 2), (Screen.height - objPos.y) - (texHeight / 2), texWidth, texHeight), aTexture);
        }
        else
        {
            GUI.DrawTexture(new Rect(mousePos.x - (texWidth / 2), (Screen.height - mousePos.y) - (texHeight / 2), texWidth, texHeight), aTexture);
        }
    }
}
