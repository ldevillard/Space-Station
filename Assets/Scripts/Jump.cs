using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        if (other.collider.tag == "Player")
        {
            //send to gamemanager to disable arrow
        }    
    }
}
