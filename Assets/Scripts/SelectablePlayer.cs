using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SelectablePlayer : MonoBehaviour
{
    public GameObject challenge;
    public XRSimpleInteractable takeScript;
    public GameObject playerCheMiSeleziona;

    public void OnSelection()
    {
        //playerCheMiSeleziona = takeScript.interactorsSelecting[0].transform.gameObject;
        Debug.Log("Ho interagito con " + takeScript.interactorsSelecting[0].transform.gameObject.name);
        //challenge.setChallenge(takeScript.interactorsSelecting[0].transform.gameObject.name, gameObject);
        challenge.SetActive(true);
    }

}
