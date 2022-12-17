using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket_0_2_0 : MonoBehaviour
{
    public Interface _interface;

    int x = 0;
    int y = 2;
    int z = 0;

    public void setOccupied()
    {
        _interface.setSocketOccupied(x, y, z);
    }

}
