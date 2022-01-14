using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioManager.Mine.KeyTaken_SFX();
            GetComponentInParent<PlanetData>().PlanetDone();
            Destroy(gameObject);
        }
    }

}
