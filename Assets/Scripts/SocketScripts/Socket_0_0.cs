using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketScript : MonoBehaviour
{
    public PasswordCalculator passwordCalc;

    private int pw;

    public void incrementVal0()
    {
        //Debug.Log("AOOO Trigger attivo");

        pw = passwordCalc.Val0;
        pw += 1;
        passwordCalc.Val0 = pw; 

        //Debug.Log("Contatore : " + password.getVal0());

    }

    public void decrementVal0()
    {
        //Debug.Log("é uscito Trigger");

        pw = passwordCalc.Val0;
        pw -= 1;
        passwordCalc.Val0 = pw;

        //Debug.Log("Contatore : " + password.getVal0());
    }



}
