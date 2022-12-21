using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    private static int[,,] matrix = new int[3,3,3];
  
    public int[,,] Matrix
    {
        get { return matrix; }
        set { matrix = value; }
    }
   
    public void setSocketOccupied(int x, int y, int z)
    {
        matrix[x, y, z] = 1;
        Debug.Log("Occupato : " + x + y + z );
    }
    public void setSocketFree(int x, int y, int z)
    {
        matrix[x, y, z] = 0;
        Debug.Log("Libero : " + x + y + z);
    }

}
