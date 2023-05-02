using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    public Vector3 startPostion;
    
    // Start is called before the first frame update
    void Start()
    {
        startPostion = gameObject.transform.position;
    }

    // Update is called once per frame
    public void ResetFunction()
    {
        gameObject.transform.position = startPostion;
    }
}
