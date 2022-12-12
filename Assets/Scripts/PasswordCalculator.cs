using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordCalculator : MonoBehaviour

{
    private static int password = 0;
   
    public void incrementPassword()
    {
        password++;
    }

    public void decrementPassword()
    {
        password--;
    }

    public int getPassword()
    {
        return password;
    }
}
