using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAtoB : MonoBehaviour
{
    //put into the enemy

    public Transform pointA;
    public Transform pointB;

    Vector3 back; //assign it whatever value you want one edge of the movement to be
    Vector3 forth; //again, assign whatever the other edge is supposed to be
    float phase = 0;
    public float speed = 1; //adjust to anything that results in the speed u want
    float phaseDirection = 1; //this is just to make the code less "ify" =D

    private void Start()
    {
        back = pointA.position;
        forth = pointB.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(back, forth, phase); //phase determines (in percent, basically) where on the line between the points "back" and "forth" you want the enemy to be placed, so if we gradually increase/decrease the variable, it makes the enemy move between those two points.
        phase += Time.deltaTime * speed * phaseDirection; //subtracts from 1 to zero when phaseDirection is negative, adds from zero to one when phaseDirection is positive.
        if (phase >= 1 || phase <= 0) phaseDirection *= -1; //flip the sign to flip direction
    }
}
