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
    public GameObject playerCheMiSeleziona;
    public Material verde;
    

   

    public void Start()
    {
        challenge = GameObject.FindGameObjectWithTag("Challenge");
        
    }
    

    public void OnSelection()
    {
       
        playerCheMiSeleziona = takeScript.interactorsSelecting[0].transform.gameObject;
        Debug.LogError(playerCheMiSeleziona);
        playerCheMiSeleziona.GetComponent<HandChild>().player.cmdSelectPlayer(gameObject);

    }

    public void Selected()
    {
        Debug.Log("Ho interagito con " + takeScript.interactorsSelecting[0].transform.gameObject.name);
        //challenge.setChallenge(takeScript.interactorsSelecting[0].transform.gameObject.name, gameObject);
        challenge.GetComponent<MeshRenderer>().material = verde;
    }
   

}
