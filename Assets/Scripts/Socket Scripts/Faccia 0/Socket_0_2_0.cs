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
        Debug.Log("provo in socket 001: " + value);
        Debug.Log($"{args.interactorObject} hovered over {args.interactableObject}", this);
        setOccupied();
    }

    public void OnHoverExited(HoverExitEventArgs args)
    {
        value = 0;
        Debug.Log($"{args.interactorObject} stopped hovering over {args.interactableObject}", this);
        setFree();
    }
}
