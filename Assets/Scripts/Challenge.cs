using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
using System.Linq;
using Unity.VisualScripting;

public class Challenge : NetworkBehaviour
{
    public Porta porta;
    public IdKeyPairs idKeyPairs;
    public string message;
    public int activePlayerId;
    public int passivePlayerId;
    public string messageEncrypted;
  


    //for debug
    public string test = "TEST CHALLENGE";

    //in multi: NullReferenceException: Object reference not set to an instance of an object
    private void Start()
    {
        idKeyPairs = GameObject.FindWithTag("IdKeyPairs").GetComponent<IdKeyPairs>();
        porta = GameObject.FindWithTag("Porta").GetComponent<Porta>(); ;
        //Debug.Log(String.Format(idKeyPairs.test));
        // Debug.Log(String.Format(porta.test));
        //if (isServer)
        //  gameObject.GetComponent<NetworkIdentity>().AssignClientAuthority(this.GetComponent<NetworkIdentity>().connectionToClient);

    }



    //for encryption and decryption
    long[] m; //message in long array
    long[] temp;
    long[] en; //encrypted message in long array
    public void setChallenge(int activePlayer, int passivePlayer)
    {
        Debug.LogError(String.Format("SONO IN SETCHALLENGE "));

        activePlayerId = activePlayer;
        passivePlayerId = passivePlayer;
        message = generateMessage();
        porta.setPassword(message);
       

        PlayerManager player = findPlayerById(activePlayerId);
        player.GetComponent<PlayerManager>().setPassword(message);

        m = new long[message.Length];
        temp = new long[message.Length];
        en = new long[message.Length];

        encrypt();
        Debug.LogError(String.Format("after encrypt"));
        //rpcSetChallenge(activePlayer,passivePlayer);
        //   newChallengeNotify();
    }

    //[ClientRpc]
    //public void rpcSetChallenge()
    //{
    //    activePlayerId = activePlayer.GetComponent<PlayerManager>().getId();
    //    passivePlayerId = passivePlayer.GetComponent<PlayerManager>().getId();
    //    message = generateMessage();
    //    porta.setPassword(message);
    //    activePlayer.GetComponent<PlayerManager>().setPassword(message);

    //    m = new long[message.Length];
    //    temp = new long[message.Length];
    //    en = new long[message.Length];

    //    encrypt();
    //    Debug.Log(String.Format("after encrypt"));
    //}


    public void resolveChallenge(int key, GameObject player)
    {
        if (!player.CompareTag("Player")) { return; }
        PlayerManager playerManager = player.GetComponent<PlayerManager>();
        int playerId = playerManager.getId();
        if (!playerId.Equals(passivePlayerId)) { return; }
        string messageDecrypted = decrypt(key);
        playerManager.setPassword(messageDecrypted);
    }

    private string generateMessage()
    {
        return "Bangtan Sonyeondan";
    }


    private void encrypt()
    {
        Debug.LogError(String.Format("in ENCRYPTED " ));

        long[] m = new long[message.Length];
        long pt, ct, k;
        long key = idKeyPairs.getEncode(passivePlayerId);
        int n = idKeyPairs.getModule(passivePlayerId);
        int i = 0;

        while (i < message.Length)
        {
            pt = m[i];
            pt = pt - 96;
            k = 1;
            for (long j = 0; j < key; j++)
            {
                k = k * pt;
                k = k % n;
            }
            temp[i] = k;
            ct = k + 96;
            en[i] = ct;
            i++;
        }

        string encryptMex = "";
        for (i = 0; i < en.Length; i++)
        {
            Debug.LogError((char)en[i]);
            encryptMex.Append<char>((char)en[i]);
        }
        messageEncrypted = encryptMex;
        Debug.LogError(String.Format("\nTHE ENCRYPTED MESSAGE IS " + messageEncrypted));

    }

    private string decrypt(int key)
    {
        long pt, ct, k;
        int n = idKeyPairs.getModule(passivePlayerId);
        int i = 0;
        while (en[i] < en.Length)
        {
            ct = temp[i];
            k = 1;
            for (long j = 0; j < key; j++)
            {
                k = k * ct;
                k = k % n;
            }
            pt = k + 96;
            m[i] = pt;
            i++;
        }

        string decryptMex = string.Empty;

        for (i = 0; i < m.Length; i++)
        {
            decryptMex = decryptMex + (char)m[i];
        }

        //Debug.Log(String.Format("\nTHE DECRYPTED MESSAGE IS " + decryptMex));

        return decryptMex;
    }

    //[Command]
    //public void newChallengeNotify()
    //{
    //    GameObject[] players = GameObject.FindGameObjectsWithTag("player");
    //    for (int i = 0; i < players.Length; i++)
    //    {
    //        GameObject p = players[i];

    //        if (passivePlayerId.Equals(p.GetComponent<PlayerManager>().getId()))
    //        {
    //            p.GetComponent<PlayerManager>().isInvited(true);
    //        }
    //        else if (activePlayerId.Equals(p.GetComponent<PlayerManager>().getId()))
    //        {
    //            p.GetComponent<PlayerManager>().isInvited(true);
    //        }
    //        else
    //        {
    //            p.GetComponent<PlayerManager>().isInvited(false);
    //        }

    //    }
    //}
    private PlayerManager findPlayerById(int activePlayerId)
    {
        Debug.LogError("activePlayer is " + activePlayerId);
        GameObject[] listaPlayer = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < listaPlayer.Length; i++)
        {
            Debug.LogError(listaPlayer[i].GetComponent<PlayerManager>().getId());
            if (listaPlayer[i].GetComponent<PlayerManager>().getId().Equals(activePlayerId))
            {
                Debug.LogError("trovato l'active " +listaPlayer[i].GetComponent<PlayerManager>().getId());
                return listaPlayer[i].GetComponent<PlayerManager>();
            }
        }
        return null;
    }

}
