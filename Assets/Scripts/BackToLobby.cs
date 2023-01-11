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

      //  selectingHand.GetComponent<HandChild>().gameObject.GetComponent<ActivePlayer>().setPrivateKey(key);

        PlayerNet p = selectingHand.GetComponent<HandChild>().player;



        Debug.LogError("In OnSelection in BackToLobby, password del selettore before: " + p.gameObject.GetComponent<PlayerManager>().password);


        //setto password nel player che ha selezionato BackToLobby, da spezzare, 
        //anzi fare metodo play in challenge che gestisce se sono active e player a seconda di cosa è salvato in challenge, 
        //e setta anche la password in me perchè gli passo io come riferimento

        //challenge.GetComponent<Challenge>().play(key, p.gameObject);
        p.GetComponentInParent<PlayerManager>().setPassword(challenge.GetComponent<Challenge>().decrypt(key));

        Debug.LogError("In OnSelection in BackToLobby, password del selettore after: " + p.gameObject.GetComponent<PlayerManager>().password);

        //teleporto il player attraverso command
        p.cmdLobbyTeleportPlayer(selectingHand.GetComponent<HandChild>().player.gameObject, gameObject);
        //
    }

    public void LobbyTeleport()
    {

        //  challenge.GetComponent<MeshRenderer>().material = azzurro;
        Debug.LogError("In LobbyTeleport in BackToLobby ");

        PlayerNet p = selectingHand.GetComponent<HandChild>().player;

        //if (p.GetComponentInParent<PlayerManager>().password == null)
        //{
        //    if (p.GetComponentInParent<PlayerManager>().getId() == 1)
        //        p.GetComponentInParent<PlayerManager>().setPassword(challenge.GetComponent<Challenge>().decrypt(867));
        //    if (p.GetComponentInParent<PlayerManager>().getId() == 2)
        //        p.GetComponentInParent<PlayerManager>().setPassword(challenge.GetComponent<Challenge>().decrypt(379));
        //}
        p.gameObject.transform.position = Lobby.transform.position;

    }

    [TargetRpc]
    public void rpcLobbyTeleport(NetworkConnection target)
    {
        //if (isLocalPlayer) return;
        LobbyTeleport();
    }

}
