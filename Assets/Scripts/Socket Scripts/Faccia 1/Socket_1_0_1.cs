using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Socket_1_0_1 : Socket
{
    public Interface _interface;

    int x = 1;
    int y = 0;
    int z = 1;
    int value = 0;

    public void setOccupied()
    {

        //int value = socket.interactablesHovered[0].transform.gameObject.GetComponent<cubeSel>().getValueColor();
        //legge giusta ma setSocket legge prima fare 2 funzioni diverse :)
        _interface.setSocketOccupied(x, y, z, value);

    }
    public void setFree()
    {
        _interface.setSocketFree(x, y, z);
    }

    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        value = args.interactableObject.transform.gameObject.GetComponent<cubeSel>().getValueColor();

        setOccupied();
    }

    public void OnHoverExited(HoverExitEventArgs args)
    {
        value = 0;

        setFree();
    }
}
