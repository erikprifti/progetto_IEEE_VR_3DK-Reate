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
    public  Material grigio; //0
    public  Material rosso;  //1
    public  Material verde;  //2
    public  Material blu;    //3
    public  Material rosa;   //4
    public  Material giallo;  //5
    public  Material arancione;  //6
    public  Material viola;  //7
    public  Material azzurro;  //8
    public  Material marrone;  //9
    public int counter = 0;
    private int value;
    public Material[] colors;
    GameObject parent;

    private void Start()
    {
        colors = new Material[10];
        colors[0] = grigio;
        colors[1] = rosso;
        colors[2] = verde;
        colors[3] = blu;
        colors[4] = rosa;
        colors[5] = giallo;
        colors[6] = arancione;
        colors[7] = viola;
        colors[8] = azzurro;
        colors[9] = marrone;

        parent = gameObject.transform.parent.gameObject;

    }

     
    private bool inHand = false;

    public void OnSelection()
    {
        GameObject handController = takeScript.interactorsSelecting[0].transform.gameObject;

            
            //Kinematic
            gameObject.GetComponent<Rigidbody>().isKinematic = true;

            //trigger
            // gameObject.GetComponent<BoxCollider>().isTrigger = true;
            //   gameObject.GetComponent<BoxCollider>().enabled = false;

            //parent
           // parent = gameObject.transform.parent.gameObject;

            //GameObject handController = takeScript.interactorsSelecting[0].transform.gameObject;
            gameObject.transform.parent = handController.transform;

        if (handController.GetComponent<HandChild>() != null)
        {
            //position  sul controller, cubetto in mano
            inHand = true;
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
            inHand = false;
        }

        colorReference.action.started -= changeColor;


    }

    private void changeColor(InputAction.CallbackContext context)
    {

        if (inHand)
        {
            currentColor = colors[counter];
            meshRenderer.material = currentColor;
            counter++;
            if (counter == 10)
            {
                counter = 0;
            }
            value = getValueColor();

        }

    }

    public int getValueColor()
    {
       if(currentColor == grigio)
        {
            return 0;
        }else if(currentColor == rosso)
        {
            return 1;
        }else  if(currentColor == verde)
        {
            return 2;
        }
        else if (currentColor == blu)
        {
            return 3;
        }
        else if (currentColor == rosa)
        {
            return 4;
        }
        else if (currentColor == giallo)
        {
            return 5;
        }
        else if (currentColor == arancione)
        {
            return 6;
        }
        else if (currentColor == viola)
        {
            return 7;
        }
        else if (currentColor == azzurro)
        {
            return 8;
        }
        else if (currentColor == marrone)
        {
            return 9;
        }
        else 
        {
            Debug.LogError("error in getValueColor");
            return 0;
        }


    }
    
}
