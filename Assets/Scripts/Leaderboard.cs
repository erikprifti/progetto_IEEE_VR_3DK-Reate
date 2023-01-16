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

    public PlayerNet playerActive;

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
        //Debug.LogError("! display da start " );

        //displayPlayers();
    }

    public void addPlayer(int id, GameObject player) //su server, chaiamto da setPlayerInfo
    {
        id_player_map.Add(id, player);
        GameObject t = id_text_map.GetValueOrDefault(id);
        t.GetComponent<SelectablePlayer>().id = id;
        t.GetComponent<TextMeshProUGUI>().text = player.GetComponent<PlayerManager>().playerName;
        if (player.GetComponent<PlayerManager>().playerName.Equals(PlayerInfo.instance.PlayerName)){
            t.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        //player.GetComponent<PlayerNet>().cmdUpdatePlayerMap();
        //Debug.LogError("! display da addPlayer ");

        // displayPlayers();
    }
    
    //public void displayPlayers()
    //{
    //    for(int i = 0; i < 5; i++){
    //        if (id_player_map.ContainsKey(i))
    //        {
               

    //            //Debug.LogError("! player map contienee: " + i);
    //            GameObject t = id_text_map.GetValueOrDefault(i);
    //            t.GetComponent<SelectablePlayer>().id = i;
    //            t.GetComponent<TextMeshProUGUI>().text = "player " + i;
    //        }
    //    }
    //}

    [ClientRpc]
    public void rpcClearPlayerMap()
    {
        id_player_map.Clear();

    }
    [ClientRpc]
    public void rpcSetTextOnLB(int id, GameObject player)
    {
         addPlayer(id, player);
        //Debug.LogError("after adding in rpcSetTextOnLB, added: " + id);
        id_player_map.GetValueOrDefault(id);
    }

}
