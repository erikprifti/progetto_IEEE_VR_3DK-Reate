using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burgerScript : MonoBehaviour
{
    public orientationDetection _oriDet;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("haitocccatoilBurger");
        _oriDet.makeRotations();
    }
}
