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
    public Material giusto;
    public GameObject cilindro;

        int[] err = new int[2];

       static int[,] key1 = new int[3,9]{
            { 0,3,0,0,0,5,0,0,0},
            { 0,0,4,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,1} };
       
       static int[,] key2 = new int[3, 9]{
            { 0,0,0,0,0,0,0,9,0},
            { 0,2,0,0,3,0,0,0,0},
            { 0,0,6,0,0,0,0,0,0} };

    private int[] multiplier = {  1, 2, 4, 8, 16, 32, 64, 128, 256 };

    private int[] values = {0,0,0};
    private int key;

    public Interface _interface;

    private static int[,] rotated_matrix = new int[9, 3];

    public int passwordGenerator() //last method that confirm the challenge
    {
        printMat();

//        copyInterfaceInRotationMatrix();
        makeRotations();
        printMat();
        multiplyMatrix();

        int keyGen = getKey();


        
        resetValues();
        resetRotationMatrix();

        return keyGen;
    }

    public int checkKey()
    {
        
        makeRotations();
        printMat();
        multiplyMatrix();
        printMat();
        for (int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 9; j++)
            {
                if (rotated_matrix[j, i] != key1[i,j]) 
                    err[0]++;
                if (rotated_matrix[j, i] != key2[i, j]) 
                    err[1]++;
            }
        }

        Debug.Log("Floating cylinder errors: " + err[0]);
        Debug.Log("Handeled cylinder errors: " + err[1]);

        
        resetRotationMatrix();

        if (err[0] == 0 || err[1] == 0)
        { err[0] = 0;
            err[1] = 0;
            return 0;
        }
        err[0] = 0;
        err[1] = 0;
        return 1;
    }


    public void makeRotations()
    {
        if (back.isActive()) //collider1 collide con front
       {

            if (lato1.isActive())
            {
                Debug.Log("lato1 attivo");

                // già nel verso giusto

                rotated_matrix = ruotaZ(0);

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
        Debug.Log("PRINTO LA ROTATED MATRIX");
        for(int i = 0; i < 3; i++)
        {
            Debug.Log(rotated_matrix[0, i] + ", " + rotated_matrix[1, i] + ", " + rotated_matrix[2, i] + 
                ", " + rotated_matrix[3, i] + ", " + rotated_matrix[4, i] + ", " + rotated_matrix[5, i] +  
                ", " + rotated_matrix[6, i] + ", " + rotated_matrix[7, i] + ", " + rotated_matrix[8, i] );

        }


    }


    public void multiplyMatrix()
    {
        int value = 0;
        //Debug.Log("Entrato in multiplyMatrix");
       
            //    Debug.Log("Entrato in multiplyMatrix " + i);

            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 9; k++)
                {

                    value = 0;
                    if (rotated_matrix[k, j] != 0)
                    {
                        value = rotated_matrix[k, j] - 1;
                        rotated_matrix[k, j] = rotated_matrix[k, j] - value;
                    }
                    rotated_matrix[k, j] = (rotated_matrix[k, j]) * multiplier[k];
                    //                      Debug.Log("reading from rotated_matrix, prof " + i + ", riga " + j + ", colonna " + k + " : " + rotated_matrix[k, j, i] + ", with multiplier:  " + multiplier[j, k]);

                    values[j] += rotated_matrix[k, j] + value;
                   // Debug.Log("after increment value " + j + ": " + values[j]);
                }
            }
        


    }

    public void filterValues()
    {
        Debug.Log("filtra valori");
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
        key = values[0] + values[1] * 10 + values[2] * 100;

        Debug.Log("restituisce chiave");

        return key;
    }

    private void copyInterfaceInRotationMatrix()
    {
        Debug.Log("copio matrice");

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                rotated_matrix[j, i] = _interface.Matrix[j, i];
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
            for (int j = 0; j < 9; j++)
            {
                rotated_matrix[(n + j) % 9, i] = _interface.Matrix[j, i];
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







