using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class cubeSel : MonoBehaviour
{
    public XRSimpleInteractable takeScript;
    GameObject parent;
    private bool entered = false;

    public void OnSelection()
    {
        GameObject handController = takeScript.interactorsSelecting[0].transform.gameObject;

            entered = true;
            //Kinematic
            gameObject.GetComponent<Rigidbody>().isKinematic = true;

            //trigger
            // gameObject.GetComponent<BoxCollider>().isTrigger = true;
            //   gameObject.GetComponent<BoxCollider>().enabled = false;

            //parent
            parent = gameObject.transform.parent.gameObject;

            //GameObject handController = takeScript.interactorsSelecting[0].transform.gameObject;
            gameObject.transform.parent = handController.transform;

        if (handController.GetComponent<HandChild>() != null)
        {
            //position
            gameObject.transform.position = handController.GetComponent<HandChild>().offsetCube.transform.position;
            gameObject.transform.rotation = handController.GetComponent<HandChild>().offsetCube.transform.rotation;
        }
        else if (handController.GetComponent<Socket>() != null)
        {
            gameObject.transform.localPosition = new Vector3(0, 0, 0);
            gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
        }


    }

    public void OnDiselection()
    {
        if (gameObject.transform.parent.gameObject.GetComponent<HandChild>() != null)
        {
            //position
            gameObject.transform.parent = parent.transform;

            //Kinematic
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            entered = false;
        }

        //trigger
      //  gameObject.GetComponent<BoxCollider>().isTrigger = false;
        //   gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
