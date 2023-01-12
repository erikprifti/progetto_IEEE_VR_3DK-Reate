using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;
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
        if (!isLocalPlayer)
        {
            XRsim.enabled = false; 
        }
    }

    //[Command]
    //public void cmdSelectPlayer(GameObject target, int activeID, int passiveID)
    //{
    //    Debug.LogError("in CMDSELECTPLAYER "+activeID + " ha selezionato, mentre " + passiveID + " è stato selezionato");

    //    target.GetComponent<SelectablePlayer>().challenge.GetComponent<Challenge>().setChallenge(activeID,passiveID);
    //    target.GetComponent<SelectablePlayer>().challenge.GetNamedChild("Schermo").GetComponent<MeshRenderer>().material = target.GetComponent<SelectablePlayer>().verde;
    //    target.GetComponent<SelectablePlayer>().challenge.GetComponent<BoxCollider>().enabled = true;

    //    target.GetComponent<SelectablePlayer>().rpcSelected(activeID,passiveID);
    //    target.GetComponent<SelectablePlayer>().rpcSelectableChallenge(target.GetComponent<NetworkIdentity>().connectionToClient);
    //}

    [Command]
    public void cmdTeleportPlayer(GameObject player, GameObject challenge)
    {
        Debug.LogError("IN COMMAND TELEPORT PLAYER"); //su server
        challenge.GetNamedChild("Schermo").GetComponent<MeshRenderer>().material = challenge.GetComponent<Teleport>().rosso;
        challenge.GetComponent<BoxCollider>().enabled = false;

        challenge.GetComponent<Teleport>().rpcChallengeBusy();
        challenge.GetComponent<Teleport>().rpcSelectedTeleport(player.GetComponent<NetworkIdentity>().connectionToClient);

    }

    [Command]
    public void cmdLobbyTeleportPlayer(GameObject player, GameObject btl)
    {

        btl.GetComponent<BackToLobby>().rpcLobbyTeleport(player.GetComponent<NetworkIdentity>().connectionToClient);

    }

    [Command]
    public void cmdChallengeFree(GameObject challenge)
    {
        challenge.GetComponent<Teleport>().rpcChallengeFree();
    }

    //[Command]
    //public void cmdChallengeFreeTarget(GameObject challenge, GameObject playerP)
    //{
    //    challenge.GetComponent<Teleport>().rpcChallengeFreeTarget(playerP.GetComponent<NetworkIdentity>().connectionToClient);
    //}


    [Command]
    public void cmdFinalTeleportPlayer(GameObject play, GameObject porta,GameObject c)
    {
        porta.GetComponent<Porta>().passingTheTreshold++;


        porta.GetComponent<Porta>().rpcFinalTeleport(play.GetComponent<NetworkIdentity>().connectionToClient);

        if (porta.GetComponent<Porta>().passingTheTreshold < 2)
        {
            c.GetComponent<Challenge>().resetChallenge();
            c.GetNamedChild("Schermo").GetComponent<MeshRenderer>().material = porta.GetComponent<Porta>().azzurro;
            porta.GetComponent<Porta>().rpcResetChallenge();
        }

    }

    [Command]
    public void cmdSendMessage(GameObject challenge, GameObject playerP)
    {
        challenge.GetComponent<Challenge>().sendMessage(playerP); //in server
        //cmdChallengeFreeTarget(gameObject, playerP);
       // challenge.GetComponent<Challenge>().rpcSendMessageTarget(playerP.GetComponent<NetworkIdentity>().connectionToClient, playerP); //setto challenge client specifico
        challenge.GetComponent<Teleport>().rpcChallengeFreeTarget(playerP.GetComponent<NetworkIdentity>().connectionToClient); //enable challenge su client specifico

    }

    //[Command]
    //public void cmdSetTextOnLB(GameObject lb, int id)
    //{
    //    GameObject t = lb.GetComponent<Leaderboard>().id_text_map.GetValueOrDefault(id);
    //    Debug.LogError("in  player net : " + id);

    //    t.GetComponent<SelectablePlayer>().id = id;
    //    t.GetComponent<TextMeshProUGUI>().text = "player " + id;
    //    lb.GetComponent<Leaderboard>().rpcSetTextOnLB(id);

    //}

    [Command]
    public void cmdPlayChallenge(int key, GameObject challenge)
    {
        challenge.GetComponent<Challenge>().play(key, gameObject.GetComponent<PlayerManager>().id);
    }

}
