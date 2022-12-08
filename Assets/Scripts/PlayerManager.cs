using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerManager : NetworkBehaviour
{
    public Challenge challenge;
    public ServerData serverData;

    private int id;
    private int publicKeyEncode;
    private int publicKeyModule;
    private bool invited = false;
    private string password;
    
    void Start()
    {
        challenge = GameObject.FindWithTag("Challenge").GetComponentInChildren<Challenge>();
        if (hasAuthority) { CmdSetPlayerInfo(); } 
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
            if (serverData.idAvailable(i))
            {
                id = i;
                publicKeyEncode = serverData.getEncode(id);
                publicKeyModule = serverData.getModule(id);
                break;
            }
             
        }
        
    }

    public void isInvited(bool b)
    {
        invited = b;
    }
}
