using Mirror;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Teleport : NetworkBehaviour
{
    public GameObject ChallengeRoom;
    public GameObject challenge;
    public GameObject selectingHand;
    public XRSimpleInteractable takeScript;
    public GameObject schermo;
    public Material rosso;
    public Material verde;

    public void Start()
    {
        ChallengeRoom = GameObject.FindGameObjectWithTag("ChallengeRoom");
       challenge = GameObject.FindGameObjectWithTag("Challenge");
    }


    public void OnSelection()
    {

        //Debug.LogError("on selection in teleport, id selezionatore della challenge: " + takeScript.interactorsSelecting[0].transform.gameObject.GetComponentInParent<PlayerManager>().getId());
        //Debug.LogError("on selection in teleport, id del passive: " + takeScript.interactorsSelecting[0].transform.gameObject.GetComponentInParent<PlayerManager>().getId());

       
        selectingHand = takeScript.interactorsSelecting[0].transform.gameObject;
        selectingHand.GetComponent<HandChild>().player.cmdTeleportPlayer(selectingHand.GetComponent<HandChild>().player.gameObject, challenge, gameObject);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        //if (takeScript.interactorsSelecting[0].transform.gameObject.GetComponentInParent<PlayerManager>().getId() == gameObject.GetComponent<Challenge>().passivePlayerId)
        //{

        //    selectingHand = takeScript.interactorsSelecting[0].transform.gameObject;
        //    selectingHand.GetComponent<HandChild>().player.cmdTeleportPlayer(selectingHand.GetComponent<HandChild>().player.gameObject, gameObject);
        //}

    }



    public void Teleportation()
    {
        
      //  GetComponent<MeshRenderer>().material = GetComponent<Teleport>().rosso;

        PlayerNet p = selectingHand.GetComponent<HandChild>().player;

        p.gameObject.transform.position = ChallengeRoom.transform.position;
     //   p.gameObject.transform.TransformPoint(ChallengeRoom.transform.position);

    }

    [TargetRpc]
    public void rpcSelectedTeleport(NetworkConnection target)
    {
        //if (isLocalPlayer) return;
        //Debug.LogError("in rpcSelectedTeleport, before teleportation");

        Teleportation();
    }

    

    [ClientRpc]
    public void rpcChallengeFree()
    {
        gameObject.GetNamedChild("Schermo").GetComponent<MeshRenderer>().material = verde;
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }


    [TargetRpc]
    public void rpcChallengeFreeTarget(NetworkConnection target)
    {
        gameObject.GetNamedChild("Schermo").GetComponent<MeshRenderer>().material = verde;
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
