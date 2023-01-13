using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Display : MonoBehaviour
{
    static string available = "I'm free\nPlay with me!";
    static string busy = "Sorry!\nSomone is already playing!";
    static string waiting = "I'm waiting for you!";
    static string nextMove = "Select a player on the board";
    static string confirm = "Confirm!";
    private TextMeshProUGUI display;
    public Material red;
    public Material green;
    public Material blu;

    private void Start()
    {
        display = gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void setDisplayBusy()
    {
        display.GetComponent<TextMeshProUGUI>().text = busy;
    }
    public void setDisplayAvailable()
    {
        display.GetComponent<TextMeshProUGUI>().text = available;
    }
    public void setDisplayWaiting()
    {
        display.GetComponent<TextMeshProUGUI>().text = waiting;
    }

    public void setDisplayNextMove()
    {
        display.GetComponent<TextMeshProUGUI>().text = nextMove;
    }
    public void setDisplayConfirm()
    {
        display.GetComponent<TextMeshProUGUI>().text = confirm;
    }

}

