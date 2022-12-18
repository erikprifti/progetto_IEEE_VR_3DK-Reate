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
    
    public void calculate()
    {
        if (front.isActive())
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
        else if (back.isActive())
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
        else if (left.isActive())
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
        else if (right.isActive())
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
        else if (bottom.isActive())
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
        else
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
    }
}
