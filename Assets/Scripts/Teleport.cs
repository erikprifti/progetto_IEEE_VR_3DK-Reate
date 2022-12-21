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
        Debug.LogError("on selection in teleport, id selezionatore della challenge: " + takeScript.interactorsSelecting[0].transform.gameObject.GetComponentInParent<PlayerManager>().getId());
        Debug.LogError("on selection in teleport, id del passive: " + takeScript.interactorsSelecting[0].transform.gameObject.GetComponentInParent<PlayerManager>().getId());

        if (takeScript.interactorsSelecting[0].transform.gameObject.GetComponentInParent<PlayerManager>().getId() == gameObject.GetComponent<Challenge>().passivePlayerId)
        {

            selectingHand = takeScript.interactorsSelecting[0].transform.gameObject;
            selectingHand.GetComponent<HandChild>().player.cmdTeleportPlayer(selectingHand.GetComponent<HandChild>().player.gameObject, gameObject);
        }

    }



    public void Teleportation()
    {
        
      //  GetComponent<MeshRenderer>().material = GetComponent<Teleport>().rosso;

        PlayerNet p = selectingHand.GetComponent<HandChild>().player;
        Debug.LogError("in Teleportation, player id: " + p.gameObject.GetComponent<PlayerManager>().getId());
        Debug.LogError("ChallengeRoom poisition: " + ChallengeRoom.transform.position);

        p.gameObject.transform.position = ChallengeRoom.transform.position;
     //   p.gameObject.transform.TransformPoint(ChallengeRoom.transform.position);

        Debug.LogError("player after poisition: " + p.gameObject.transform.position);


    }

    [TargetRpc]
    public void rpcSelectedTeleport(NetworkConnection target)
    {
        //if (isLocalPlayer) return;
        Debug.LogError("in rpcSelectedTeleport, before teleportation");

        Teleportation();
    }

    [ClientRpc]
    public void rpcChallengeStarted()
    {
        gameObject.GetComponent<MeshRenderer>().material = rosso;
        gameObject.GetComponent<SphereCollider>().enabled = false;

    }

}
