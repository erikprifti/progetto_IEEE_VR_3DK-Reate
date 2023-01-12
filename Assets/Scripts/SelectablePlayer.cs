using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class SelectablePlayer : NetworkBehaviour
{
    public GameObject challenge;
    public Leaderboard lb;
    public XRSimpleInteractable takeScript;
    public GameObject selectingHand;
    public Material verde;
    public int id;



    public void Start()
    {
        challenge = GameObject.FindWithTag("Challenge");

    }

    public void onHoverEnter()
    {
        int selector = takeScript.interactorsHovering[0].transform.gameObject.GetComponentInParent<PlayerManager>().getId();
        if (id == 0  || challenge.GetComponent<Challenge>().activePlayerId == 0)
        {
               gameObject.GetComponent<TextMeshProUGUI>().color = Color.red;

            return;

        }
        else if(id == selector)
            {
            gameObject.GetComponent<TextMeshProUGUI>().color = Color.yellow;

        }else
        gameObject.GetComponent<TextMeshProUGUI>().color = Color.green;
    }
    
    public void onHoverExit()
    {
        gameObject.GetComponent<TextMeshProUGUI>().color = Color.white;
    }

    public void OnSelection()
    {
        Debug.LogError("selezione da" + takeScript.interactorsSelecting[0].transform.gameObject.GetComponentInParent<PlayerManager>().getId() + " selezionato " + id);
        if(id == 0 || challenge.GetComponent<Challenge>().activePlayerId == 0)
        {
            return;
        }
       

        int activeID = takeScript.interactorsSelecting[0].transform.gameObject.GetComponentInParent<PlayerManager>().getId();
        int passiveID = id;
        if (activeID == passiveID)
            return;

        selectingHand = takeScript.interactorsSelecting[0].transform.gameObject; //selectingHand è l'attivo
        Debug.LogError("in ONSelection " + activeID + " ha selezionato, mentre " + passiveID + " è stato selezionato");
        GameObject playerP = lb.id_player_map.GetValueOrDefault(passiveID);
        selectingHand.GetComponent<HandChild>().player.cmdSendMessage(challenge, playerP); //passiamo a cmdSelectPlayer gameObject=player selezionato(passivePlayer)
      
        gameObject.GetComponent<TextMeshProUGUI>().color = Color.red;

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
