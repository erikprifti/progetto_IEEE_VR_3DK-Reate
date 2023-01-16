using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo instance;
    public string PlayerName;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null) { Destroy(this); }
        else { 
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    
}
