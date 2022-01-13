using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{

    public void SwapCam()
    {
        Camera Main = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        Camera Orbital = GameObject.FindWithTag("OrbitalCam").GetComponent<Camera>();

        if (Orbital.depth == -1)
            Orbital.depth = 1;
        else
            Orbital.depth = -1;
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

}
