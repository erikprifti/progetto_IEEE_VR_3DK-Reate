using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InsertCube : MonoBehaviour
{
    public GameObject cilindroInterno;
    public Material OK;
    public Material NOK;
    public cubeOrientation2 coll2;

    public Interface key;

    public void OnTriggerEnter(Collider other)
    {
        GameObject bl;
        bl = GameObject.FindWithTag("BackToLobby");
        if (other.GetComponent<Interface>() )
        {
            float a = key.transform.rotation.eulerAngles.z;
            key.transform.Rotate(0,0,a-(a%(360/9)));
          
                bl.GetComponentInChildren<displayBL>().setBLAvailable();
                bl.GetComponent<XRSimpleInteractable>().enabled = true;
                cilindroInterno.GetComponent<MeshRenderer>().material = OK;
            
            
            other.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    public void uscito()
    {
        Debug.Log("rimosso");

        GameObject bl;
        bl = GameObject.FindWithTag("BackToLobby");
        bl.GetComponent<XRSimpleInteractable>().enabled = false;
        bl.GetComponentInChildren<displayBL>().setBLUnavailable();
        cilindroInterno.GetComponent<MeshRenderer>().material = NOK;
        cilindroInterno.GetComponentInParent<Rigidbody>().isKinematic = true;

    }
}
