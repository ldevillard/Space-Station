using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiting : MonoBehaviour
{
    public Transform Point;
    public float Speed;
    public bool Orientation;

    void Update()
    {
        if (Orientation)
            transform.RotateAround(Point.position, Vector3.left, Speed * Time.deltaTime);
        else
            transform.RotateAround(Point.position, Vector3.up, Speed * Time.deltaTime);
    }
}
