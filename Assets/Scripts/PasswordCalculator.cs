using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordCalculator : MonoBehaviour

{
    public Interface _interface;

    private int[,] multiplier = { { 1, 2, 4 }, { 8, 16, 32 }, {64, 128, 256 } };

    private int[] values;

    public void multiplyMatrix()
    {
        Debug.Log("Entrato in multiplyMatrix");
        int[,,] mat = _interface.Matrix;
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("Entrato in multiplyMatrix" + i);

            /*for (int j = 0; j < 3; j++)
            {
                for(int k = 0; k < 3; k++)
                {
                    mat[k, j, i] = mat[k, j, i] * multiplier[k, j];
                    values[i] += mat[k, j, i];
                }

            }*/
           // values[i] = i;

        }
        //_interface.Matrix = mat;
        Debug.Log("finito in multiplyMatrix");

    }

    public void filterValues()
    {
        for( int i = 0; i < 3; i++)
        {
            values[i] = values[i] % 10;
            Debug.Log(values[i]);  
        }
    }

    public void printValues()
    {
        for (int i = 0; i < 3; i++)
        {
            Debug.Log(values[i]);
        }
        //return values;
    }

}
