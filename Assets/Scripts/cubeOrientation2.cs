using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeOrientation2 : MonoBehaviour
{
    private bool _isActive = false;
    private bool rotation = true;

    public void OnTriggerEnter(Collider other)
    {
        _isActive = true;
        Debug.Log("AAA cubo attivo");
    }

    public void OnTriggerExit(Collider other)
    {
        _isActive = false;
        Debug.Log("AAA cubo uscito");

    }
    public bool isActive()
    {
        return _isActive;
    }
   
}
