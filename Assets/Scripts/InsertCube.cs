using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertCube : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Interface>())
        {
            Debug.Log("inserito");
        }
    }

    public void uscito()
    {
        Debug.Log("rimosso");
    }
}
