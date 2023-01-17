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
        else
        {
            FindObjectOfType<Leaderboard>().playerActive = this;
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
    public void cmdTeleportPlayer(GameObject player, GameObject challenge, GameObject startButton)
    {
     //   challenge.GetNamedChild("Schermo").GetComponent<MeshRenderer>().material = challenge.GetComponent<Teleport>().rosso;
        //challenge.GetComponent<BoxCollider>().enabled = false;

        
        startButton.GetComponent<Teleport>().rpcSelectedTeleport(player.GetComponent<NetworkIdentity>().connectionToClient);
        challenge.GetComponent<Challenge>().rpcChallengeBusy();
    }

    [Command]
    public void cmdChallengeUpdate(int state, GameObject challenge, GameObject player)
    {
        if (state == 0)  //nextMove
        {
            challenge.GetComponent<Challenge>().rpcTargetChallengeNextMove(player.GetComponent<NetworkIdentity>().connectionToClient);
        }
        else
        { //passive player ha confermato
            challenge.GetComponent<Challenge>().rpcChallengeDestroy();
            challenge.GetComponent<Challenge>().rpcTargetEnableDoor(player.GetComponent<NetworkIdentity>().connectionToClient);

        }
    }

    [Command]
    public void cmdLobbyTeleportPlayer(GameObject player, GameObject btl, GameObject challenge)
    {

        btl.GetComponent<BackToLobby>().rpcLobbyTeleport(player.GetComponent<NetworkIdentity>().connectionToClient);
        challenge.GetComponent<Challenge>().rpcTargetChallengeConfirm(player.GetComponent<NetworkIdentity>().connectionToClient);


    }

    //[Command]
    //public void cmdChallengeFree(GameObject challenge)
    //{
    //    challenge.GetComponent<Teleport>().rpcChallengeFree();
    //}

    //[Command]
    //public void cmdChallengeFreeTarget(GameObject challenge, GameObject playerP)
    //{
    //    challenge.GetComponent<Teleport>().rpcChallengeFreeTarget(playerP.GetComponent<NetworkIdentity>().connectionToClient);
    //}


    [Command]
    public void cmdFinalTeleportPlayer(GameObject play, GameObject porta, GameObject c)
    {

        porta.GetComponent<Porta>().rpcFinalTeleport(play.GetComponent<NetworkIdentity>().connectionToClient);
        //porta.GetComponent<Porta>().threshold++;
        //if (porta.GetComponent<Porta>().threshold == 2)
        //{
        //    c.GetComponent<Challenge>().resetChallenge();
        //    // porta.GetComponent<Porta>().rpcResetChallenge();
        //    return;
        //}


    }

    [Command]
    public void cmdSendMessage(GameObject challenge, GameObject playerP, GameObject playerA)
    {
        challenge.GetComponent<Challenge>().sendMessage(playerP); //in server
                                                                  //cmdChallengeFreeTarget(gameObject, playerP);
                                                                  // challenge.GetComponent<Challenge>().rpcSendMessageTarget(playerP.GetComponent<NetworkIdentity>().connectionToClient, playerP); //setto challenge client specifico
        challenge.GetComponent<Challenge>().rpcChallengeBusy(); //enable challenge su client specifico
        challenge.GetComponent<Challenge>().rpcTargetChallengeToDoor(playerA.GetComponent<NetworkIdentity>().connectionToClient);
        challenge.GetComponent<Challenge>().rpcTargetChallengeWait(playerP.GetComponent<NetworkIdentity>().connectionToClient);
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
        int result = challenge.GetComponent<Challenge>().play(key, gameObject.GetComponent<PlayerManager>().id);
        gameObject.GetComponent<PlayerManager>().rcpTargetSetPassword(gameObject.GetComponent<NetworkIdentity>().connectionToClient, result);

    }

    [Command]
    public void cmdTurnBackToLobby( GameObject player, GameObject finalDoor)
    {
        finalDoor.GetComponent<backToSalaGame>().rpcLobbyTeleport(player.GetComponent<NetworkIdentity>().connectionToClient);
    }

}
