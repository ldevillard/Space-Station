using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    public Vector3 Speed;

    void Update()
    {
        transform.Rotate(Speed * Time.deltaTime);        
    }
}
