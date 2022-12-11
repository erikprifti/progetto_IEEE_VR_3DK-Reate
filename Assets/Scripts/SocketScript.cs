using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketScript : MonoBehaviour
{
    public PasswordCalculator password;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("AOOO Trigger attivo");
        password.incrementPassword();
        Debug.Log(password.getPassword());

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("é uscito Trigger");
        password.decrementPassword();
        Debug.Log(password.getPassword());
    }


}
