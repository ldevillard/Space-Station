using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PlanetPrefab;
    GameObject[] Planets = new GameObject[2];

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        Planets[0] = Instantiate(PlanetPrefab, Vector3.zero, new Quaternion());
        Planets[0].GetComponent<PlanetData>().FirstPlanet();
        Planets[0].GetComponent<PlanetData>().Tag = "first";

        Planets[1] = Instantiate(PlanetPrefab, new Vector3(0, 100, 0), new Quaternion(0, 0, 180, 0));
        Planets[1].GetComponent<PlanetData>().Tag = "second";
    }

    public void Generate()
    {
    }
}
