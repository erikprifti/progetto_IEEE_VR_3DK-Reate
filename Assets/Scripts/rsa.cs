using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using UnityEngine;


public class rsa : MonoBehaviour
{

    long p, q, n, t,e, d, flag, j;
   // char msg[100];
    
    static string msg = "Ciao!";
    long[] m = new long[msg.Length];
    long[] temp = new long[msg.Length];
    long[] en = new long[msg.Length];


   
    public rsa()
    {
        p = 83;
        q = 71;
        e = 5737;  //public key, n= 5*11
        d = 7653; //private key


        for (int i = 0; i < msg.Length; i++)
        {
            m[i] = (int)msg[i]; //da char a int
        }


        n = p * q;
        t = (p - 1) * (q - 1);

    //    Debug.Log(String.Format("the Starting message is : " + msg));
        encrypt();
        decrypt();

        

        void encrypt()
        {
            long pt, ct, key = e, k;
            int i = 0;

            while (i < msg.Length)
            {
                pt = m[i];
                pt = pt - 96;
                k = 1;
                for (j = 0; j < key; j++)
                {
                    k = k * pt;
                    k = k % n;
                }
                temp[i] = k;
                ct = k + 96;
                en[i] = ct;
                i++;
            }
            string encryptMex = string.Empty;

            for (i = 0; i < en.Length; i++)
            {
                encryptMex = encryptMex + (char)en[i];
            }
           // Debug.Log(String.Format("\nTHE ENCRYPTED MESSAGE IS " + encryptMex));

        }
        void decrypt()
        {
            long pt, ct, key = d, k;
            int i = 0;
            while (en[i] < en.Length)
            {
                ct = temp[i];
                k = 1;
                for (j = 0; j < key; j++)
                {
                    k = k * ct;
                    k = k % n;
                }
                pt = k + 96;
                m[i] = pt;
                i++;
            }
            
            string decryptMex = string.Empty;

            for (i = 0; i < m.Length; i++)
            {
                decryptMex = decryptMex + (char)m[i];
            }
         //   Debug.Log(String.Format("\nTHE DECRYPTED MESSAGE IS "+ decryptMex));
        }

    }
}
