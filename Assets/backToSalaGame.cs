
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Mirror;

public class backToSalaGame : NetworkBehaviour
{
    public GameObject Lobby;
    public GameObject selectingHand;
    public XRSimpleInteractable takeScript;
    //  public Material azzurro;

    public void Start()
    {
        Lobby = GameObject.FindGameObjectWithTag("Lobby");
    }

    public void OnSelection() //IN LOCALE
    {
        selectingHand = takeScript.interactorsSelecting[0].transform.gameObject;
        PlayerNet p = selectingHand.GetComponent<HandChild>().player;
        p.cmdTurnBackToLobby(selectingHand.GetComponent<HandChild>().player.gameObject, gameObject);

    }
    public void LobbyTeleport()
    {
        PlayerNet p = selectingHand.GetComponent<HandChild>().player;

        p.gameObject.transform.position = Lobby.transform.position;

    }

    [TargetRpc]
    public void rpcLobbyTeleport(NetworkConnection target)
    {
        LobbyTeleport();
    }
}
