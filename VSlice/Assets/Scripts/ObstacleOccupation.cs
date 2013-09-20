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
    /// <summary>
    /// returns the space needed for the object; can be accesed by calling getOccupation()[value] 0 = width 1 = height 2 == depth
    /// </summary>
    /// <returns></returns>
    public int[] getOccupation()
    {
        return occupates;
    }


}
