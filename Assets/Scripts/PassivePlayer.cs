using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PassivePlayer : NetworkBehaviour
{
    public Challenge challenge;

    private void Start()
    {
        challenge = GameObject.FindWithTag("Challenge").GetComponent<Challenge>();
    }
}
