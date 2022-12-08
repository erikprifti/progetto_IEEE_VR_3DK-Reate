using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ServerData : NetworkBehaviour
{
    public class publicKey
    {
        public int encode;
        public int module;

        public publicKey(int e, int m)
        {
            encode = e;
            module = m;
        }
    }

    private Dictionary<int, publicKey> id_key_pairs;
    private Dictionary<int, bool> id_available;
    // Start is called before the first frame update
    private void Start()
    {
        id_key_pairs.Add(1, new publicKey(5753, 5893));
        id_key_pairs.Add(2, new publicKey(5281, 5459));
        id_key_pairs.Add(3, new publicKey(6283, 6541));
        id_key_pairs.Add(4, new publicKey(7625, 7849));

        id_available.Add(1, true);
        id_available.Add(2, true);
        id_available.Add(3, true);
        id_available.Add(4, true);

    }

    public bool idAvailable(int id)
    {
        return id_available.GetValueOrDefault(id);
    }

    public void setUnavailable(int id)
    {
        id_available.Remove(id);
        id_available.Add(id, false);
    }

    public void setAvailable(int id)
    {
        id_available.Remove(id);
        id_available.Add(id, true);
    }

    public int getEncode(int id)
    {
        return id_key_pairs.GetValueOrDefault(id).encode;
    }
    public int getModule(int id)
    {
        return id_key_pairs.GetValueOrDefault(id).module;
    }
}
