using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class socketCollision : MonoBehaviour
{
    public cubeOrientation1 coll_1;
    public cubeOrientation2 coll_2;

    private bool _isActive = false;
    private bool _isPosition = false;
    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<cubeOrientation1>() || other.GetComponent<cubeOrientation2>())
        {
            _isActive = true;
            if (other == coll_1.gameObject.GetComponent<Collider>())
            {
                _isPosition = true;
            }
            Debug.Log("AAA socket attivo");
        }
        
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<cubeOrientation1>() || other.GetComponent<cubeOrientation2>())
        {
            _isActive = false;
            _isPosition = false;
            Debug.Log("AAA socket uscito");
        }
            

    }

    public bool isActive()
    {
        return _isActive;
    }
    public bool isPosition()
    {
        return _isPosition;
    }
}
