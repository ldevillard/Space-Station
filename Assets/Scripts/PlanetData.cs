using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetData : MonoBehaviour
{
    public GameObject Jump;
    public Mesh[] Textures;
    public Key key;

    public string ID;

    public GameObject[] Obstacles;

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
        RandomSize();
        RandomTexture();
        if (GameManager.Mine.nbrPlanetSpawned > 0)
            RandomObstacle();
        
        Jump.SetActive(false);

        GameManager.Mine.nbrPlanetSpawned++;
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

    void RandomTexture()
    {
        GetComponent<MeshFilter>().mesh = Textures[Random.Range(0, Textures.Length)];
    }

    void RandomSize()
    {
        int i = Random.Range(0, 4);

        if (i == 0)
            transform.localScale = new Vector3(18, 18, 18);
        else if (i == 1)
            transform.localScale = new Vector3(20, 20, 20);
        else if (i == 2)
            transform.localScale = new Vector3(22, 22, 22);
        else if (i == 3)
            transform.localScale = new Vector3(24, 24, 24);
    }

    void RandomObstacle()
    {
        int i = Random.Range(0, Obstacles.Length);
        Instantiate(Obstacles[i], transform);
    }
}
