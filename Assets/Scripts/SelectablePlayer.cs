using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SelectablePlayer : NetworkBehaviour
{
    public GameObject challenge;
    public XRSimpleInteractable takeScript;
    public GameObject selectingHand;
    public Material verde;
 

   

    public void Start()
    {
        challenge = GameObject.FindWithTag("Challenge");

    }
    

    public void OnSelection()
    {
        
        Debug.LogError("Ho interagito con " + takeScript.interactorsSelecting[0].transform.gameObject.name);
        int activeID = takeScript.interactorsSelecting[0].transform.gameObject.GetComponentInParent<PlayerManager>().getId();
        int passiveID = gameObject.GetComponent<PlayerManager>().getId();
        selectingHand = takeScript.interactorsSelecting[0].transform.gameObject;
        Debug.LogError("in ONSelection "+activeID + " ha selezionato, mentre " + passiveID + " è stato selezionato");
        selectingHand.GetComponent<HandChild>().player.cmdSelectPlayer(gameObject, activeID, passiveID); //passiamo a cmdSelectPlayer gameObject=player selezionato(passivePlayer)

    }

    public void Selected(int aID,int pID)
    {
        //Debug.Log("Ho interagito con " + takeScript.interactorsSelecting[0].transform.gameObject.name + " " + gameObject.name);
        challenge.GetComponent<Challenge>().setChallenge(aID,pID);
        challenge.GetComponent<MeshRenderer>().material = verde;
        challenge.GetComponent<SphereCollider>().enabled = true;
    }

    [ClientRpc]
    public void rpcSelected(int aID, int pID)
    {
        //if (isLocalPlayer) return;
        Selected(aID,pID);
    }



}
