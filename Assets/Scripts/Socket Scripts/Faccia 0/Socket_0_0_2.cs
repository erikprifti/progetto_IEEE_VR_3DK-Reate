using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket_0_0_2 : MonoBehaviour
{
    public Interface _interface;

    int x = 2;
    int y = 0;
    int z = 0;

    public void setOccupied()
    {
        _interface.setSocketOccupied(x, y, z);
    }

}
