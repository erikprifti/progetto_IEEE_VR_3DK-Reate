using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerManager : NetworkBehaviour
{
    public Challenge challenge;
    public IdKeyPairs idKeyPairs;
    public int id;
    public int publicKeyEncode;
    public int publicKeyModule;
    private bool invited = false;
    private string password;

    

    void Start()
    {
        //in multi: NullReferenceException: Object reference not set to an instance of an object
        idKeyPairs = GameObject.FindWithTag("IdKeyPairs").GetComponent<IdKeyPairs>(); ;
        challenge = GameObject.FindWithTag("Challenge").GetComponentInChildren<Challenge>();
        if (isOwned) { CmdSetPlayerInfo(); } 
        Debug.Log(String.Format(challenge.test));
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
        for (int i = 0; i < 3; i++) {
            if (idKeyPairs.idAvailable(i))
            {
                id = i;
                publicKeyEncode = idKeyPairs.getEncode(id);
                publicKeyModule = idKeyPairs.getModule(id);
                break;
            }
             
        }
        
    }

    public void isInvited(bool b)
    {
        invited = b;
    }
}
