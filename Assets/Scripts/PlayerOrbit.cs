using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrbit : MonoBehaviour
{

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().targetPlanet = transform.parent;
        }
    }
}
