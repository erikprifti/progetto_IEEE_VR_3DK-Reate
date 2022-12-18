using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    private static int[,,] val = new int[3,3,3];
  
    public int[,,] Val
    {
        get { return val; }
        set { val = value; }
    }
   
    public void setSocketOccupied(int x, int y, int z)
    {
        val[x, y, z] = 1;
        Debug.Log("Occupato : " + x + y + z );
    }
    
}
