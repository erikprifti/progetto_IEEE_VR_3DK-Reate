using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grabbables : MonoBehaviour
{
    public GameObject g0;
    public GameObject g1;
    public GameObject g2;
    public GameObject g3;
    public GameObject g4;
    public GameObject g5;
    public GameObject g6;
        
    public GameObject g7;
    public GameObject g8;
    public GameObject g9;
    public GameObject g10;
    public GameObject g11;
    public GameObject g12;
    public GameObject g13;
    public GameObject g14;
    public GameObject g15;
    public GameObject g16;
    public GameObject g17;
    public GameObject g18;
    public GameObject g19;
    public GameObject g20;
    public GameObject g21;
    public GameObject g22;
    public GameObject g23;
    public GameObject g24;
    public GameObject g25;
    public GameObject g26;


    public GameObject parent;
    public Material rosso;
    public GameObject[] vector;
    
    // Start is called before the first frame update
    void Start()
    {
        vector = new GameObject[27];

        vector[0] = g0;
        vector[1] = g1;
        vector[2] = g2;
        vector[3] = g3;
        vector[4] = g4;
        vector[5] = g5;
        vector[6] = g6;

        vector[7] = g7;
        vector[8] = g8;
        vector[9] = g9;

        vector[10] = g10;

        vector[11] = g11;
        vector[12] = g12;

        vector[13] = g13;

        vector[14] = g14;

        vector[15] = g15;
        vector[16] = g16;
        vector[17] = g17;

        vector[18] = g18;
        vector[19] = g19;
        vector[20] = g20;
        vector[21] = g21;
        vector[22] = g22;
        vector[23] = g23;
        vector[24] = g24;
        vector[25] = g25;
        vector[26] = g26;
    }

    // Update is called once per frame
    public void ResetGrabbables()
    {
        for(int i= 0; i<27; i++)
        {
            vector[i].transform.SetParent(parent.transform);

            vector[i].GetComponent<ResetPosition>().ResetFucntion();
            vector[i].GetComponent<Rigidbody>().isKinematic = false;
            vector[i].GetComponent<MeshRenderer>().material = rosso;
        }
    }
}
