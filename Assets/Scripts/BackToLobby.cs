using Mirror;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BackToLobby : NetworkBehaviour
{
    public GameObject challenge;
    public GameObject Lobby;
    public GameObject selectingHand;
    public XRSimpleInteractable takeScript;
    public orientationDetection _oriDet;
    //  public Material azzurro;

    public void Start()
    {
        Lobby = GameObject.FindGameObjectWithTag("Lobby");
        challenge = GameObject.FindWithTag("Challenge");
    }

    public void OnSelection()
    {
        //leggo la chiave a partire dal socket
        int key = _oriDet.passwordGenerator();
        Debug.LogError("In OnSelection in BackToLobby, key read: " + key);

        selectingHand = takeScript.interactorsSelecting[0].transform.gameObject;
        PlayerNet p = selectingHand.GetComponent<HandChild>().player;

        Debug.LogError("In OnSelection in BackToLobby, id del selettore: " + p.gameObject.GetComponent<PlayerManager>().getId());


        //setto password nel player che ha selezionato BackToLobby
        p.GetComponentInParent<PlayerManager>().setPassword(challenge.GetComponent<Challenge>().decrypt(key));
        
        //teleporto il player attraverso command
        p.cmdLobbyTeleportPlayer(selectingHand.GetComponent<HandChild>().player.gameObject, challenge,gameObject);
    }

    public void LobbyTeleport()
    {

      //  challenge.GetComponent<MeshRenderer>().material = azzurro;
        
        PlayerNet p = selectingHand.GetComponent<HandChild>().player;

        if (p.GetComponentInParent<PlayerManager>().password == null)
        {
            if (p.GetComponentInParent<PlayerManager>().getId() == 1)
                p.GetComponentInParent<PlayerManager>().setPassword(challenge.GetComponent<Challenge>().decrypt(867));
            if (p.GetComponentInParent<PlayerManager>().getId() == 2)
                p.GetComponentInParent<PlayerManager>().setPassword(challenge.GetComponent<Challenge>().decrypt(379));
        }
        p.transform.position = Lobby.transform.position;

    }

    [TargetRpc]
    public void rpcLobbyTeleport(NetworkConnection target)
    {
        //if (isLocalPlayer) return;
        LobbyTeleport();
    }

}
