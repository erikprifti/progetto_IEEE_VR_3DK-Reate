using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Key
{
    public class PublicKey
    {
        public readonly int encode;
        public readonly int module;

        public PublicKey(int e, int m)
        {
            encode = e;
            module = m;
        }
    }

    public class PrivateKey : MonoBehaviour
    {
        private readonly int decode;
        public int module;

        public PrivateKey(int d, int m)
        {
            decode = d;
            module = m;
        }

        public int getDecode()
        {
            return decode;
        }
    }
}
