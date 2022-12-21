using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket_2_0_0 : MonoBehaviour
{
    public Interface _interface;

    int x = 0;
    int y = 0;
    int z = 2;

    public void setOccupied()
    {
        _interface.setSocketOccupied(x, y, z);
    }
    public void setFree()
    {
        _interface.setSocketFree(x, y, z);
    }
}
