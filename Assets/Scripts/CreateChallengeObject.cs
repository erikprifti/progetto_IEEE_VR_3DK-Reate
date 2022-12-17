using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateChallengeObject : NetworkBehaviour
{
    // Start is called before the first frame update
    public GameObject prefabChallenge;
    void Start()
    {

        if (isServer)
        {
            GameObject go = Instantiate(prefabChallenge);
            NetworkServer.Spawn(go, connectionToClient);

        }

    }


}

