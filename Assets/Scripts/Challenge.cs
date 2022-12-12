using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class Challenge : NetworkBehaviour
{
    public Porta porta;
    public IdKeyPairs idKeyPairs;
    [SyncVar]
    public string message;
    [SyncVar]
    public int activePlayerId;
    [SyncVar]
    public int passivePlayerId;
    public string messageEncrypted;
    private bool busy = false;


    //for debug
    public string test = "TEST CHALLENGE";

    //in multi: NullReferenceException: Object reference not set to an instance of an object
    private void Start()
    {
       // idKeyPairs = GameObject.FindWithTag("IdKeyPairs").GetComponent<IdKeyPairs>();
       // porta = GameObject.FindWithTag("Porta").GetComponent<Porta>(); ;
        //Debug.Log(String.Format(idKeyPairs.test));
       // Debug.Log(String.Format(porta.test));

    }
    


    //for encryption and decryption
    long[] m; //message in long array
    long[] temp;
    long[] en; //encrypted message in long array

    [Command]
    public void setChallenge(GameObject activePlayer, GameObject passivePlayer)
    {
        if (busy) { return; }
        if(!activePlayer.CompareTag("Player") || !passivePlayer.CompareTag("Player"))
        {
            Debug.Log(String.Format("not a player/s in setChallenge"));
            return;
        }
        setBusy(true);
        activePlayerId = activePlayer.GetComponentInChildren<PlayerManager>().getId();
        passivePlayerId = passivePlayer.GetComponentInChildren<PlayerManager>().getId();
        message = generateMessage();
        porta.setPassword(message);
        activePlayer.GetComponentInChildren<PlayerManager>().setPassword(message);

        m = new long[message.Length];
        temp = new long[message.Length];
        en = new long[message.Length];

        encrypt();
     //   newChallengeNotify();
    }

    
    public void resolveChallenge(int key, GameObject player)
    {
        if (!player.CompareTag("Player")) {  return; }
        PlayerManager playerManager = player.GetComponentInChildren<PlayerManager>();
        int playerId = playerManager.getId();
        if (!playerId.Equals(passivePlayerId)) { return; }
        string messageDecrypted = decrypt(key);
        playerManager.setPassword(messageDecrypted);
        setBusy(false);
    }

    private string generateMessage()
    {
        return "Bangtan Sonyeondan";
    }


    private void encrypt()
    {
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
        string encryptMex = string.Empty;

        for (i = 0; i < en.Length; i++)
        {
            encryptMex = encryptMex + (char)en[i];
        }
        messageEncrypted = encryptMex;
        //Debug.Log(String.Format("\nTHE ENCRYPTED MESSAGE IS " + encryptMex));

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

    [Command]
    public void newChallengeNotify()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("player");
        for(int i = 0; i < players.Length; i++)
        {
            GameObject p = players[i];

            if (passivePlayerId.Equals(p.GetComponent<PlayerManager>().getId()))
            {
                p.GetComponent<PlayerManager>().isInvited(true);
            }
            else if(activePlayerId.Equals(p.GetComponent<PlayerManager>().getId()))
            {
                p.GetComponent<PlayerManager>().isInvited(true);
            }
            else
            {
                p.GetComponent<PlayerManager>().isInvited(false);
            }

        }
    }

    [Command]
    private void setBusy(bool b)
    {
        busy = b;
    }
}

