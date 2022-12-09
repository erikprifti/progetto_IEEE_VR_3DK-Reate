using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerNet : NetworkBehaviour
{
    PlayerNetInput input;

    private void Awake()
    {
        input = GetComponent<PlayerNetInput>();
        
    }

     void Start()
    {
        if (isServer)
        {
            input.keyboardNet[KeyCode.G].AddListener(SelectCheDeviAncoraDefinirla);
            input.keyboardNet[KeyCode.R].AddListener(SelectCheDeviAncoraDefinirla);
        }
        
    }

    private void SelectCheDeviAncoraDefinirla(KeyCode arg0, bool arg1)
    {
        if(arg0 == KeyCode.G)
        {
            //Funzione di selezione
            GetComponentInChildren<>();
        }
    }
}
