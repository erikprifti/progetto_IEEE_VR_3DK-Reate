using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ActivePlayer : NetworkBehaviour
{

    public Challenge challenge;

    private void Start()
    {
        challenge = GameObject.FindWithTag("Challenge").GetComponentInChildren<Challenge>();
    }


}
