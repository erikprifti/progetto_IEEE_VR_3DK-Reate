using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.XR;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem.XR;

public class PlayerManager : NetworkBehaviour
{
    public Challenge challenge;
    public IdKeyPairs idKeyPairs;
    public Leaderboard leaderBoard;
    [SyncVar]
    public int id;
    [SyncVar]
    public int publicKeyEncode;
    [SyncVar]
    public int publicKeyModule;
    [SyncVar]
    public string password;
    public NetworkIdentity networkIdentity;

    public XROrigin xrOrigin;
    public InputActionManager iAM;
    public CharacterController cc;
    public TrackedPoseDriver tpd;
    public ActionBasedController l, r;
    public XRRayInteractor xrRr, xrRl;
    public ActionBasedContinuousMoveProvider abcM;
    public ActionBasedContinuousTurnProvider abcT;
    public LocomotionSystem lS;
    public Camera cameraActive;
    public GameObject avatar;
    public GameObject cRoom;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        gameObject.transform.position = cRoom.transform.position;
    }

    void Start()
    {
        idKeyPairs = GameObject.FindWithTag("IdKeyPairs").GetComponent<IdKeyPairs>();
        challenge = GameObject.FindWithTag("Challenge").GetComponent<Challenge>();
        leaderBoard = GameObject.FindWithTag("LeaderBoard").GetComponent<Leaderboard>();
        cRoom = GameObject.FindGameObjectWithTag("ChallengeRoom");

        if (isLocalPlayer)
        {
            if (isClient) {

                CmdSetPlayerInfo();
            }

            cameraActive.enabled = true;
        }
        else
        {
            xrOrigin.enabled = false;
            //iAM.enabled = false;
            //cc.enabled = false;
            lS.enabled = false;
            abcM.enabled = false;
            abcT.enabled = false;
            tpd.enabled = false;
            l.enabled = false;
            r.enabled = false;
            xrRl.enabled = false;
            xrRr.enabled = false;
            avatar.SetActive(true);
        }
        
    }

    public int getId()
    {
        return id;
    }

    public string getPassword()
    {
        return password;
    }

    public void setPassword(string p)
    {
        password = p;
    }

    [Command]
    public void CmdSetPlayerInfo()
    {
        for (int i = 1; i < 5; i++)
        {
            if (idKeyPairs.idAvailable(i))
            {

                id = i;
                publicKeyEncode = idKeyPairs.getEncode(id);
                publicKeyModule = idKeyPairs.getModule(id);
                idKeyPairs.setUnavailable(id);
                leaderBoard.addPlayer(id, gameObject); // on server

                leaderBoard.rpcClearPlayerMap();

                for (int j = 1; j <= leaderBoard.id_player_map.Count; j++)
                {
                    leaderBoard.rpcSetTextOnLB(j, leaderBoard.id_player_map.GetValueOrDefault(j));
                }
                break;
            }

        }

    }

    private void OnPlayerDisconnected(NetworkIdentity player)
    {
        //da rivedere
        idKeyPairs.setAvailable(id);
    }
}
