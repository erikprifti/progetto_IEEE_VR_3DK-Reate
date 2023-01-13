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
    private bool calculated = false;

    public Interface _interface;

    private static int[,,] cube;

    public int passwordGenerator() //last method that confirm the challenge
    {
        if (!calculated) {
            makeRotations();
            multiplyMatrix();
            calculated = true;
        }

        Debug.Log(getKey());

        return getKey();
    }

    public void makeRotations()
    {
 //       cube = new int[3, 3, 3];

        cube = _interface.Matrix;

        if (front.isActive() && coll_1.isActive() && front.isPosition())
        {
            cube = ruotaX();

            if (left.isActive())
            {
                cube = ruotaZ();
            }
            else if (bottom.isActive())
            {
                // già nel verso giusto
            }
            else if (right.isActive())
            {
                cube = ruotaZ();
                cube = ruotaZ();
                cube = ruotaZ();
            }
            else
            {
                cube = ruotaZ();
                cube = ruotaZ();
            }
        }
        else if (back.isActive() && coll_1.isActive() && back.isPosition())
        {
            cube = ruotaX();
            cube = ruotaX();
            cube = ruotaX();
            
            if (left.isActive())
            {
                cube = ruotaZ();
                cube = ruotaZ();
                cube = ruotaZ();
            }
            else if (bottom.isActive())
            {
                cube = ruotaZ();
                cube = ruotaZ();
            }
            else if (right.isActive())
            {
                cube = ruotaZ();
            }
            else
            {
                // già a posto
            }
        }
        else if (left.isActive() && coll_1.isActive() && left.isPosition())
        {
            cube = ruotaZ();
            cube = ruotaZ();
            cube = ruotaZ();

            if (front.isActive())
            {
                // posizione già giusta
            }
            else if (bottom.isActive())
            {
                cube = ruotaX();
            }
            else if (back.isActive())
            {
                cube = ruotaX();
                cube = ruotaX();
            }
            else
            {
                cube = ruotaX();
                cube = ruotaX();
                cube = ruotaX();
            }
        }
        else if (right.isActive() && coll_1.isActive()  && back.isPosition())
        {
            cube=ruotaZ();

            if (front.isActive())
            {
                // già a posto
            }
            else if (bottom.isActive())
            {
                cube = ruotaX();
              
            }
            else if (back.isActive())
            {
                cube = ruotaX();
                cube = ruotaX();
            }
            else
            {
                cube = ruotaX();
                cube = ruotaX();
                cube = ruotaX();
            }
        }
        else if(bottom.isActive() && coll_1.isActive() && bottom.isPosition())
        {
            cube = ruotaX();
            cube = ruotaX();

            if (back.isActive())
            {
                // già a posto
            }
            if (right.isActive())
            {
                cube = ruotaZ();
            }
            if (front.isActive())
            {
                cube = ruotaZ();
                cube = ruotaZ();
            }
            if (left.isActive())
            {
                cube = ruotaZ();
                cube = ruotaZ();
                cube = ruotaZ();            }
        }
        else
        {
            if (front.isActive())
            {
                // già orientato nel verso predefinito
            }
            else if (left.isActive())
            {
                cube = ruotaY();
            }
            else if (back.isActive())
            {
                cube = ruotaY();
                cube = ruotaY();
            }
            else if(right.isActive())
            {
                cube = ruotaY();
                cube = ruotaY();
                cube = ruotaY();
            }
        }

 //       _interface.Matrix = cube;

        printMat();
    }
    private int[,,] ruotaX()
    {
        int temp, temp2;

        for (int i = 0; i < 3; i++)
        {
            temp = cube[i, 0, 0];
            cube[i, 0, 0] = cube[i, 0, 2];

            temp2 = cube[i, 2, 0];
            cube[i, 2, 0] = temp;

            temp = cube[i, 2, 2];
            cube[i, 2, 2] = temp2;

            cube[i, 0, 2] = temp;

            temp = cube[i, 1, 0];
            cube[i, 1, 0] = cube[i, 0, 1];

            temp2 = cube[i, 2, 1];
            cube[i, 2, 1] = temp;

            temp = cube[i, 1, 2];
            cube[i, 1, 2] = temp2;

            cube[i, 1, 0] = temp;
        }

        return cube;
    }
    private int[,,] ruotaY()
    {
        int temp, temp2;

        for (int i = 0; i < 3; i++)
        {
            temp = cube[0, i, 2];
            cube[0, i, 2] = cube[0, i, 0];

            temp2 = cube[2, i, 2];
            cube[2, i, 2] = temp;

            temp = cube[2, i, 0];
            cube[2, i, 0] = temp2;

            cube[0, i, 0] = temp;

            temp = cube[2, i, 1];
            cube[2, i, 1] = cube[1, i, 2];

            temp2 = cube[1, i, 0];
            cube[1, i, 0] = temp;

            temp = cube[0, i, 1];
            cube[0, i, 1] = temp2;

            cube[1, i, 2] = temp;

        }

        return cube;
    } 
    private int[,,] ruotaZ()
    {
        int temp, temp2;

        for (int i = 0; i < 3; i++)
        {
            temp = cube[2, 0, i];
            cube[2, 0, i] = cube[0, 0, i];

            temp2 = cube[2, 2, i];
            cube[2, 2, i] = temp;

            temp = cube[0, 2, i];
            cube[0, 2, i] = temp2;

            cube[0, 0, i] = temp;

            temp = cube[2, 1, i];
            cube[2, 1, i] = cube[1, 0, i];

            temp2 = cube[1, 2, i];
            cube[1, 2, i] = temp;

            temp = cube[0, 1, i];
            cube[0, 1, i] = temp2;

            cube[1, 0, i] = temp;
        }

        return cube;
    }

    public void printMat()
    {
        // per adesso stampo solo la faccia frontale
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("cuberice " + i + ": \n");
            Debug.Log(cube[0, 0, i] + " " + cube[1, 0, i] + " " + cube[2, 0, i] + "\n" +
                      cube[0, 1, i] + " " + cube[1, 1, i] + " " + cube[2, 1, i] + "\n" +
                      cube[0, 2, i] + " " + cube[1, 2, i] + " " + cube[2, 2, i]);
        }
    }




    public void multiplyMatrix()
    {
        //Debug.Log("Entrato in multiplyMatrix");
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("Entrato in multiplyMatrix " + i);
            
            for (int j = 0; j < 3; j++)
            {
                for(int k = 0; k < 3; k++)
                {
                    cube[k, j, i] = cube[k, j, i] * multiplier[j, k];
//                      Debug.Log("reading from cube, prof " + i + ", riga " + j + ", colonna " + k + " : " + cube[k, j, i] + ", with multiplier:  " + multiplier[j, k]);

                    values[i] += cube[k, j, i];
 //                   Debug.Log("after increment value " + i + ": " + values[i]);
                }
            }
        }
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


