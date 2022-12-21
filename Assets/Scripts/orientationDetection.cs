using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orientationDetection : MonoBehaviour



{
    public socketCollision front;
    public socketCollision back;
    public socketCollision left;
    public socketCollision right;
    public socketCollision bottom;

    public cubeOrientation1 coll_1;
    public cubeOrientation2 coll_2;


    private int[,] multiplier = { { 1, 2, 4 }, 
                                  { 8, 16, 32 }, 
                                  { 64, 128, 256 } };

    private int[] values = {0,0,0};

    private int key;

    public Interface _interface;

    private static int[,,] cube = new int[3, 3, 3];

    public int passwordGenerator() //last method that confirm the challenge
    {
        makeRotations();

        multiplyMatrix();

        Debug.Log(getKey());

        return getKey();
    }

    public void makeRotations()
    {
        cube = _interface.Matrix;

        if (front.isActive() && coll_1.isActive() && front.isPosition())
        {
            cube = ruotaX(cube);

            if (left.isActive())
            {
                cube = ruotaZ(cube);
            }
            else if (bottom.isActive())
            {
                // già nel verso giusto
            }
            else if (right.isActive())
            {
                cube = ruotaZ(cube);
                cube = ruotaZ(cube);
                cube = ruotaZ(cube);
            }
            else
            {
                cube = ruotaZ(cube);
                cube = ruotaZ(cube);
            }
        }
        else if (back.isActive() && coll_1.isActive() && back.isPosition())
        {
            cube = ruotaX(cube);
            cube = ruotaX(cube);
            cube = ruotaX(cube);
            
            if (left.isActive())
            {
                cube = ruotaZ(cube);
                cube = ruotaZ(cube);
                cube = ruotaZ(cube);
            }
            else if (bottom.isActive())
            {
                cube = ruotaZ(cube);
                cube = ruotaZ(cube);
            }
            else if (right.isActive())
            {
                cube = ruotaZ(cube);
            }
            else
            {
                // già a posto
            }
        }
        else if (left.isActive() && coll_1.isActive() && left.isPosition())
        {
            cube = ruotaZ(cube);
            cube = ruotaZ(cube);
            cube = ruotaZ(cube);

            if (front.isActive())
            {
                // posizione già giusta
            }
            else if (bottom.isActive())
            {
                cube = ruotaX(cube);
            }
            else if (back.isActive())
            {
                cube = ruotaX(cube);
                cube = ruotaX(cube);
            }
            else
            {
                cube = ruotaX(cube);
                cube = ruotaX(cube);
                cube = ruotaX(cube);
            }
        }
        else if (right.isActive() && coll_1.isActive()  && back.isPosition())
        {
            cube=ruotaZ(cube);

            if (front.isActive())
            {
                // già a posto
            }
            else if (bottom.isActive())
            {
                cube = ruotaX(cube);
              
            }
            else if (back.isActive())
            {
                cube = ruotaX(cube);
                cube = ruotaX(cube);
            }
            else
            {
                cube = ruotaX(cube);
                cube = ruotaX(cube);
                cube = ruotaX(cube);
            }
        }
        else if(bottom.isActive() && coll_1.isActive() && bottom.isPosition())
        {
            cube = ruotaX(cube);
            cube = ruotaX(cube);

            if (back.isActive())
            {
                // già a posto
            }
            if (right.isActive())
            {
                cube = ruotaZ(cube);
            }
            if (front.isActive())
            {
                cube = ruotaZ(cube);
                cube = ruotaZ(cube);
            }
            if (left.isActive())
            {
                cube = ruotaZ(cube);
                cube = ruotaZ(cube);
                cube = ruotaZ(cube);            }
        }
        else
        {
            if (front.isActive())
            {
                // già orientato nel verso predefinito
            }
            else if (left.isActive())
            {
                cube = ruotaY(cube);
            }
            else if (back.isActive())
            {
                cube = ruotaY(cube);
                cube = ruotaY(cube);
            }
            else if(right.isActive())
            {
                cube = ruotaY(cube);
                cube = ruotaY(cube);
                cube = ruotaY(cube);
            }
        }

        _interface.Matrix = cube;

        printMat(cube);
    }
    private int[,,] ruotaX(int[,,] mat)
    {
        int temp, temp2;

        for (int i = 0; i < 3; i++)
        {
            temp = mat[i, 0, 0];
            mat[i, 0, 0] = mat[i, 0, 2];

            temp2 = mat[i, 2, 0];
            mat[i, 2, 0] = temp;

            temp = mat[i, 2, 2];
            mat[i, 2, 2] = temp2;

            mat[i, 0, 2] = temp;

            temp = mat[i, 1, 0];
            mat[i, 1, 0] = mat[i, 0, 1];

            temp2 = mat[i, 2, 1];
            mat[i, 2, 1] = temp;

            temp = mat[i, 1, 2];
            mat[i, 1, 2] = temp2;

            mat[i, 1, 0] = temp;
        }

        return mat;
    }
    private int[,,] ruotaY(int[,,] mat)
    {
        int temp, temp2;

        for (int i = 0; i < 3; i++)
        {
            temp = mat[0, i, 2];
            mat[0, i, 2] = mat[0, i, 0];

            temp2 = mat[2, i, 2];
            mat[2, i, 2] = temp;

            temp = mat[2, i, 0];
            mat[2, i, 0] = temp2;

            mat[0, i, 0] = temp;

            temp = mat[2, i, 1];
            mat[2, i, 1] = mat[1, i, 2];

            temp2 = mat[1, i, 0];
            mat[1, i, 0] = temp;

            temp = mat[0, i, 1];
            mat[0, i, 1] = temp2;

            mat[1, i, 2] = temp;

        }

        return mat;
    } 
    private int[,,] ruotaZ(int[,,] mat)
    {
        int temp, temp2;

        for (int i = 0; i < 3; i++)
        {
            temp = mat[2, 0, i];
            mat[2, 0, i] = mat[0, 0, i];

            temp2 = mat[2, 2, i];
            mat[2, 2, i] = temp;

            temp = mat[0, 2, i];
            mat[0, 2, i] = temp2;

            mat[0, 0, i] = temp;

            temp = mat[2, 1, i];
            mat[2, 1, i] = mat[1, 0, i];

            temp2 = mat[1, 2, i];
            mat[1, 2, i] = temp;

            temp = mat[0, 1, i];
            mat[0, 1, i] = temp2;

            mat[1, 0, i] = temp;
        }

        return mat;
    }

    public void printMat(int[,,] mat)
    {
        // per adesso stampo solo la faccia frontale
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("matrice " + i + ": \n");
            Debug.Log(mat[0, 0, i] + " " + mat[1, 0, i] + " " + mat[2, 0, i] + "\n" +
                      mat[0, 1, i] + " " + mat[1, 1, i] + " " + mat[2, 1, i] + "\n" +
                      mat[0, 2, i] + " " + mat[1, 2, i] + " " + mat[2, 2, i]);
        }
    }




    public void multiplyMatrix()
    {
        //Debug.Log("Entrato in multiplyMatrix");
        int[,,] mat = _interface.Matrix;
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("Entrato in multiplyMatrix " + i);
            
            for (int j = 0; j < 3; j++)
            {
                for(int k = 0; k < 3; k++)
                {
                    mat[k, j, i] = mat[k, j, i] * multiplier[j, k];
//                      Debug.Log("reading from mat, prof " + i + ", riga " + j + ", colonna " + k + " : " + mat[k, j, i] + ", with multiplier:  " + multiplier[j, k]);

                    values[i] += mat[k, j, i];
 //                   Debug.Log("after increment value " + i + ": " + values[i]);
                }
            }
        }
        _interface.Matrix = mat;
 //       Debug.Log("finito in multiplyMatrix");

    }

    public void filterValues()
    {
        for (int i = 0; i < 3; i++)
        {
            values[i] = values[i] % 10;
            Debug.Log(values[i]);
        }
    }

    public int[] getValues()
    {
        return values;
    }

    public int getKey()
    {
        filterValues();
        key = values[0] + values[1]*10 + values[2]*100;
        return key;
    }

}


