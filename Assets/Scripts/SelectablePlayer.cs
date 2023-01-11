using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SelectablePlayer : NetworkBehaviour
{
    public GameObject challenge;
    public XRSimpleInteractable takeScript;
    public GameObject selectingHand;
    public Material verde;
    public int id;



    public void Start()
    {
        challenge = GameObject.FindWithTag("Challenge");

    }



    public void OnSelection()
    {
        if(id == 0)
        {
            return;
        }
        Leaderboard lb = gameObject.GetComponentInParent<Leaderboard>();

        Debug.LogError("selezione da" + takeScript.interactorsSelecting[0].transform.gameObject.name);
        int activeID = takeScript.interactorsSelecting[0].transform.gameObject.GetComponentInParent<PlayerManager>().getId();
        int passiveID = id;
        if (activeID == passiveID)
            return;
        selectingHand = takeScript.interactorsSelecting[0].transform.gameObject; //selectingHand è l'attivo
        Debug.LogError("in ONSelection " + activeID + " ha selezionato, mentre " + passiveID + " è stato selezionato");

        //selectingHand.GetComponent<HandChild>().player.cmdSendMessage(challenge, activeID, passiveID); //passiamo a cmdSelectPlayer gameObject=player selezionato(passivePlayer)

    }

    //public void Selected(int aID,int pID)
    //{
    //    //Debug.Log("Ho interagito con " + takeScript.interactorsSelecting[0].transform.gameObject.name + " " + gameObject.name);
    //    challenge.GetComponent<Challenge>().setChallenge(aID,pID);
    //    challenge.GetNamedChild("Schermo").GetComponent<MeshRenderer>().material = verde; 
    //    //challenge.GetComponent<SphereCollider>().enabled = true;
    //}

    //[ClientRpc]
    //public void rpcSelected(int aID, int pID)
    //{
    //    //if (isLocalPlayer) return;
    //    Selected(aID,pID);
    //}

    //[TargetRpc]
    //public void rpcSelectableChallenge(NetworkConnection target)
    //{
    //    //da cambiare per new logic
    //    challenge.GetComponent<BoxCollider>().enabled = true;
    //}


}
