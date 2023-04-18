using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Socket_2_0_1 : Socket
{

    public Interface _interface;
    public XRSocketInteractor socket;
    int x = 1;
    int y = 2;
    int value = 0;

    public void setOccupied()
    {

        //int value = socket.interactablesHovered[0].transform.gameObject.GetComponent<cubeSel>().getValueColor();
        //legge giusta ma setSocket legge prima fare 2 funzioni diverse :)
        _interface.setSocketOccupied(x, y);

    }
    public void setFree()
    {
        _interface.setSocketFree(x, y);
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
