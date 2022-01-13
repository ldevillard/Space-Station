using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{

    public GameObject Fade;

    bool inCinematic;
    bool countStarted;

    void Start()
    {
        Fade.SetActive(false);    
    }

    void Update()
    {
        if (!PlayerController.isMoving)
        {
            if (!countStarted && !inCinematic)
                StartCoroutine(CountDown());
        }
        else
        {
            if (countStarted)
            {
                StopAllCoroutines();
                countStarted = false;
            }

            if (inCinematic && !Fade.activeSelf)
            {
                inCinematic = false;
                Fade.SetActive(true);
            }
        }
    }

    IEnumerator CountDown()
    {
        countStarted = true;
        yield return new WaitForSeconds(5);
        Fade.SetActive(true);
        inCinematic = true;
    }
}
