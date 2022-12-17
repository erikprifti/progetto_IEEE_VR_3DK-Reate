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
    public PlayerNetInput input;
    public XRDeviceSimulator XRsim;


    private void Awake()
    {
        input = GetComponent<PlayerNetInput>();
        
    }

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
        //int passiveID = target.GetComponent<PlayerManager>().getId();
        Debug.LogError( "passive " + passiveID);
        //SelectablePlayer s= target.GetComponent<SelectablePlayer>();
        //XRSimpleInteractable takeScript = s.takeScript;
        //List<IXRSelectInteractor> list = takeScript.interactorsSelecting;

        //Debug.LogError(list);

        //Debug.LogError(list.ToArray().Length);

        //Debug.LogError(list.ToArray()[1]);

        //Debug.LogError(list.ToArray()[0]);

        //IXRSelectInteractor IX = list[0];

        //Transform t = IX.transform;

        //GameObject g = t.gameObject;

        //Debug.LogError(g);

        

        //int activeID = g.GetComponentInParent<PlayerManager>().getId();
        Debug.LogError("active "+ activeID );
        target.GetComponent<SelectablePlayer>().challenge.setChallenge(activeID,passiveID);
        target.GetComponent<SelectablePlayer>().challenge.GetComponent<MeshRenderer>().material = target.GetComponent<SelectablePlayer>().verde;
        target.GetComponent<SelectablePlayer>().challenge.GetComponent<SphereCollider>().enabled = true;
        target.GetComponent<SelectablePlayer>().rpcSelected(activeID,passiveID);
    }

    [Command]
    public void cmdTeleportPlayer(GameObject play, GameObject t)
    {
        Debug.LogError(t);
        t.GetComponent<MeshRenderer>().material = t.GetComponent<Teleport>().rosso;
        t.GetComponent<SphereCollider>().enabled = false;
        t.GetComponent<Teleport>().rpcSelectedTeleport(play.GetComponent<NetworkIdentity>().connectionToClient);

    }

    [Command]
    public void cmdLobbyTeleportPlayer(GameObject play, Challenge c,GameObject t)
    {
        Debug.LogError(c);
        c.GetComponent<MeshRenderer>().material = c.GetComponent<BackToLobby>().azzurro;
        t.GetComponent<BackToLobby>().rpcLobbyTeleport(play.GetComponent<NetworkIdentity>().connectionToClient);

    }


    [Command]
    public void cmdFinalTeleportPlayer(GameObject play, GameObject t)
    {
        Debug.LogError(t);
        t.GetComponent<Porta>().rpcFinalTeleport(play.GetComponent<NetworkIdentity>().connectionToClient);

    }

    //[ClientRpc]
    //public void rpcSelected(GameObject t)
    //{
    //    Debug.LogError(t);
    //    t.GetComponent<SelectablePlayer>().Selected();
    //}

    //private void SelectCheDeviAncoraDefinirla(KeyCode arg0, bool arg1)
    //{
    //    if(arg0 == KeyCode.G)
    //    {
    //        //Funzione di selezione
    //        m_TriggerAction.SetDirty();
    //    }
    //}
}
