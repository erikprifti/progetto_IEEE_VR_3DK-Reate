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
        challenge = GameObject.FindGameObjectWithTag("Challenge");
        
    }
    

    public void OnSelection()
    {
       
        selectingHand = takeScript.interactorsSelecting[0].transform.gameObject;
        selectingHand.GetComponent<HandChild>().player.cmdSelectPlayer(gameObject);

    }

    public void Selected()
    {
        //Debug.LogError("Ho interagito con " + takeScript.interactorsSelecting[0].transform.gameObject.name);
        //challenge.setChallenge(takeScript.interactorsSelecting[0].transform.gameObject.name, gameObject);
        challenge.GetComponent<MeshRenderer>().material = verde;
        challenge.GetComponent<SphereCollider>().enabled = true;
    }

    [ClientRpc]
    public void rpcSelected()
    {
        //if (isLocalPlayer) return;
        Selected();
    }



}
