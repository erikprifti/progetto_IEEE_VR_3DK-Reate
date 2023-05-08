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

    public orientationDetection oriDet;

    public void OnTriggerEnter(Collider other)
    {
        Debug.LogError("dentro insert cube");
        GameObject bl;
        bl = GameObject.FindWithTag("BackToLobby");
        if (other.GetComponent<Interface>() )
        {
            snapCylinder();

            bl.GetComponentInChildren<displayBL>().setBLAvailable();
            bl.GetComponent<XRSimpleInteractable>().enabled = true;
            other.GetComponent<Rigidbody>().isKinematic = false;

            if (oriDet.checkKey() > 0) { 
                cilindroInterno.GetComponent<MeshRenderer>().material = NOK;
            }
            else
            {
                cilindroInterno.GetComponent<MeshRenderer>().material = OK;
            }


        }
    }

    public void snapCylinder()
    {
        float a = key.transform.rotation.eulerAngles.z; //initial angle
        Debug.Log(a);
        float b = a % (360 / 9);                       //offset

        if(b > 20)
        {
            key.transform.Rotate(0, 0, 40-b);
        }
        else
        {
            key.transform.Rotate(0, 0, -b);
        }

        //key.transform.Rotate(0, 0, a - (a % (360 / 9)));
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
