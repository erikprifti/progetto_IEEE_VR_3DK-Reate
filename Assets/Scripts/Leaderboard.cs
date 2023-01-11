using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public TMP_Text slot1;
    public TMP_Text slot2;
    public TMP_Text slot3;
    public TMP_Text slot4;

    private int freeslot = 1;

    public void addPlayer(string name)
    {
        slot1.text = "giocatore " + freeslot;
    }

}
