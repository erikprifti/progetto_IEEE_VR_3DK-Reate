using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ActivePlayer : NetworkBehaviour
{

    public Challenge challenge;
    private int privateKey;
    private void Start()
    {
        challenge = GameObject.FindWithTag("Challenge").GetComponent<Challenge>();
    }

    public void setPrivateKey(int p)
    {
        privateKey = p;
    }


}

