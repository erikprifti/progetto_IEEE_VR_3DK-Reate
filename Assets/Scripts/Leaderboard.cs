using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public TextMeshPro slot1;
    public TextMeshPro slot2;
    public TextMeshPro slot3;

    private int freeslot = 1;

    public void addPlayer(string name)
    {
        if (freeslot == 1)
        {
            freeslot++;
            slot1.text = name;
        }
        if (freeslot == 2)
        {
            freeslot++;
            slot2.text = name;
        }
        if (freeslot == 3)
        {
            freeslot++;
            slot3.text = name;
        }
    }

}
