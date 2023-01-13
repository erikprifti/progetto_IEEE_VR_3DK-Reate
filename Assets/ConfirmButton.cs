using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ConfirmButton : MonoBehaviour
{
    public GameObject selectingHand;
    public XRSimpleInteractable takeScript;
    public void OnSelection() //IN LOCALE
    {
        selectingHand = takeScript.interactorsSelecting[0].transform.gameObject;
        PlayerNet p = selectingHand.GetComponent<HandChild>().player;
        int k = p.gameObject.GetComponent<PlayerManager>().privateKey;

        GameObject challenge = GameObject.FindWithTag("Challenge");
        p.cmdPlayChallenge(k, challenge); //questo command spostarlo su interazione della challenge       
        gameObject.GetComponent<BoxCollider>().enabled = false;

        Debug.LogError(challenge.GetComponent<Challenge>().passivePlayerId);
        if(challenge.GetComponent<Challenge>().passivePlayerId == 0)
            p.cmdChallengeUpdate(0, challenge, p.gameObject);
        else
            p.cmdChallengeUpdate(1, challenge, p.gameObject);

        //gameObject.GetComponentInParent<Challenge>().rpcTargetChallengeNextMove(p.gameObject.GetComponent<NetworkIdentity>().connectionToClient);
    }
}
