using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetData : MonoBehaviour
{
    public GameObject Jump;
    public Mesh[] Textures;
    public Key key;

    public string Tag;

    void Awake()
    {
        Jump.SetActive(false);
        /*Random Planet*/
        GetComponent<MeshFilter>().mesh = Textures[Random.Range(0, Textures.Length)];
    }

    public void PlanetDone()
    {
        Jump.SetActive(true);
    }

    public void FirstPlanet()
    {
        Jump.SetActive(true);
        key.gameObject.SetActive(false);
    }
}
