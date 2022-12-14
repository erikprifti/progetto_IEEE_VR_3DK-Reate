using Mirror;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Teleport : NetworkBehaviour
{
    // Start is called before the first frame update

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

        selectingHand = takeScript.interactorsSelecting[0].transform.gameObject;
        selectingHand.GetComponent<HandChild>().player.cmdTeleportPlayer(selectingHand.GetComponent<HandChild>().player.gameObject, gameObject);

    }

    public void Teleportation()
    {
        //selectingHand = takeScript.interactorsSelecting[0].transform.gameObject;
        GetComponent<MeshRenderer>().material = GetComponent<Teleport>().rosso;
        // if(gameObject.GetInstanceID()== challenge.GetPassivePlayerID())

        PlayerNet p = selectingHand.GetComponent<HandChild>().player;
        p.transform.position = ChallengeRoom.transform.position;
        
    }

    [TargetRpc]
    public void rpcSelectedTeleport(NetworkConnection target)
    {
        //if (isLocalPlayer) return;
        Teleportation();
    }

}
