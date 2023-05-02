using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabbables : MonoBehaviour
{

    public GameObject grabbable0;
    public GameObject grabbable1;
    public GameObject grabbable2;
    public GameObject grabbable3;       
    public GameObject grabbable4;
    public GameObject grabbable5;
    public GameObject grabbable6;
    public GameObject grabbable7;
    public GameObject grabbable8;      
    public GameObject grabbable9;
    public GameObject grabbable10;
    public GameObject grabbable11;
    public GameObject grabbable12;
    public GameObject grabbable13;
    public GameObject grabbable14;    
    public GameObject grabbable15;
    public GameObject grabbable16;
    public GameObject grabbable17;
    public GameObject grabbable18;      
    public GameObject grabbable19;
    public GameObject grabbable20;
    public GameObject grabbable21;       
    public GameObject grabbable22;
    public GameObject grabbable23;
    public GameObject grabbable24;
    public GameObject grabbable25;
    public GameObject grabbable26;

    public GameObject parent;
    public Material rosso;

    public GameObject[] gvector;

    private void Start()
    {
        gvector = new GameObject[27];

        gvector[0] = grabbable0;
        gvector[1] = grabbable1;
        gvector[2] = grabbable2;
        gvector[3] = grabbable3;
        gvector[4] = grabbable4;
        gvector[5] = grabbable5;
        gvector[6] = grabbable6;
        gvector[7] = grabbable7;
        gvector[8] = grabbable8;
        gvector[9] = grabbable9;
        gvector[10] = grabbable10;
        gvector[11] = grabbable11;
        gvector[12] = grabbable12;
        gvector[13] = grabbable13;
        gvector[14] = grabbable14;
        gvector[15] = grabbable15;
        gvector[16] = grabbable16;
        gvector[17] = grabbable17;
        gvector[18] = grabbable18;
        gvector[19] = grabbable19;
        gvector[20] = grabbable20;
        gvector[21] = grabbable21;
        gvector[22] = grabbable22;
        gvector[23] = grabbable23;
        gvector[24] = grabbable24;
        gvector[25] = grabbable25;
        gvector[26] = grabbable26;
    }

    public void resetGrabbables()
    {
        for(int i=0; i<27; i++)
        {
            gvector[i].transform.SetParent(parent.transform);
            gvector[i].GetComponent<ResetPosition>().ResetFunction();
            gvector[i].GetComponent<Rigidbody>().isKinematic = false;
            gvector[i].GetComponent<MeshRenderer>().material = rosso;
     
        }
    }

}
