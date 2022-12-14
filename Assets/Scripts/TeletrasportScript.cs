using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeletrasportScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider Col)
    {
        Col.transform.position = new Vector3(Random.Range(-5.0f, 5.0f), Col.transform.position.z, Random.Range(25.0f, 35.0f));
    }
}
