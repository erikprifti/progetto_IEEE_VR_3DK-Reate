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


    public void calculate()
    {

        cube = _interface.Matrix;

        if (front.isActive() && coll_1.isActive())
        {
            if (left.isActive())
            {

            }
            else if (bottom.isActive())
            {

            }
            else if (right.isActive())
            {

            }
            else
            {

            }
        }
        else if (back.isActive() && coll_1.isActive())
        {
            if (left.isActive())
            {

            }
            else if (bottom.isActive())
            {

            }
            else if (right.isActive())
            {

            }
            else
            {

            }
        }
        else if (left.isActive() && coll_1.isActive())
        {
            if (front.isActive())
            {

            }
            else if (bottom.isActive())
            {

            }
            else if (back.isActive())
            {

            }
            else
            {

            }
        }
        else if (right.isActive() && coll_1.isActive())
        {
            if (front.isActive())
            {

            }
            else if (bottom.isActive())
            {

            }
            else if (back.isActive())
            {

            }
            else
            {

            }
        }
        else if (bottom.isActive() && coll_1.isActive())
        {
            if (front.isActive())
            {

            }
            if (left.isActive())
            {

            }
            if (back.isActive())
            {

            }
            if (right.isActive())
            {

            }
        }
        else if(!coll_1.isActive())
        {
            if (front.isActive())
            {
               // già orientato nel verso predefinito
            }
            if (left.isActive())
            {
                _interface.Matrix = ruotaZ(cube);
            }
            if (back.isActive())
            {
                _interface.Matrix = ruotaZ(cube);
                _interface.Matrix = ruotaZ(cube);

            }
            if (right.isActive())
            {
                _interface.Matrix = ruotaZ(cube);
                _interface.Matrix = ruotaZ(cube);
                _interface.Matrix = ruotaZ(cube);

            }
        }
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

}
