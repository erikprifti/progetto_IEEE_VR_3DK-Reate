using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
using UnityEngine.XR.Interaction.Toolkit;


public class Porta : NetworkBehaviour
{
    public string password;
    public Challenge challenge;
    public GameObject selectingHand;
    public XRSimpleInteractable takeScript;
    public GameObject FinalScene;

    //for debug
    public string test = "TEST PORTA";

    private void Start()
    {
        FinalScene = GameObject.FindGameObjectWithTag("FinalScene");
        challenge = GameObject.FindWithTag("Challenge").GetComponent<Challenge>();
    }

    public void setPassword(string p)
    {
        password = p;
    }

    public bool verifyPassword(string p)
    {
        if (p.Equals(password))
        {
            Debug.Log(String.Format("Password are equals"));
            return true;
        }
        return false;
    }

    //ora serve il method dell'interazione tra giocatore e porta
    //NB: il giocatore attivo ha già la password appena crea la challenge
    //il giocatore passivo avrà la password dopo aver risolto la challenge
    //il method di interazione +  trasporto andrà ad invocare il method verifyPassword
    //di seguito un prototipo 
    public void OnSelection()
    {
        if (takeScript.interactorsSelecting[0].transform.gameObject.GetInstanceID() == challenge.passivePlayerId)
        {
            selectingHand = takeScript.interactorsSelecting[0].transform.gameObject;
            if (!verifyPassword(selectingHand.transform.gameObject.GetComponentInChildren<PlayerManager>().getPassword())) { return; }
            selectingHand.GetComponent<HandChild>().player.cmdFinalTeleportPlayer(selectingHand.GetComponent<HandChild>().player.gameObject, gameObject);
        }

        if (takeScript.interactorsSelecting[0].transform.gameObject.GetInstanceID() == challenge.activePlayerId)
        {
            selectingHand = takeScript.interactorsSelecting[0].transform.gameObject;
            if (!verifyPassword(selectingHand.transform.gameObject.GetComponentInChildren<PlayerManager>().getPassword())) { return; }
            selectingHand.GetComponent<HandChild>().player.cmdFinalTeleportPlayer(selectingHand.GetComponent<HandChild>().player.gameObject, gameObject);
        }

    }

    public void FinalTeleport()
    {
        PlayerNet p = selectingHand.GetComponent<HandChild>().player;
        p.transform.position = FinalScene.transform.position;

    }

    [TargetRpc]
    public void rpcFinalTeleport(NetworkConnection target)
    {
        //if (isLocalPlayer) return;
        FinalTeleport();
    }
    //public void OnTriggerEnter(Collider other)
    //{
    //    //if (!other.CompareTag("Player"))
    //    //{
    //    //    return;
    //    //}

    //    PlayerManager player = other.GetComponentInChildren<PlayerManager>();
    //    string playerSolution = player.getPassword();
    //    if (!verifyPassword(playerSolution)) { return; }

    //    //qui codice di teletrasporto
    //}
}
