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
    public GameObject cilindro;
    public GameObject cilindroInterno;
    public Material NOK;
    public grabbables gb;
    //  public Material azzurro;

    public void Start()
    {
        Lobby = GameObject.FindGameObjectWithTag("Lobby");
        challenge = GameObject.FindWithTag("Challenge");
        cilindro = GameObject.FindWithTag("Cilindro");
    }

    public void OnSelection() //IN LOCALE
    {
        int key = _oriDet.passwordGenerator();

        Debug.LogError("In OnSelection in BackToLobby, key read: " + key);

        selectingHand = takeScript.interactorsSelecting[0].transform.gameObject;
        PlayerNet p = selectingHand.GetComponent<HandChild>().player;

        p.gameObject.GetComponent<PlayerManager>().setPrivateKey(key);

        //cilindro.GetComponent<ResetPosition>().ResetFunction();
        //cilindro.GetComponent<Rigidbody>().isKinematic = true;
        //cilindroInterno.GetComponent<MeshRenderer>().material = NOK;
        //gb.resetGrabbables();

        //Debug.LogError("In OnSelection in BackToLobby, password del selettore before: " + p.gameObject.GetComponent<PlayerManager>().password);
        //p.cmdPlayChallenge(key, challenge); //questo command spostarlo su interazione della challenge
        //challenge.GetComponent<Challenge>().play(key, p.gameObject);

        //Debug.LogError("In OnSelection in BackToLobby, password del selettore after: " + p.gameObject.GetComponent<PlayerManager>().password);

        //teleporto il player attraverso command
        p.cmdLobbyTeleportPlayer(selectingHand.GetComponent<HandChild>().player.gameObject, gameObject, challenge);
        //
    }

    public void LobbyTeleport()
    {
        PlayerNet p = selectingHand.GetComponent<HandChild>().player;

        p.gameObject.transform.position = Lobby.transform.position;

    }

    [TargetRpc]
    public void rpcLobbyTeleport(NetworkConnection target)
    {
        LobbyTeleport();
    }

}
