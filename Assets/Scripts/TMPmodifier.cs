using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TMPmodifier : MonoBehaviour
{
    private TextMeshProUGUI slot;

    public void addName(string name)
    {
        slot.text = name;
    }


}
