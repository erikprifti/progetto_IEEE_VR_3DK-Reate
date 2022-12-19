using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation;
using UnityEngine.XR.Interaction.Toolkit;
//using UnityEngine.InputSystem;
//using UnityEditor;
//using UnityEngine.UIElements;
//using static UnityEngine.GraphicsBuffer;
//using UnityEditor.VersionControl;

public class PlayerNet : NetworkBehaviour
{
    public XRDeviceSimulator XRsim;

     void Start()
    {
        //if (isServer)
        //{
        //    //input.keyboardNet[KeyCode.G].AddListener(SelectCheDeviAncoraDefinirla);
        //    //input.keyboardNet[KeyCode.R].AddListener(SelectCheDeviAncoraDefinirla);
        //    XRsim.enabled = false;
        //}
        if (!isLocalPlayer)
        {
            XRsim.enabled = false; 
        }
    }

    [Command]
    public void cmdSelectPlayer(GameObject target, int activeID, int passiveID)
    {
        Debug.LogError("in CMDSELECTPLAYER "+activeID + " ha selezionato, mentre " + passiveID + " è stato selezionato");

        target.GetComponent<SelectablePlayer>().challenge.GetComponent<Challenge>().setChallenge(activeID,passiveID);
        target.GetComponent<SelectablePlayer>().challenge.GetComponent<MeshRenderer>().material = target.GetComponent<SelectablePlayer>().verde;
        target.GetComponent<SelectablePlayer>().challenge.GetComponent<SphereCollider>().enabled = true;
        target.GetComponent<SelectablePlayer>().rpcSelected(activeID,passiveID);
    }

    [Command]
    public void cmdTeleportPlayer(GameObject play, GameObject t)
    {
        Debug.LogError("IN COMMAND TELEPORT PLAYER");
        t.GetComponent<MeshRenderer>().material = t.GetComponent<Teleport>().rosso;
        t.GetComponent<SphereCollider>().enabled = false;
        t.GetComponent<Teleport>().rpcChallengeStarted();
        t.GetComponent<Teleport>().rpcSelectedTeleport(play.GetComponent<NetworkIdentity>().connectionToClient);

    }

    [Command]
    public void cmdLobbyTeleportPlayer(GameObject play, GameObject c,GameObject t)
    {
        //Debug.LogError(c);
        //c.GetComponent<MeshRenderer>().material = t.GetComponent<BackToLobby>().azzurro;
        t.GetComponent<BackToLobby>().rpcLobbyTeleport(play.GetComponent<NetworkIdentity>().connectionToClient);


        play.GetComponentInParent<PlayerManager>().setPassword(c.GetComponent<Challenge>().decrypt(1153)); //chiave del player con id=2

    }


    [Command]
    public void cmdFinalTeleportPlayer(GameObject play, GameObject t)
    {
        //Debug.LogError(t);
        

        t.GetComponent<Porta>().passingTheTreshold++;

        GameObject.FindGameObjectWithTag("Challenge").GetComponent<Challenge>().resetChallenge();
        GameObject.FindGameObjectWithTag("Challenge").GetComponent<SphereCollider>().enabled = true;
        GameObject.FindGameObjectWithTag("Challenge").GetComponent<MeshRenderer>().material = t.GetComponent<Porta>().azzurro;

        t.GetComponent<Porta>().rpcFinalTeleport(play.GetComponent<NetworkIdentity>().connectionToClient);

        if (t.GetComponent<Porta>().passingTheTreshold == 2)
            t.GetComponent<Porta>().rpcResetChallenge();

    }

}
