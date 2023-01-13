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

    [SyncVar]
    public double message;
    [SyncVar]
    public int activePlayerId;
    [SyncVar]
    public int passivePlayerId;
    [SyncVar]
    public double messageEncryptedP;
    [SyncVar]
    public double messageEncryptedA;
    
    public double doorPassword;

    public GameObject ConfirmButton;
    public GameObject StartButton;
    public GameObject Display;
   
    SyncList<long> tempP = new SyncList<long>();

    SyncList<long> tempA = new SyncList<long>();

    private void Start()
    {
        idKeyPairs = GameObject.FindWithTag("IdKeyPairs").GetComponent<IdKeyPairs>();
        porta = GameObject.FindWithTag("Porta").GetComponent<Porta>();
        StartButton = GameObject.FindWithTag("StartButton");

        ConfirmButton = GameObject.FindWithTag("ConfirmButton");


    }



    //for encryption and decryption
    long[] mbA; //message in long array
    long[] maA;
    long[] mbP; //message in long array
    long[] maP;
    long[] enA; //encrypted message in long array
    long[] enP; //encrypted message in long array

    long[] vettA;
    long[] vettP;
    //public void setChallenge(int activePlayer, int passivePlayer)
    //{

    //    activePlayerId = activePlayer;
    //    passivePlayerId = passivePlayer;
    //    message = generateMessage();
    //    porta.setPassword(message);


    //    PlayerManager player = findPlayerById(activePlayerId);
    //    player.GetComponent<PlayerManager>().setPassword(message);

    //    Debug.LogError("IN SETCHALLENGE: " +activePlayer + " ha selezionato, mentre " + passivePlayer + " è stato selezionato");


    //    encrypt();
       
    //}

 

    private int generateMessage()
    {
        doorPassword = 1234;
        return 1234;
    }


    //private string encryptA(string mex, int key, int n)
    //{
    //    mbA = new long[mex.Length];
    //    maA = new long[mex.Length];

    //    vettA = new long[mex.Length];
    //    enA = new long[mex.Length];
    //    long pt, ct, k;
    //    int i = 0;

    //    for (int j = 0; j < mex.Length; j++)
    //    {
    //        mbA[j] = (int)mex[j];
    //    }

    //    while (i < mex.Length)
    //    {
    //        pt = mbA[i];
    //        pt = pt - 64;
    //        k = 1;
    //        for (long j = 0; j < key; j++)
    //        {
    //            k = k * pt;
    //            k = k % n;
    //        }
    //        vettA[i] = k;
    //        ct = k + 64;
    //        enA[i] = ct;
    //        i++;
    //    }

    //    string encryptMex = string.Empty;
    //    for (i = 0; i < enA.Length; i++)
    //    {
    //        encryptMex = encryptMex + (char)enA[i];
    //    }
    //    messageEncryptedP = encryptMex;
    //    return encryptMex;

    //}

    //private string encryptP(string mex, int key, int n)
    //{
    //    mbP = new long[mex.Length];
    //    maP = new long[mex.Length];

    //    vettP = new long[mex.Length];
    //    enP = new long[mex.Length];
    //    long pt, ct, k;
    //    int i = 0;

    //    for (int j = 0; j < mex.Length; j++)
    //    {
    //        mbP[j] = (int)mex[j];
    //    }

    //    while (i < mex.Length)
    //    {
    //        pt = mbP[i];
    //        pt = pt - 64;
    //        k = 1;
    //        for (long j = 0; j < key; j++)
    //        {
    //            k = k * pt;
    //            k = k % n;
    //        }
    //        vettP[i] = k;
    //        ct = k + 64;
    //        enP[i] = ct;
    //        i++;
    //    }

    //    string encryptMex = string.Empty;
    //    for (i = 0; i < enP.Length; i++)
    //    {
    //        encryptMex = encryptMex + (char)enP[i];
    //    }
    //    messageEncryptedP = encryptMex;
    //    return encryptMex;
    //}

    //public string decryptA(string mex, int key, int n)
    //{
    //    long pt, ct, k;
    //    int i = 0;
    //    //invece che usare en e ma devo prendere la stringa encryptmessage e usarla come array
    //    while (i < enA.Length)
    //    {

    //        ct = vettA[i];
    //        k = 1;
    //        for (long j = 0; j < key; j++)
    //        {
    //            k = k * ct;
    //            k = k % n;
    //        }
    //        pt = k + 64;
    //        maA[i] = pt;

    //        i++;
    //    }

    //    string decryptMex = null;

    //    for (i = 0; i < maA.Length; i++)
    //    {
    //        decryptMex = decryptMex + (char)maA[i];
    //    }

    //    return decryptMex;
    //}

    //public string decryptP(string mex, int key, int n)
    //{
    //    long pt, ct, k;
    //    int i = 0;
    //    //invece che usare en e ma devo prendere la stringa encryptmessage e usarla come array
    //    while (i < enP.Length)
    //    {

    //        ct = vettP[i];
    //        k = 1;
    //        for (long j = 0; j < key; j++)
    //        {
    //            k = k * ct;
    //            k = k % n;
    //        }
    //        pt = k + 64;
    //        maP[i] = pt;

    //        i++;
    //    }

    //    string decryptMex = null;

    //    for (i = 0; i < maP.Length; i++)
    //    {
    //        decryptMex = decryptMex + (char)maP[i];
    //    }

    //    return decryptMex;
    //}

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
        message = 0;
        activePlayerId = 0;
        passivePlayerId = 0;
        messageEncryptedP = 0;
        messageEncryptedA = 0;
        doorPassword = 0;
        tempA.Clear();
        tempP.Clear();
    }

    public double play(int key, int Id) //CHIMATA IN SERVER
    {
      
        PlayerManager p = findPlayerById(Id);

        if (activePlayerId == 0 && passivePlayerId == 0 ) //play chiamato dall attivo dopo aver messo la sua chiave privata con la quale decriptare per prima il messaggio
        {
            activePlayerId = p.id;
            int mex = generateMessage();
            messageEncryptedA = encryptA(mex, key, idKeyPairs.getModule(p.id));
          //  messageEncryptedA = encrypt(mex, key, idKeyPairs.getModule(p.id), 0);
            porta.setPassword(doorPassword);
            return doorPassword;
            //p.setPassword(doorPassword);
        }
        else if(activePlayerId != 0 && passivePlayerId != 0)
        {
            //momento di decriptazione
            Debug.LogError("Momento di risoluzione challenge");
            return resolveChallenge(key, p.gameObject);

        }else 
            return 0;
    }

    public void sendMessage(GameObject player) //player passivo a cui mandare mex
    {
        int pId = player.GetComponent<PlayerManager>().id;
        passivePlayerId = pId;
        int publicKey = idKeyPairs.getEncode(passivePlayerId);
        messageEncryptedP = encryptP(message, publicKey, idKeyPairs.getModule(pId));

      // messageEncryptedP = encrypt(messageEncryptedA, publicKey, idKeyPairs.getModule(pId), 1);
        message = messageEncryptedP;
        
    }

    private double encryptA(double mex, int key, int n)
    {
        double e = Math.Pow(mex, key);
        e = e % n;
        messageEncryptedA = e;
        return e;
    }
    private double encryptP(double mex, int key, int n)
    {
        double e = Math.Pow(mex, key);
        e = e % n;
        messageEncryptedP = e;
        return e;
    }

    private double decryptA(double mex, int key, int n)
    {
        double d = Math.Pow(mex, key);
        d = d % n;
        return d;
    }

    private double decryptP(double mex, int key, int n)
    {
        double d = Math.Pow(mex, key);
        d = d % n;
        return d;
    }
    //private string encrypt(string mex, int key, int n, int caso)
    //{

    //    mb = new long[mex.Length];
    //    SyncList<long> temp;

    //    if (caso == 0)
    //    {

    //        temp = tempA;
    //    }
    //    else
    //    {

    //        temp = tempP;
    //    }

    //    en = new long[mex.Length];
    //    long pt, ct, k;
    //    int i = 0;

    //    for (int j = 0; j < mex.Length; j++)
    //    {
    //        mb[j] = (int)mex[j];
    //    }

    //    while (i < mex.Length)
    //    {
    //        pt = mb[i];
    //        pt = pt - 64;
    //        k = 1;
    //        for (long j = 0; j < key; j++)
    //        {
    //            k = k * pt;
    //            k = k % n;
    //        }
    //        temp.Insert(i, k);
    //       // temp[i] = k;
    //        ct = k + 64;
    //        en[i] = ct;
    //        i++;
    //    }

    //    string encryptMex = string.Empty;
    //    for (i = 0; i < en.Length; i++)
    //    {
    //        encryptMex = encryptMex + (char)en[i];
    //    }

    //    return encryptMex;
    //}

    //public string decrypt(string mex, int key, int n, int caso)
    //{
    //    long pt, ct, k;
    //    int i = 0;
    //    ma = new long[mex.Length];
    //    SyncList<long> temp;

    //    if (caso == 0)
    //    {
    //        temp = tempA;
    //    }
    //    else
    //    {
    //        temp = tempP;
    //    }
    //    //invece che usare en e ma devo prendere la stringa encryptmessage e usarla come array
    //    while (i < mex.Length)
    //    {

    //        ct = temp[i];
    //        k = 1;
    //        for (long j = 0; j < key; j++)
    //        {
    //            k = k * ct;
    //            k = k % n;
    //        }
    //        pt = k + 64;
    //        ma[i] = pt;

    //        i++;
    //    }

    //    string decryptMex = null;

    //    for (i = 0; i < ma.Length; i++)
    //    {
    //        Debug.LogError((char)ma[i]);

    //        decryptMex = decryptMex + (char)ma[i];
    //    }
    //    Debug.LogError(decryptMex);

    //    return decryptMex;
    //}


    public double resolveChallenge(int privateKey, GameObject player) //chiamata da command
    {
        Debug.LogError("chiave del passivo: " + privateKey);

        PlayerManager playerManager = player.GetComponent<PlayerManager>();
        int playerId = playerManager.getId();
        if (!playerId.Equals(passivePlayerId)) { return 0; }

        Debug.LogError("password prima si decrypt" + playerManager.password);

        Debug.LogError(" messageEncryptedP:  messaggio criptato con la chiave pubblica dell passivo ->  " + messageEncryptedP);
        Debug.LogError(" messageEncryptedA:  messaggio criptato con la chiave privata dell attivo ->  " + messageEncryptedA);

        //message == messageEncrypted
        double messageDecryptedP = decryptP(message, privateKey, idKeyPairs.getModule(passivePlayerId));
      //  string messageDecryptedP = decrypt(message, privateKey, idKeyPairs.getModule(passivePlayerId), 1);
        Debug.LogError("MessageDecrypteedP, decriptato con chiave privata del passivo " + messageDecryptedP);
        double messageDecryptedA = decryptA(messageDecryptedP, idKeyPairs.getEncode(activePlayerId), idKeyPairs.getModule(activePlayerId));

      //  string messageDecryptedA = decrypt(messageDecryptedP, idKeyPairs.getEncode(activePlayerId), idKeyPairs.getModule(activePlayerId), 0);
        Debug.LogError("MessageDecrypteedA (con chiave pubblica attivo) e quindi password: " + messageDecryptedA);

        //PlayerManager p = findPlayerById(playerId);
     //   p.setPassword(messageDecryptedA); //questo da verificare

        // player.GetComponent<PlayerNet>().cmdChallengeFree(gameObject);
        //gameObject.GetComponent<Teleport>().rpcChallengeFree();
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
