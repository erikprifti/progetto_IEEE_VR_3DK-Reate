using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Mirror;

public class Leaderboard : NetworkBehaviour
{
    public TMPmodifier slot1;
    public TMPmodifier slot2;
    public TMPmodifier slot3;
    public TMPmodifier slot4;




    private int freeslot = 1;

    public readonly Dictionary<int, TMPmodifier> id_text_map = new Dictionary<int, TMPmodifier>();

    public Dictionary<int, GameObject> id_player_map = new Dictionary<int, GameObject>();

    public void Start()
    {
        slot1.addName("pierino");
        id_text_map.Add(1, slot1);
        id_text_map.Add(2, slot2);
        id_text_map.Add(3, slot3);
        id_text_map.Add(4, slot4);

    }

    public void addPlayer(int id, GameObject player)
    {
        Debug.LogError("in LB");

        id_player_map.Add(id, player);

        player.GetComponent<PlayerNet>().cmdSetTextOnLB(gameObject, id);
    }

    [ClientRpc]
    public void rpcSetTextOnLB(int id)
    {
        TMPmodifier t = id_text_map.GetValueOrDefault(id);
        t.GetComponent<SelectablePlayer>().id = id;

        t.addName("player " + id.ToString()); 
    }

}
