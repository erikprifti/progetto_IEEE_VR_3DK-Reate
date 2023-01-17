using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class displayBL : MonoBehaviour
{
    private TextMeshProUGUI display;
    public Material off;
    public Material green;
    static string av = "Select me to return at the Arcade Room ";
    static string un = "Insert the key";

    private void Start()
    {
        display = gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void setBLAvailable()
    {
        display.GetComponent<TextMeshProUGUI>().text = av;
        display.GetComponentInParent<MeshRenderer>().material = green;
    }

    public void setBLUnavailable()
    {
        display.GetComponent<TextMeshProUGUI>().text = un;
        display.GetComponentInParent<MeshRenderer>().material = off;
    }
}
