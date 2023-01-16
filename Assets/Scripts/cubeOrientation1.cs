using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeOrientation1 : MonoBehaviour
{
    private bool _isActive = false;

    public void OnTriggerEnter(Collider other)
    {
        _isActive = true;
    }

    public void OnTriggerExit(Collider other)
    {
        _isActive = false;

    }
    public bool isActive()
    {
        return _isActive;
    }
 
}
