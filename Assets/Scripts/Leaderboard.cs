using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Mirror;

public class Leaderboard : NetworkBehaviour
{
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;




    public readonly Dictionary<int, GameObject> id_text_map = new Dictionary<int, GameObject>();

    public Dictionary<int, GameObject> id_player_map = new Dictionary<int, GameObject>();

    public void Start()
    {
        slot1 = GameObject.FindGameObjectWithTag("T1");
        slot2 = GameObject.FindGameObjectWithTag("T2");
        slot3 = GameObject.FindGameObjectWithTag("T3");
        slot4 = GameObject.FindGameObjectWithTag("T4");

        // slot1.addName("pierino");
        id_text_map.Add(1, slot1);
        id_text_map.Add(2, slot2);
        id_text_map.Add(3, slot3);
        id_text_map.Add(4, slot4);

    }

    public void addPlayer(int id, GameObject player)
    {
        id_player_map.Add(id, player);
        GameObject t = id_text_map.GetValueOrDefault(id);
        t.GetComponent<SelectablePlayer>().id = id;
        t.GetComponent<TextMeshProUGUI>().text = "player " + id;
    }

    [ClientRpc]
    public void rpcSetTextOnLB(int id, GameObject player)
    {
        addPlayer(id, player);


    }

}
