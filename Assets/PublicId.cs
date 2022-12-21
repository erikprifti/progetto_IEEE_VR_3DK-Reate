using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Key;
using Unity.XR.CoreUtils;

public class PublicId : MonoBehaviour
{

    public int id;
    public PublicKey key;
    public XROrigin xrOrigin;

    public void Start()
    {
        key = gameObject.GetComponentInParent<IdKeyPairs>().getKey(id);
    }


}
