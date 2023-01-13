using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System.Numerics;

public class Challenge : NetworkBehaviour
{
    public Porta porta;
    public IdKeyPairs idKeyPairs;

    [SyncVar]
    public int message;
    [SyncVar]
    public int activePlayerId;
    [SyncVar]
    public int passivePlayerId;
    [SyncVar]
    public int messageEncryptedP;
    [SyncVar]
    public int messageEncryptedA;

    public int doorPassword;

    public GameObject ConfirmButton;
    public GameObject StartButton;
    public GameObject Display;
    private void Start()
    {
        idKeyPairs = GameObject.FindWithTag("IdKeyPairs").GetComponent<IdKeyPairs>();
        porta = GameObject.FindWithTag("Porta").GetComponent<Porta>();
        StartButton = GameObject.FindWithTag("StartButton");

        ConfirmButton = GameObject.FindWithTag("ConfirmButton");


    }



    private int generateMessage()
    {
        doorPassword = 13;
        return doorPassword;
    }



    private int encrypt(int mex, int key, int module)
    {
        Debug.LogError("in encrypt");

        Debug.LogError(mex);

        Debug.LogError(key);

        Debug.LogError(module);

        BigInteger c = BigInteger.Pow(mex, key);
        int res = (int)(c % module);

        messageEncryptedA = res;
        return res;
    }
    private int decrypt(int mex, int key, int module)
    {
        BigInteger c = BigInteger.Pow(mex, key);
        int res = (int)(c % module);

        return res;
    }

    private PlayerManager findPlayerById(int activePlayerId)
    {
        GameObject[] listaPlayer = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < listaPlayer.Length; i++)
        {
            if (listaPlayer[i].GetComponent<PlayerManager>().getId().Equals(activePlayerId))
            {
                return listaPlayer[i].GetComponent<PlayerManager>();
            }
        }
        return null;
    }

    public void resetChallenge()
    {
        message = 0;
        activePlayerId = 0;
        passivePlayerId = 0;
        messageEncryptedP = 0;
        messageEncryptedA = 0;
        doorPassword = 0;
    }

    public int play(int key, int Id) //CHIMATA IN SERVER
    {

        PlayerManager p = findPlayerById(Id);

        if (activePlayerId == 0 && passivePlayerId == 0) //play chiamato dall attivo dopo aver messo la sua chiave privata con la quale decriptare per prima il messaggio
        {
            activePlayerId = p.id;
            int mex = generateMessage();
            messageEncryptedA = encrypt(mex, key, idKeyPairs.getModule(p.id));
            Debug.LogError("messageEncryptedA " + messageEncryptedA);
            porta.setPassword(doorPassword);
            return doorPassword;
        }
        else if (activePlayerId != 0 && passivePlayerId != 0)
        {
            //momento di decriptazione
            return resolveChallenge(key, p.gameObject);

        }
        else
            return 0;
    }

    public void sendMessage(GameObject player) //player passivo a cui mandare mex
    {
        int pId = player.GetComponent<PlayerManager>().id;
        passivePlayerId = pId;
        int publicKey = idKeyPairs.getEncode(passivePlayerId);
        messageEncryptedP = encrypt(messageEncryptedA, publicKey, idKeyPairs.getModule(pId));
        message = messageEncryptedP;

    }

  
    public int resolveChallenge(int privateKey, GameObject player) //chiamata da command
    {
        if (!player.CompareTag("Player")) { return 0; }
        PlayerManager playerManager = player.GetComponent<PlayerManager>();
        int playerId = playerManager.getId();
        if (!playerId.Equals(passivePlayerId)) { return 0; }

        int messageDecryptedP = decrypt(message, privateKey, idKeyPairs.getModule(passivePlayerId));
        Debug.LogError("messageDEP " + messageDecryptedP);

        int messageDecryptedA = decrypt(messageDecryptedP, idKeyPairs.getEncode(activePlayerId), idKeyPairs.getModule(activePlayerId));
        Debug.LogError("messageDEA " + messageDecryptedA);

        return messageDecryptedA;
    }

    [TargetRpc]
    public void rpcSendMessageTarget(NetworkConnection target, GameObject player)
    {

        sendMessage(player);
    }

    [ClientRpc]
    public void rpcChallengeBusy()
    {
        Display.GetComponentInParent<MeshRenderer>().material = Display.GetComponent<Display>().red;
        Display.GetComponent<Display>().setDisplayBusy();
        StartButton.GetComponent<BoxCollider>().enabled = false;

    }

    [ClientRpc]
    public void rpcChallengeFree()
    {
        Display.GetComponentInParent<MeshRenderer>().material = Display.GetComponent<Display>().green;
        Display.GetComponent<Display>().setDisplayAvailable();
        StartButton.GetComponent<BoxCollider>().enabled = true;

    }

    [TargetRpc]
    public void rpcTargetChallengeNextMove(NetworkConnection target)
    {
        Display.GetComponentInParent<MeshRenderer>().material = Display.GetComponent<Display>().red;
        Display.GetComponent<Display>().setDisplayNextMove();
        ConfirmButton.GetComponent<BoxCollider>().enabled = false;

        StartButton.GetComponent<BoxCollider>().enabled = false;
    }

    [TargetRpc]
    public void rpcTargetChallengeConfirm(NetworkConnection target)
    {
        Display.GetComponentInParent<MeshRenderer>().material = Display.GetComponent<Display>().red;
        Display.GetComponent<Display>().setDisplayConfirm();
        StartButton.GetComponent<BoxCollider>().enabled = true;

        ConfirmButton.GetComponent<BoxCollider>().enabled = true;
    }

    [TargetRpc]
    public void rpcTargetChallengeWait(NetworkConnection target)
    {
        Display.GetComponentInParent<MeshRenderer>().material = Display.GetComponent<Display>().blu;
        Display.GetComponent<Display>().setDisplayWaiting();
        StartButton.GetComponent<BoxCollider>().enabled = true;
    }
}