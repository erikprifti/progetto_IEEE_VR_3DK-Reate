using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordCalculator : MonoBehaviour

{
    private static int val0;
    private static int val1;
    private static int val2;
    public int Val0
    {
        get { return val0; }
        set { val0 = value; }
    }
    public int Val1
    {
        get { return val1; }
        set { val1 = value; }
    }
    public int Val2
    {
        get { return val2; }
        set { val2 = value; }
    }

    public void increment_0_0()
    {
        val0++;
        Debug.Log("val0 : " + val0);

    }
    public void decrement_0_0()
    {
        val0--;
        Debug.Log("val0 : " + val0);

    }
    public void increment_0_1()
    {
        val0 += 2;
        Debug.Log("val0 : " + val0);

    }
    public void decrement_0_1()
    {
        val0 -= 2;
        Debug.Log("val0 : " + val0);

    }
    public void increment_0_2()
    {
        val0 += 4;
        Debug.Log("val0 : " + val0);

    }
    public void decrement_0_2()
    {
        val0 -= 4;
        Debug.Log("val0 : " + val0);

    }

    public void increment_1_0()
    {
        val0 += 8;
        Debug.Log("val0 : " + val0);

    }
    public void decrement_1_0()
    {
        val0 -= 8;
        Debug.Log("val0 : " + val0);

    }
    public void increment_1_1()
    {
        val0 += 16;
        Debug.Log("val0 : " + val0);

    }
    public void decrement_1_1()
    {
        val0 -= 16;
        Debug.Log("val0 : " + val0);

    }
    public void increment_1_2()
    {
        val0 += 32;
        Debug.Log("val0 : " + val0);

    }
    public void decrement_1_2()
    {
        val0 -= 32;
        Debug.Log("val0 : " + val0);

    }

    public void increment_2_0()
    {
        val0 +=64;
        Debug.Log("val0 : " + val0);

    }
    public void decrement_2_0()
    {
        val0 -= 64;
        Debug.Log("val0 : " + val0);

    }
    public void increment_2_1()
    {
        val0 += 128;
        Debug.Log("val0 : " + val0);

    }
    public void decrement_2_1()
    {
        val0 -= 128;
        Debug.Log("val0 : " + val0);

    }
    public void increment_2_2()
    {
        val0 += 256;
        Debug.Log("val0 : " + val0);

    }
    public void decrement_2_2()
    {
        val0 -= 256;
        Debug.Log("val0 : " + val0);

    }


    /*   public int getPassword()
       {
           return password;
       }

       public void setPassword(int password)
       {
           this. = password;
       }

       public void AddCount()
       {
           Debug.Log("aggiungi valore count");
       }
    */
}
