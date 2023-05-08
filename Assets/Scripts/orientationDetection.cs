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
    public GameObject cubo;
    public Material giusto;


    private int[,] multiplier = { { 1, 2, 4 }, 
                                  { 8, 16, 32 }, 
                                  { 64, 128, 256 } };

    private int[] values = {0,0,0};
    private int key;

    public Interface _interface;

    private static int[,,] rotated_matrix = new int[3, 3, 3];

    public int passwordGenerator() //last method that confirm the challenge
    {
        makeRotations();
        multiplyMatrix();
        resetRotationMatrix();

        int keyGen = getKey();

       
        resetValues();
        return keyGen;
    }

    public int checkKey()
    {
        int[] err = new int[2];

        int[,,] key1 = new int[3, 3, 3]{ { { 0,3,0}, { 0,0,0}, { 0,0,0} },
                                           { { 7,0,0}, { 0,2,0}, { 0,0,0} },
                                           { { 0,0,0}, { 0,0,0}, { 0,0,8} } };


        int[,,] key2 = new int[3, 3, 3]{ { { 0,0,0}, { 6,0,2}, { 0,0,0} },
                                          { { 3,0,0}, { 0,0,0}, { 0,0,0} },
                                          { { 0,0,0}, { 0,0,0}, { 0,0,8} } };


        makeRotations();
        multiplyMatrix();

        for (int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                for(int k = 0; k < 3; k++)
                {
                    if (rotated_matrix[i,j,k] != key1[i,j,k])
                    {
                        err[0]++;
                    }
                    if (rotated_matrix[i, j, k] != key2[i, j, k])
                    {
                        err[1]++;
                    }
                }
            }
        }

        Debug.Log("Floating key errors: " + err[0]);
        Debug.Log("Handeled key errors: " + err[1]);

        resetRotationMatrix();

        if (err[0] == 0 || err[1] == 0) return 0;

        return 1;

    }

    public void makeRotations()
    {
        copyInterfaceInRotationMatrix();
        

        if (front.isActive() && coll_1.isActive() && front.isPosition()) //collider1 collide con front
        {
            rotated_matrix = ruotaX();

            if (left.isActive())
            {
                rotated_matrix = ruotaZ();
            }
            else if (bottom.isActive())
            {
                // già nel verso giusto
            }
            else if (right.isActive())
            {
                rotated_matrix = ruotaZ();
                rotated_matrix = ruotaZ();
                rotated_matrix = ruotaZ();
            }
            else
            {
                rotated_matrix = ruotaZ();
                rotated_matrix = ruotaZ();
            }
        }
        else if (back.isActive() && coll_1.isActive() && back.isPosition())
        {
            rotated_matrix = ruotaX();
            rotated_matrix = ruotaX();
            rotated_matrix = ruotaX();
            
            if (left.isActive())
            {
                rotated_matrix = ruotaZ();
                rotated_matrix = ruotaZ();
                rotated_matrix = ruotaZ();
            }
            else if (bottom.isActive())
            {
                rotated_matrix = ruotaZ();
                rotated_matrix = ruotaZ();
            }
            else if (right.isActive())
            {
                rotated_matrix = ruotaZ();
            }
            else
            {
                // già a posto
            }
        }
        else if (left.isActive() && coll_1.isActive() && left.isPosition())
        {
            rotated_matrix = ruotaZ();
            rotated_matrix = ruotaZ();
            rotated_matrix = ruotaZ();

            if (front.isActive())
            {
                // posizione già giusta
            }
            else if (bottom.isActive())
            {
                rotated_matrix = ruotaX();
            }
            else if (back.isActive())
            {
                rotated_matrix = ruotaX();
                rotated_matrix = ruotaX();
            }
            else
            {
                rotated_matrix = ruotaX();
                rotated_matrix = ruotaX();
                rotated_matrix = ruotaX();
            }
        }
        else if (right.isActive() && coll_1.isActive()  && right.isPosition())
        {
            rotated_matrix=ruotaZ();

            if (front.isActive())
            {
                // già a posto
            }
            else if (bottom.isActive())
            {
                rotated_matrix = ruotaX();
              
            }
            else if (back.isActive())
            {
                rotated_matrix = ruotaX();
                rotated_matrix = ruotaX();
            }
            else
            {
                rotated_matrix = ruotaX();
                rotated_matrix = ruotaX();
                rotated_matrix = ruotaX();
            }
        }
        else if(bottom.isActive() && coll_1.isActive() && bottom.isPosition())
        {
            rotated_matrix = ruotaX();
            rotated_matrix = ruotaX();

            if (back.isActive())
            {
                // già a posto
            }
            if (right.isActive())
            {
                rotated_matrix = ruotaZ();
            }
            if (front.isActive())
            {
                rotated_matrix = ruotaZ();
                rotated_matrix = ruotaZ();
            }
            if (left.isActive())
            {
                rotated_matrix = ruotaZ();
                rotated_matrix = ruotaZ();
                rotated_matrix = ruotaZ();            }
        }
        else
        {
            if (front.isActive())
            {
                // già orientato nel verso predefinito
            }
            else if (left.isActive())
            {
                rotated_matrix = ruotaY();
            }
            else if (back.isActive())
            {
                rotated_matrix = ruotaY();
                rotated_matrix = ruotaY();
            }
            else if(right.isActive())
            {
                rotated_matrix = ruotaY();
                rotated_matrix = ruotaY();
                rotated_matrix = ruotaY();
            }
        }

        //printMat();
    }
    private int[,,] ruotaX()
    {
        int temp, temp2;

        for (int i = 0; i < 3; i++)
        {
            temp = rotated_matrix[i, 0, 0];
            rotated_matrix[i, 0, 0] = rotated_matrix[i, 0, 2];

            temp2 = rotated_matrix[i, 2, 0];
            rotated_matrix[i, 2, 0] = temp;

            temp = rotated_matrix[i, 2, 2];
            rotated_matrix[i, 2, 2] = temp2;

            rotated_matrix[i, 0, 2] = temp;

            temp = rotated_matrix[i, 1, 0];
            rotated_matrix[i, 1, 0] = rotated_matrix[i, 0, 1];

            temp2 = rotated_matrix[i, 2, 1];
            rotated_matrix[i, 2, 1] = temp;

            temp = rotated_matrix[i, 1, 2];
            rotated_matrix[i, 1, 2] = temp2;

            rotated_matrix[i, 1, 0] = temp;
        }

        return rotated_matrix;
    }
    private int[,,] ruotaY()
    {
        int temp, temp2;

        for (int i = 0; i < 3; i++)
        {
            temp = rotated_matrix[0, i, 2];
            rotated_matrix[0, i, 2] = rotated_matrix[0, i, 0];

            temp2 = rotated_matrix[2, i, 2];
            rotated_matrix[2, i, 2] = temp;

            temp = rotated_matrix[2, i, 0];
            rotated_matrix[2, i, 0] = temp2;

            rotated_matrix[0, i, 0] = temp;

            temp = rotated_matrix[2, i, 1];
            rotated_matrix[2, i, 1] = rotated_matrix[1, i, 2];

            temp2 = rotated_matrix[1, i, 0];
            rotated_matrix[1, i, 0] = temp;

            temp = rotated_matrix[0, i, 1];
            rotated_matrix[0, i, 1] = temp2;

            rotated_matrix[1, i, 2] = temp;

        }

        return rotated_matrix;
    } 
    private int[,,] ruotaZ()
    {
        int temp, temp2;

        for (int i = 0; i < 3; i++)
        {
            temp = rotated_matrix[2, 0, i];
            rotated_matrix[2, 0, i] = rotated_matrix[0, 0, i];

            temp2 = rotated_matrix[2, 2, i];
            rotated_matrix[2, 2, i] = temp;

            temp = rotated_matrix[0, 2, i];
            rotated_matrix[0, 2, i] = temp2;

            rotated_matrix[0, 0, i] = temp;

            temp = rotated_matrix[2, 1, i];
            rotated_matrix[2, 1, i] = rotated_matrix[1, 0, i];

            temp2 = rotated_matrix[1, 2, i];
            rotated_matrix[1, 2, i] = temp;

            temp = rotated_matrix[0, 1, i];
            rotated_matrix[0, 1, i] = temp2;

            rotated_matrix[1, 0, i] = temp;
        }

        return rotated_matrix;
    }

    public void printMat()
    {
        // per adesso stampo solo la faccia frontale
        for (int i = 0; i < 3; i++)
        {
          //  Debug.Log("rotated_matrixrice " + i + ": \n");
            Debug.Log(_interface.Matrix[0, 0, i] + " " + _interface.Matrix[0, 1, i] + " " + _interface.Matrix[0, 2, i] + "\n" +
            _interface.Matrix[1, 0, i] + " " + _interface.Matrix[1, 1, i] + " " + _interface.Matrix[1, 2, i] + "\n" +
                             _interface.Matrix[2, 0, i] + " " + _interface.Matrix[2, 1, i] + " " + _interface.Matrix[2, 2, i]);
            Debug.Log("rotatedMatrix: ");
            
            Debug.Log(rotated_matrix[0, 0, i] + " " + rotated_matrix[0, 1, i] + " " + rotated_matrix[0, 2, i] + "\n" +
            rotated_matrix[1, 0, i] + " " + rotated_matrix[1, 1, i] + " " + rotated_matrix[1, 2, i] + "\n" +
                             rotated_matrix[2, 0, i] + " " + rotated_matrix[2, 1, i] + " " + rotated_matrix[2, 2, i]);

    }
    }


    public void multiplyMatrix()
    {
        int value = 0;
        //Debug.Log("Entrato in multiplyMatrix");
        for (int i = 0; i < 3; i++)
        {
        //    Debug.Log("Entrato in multiplyMatrix " + i);
            
            for (int j = 0; j < 3; j++)
            {
                for(int k = 0; k < 3; k++)
                {

                    value = 0;
                    if (rotated_matrix[k, j, i] != 0)
                    {
                        value = rotated_matrix[k, j, i] - 1;
                        rotated_matrix[k, j, i] = rotated_matrix[k, j, i] - value;
                    }
                    rotated_matrix[k, j, i] = (rotated_matrix[k, j, i]) * multiplier[j, k];
//                      Debug.Log("reading from rotated_matrix, prof " + i + ", riga " + j + ", colonna " + k + " : " + rotated_matrix[k, j, i] + ", with multiplier:  " + multiplier[j, k]);

                    values[i] += rotated_matrix[k, j, i] + value;
                    Debug.Log("after increment value " + i + ": " + values[i]);
                }
            }
        }


    }

    public void filterValues()
    {
        for (int i = 0; i < 3; i++)
        {           
            Debug.LogError("valore di values[i]: " +values[i]);

            values[i] = values[i] % 10;
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

   private void copyInterfaceInRotationMatrix()
    {
        for(int i = 0; i <3; i++)
        {
            for(int j = 0; j<3; j++)
            {
                for(int k = 0; k<3; k++)
                {
                    rotated_matrix[i, j, k] = _interface.Matrix[i, j, k];
                }
            }
        }
    }

    private void resetRotationMatrix()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    rotated_matrix[i, j, k] = 0;
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

    }
}


