using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Key;
using System;

public class IdKeyPairs : MonoBehaviour
{

    static readonly Dictionary<int, PublicKey> idKeyPairs = new Dictionary<int, PublicKey>
    {
        { 1, new PublicKey(203, 253)}, //private key = (867, 253)
        { 2, new PublicKey(435, 493)}, //private key = (379, 493)
        { 3, new PublicKey(811, 893)}, //private key = (487, 893)
        { 4, new PublicKey(181, 221)}, //private key = (157, 221)
    };


    static Dictionary<int, bool> id_available = new Dictionary<int, bool>()
    {
        { 1, true},
        { 2, true},
        { 3, true},
        { 4, true},
    };

    public void setAvailable(int id)
    {
        id_available.Remove(id);
        id_available.Add(id, true);
    }


    public void setUnavailable(int id)
    {
        id_available.Remove(id);
        id_available.Add(id, false);

        Debug.Log(String.Format(id_available.GetValueOrDefault(1) + " " +
                                id_available.GetValueOrDefault(2) + " " +
                                   id_available.GetValueOrDefault(3) + " " +
                                   id_available.GetValueOrDefault(4) + " "));
    }

    public bool idAvailable(int id)
    {
        return id_available.GetValueOrDefault(id);
    }

    public int getEncode(int id)
    {
        return idKeyPairs.GetValueOrDefault(id).encode;
    }
    public int getModule(int id)
    {
        return idKeyPairs.GetValueOrDefault(id).module;
    }

    public PublicKey getKey(int id)
    {
        return idKeyPairs.GetValueOrDefault(id);
    }
}
