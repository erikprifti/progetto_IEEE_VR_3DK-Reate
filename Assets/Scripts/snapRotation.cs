using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snapRotation : MonoBehaviour
{
    public Interface key;

    public socketCollision lato1;
    public socketCollision lato2;
    public socketCollision lato3;
    public socketCollision lato4;
    public socketCollision lato5;
    public socketCollision lato6;
    public socketCollision lato7;
    public socketCollision lato8;
    public socketCollision lato9;

    public void snapCylinder()
    {
        float initialRotation = key.transform.rotation.eulerAngles.z;
        float finalRotation;

        if (lato1.isActive())
        {
            
        }
    }

}
