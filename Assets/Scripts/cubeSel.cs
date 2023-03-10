using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class cubeSel : MonoBehaviour
{
    public InputActionReference colorReference = null;

    public MeshRenderer meshRenderer = null;
    public XRSimpleInteractable takeScript;
    public  Material currentColor;
    public static Material grigio; //0
    public static Material rosso;  //1
    public static Material verde;  //2
    public static Material blu;    //3
    public static Material rosa;   //4
    public static Material giallo;  //5
    public static Material arancione;  //6
    public static Material viola;  //7
    public static Material azzurro;  //8
    public static Material marrone;  //9
    public int value = 0;

    private Material[] colors = { grigio, rosso, verde, blu, rosa, giallo, arancione, viola, azzurro, marrone };

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


        colorReference.action.started += changeColor;

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

        colorReference.action.started -= changeColor;

        //trigger
        //  gameObject.GetComponent<BoxCollider>().isTrigger = false;
        //   gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    private void changeColor(InputAction.CallbackContext context)
    {
       // bool isActive = !gameObject.activeSelf;
        currentColor = colors[value];
        meshRenderer.material = currentColor;
        value++;
        if(value == 10) { value = 0; }


    }
}
