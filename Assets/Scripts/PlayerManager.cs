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
    public SnapTurnProviderBase stpb;
    public TrackedPoseDriver tpd;
    public ActionBasedController l, r;
    public XRRayInteractor xrRr, xrRl;



    void Start()
    {
        idKeyPairs = GameObject.FindWithTag("IdKeyPairs").GetComponent<IdKeyPairs>();
        challenge = GameObject.FindWithTag("Challenge").GetComponent<Challenge>();


        if (isLocalPlayer)
        {
            if (isClient)
                CmdSetPlayerInfo();

        }
        else
        {
            xrOrigin.enabled = false;
            iAM.enabled = false;
            cc.enabled = false;
            stpb.enabled = false;
            tpd.enabled = false;
            l.enabled = false;
            r.enabled = false;
            xrRl.enabled = false;
            xrRr.enabled = false;
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
