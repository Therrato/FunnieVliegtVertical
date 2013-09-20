using System;

public class FlyLane
{
    private int _x;

    public int x
    {
        get { return _x; }
        set { _x = value; }
    }

    private int _y;

    public int y
    {
        get { return _y; }
        set { _y = value; }
    }
    
	public FlyLane(int lanex,int laney)
	{
        _x = lanex;
        _y = laney;
	}
}
