using UnityEngine;
using System.Collections;

public class HudScript : MonoBehaviour {
    public Texture2D hudImage;
    public InitScript statholder;
    public Texture2D filltext;
    public int drawx = 1095;
    public int drawY = 250;
    public int drawx2 = -114;
    public int drawY2 = -18;
    public int a = 0;
    

    void Awake()
    {
       
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //if (statholder.settings)
        statholder = GameObject.Find("InitHolder").GetComponent<InitScript>();
       
	}

    void DrawBar(int percentage)
    {
        GUI.DrawTexture(new Rect(drawx, drawY, 10, -percentage * 2), filltext);
        GUI.DrawTexture(new Rect(drawx2, drawY2, 1275, 720), hudImage);
        
        
        
        Debug.Log(percentage);
        
    }

    void OnGUI()
    {
        
        if (statholder.getRound() != 0)
        {
            DrawBar(statholder.NormalGoal.getPercentageReachedBananas(statholder.playerStats));
        }
        else
        {
            DrawBar(statholder.NormalGoal.getBarInt(statholder.playerStats));
        }
    }
}
