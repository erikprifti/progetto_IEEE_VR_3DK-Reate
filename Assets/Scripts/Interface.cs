using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Interface : MonoBehaviour
{
    public XRSimpleInteractable takeScript;
    private static int[,] matrix = new int[9, 3];
    GameObject parent;

    public int[,] Matrix
    {
        get { return matrix; }
        set { matrix = value; }
    }

    public void setSocketOccupied(int x, int y, int value)
    {
        Debug.Log("occupato" + x + y );
        matrix[x, y] = value;
        //Debug.Log("Occupato : " + x + y + z );
        //qui prendere valore del colore cubetto e sommarlo

    }
    public void setSocketFree(int x, int y)
    {
        Debug.Log("libero" + x + y);

        matrix[x, y] = 0;
        //Debug.Log("Libero : " + x + y + z);
    }

    public void OnSelection()
    {
        //Kinematic
        gameObject.GetComponent<Rigidbody>().isKinematic = true;

        //trigger
        gameObject.GetComponent<MeshCollider>().isTrigger = true;
        //   gameObject.GetComponent<BoxCollider>().enabled = false;

        //parent
        parent = gameObject.transform.parent.gameObject;
        GameObject handController = takeScript.interactorsSelecting[0].transform.gameObject;
        gameObject.transform.parent = handController.transform;

        //position
        gameObject.transform.position = handController.GetComponent<HandChild>().offset.transform.position;
        gameObject.transform.rotation = handController.GetComponent<HandChild>().offset.transform.rotation;


    }

    public void OnDiselection()
    {
        //position
        gameObject.transform.parent = parent.transform;

        //Kinematic
        gameObject.GetComponent<Rigidbody>().isKinematic = false;

        //trigger
        gameObject.GetComponent<MeshCollider>().isTrigger = false;
        //   gameObject.GetComponent<BoxCollider>().enabled = true;
    }

}