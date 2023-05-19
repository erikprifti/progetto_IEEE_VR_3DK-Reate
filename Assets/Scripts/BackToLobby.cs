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
    public GameObject cubo;
    public Material NOK;
    public Grabbables gb;
    public GameObject gabbia;
  
    //  public Material azzurro;

    public void Start()
    {
        Lobby = GameObject.FindGameObjectWithTag("Lobby");
        challenge = GameObject.FindWithTag("Challenge");
        cubo = GameObject.FindWithTag("Cubo");

    }

    public void OnSelection() //IN LOCALE
    {
        int key = _oriDet.passwordGenerator();

        Debug.LogError("In OnSelection in BackToLobby, key read: " + key);

        selectingHand = takeScript.interactorsSelecting[0].transform.gameObject;
        PlayerNet p = selectingHand.GetComponent<HandChild>().player;

        p.gameObject.GetComponent<PlayerManager>().setPrivateKey(key);

        //cubo.GetComponent<ResetPosition>().ResetFucntion();
        //cubo.GetComponent<Rigidbody>().isKinematic = true;
        //gabbia.GetComponent<MeshRenderer>().material = NOK;
        //gb.ResetGrabbables();


        //Debug.LogError("In OnSelection in BackToLobby, password del selettore before: " + p.gameObject.GetComponent<PlayerManager>().password);
        //p.cmdPlayChallenge(key, challenge); //questo command spostarlo su interazione della challenge
        //challenge.GetComponent<Challenge>().play(key, p.gameObject.GetComponent<PlayerManager>().getId());

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
