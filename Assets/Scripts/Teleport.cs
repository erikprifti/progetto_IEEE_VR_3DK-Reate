using Mirror;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Teleport : NetworkBehaviour
{
    public GameObject ChallengeRoom;
    public GameObject selectingHand;
    public XRSimpleInteractable takeScript;
    public Material rosso;

    public void Start()
    {
        ChallengeRoom = GameObject.FindGameObjectWithTag("ChallengeRoom");

    }

    public void OnSelection()
    {
        if (takeScript.interactorsSelecting[0].transform.gameObject.GetComponentInParent<PlayerManager>().getId() == gameObject.GetComponent<Challenge>().passivePlayerId)
        {
            Debug.LogError("on selection in teleport, id del passive: " + takeScript.interactorsSelecting[0].transform.gameObject.GetComponentInParent<PlayerManager>().getId());

            selectingHand = takeScript.interactorsSelecting[0].transform.gameObject;
            selectingHand.GetComponent<HandChild>().player.cmdTeleportPlayer(selectingHand.GetComponent<HandChild>().player.gameObject, gameObject);
        }

    }



    public void Teleportation()
    {
        
      //  GetComponent<MeshRenderer>().material = GetComponent<Teleport>().rosso;

        PlayerNet p = selectingHand.GetComponent<HandChild>().player;
        p.transform.position = ChallengeRoom.transform.position;
        
    }

    [TargetRpc]
    public void rpcSelectedTeleport(NetworkConnection target)
    {
        //if (isLocalPlayer) return;
        Teleportation();
    }

    [ClientRpc]
    public void rpcChallengeStarted()
    {
        GetComponent<MeshRenderer>().material = rosso;
        GetComponent<SphereCollider>().enabled = false;

    }

}
