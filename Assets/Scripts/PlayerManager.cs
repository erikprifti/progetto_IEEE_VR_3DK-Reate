using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerManager : NetworkBehaviour
{
    public Challenge challenge;
    public IdKeyPairs idKeyPairs;
    [SyncVar]
    public int id;
    [SyncVar]
    public int publicKeyEncode;
    [SyncVar]
    public int publicKeyModule;
    [SyncVar]
    public string password;
    public NetworkIdentity networkIdentity;


    void Start()
    {
        idKeyPairs = GameObject.FindWithTag("IdKeyPairs").GetComponent<IdKeyPairs>();
        challenge = GameObject.FindWithTag("Challenge").GetComponent<Challenge>();


        if (isClient  && isLocalPlayer)
        {
            CmdSetPlayerInfo();

        }
    }

    public int getId()
    {
        return id;
    }

    public string getPassword()
    {
        return password;
    }

    public void setPassword(string p)
    {
        password = p;
    }

    [Command]
    public void CmdSetPlayerInfo()
    {
        for (int i = 1; i < 5; i++)
        {
            if (idKeyPairs.idAvailable(i))
            {

                id = i;
                publicKeyEncode = idKeyPairs.getEncode(id);
                publicKeyModule = idKeyPairs.getModule(id);
                idKeyPairs.setUnavailable(id);

                break;
            }

        }

    }

    private void OnPlayerDisconnected(NetworkIdentity player)
    {
        //da rivedere
        idKeyPairs.setAvailable(id);
    }
}
