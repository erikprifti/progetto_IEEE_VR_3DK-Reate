using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InsertCube : MonoBehaviour
{
    
    public void OnTriggerEnter(Collider other)
    {
        GameObject bl;
        bl = GameObject.FindWithTag("BackToLobby");
        if (other.GetComponent<Interface>())
        {
            Debug.Log("inserito");
            bl.GetComponentInChildren<displayBL>().setBLAvailable();
            bl.GetComponent<XRSimpleInteractable>().enabled = true;
            
        }
    }

    public void uscito()
    {
        GameObject bl;
        bl = GameObject.FindWithTag("BackToLobby");
        Debug.Log("rimosso");
        bl.GetComponent<XRSimpleInteractable>().enabled = false;
        bl.GetComponentInChildren<displayBL>().setBLUnavailable();
    }
}
