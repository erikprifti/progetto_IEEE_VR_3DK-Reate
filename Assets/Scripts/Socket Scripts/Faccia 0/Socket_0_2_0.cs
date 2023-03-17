using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Socket_0_2_0 : Socket
{
    public Interface _interface;
    public XRSocketInteractor socket;
    int x = 0;
    int y = 2;
    int z = 0;

    public void setOccupied()
    {
        int value = socket.interactablesHovered[0].transform.gameObject.GetComponent<cubeSel>().getValueColor();
        _interface.setSocketOccupied(x, y, z, value);
    }
    public void setFree()
    {
        _interface.setSocketFree(x, y, z);
    }
}
