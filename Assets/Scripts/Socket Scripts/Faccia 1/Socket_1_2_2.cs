using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket_1_2_2 : MonoBehaviour
{
    public Interface _interface;

    int x = 2;
    int y = 2;
    int z = 1;

    public void setOccupied()
    {
        _interface.setSocketOccupied(x, y, z);
    }

}