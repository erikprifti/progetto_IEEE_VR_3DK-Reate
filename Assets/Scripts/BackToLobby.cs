using Mirror;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BackToLobby : NetworkBehaviour
{
    public Challenge challenge;
    public GameObject Lobby;
    public GameObject selectingHand;
    public XRSimpleInteractable takeScript;
    public Material azzurro;

    public void Start()
    {
        Lobby = GameObject.FindGameObjectWithTag("Lobby");
        challenge = GameObject.FindWithTag("Challenge").GetComponent<Challenge>();
    }

    public void OnSelection()
    {
        selectingHand = takeScript.interactorsSelecting[0].transform.gameObject;
        selectingHand.GetComponent<HandChild>().player.cmdLobbyTeleportPlayer(selectingHand.GetComponent<HandChild>().player.gameObject, challenge,gameObject);
    }

    public void LobbyTeleport()
    {

        challenge.GetComponent<MeshRenderer>().material = challenge.GetComponent<BackToLobby>().azzurro;
        //pulire challenge dai dati della challenge appena terminata
        PlayerNet p = selectingHand.GetComponent<HandChild>().player;
        p.transform.position = Lobby.transform.position;

    }

    [TargetRpc]
    public void rpcLobbyTeleport(NetworkConnection target)
    {
        //if (isLocalPlayer) return;
        LobbyTeleport();
    }

}
