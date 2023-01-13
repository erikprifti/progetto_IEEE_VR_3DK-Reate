using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Mirror;

public class Leaderboard : NetworkBehaviour
{

    
    public TMP_Text slot1;
    public TMP_Text slot2;
    public TMP_Text slot3;
    public TMP_Text slot4;

    public readonly Dictionary<  int, TMP_Text> id_text_map = new Dictionary<int, TMP_Text>();

    public Dictionary<int, GameObject> id_player_map = new Dictionary<int, GameObject>();

    public void Start()
    {
        id_text_map.Add( 1, slot1);
        id_text_map.Add( 2,  slot2);
        id_text_map.Add( 3, slot3);
        id_text_map.Add( 4,  slot4 );

    }

    public void addPlayer(int id, GameObject player)
    {
        id_player_map.Add(id, player);

        player.GetComponent<PlayerNet>().cmdSetTextOnLB(gameObject, id);
    }

    [ClientRpc]
    public void rpcSetTextOnLB(int id)
    {
        TMP_Text t = id_text_map.GetValueOrDefault(id);
        t.GetComponent<SelectablePlayer>().id = id;
    }
}
