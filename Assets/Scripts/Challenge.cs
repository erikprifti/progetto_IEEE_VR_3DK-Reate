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
 
    private void Start()
    {
        idKeyPairs = GameObject.FindWithTag("IdKeyPairs").GetComponent<IdKeyPairs>();
        porta = GameObject.FindWithTag("Porta").GetComponent<Porta>();
        
    }



    //for encryption and decryption
    long[] mb; //message in long array
    long[] ma;
    long[] temp;
    long[] en; //encrypted message in long array
    public void setChallenge(int activePlayer, int passivePlayer)
    {

        activePlayerId = activePlayer;
        passivePlayerId = passivePlayer;
        message = generateMessage();
        porta.setPassword(message);


        PlayerManager player = findPlayerById(activePlayerId);
        player.GetComponent<PlayerManager>().setPassword(message);

        Debug.LogError("IN SETCHALLENGE: " +activePlayer + " ha selezionato, mentre " + passivePlayer + " è stato selezionato");


        encrypt();
       
    }

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
        return "Kebab";
    }


    private void encrypt()
    {
        mb = new long[message.Length];
        ma = new long[message.Length];

        temp = new long[message.Length];
        en = new long[message.Length];
        long pt, ct, k;
        long key = idKeyPairs.getEncode(passivePlayerId);
        int n = idKeyPairs.getModule(passivePlayerId);
        int i = 0;

        for(int j = 0; j<message.Length; j++)
        {
            mb[j] = (int)message[j];
        }

        while (i < message.Length)
        {
            pt = mb[i];
            pt = pt - 64;
            k = 1;
            for (long j = 0; j < key; j++)
            {
                k = k * pt;
                k = k % n;
            }
            temp[i] = k;
            ct = k + 64;
            en[i] = ct;
            i++;
        }

        string encryptMex = string.Empty;
        for (i = 0; i < en.Length; i++)
        {
            encryptMex = encryptMex + (char)en[i];
        }
        messageEncrypted = encryptMex;

    }

    public string decrypt(int key)
    {
        long pt, ct, k;
        int n = idKeyPairs.getModule(passivePlayerId);
        int i = 0;
        while (i < en.Length) 
        {

            ct = temp[i];
            k = 1;
            for (long j = 0; j < key; j++)
            {
                k = k * ct;
                k = k % n;
            }
            pt = k + 64;
            ma[i] = pt;
            i++;
        }

        string decryptMex = null;

        for (i = 0; i < ma.Length; i++)
        {
            decryptMex = decryptMex + (char)ma[i];
        }

        return decryptMex;
    }

    private PlayerManager findPlayerById(int activePlayerId)
    {
        //Debug.LogError("activePlayer is " + activePlayerId);
        GameObject[] listaPlayer = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < listaPlayer.Length; i++)
        {
            //Debug.LogError(listaPlayer[i].GetComponent<PlayerManager>().getId());
            if (listaPlayer[i].GetComponent<PlayerManager>().getId().Equals(activePlayerId))
            {
                //Debug.LogError("trovato l'active " +listaPlayer[i].GetComponent<PlayerManager>().getId());
                return listaPlayer[i].GetComponent<PlayerManager>();
            }
        }
        return null;
    }

    public void resetChallenge()
    {
        message = null;
        activePlayerId = 0;
        passivePlayerId = 0;
        messageEncrypted = null;
    }

}
