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
    public Material azzurro;
    public int passingTheTreshold = 0;

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
            //Debug.Log(String.Format("Password are equals"));
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
        if (takeScript.interactorsSelecting[0].transform.gameObject.GetComponentInParent<PlayerManager>().getId() == challenge.passivePlayerId)
        {
            selectingHand = takeScript.interactorsSelecting[0].transform.gameObject;
            if (!verifyPassword(selectingHand.transform.gameObject.GetComponentInParent<PlayerManager>().getPassword())) { return; }
            selectingHand.GetComponent<HandChild>().player.cmdFinalTeleportPlayer(selectingHand.GetComponent<HandChild>().player.gameObject, gameObject);
        }

        if (takeScript.interactorsSelecting[0].transform.gameObject.GetComponentInParent<PlayerManager>().getId() == challenge.activePlayerId)
        {
            selectingHand = takeScript.interactorsSelecting[0].transform.gameObject;
            if (!verifyPassword(selectingHand.transform.gameObject.GetComponentInParent<PlayerManager>().getPassword())) { return; }
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

    [ClientRpc]
    public void rpcResetChallenge()
    {
        challenge.resetChallenge();
        challenge.GetComponent<MeshRenderer>().material = azzurro;
    }
}
