using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager Mine;

    public GameObject PlanetPrefab;
    GameObject[] Planets = new GameObject[2];

    string currentID;

    public int nbrPlanetSpawned;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        Mine = this;

        nbrPlanetSpawned = 0;
        
        Planets[0] = Instantiate(PlanetPrefab, Vector3.zero, new Quaternion());
        Planets[0].GetComponent<PlanetData>().FirstPlanet();
        Planets[0].GetComponent<PlanetData>().ID = "first";

        Planets[1] = Instantiate(PlanetPrefab, new Vector3(0, 100, 0), new Quaternion(0, 0, 180, 0));
        Planets[1].GetComponent<PlanetData>().ID = "second";

    }

    public void Generate(string id)
    {
        if (currentID != id)
        {
            if (id == "first")
            {
                Destroy(Planets[1]);
                Planets[1] = Instantiate(PlanetPrefab, new Vector3(0, 100, 0), new Quaternion(0, 0, 180, 0));
                Planets[1].GetComponent<PlanetData>().ID = "second";
            }
            else
            {
                Destroy(Planets[0]);
                Planets[0] = Instantiate(PlanetPrefab, Vector3.zero, new Quaternion());
                Planets[0].GetComponent<PlanetData>().ID = "first";
            }

            currentID = id;
        }
    }
}
