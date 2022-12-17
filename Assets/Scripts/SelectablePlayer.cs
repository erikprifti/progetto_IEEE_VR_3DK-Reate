using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SelectablePlayer : NetworkBehaviour
{
    public Challenge challenge;
    public XRSimpleInteractable takeScript;
    public GameObject selectingHand;
    public Material verde;
 

   

    public void Start()
    {
        challenge = GameObject.FindWithTag("Challenge").GetComponent<Challenge>();

    }
    

    public void OnSelection()
    {
        //if (!takeScript.interactorsSelecting[0].transform.gameObject.CompareTag("Player") || !gameObject.CompareTag("Player"))
        //{
        //    Debug.Log(String.Format("not a player/s in setChallenge"));
        //    return;
        //}
        Debug.LogError("Ho interagito con " + takeScript.interactorsSelecting[0].transform.gameObject.name);
        int activeID = takeScript.interactorsSelecting[0].transform.gameObject.GetComponentInParent<PlayerManager>().getId();
        int passiveID = gameObject.GetComponent<PlayerManager>().getId();
        selectingHand = takeScript.interactorsSelecting[0].transform.gameObject;
        selectingHand.GetComponent<HandChild>().player.cmdSelectPlayer(gameObject, activeID, passiveID); //passiamo a cmdSelectPlayer gameObject=player selezionato(passivePlayer)

    }

    public void Selected(int aID,int pID)
    {
        //Debug.Log("Ho interagito con " + takeScript.interactorsSelecting[0].transform.gameObject.name + " " + gameObject.name);
        challenge.setChallenge(aID,pID);
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
