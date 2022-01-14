using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetData : MonoBehaviour
{
    public GameObject Jump;
    public Mesh[] Textures;
    public Key key;

    public string ID;

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            //Debug.Log(ID);    
            GameManager.Mine.Generate(ID);
        }
    }

    void Awake()
    {
        RandomTexture();
        Jump.SetActive(false);
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

    public void RandomTexture()
    {
        GetComponent<MeshFilter>().mesh = Textures[Random.Range(0, Textures.Length)];
    }
}
