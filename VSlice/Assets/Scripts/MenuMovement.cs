using UnityEngine;
using System.Collections;

public class MenuMovement : MonoBehaviour
{
    #region public

    public GameObject handRight;
    public Camera myCam;
    public Vector3 objPos;
    public Texture2D aTexture;

    public Texture2D emptyCursor;
    public Texture2D phase1Cursor;
    public Texture2D phase2Cursor;
    public Texture2D phase3Cursor;

    public GameObject parent;

    public int texWidth = 75;
    public int texHeight = 75;

    public bool followMouse;

    #endregion

    #region privates

    private int depth = 5;
    private Vector2 mousePos;
    private Vector3 wantedPos;
    private Vector3 previousPos = new Vector3(0,0,0);
    private bool firstStart;
    


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
            if (previousPos.x == 0)
            {
                previousPos = new Vector3(handRight.transform.position.x, handRight.transform.position.y, 0);
            }
            else {
               // Debug.Log(previousPos.x - handRight.transform.position.x);
                this.transform.position = new Vector3(this.transform.position.x + (handRight.transform.position.x - previousPos.x)*8, this.transform.position.y + (handRight.transform.position.y - previousPos.y)*5, 0.0f);
                previousPos = handRight.transform.position;
            }
          //  this.transform.position = new Vector3(handRight.transform.position.x * 100, handRight.transform.position.y * 100, 0);
            objPos = myCam.WorldToScreenPoint(this.transform.position);

            
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
