using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orientationDetection : MonoBehaviour

{
    public socketCollision back;
    public socketCollision lato1;
    public socketCollision lato2;
    public socketCollision lato3;
    public socketCollision lato4;
    public socketCollision lato5;
    public socketCollision lato6;
    public socketCollision lato7;
    public socketCollision lato8;
    public socketCollision lato9;
    public cubeOrientation1 coll_1;
    public cubeOrientation2 coll_2;


    private int[] multiplier = {  1, 2, 4, 8, 16, 32, 64, 128, 256 };

    private int[] values = {0,0,0};
    private int key;

    public Interface _interface;

    private static int[,] rotated_matrix = new int[9, 3];

    public int passwordGenerator() //last method that confirm the challenge
    {
        printMat();

        copyInterfaceInRotationMatrix();
        makeRotations();
        printMat();
        multiplyMatrix();

        int keyGen = getKey();
        
        resetValues();
        resetRotationMatrix();

        return keyGen;
    }

    public void makeRotations()
    {
        if (back.isActive()) //collider1 collide con front
       {

            if (lato1.isActive())
            {
                Debug.Log("lato1 attivo");
                // già nel verso giusto

            }
            else if (lato2.isActive())
            {
                rotated_matrix = ruotaZ(1);
            }
            else if (lato3.isActive())
            {
                rotated_matrix = ruotaZ(2);
            }
            else if (lato4.isActive())
            {
                rotated_matrix = ruotaZ(3);
            }
            else if (lato5.isActive())
            {
                rotated_matrix = ruotaZ(4);
            }
            else if (lato6.isActive())
            {
                rotated_matrix = ruotaZ(5);
            }
            else if (lato7.isActive())
            {
                rotated_matrix = ruotaZ(6);
            }
            else if (lato8.isActive())
            {
                rotated_matrix = ruotaZ(7);
            }
            else if (lato9.isActive())
            {
                rotated_matrix = ruotaZ(8);
            }

        }
    }

   

    public void printMat()
    {
        // per adesso stampo solo la faccia frontale
        //for (int i = 0; i < 3; i++)
        //{
        //    //  Debug.Log("rotated_matrixrice " + i + ": \n");
        //    Debug.Log(_interface.Matrix[0, 0, i] + " " + _interface.Matrix[0, 1, i] + " " + _interface.Matrix[0, 2, i] + "\n" +
        //    _interface.Matrix[1, 0, i] + " " + _interface.Matrix[1, 1, i] + " " + _interface.Matrix[1, 2, i] + "\n" +
        //                     _interface.Matrix[2, 0, i] + " " + _interface.Matrix[2, 1, i] + " " + _interface.Matrix[2, 2, i]);
        //    Debug.Log("rotatedMatrix: ");

        //    //Debug.Log(rotated_matrix[0, 0, i] + " " + rotated_matrix[0, 1, i] + " " + rotated_matrix[0, 2, i] + "\n" +
        //    //rotated_matrix[1, 0, i] + " " + rotated_matrix[1, 1, i] + " " + rotated_matrix[1, 2, i] + "\n" +
        //    //                 rotated_matrix[2, 0, i] + " " + rotated_matrix[2, 1, i] + " " + rotated_matrix[2, 2, i]);

        //}

        for(int i = 0; i < 3; i++)
        {
            Debug.Log(rotated_matrix[0, i] + ", " + rotated_matrix[1, i] + ", " + rotated_matrix[2, i] + ", " + rotated_matrix[3, i] + ", " + rotated_matrix[4, i] 
                + ", " + rotated_matrix[5, i] +  ", " + rotated_matrix[6, i] + ", " + rotated_matrix[7, i] + ", " + rotated_matrix[8, i] );

        }


    }

    public void multiplyMatrix()
    {
        Debug.Log("mult matrix");

        int value = 0;
        //Debug.Log("Entrato in multiplyMatrix");
        for (int i = 0; i < 3; i++)
        {
            //    Debug.Log("Entrato in multiplyMatrix " + i);

            for (int j = 0; j < 9; j++)
            {
                value = 0;
                //if (rotated_matrix[j, i] != 0)
                //{
                //    value = rotated_matrix[j, i] - 1;
                //    rotated_matrix[j, i] = rotated_matrix[j, i] - value;
                //}
                //rotated_matrix[j, i] = (rotated_matrix[j, i]) * multiplier[j];
                ////                      Debug.Log("reading from rotated_matrix, prof " + i + ", riga " + j + ", colonna " + k + " : " + rotated_matrix[k, j, i] + ", with multiplier:  " + multiplier[j, k]);

                //values[i] += rotated_matrix[j, i] + value;
                ////o.                   Debug.Log("after increment value " + i + ": " + values[i]);

                values[i] += rotated_matrix[j, i] * multiplier[j];

            }
        }
    }

    public void filterValues()
    {
        Debug.Log("filtra valori");
        for (int i = 0; i < 3; i++)
        {
            values[i] = values[i] % 10;
            // Debug.Log(values[i]);
        }
    }

    public int[] getValues()
    {
        return values;
    }

    public int getKey()
    {
        filterValues();
        key = values[0] + values[1] * 10 + values[2] * 100;

        Debug.Log("restituisce chiave");

        return key;
    }

    private void copyInterfaceInRotationMatrix()
    {
        Debug.Log("copio matrice");

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    rotated_matrix[i+3*j, k] = _interface.Matrix[i, j, k];
                }
            }
        }
    }

    private void resetRotationMatrix()
    {
        Debug.Log("resetta matrice");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    rotated_matrix[i+3*j, k] = 0;
                }
            }
        }
    }

    private void resetValues()
    {
        for (int i = 0; i < 3; i++)
        {
            values[i] = 0;
            // Debug.Log(values[i]);
        }
        Debug.Log("resetta matrice");

    }

    private int[,] ruotaZ(int n)
    {
        Debug.Log("ruota di " +n);

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    rotated_matrix[( n + i + 3 * j) % 9  , k] = _interface.Matrix[i, j, k];
                }
            }
        }

        return rotated_matrix;
    }

}



//private int[,,] ruotaX()
//{
//    int temp, temp2;

//    for (int i = 0; i < 3; i++)
//    {
//        temp = rotated_matrix[i, 0, 0];
//        rotated_matrix[i, 0, 0] = rotated_matrix[i, 0, 2];

//        temp2 = rotated_matrix[i, 2, 0];
//        rotated_matrix[i, 2, 0] = temp;

//        temp = rotated_matrix[i, 2, 2];
//        rotated_matrix[i, 2, 2] = temp2;

//        rotated_matrix[i, 0, 2] = temp;

//        temp = rotated_matrix[i, 1, 0];
//        rotated_matrix[i, 1, 0] = rotated_matrix[i, 0, 1];

//        temp2 = rotated_matrix[i, 2, 1];
//        rotated_matrix[i, 2, 1] = temp;

//        temp = rotated_matrix[i, 1, 2];
//        rotated_matrix[i, 1, 2] = temp2;

//        rotated_matrix[i, 1, 0] = temp;
//    }

//    return rotated_matrix;
//}


//private int[,,] ruotaY()
//{
//    int temp, temp2;

//    for (int i = 0; i < 3; i++)
//    {
//        temp = rotated_matrix[0, i, 2];
//        rotated_matrix[0, i, 2] = rotated_matrix[0, i, 0];

//        temp2 = rotated_matrix[2, i, 2];
//        rotated_matrix[2, i, 2] = temp;

//        temp = rotated_matrix[2, i, 0];
//        rotated_matrix[2, i, 0] = temp2;

//        rotated_matrix[0, i, 0] = temp;

//        temp = rotated_matrix[2, i, 1];
//        rotated_matrix[2, i, 1] = rotated_matrix[1, i, 2];

//        temp2 = rotated_matrix[1, i, 0];
//        rotated_matrix[1, i, 0] = temp;

//        temp = rotated_matrix[0, i, 1];
//        rotated_matrix[0, i, 1] = temp2;

//        rotated_matrix[1, i, 2] = temp;

//    }

//    return rotated_matrix;
//} 







