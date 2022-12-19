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

    public cubeOrientationCollider coll_1;
    public cubeOrientationCollider coll_2;

    public Interface _interface;

    private static int[,,] cube = new int[3, 3, 3];


    public void makeRotations()
    {

        cube = _interface.Matrix;

        coll_1.enabled = true;
        coll_2.enabled = false;

        if (front.isActive() && coll_1.isActive())
        {
            cube = ruotaX(cube);

            coll_2.enabled = true;

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
        else if (back.isActive() && coll_1.isActive())
        {
            cube = ruotaX(cube);
            cube = ruotaX(cube);
            cube = ruotaX(cube);

            coll_2.enabled = true;
            
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
        else if (left.isActive() && coll_1.isActive())
        {
            cube = ruotaZ(cube);
            cube = ruotaZ(cube);
            cube = ruotaZ(cube);

            coll_2.enabled = true;

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
        else if (right.isActive() && coll_1.isActive())
        {
            cube=ruotaZ(cube);

            coll_2.enabled = true;

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
        else if(bottom.isActive() && coll_1.isActive())
        {
            cube = ruotaX(cube);
            cube = ruotaX(cube);

            coll_2.enabled=true;

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
            coll_2.enabled = true;

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

    private int[,,] ruotaZ(int[,,] mat)
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
    private int[,,] ruotaY(int[,,] mat)
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

            mat[i, 0, 0] = temp;

            temp = mat[i, 1, 0];
            mat[i, 1, 0] = mat[i, 0, 1];

            temp2 = mat[i, 2, 1];
            mat[i, 2, 1] = temp;

            temp = mat[i, 1, 2];
            mat[i, 1, 2] = temp2;

            mat[i, 0, 1] = temp;
        }

        return mat;
    }
    private int[,,] ruotaX(int[,,] mat)
    {
        int temp, temp2;

        for (int i = 0; i < 3; i++)
        {
            temp = mat[0, 2, i];
            mat[0, 2, i] = mat[0, 0, i];

            temp2 = mat[2, 2, i];
            mat[2, 2, i] = temp;

            temp = mat[2, 0, i];
            mat[2, 0, i] = temp2;

            mat[0, 0, i] = temp;

            temp = mat[1, 2, i];
            mat[1, 2, i] = mat[0, 1, i];

            temp2 = mat[2, 1, i];
            mat[2, 1, i] = temp;

            temp = mat[1, 0, i];
            mat[1, 0, i] = temp2;

            mat[0, 1, i] = temp;
        }

        return mat;
    }

    public void printMat(int[,,] mat)
    {
        // per adesso stampo solo la faccia frontale
        for(int i = 0; i < 3; i++)
        {
            Debug.Log("Riga " + i);
            for (int j = 0; j < 3; j++)
            {
                Debug.Log(mat[i, j, 0]);
            }
        }
    }

}
