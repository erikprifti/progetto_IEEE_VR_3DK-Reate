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
    public Material azzurro;

    public void Start()
    {
        Lobby = GameObject.FindGameObjectWithTag("Lobby");
        challenge = GameObject.FindWithTag("Challenge");
    }

    public void OnSelection()
    {
        selectingHand = takeScript.interactorsSelecting[0].transform.gameObject;
        selectingHand.GetComponent<HandChild>().player.cmdLobbyTeleportPlayer(selectingHand.GetComponent<HandChild>().player.gameObject, challenge,gameObject);
    }

    public void LobbyTeleport()
    {

        challenge.GetComponent<MeshRenderer>().material = azzurro;
        
        PlayerNet p = selectingHand.GetComponent<HandChild>().player;
        if(p.GetComponentInParent<PlayerManager>().getId() == 1)
             p.GetComponentInParent<PlayerManager>().setPassword(challenge.GetComponent<Challenge>().decrypt(7653));
        if (p.GetComponentInParent<PlayerManager>().getId() == 2)
            p.GetComponentInParent<PlayerManager>().setPassword(challenge.GetComponent<Challenge>().decrypt(1153));
        p.transform.position = Lobby.transform.position;

    }

    [TargetRpc]
    public void rpcLobbyTeleport(NetworkConnection target)
    {
        //if (isLocalPlayer) return;
        LobbyTeleport();
    }

}
