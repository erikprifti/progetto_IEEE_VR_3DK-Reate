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
    //[SyncVar]
    //private bool invited = false;
    [SyncVar]
    public string password;
    public NetworkIdentity networkIdentity;


    void Start()
    {
        idKeyPairs = GameObject.FindWithTag("IdKeyPairs").GetComponent<IdKeyPairs>();
        challenge = GameObject.FindWithTag("Challenge").GetComponent<Challenge>();


        if (isClient  && isLocalPlayer)
        {
            //CmdSetAutoChallenge(networkIdentity, challenge.GetComponent<NetworkIdentity>());
            CmdSetPlayerInfo();

        }


        //StartCoroutine(ValueOfPlayer());
    }

    //IEnumerator ValueOfPlayer()
    //{
    //    yield return new WaitForSeconds(2f);

    //    if (id == 2)
    //    {
    //        challenge.setChallenge(gameObject, GameObject.FindGameObjectsWithTag("Player")[0]);
    //        Debug.Log(String.Format("setChallenge by " + id));
    //    }
    //    else
    //        Debug.Log(String.Format("CHALLENGE NOT SET, because id = " + id));
    //}



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

    //[Command]
    //public void isInvited(bool b)
    //{
    //    invited = b;
    //}

    private void OnPlayerDisconnected(NetworkIdentity player)
    {
        //da rivedere
        idKeyPairs.setAvailable(id);
    }

    //[Command]
    //public void CmdSetAutoChallenge(NetworkIdentity author, NetworkIdentity target)
    //{
    //    Debug.LogError(challenge.name + " " + gameObject.name);
    //    challenge.GetComponent<NetworkIdentity>().RemoveClientAuthority();
    //    challenge.GetComponent<NetworkIdentity>().AssignClientAuthority(author.connectionToClient);
    //}

}
