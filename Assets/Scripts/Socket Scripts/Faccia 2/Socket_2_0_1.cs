using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket_2_0_1 : MonoBehaviour
{
    public Interface _interface;

    int x = 1;
    int y = 0;
    int z = 2;

    public void setOccupied()
    {
        _interface.setSocketOccupied(x, y, z);
    }

}
