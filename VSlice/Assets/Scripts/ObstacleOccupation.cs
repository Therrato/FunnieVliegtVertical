using System;

public class ObstacleOccupation
{
    private int[] occupates = new int[3];
 

	public ObstacleOccupation(int xSpots, int hSpots, int zSpots)
	{
        occupates[0] = xSpots;
        occupates[1] = hSpots;
        occupates[2] = zSpots;


	}

    public int[] getOccupation()
    {
        return occupates;
    }


}
