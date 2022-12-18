using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class socketCollision : MonoBehaviour
{
    private bool _isActive = false;
    public void OnTriggerEnter(Collider other)
    {
        _isActive = true;
        Debug.Log("hrhrsssh");
    }

    public void OnTriggerExit(Collider other)
    {
        _isActive=false; 
    }

    public bool isActive()
    {
        return _isActive;
    }
}
