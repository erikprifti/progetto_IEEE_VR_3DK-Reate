using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Key;

public class IdKeyPairs : NetworkBehaviour
{

    static readonly Dictionary<int, PublicKey> idKeyPairs = new Dictionary<int, PublicKey>
    {
        { 1, new PublicKey(5753, 5893)},
        { 2, new PublicKey(5281, 5459)},
        { 3, new PublicKey(6283, 6541)},
        { 4, new PublicKey(7625, 7849)},
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
}

