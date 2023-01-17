using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket_1_2_0 : Socket
{
    public Interface _interface;

    int x = 0;
    int y = 2;
    int z = 1;

    public void setOccupied()
    {
        _interface.setSocketOccupied(x, y, z);
    }
    public void setFree()
    {
        _interface.setSocketFree(x, y, z);
    }
}
