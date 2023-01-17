using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Display : MonoBehaviour
{
    static string available = "Play with me!\n Select Start to create a Private Room!";
    static string busy = "Sorry!\nSomeone is already playing!";
    static string waiting = "I'm waiting for you!\n Play with me by selecting Start!";
    static string nextMove = "Select a player on the board";
    static string confirm = "Confirm if your key is correct!";
    static string selectDoor = "Personal Room created\n Select the Door to enter it";
    static string destroy = "CHALLENGE DISABLED\nSelect the Door to enter the Private Room";
    static string error = "PASSWORD NOT CORRECT\nYou have insert an incorrect key!\n Or\n A Private Room hasn't been created yet";

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

    public void setDisplayDestroy()
    {
        display.GetComponent<TextMeshProUGUI>().text = destroy;

    }

    public void setDisplayToDoor()
    {
        display.GetComponent<TextMeshProUGUI>().text = selectDoor;

    }

    public void setDisplayError()
    {
        display.GetComponent<TextMeshProUGUI>().text = error;

    }
}

