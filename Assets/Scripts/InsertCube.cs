using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InsertCube : MonoBehaviour
{
   public  GameObject gabbia;
    public Material OK;
    public Material NOK;
    public void OnTriggerEnter(Collider other)
    {
        GameObject bl;
        bl = GameObject.FindWithTag("BackToLobby");
        if (other.GetComponent<Interface>())
        {
            Debug.Log("inserito");
            bl.GetComponentInChildren<displayBL>().setBLAvailable();
            bl.GetComponent<XRSimpleInteractable>().enabled = true;
            gabbia.GetComponent<MeshRenderer>().material = OK;
        }
    }

    public void uscito()
    {
        GameObject bl;
        bl = GameObject.FindWithTag("BackToLobby");
        Debug.Log("rimosso");
        bl.GetComponent<XRSimpleInteractable>().enabled = false;
        bl.GetComponentInChildren<displayBL>().setBLUnavailable();
        gabbia.GetComponent<MeshRenderer>().material = NOK;

    }
}
