using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;


public class Porta : MonoBehaviour
{
    private string password;

    //for debug
    public string test = "TEST PORTA";

    public void setPassword(string p)
    {
        password = p;
    }

    public bool verifyPassword(string p)
    {
        if (p.Equals(password))
        {
            Debug.Log(String.Format("Password are equals"));
            return true;
        }
        return false;
    }

    //ora serve il method dell'interazione tra giocatore e porta
    //NB: il giocatore attivo ha già la password appena crea la challenge
    //il giocatore passivo avrà la password dopo aver risolto la challenge
    //il method di interazione +  trasporto andrà ad invocare il method verifyPassword
    //di seguito un prototipo 

    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        PlayerManager player = other.GetComponentInChildren<PlayerManager>();
        string playerSolution = player.getPassword();
        if (!verifyPassword(playerSolution)) { return; }

        //qui codice di teletrasporto
    }
}
