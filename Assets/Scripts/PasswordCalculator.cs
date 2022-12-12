using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordCalculator : MonoBehaviour

{
    private static int password = 0;
   
    public void incrementPassword()
    {
        //password++;
        Debug.Log("Contatore : " + ++password);

    }

    public void decrementPassword()
    {
        //password--;
        Debug.Log("Contatore : " + --password);

    }

    public int getPassword()
    {
        return password;
    }

    public void AddCount()
    {
        Debug.Log("aggiungi valore count");
    }
}
