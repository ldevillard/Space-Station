using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Orbiting : MonoBehaviour
{
    Camera cam;
    Vector3 previousPos;

    public Transform Target;
    public float Distance;

    void Start()
    {
        cam = gameObject.GetComponent<Camera>();    
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //Change Input if needed
        {
            previousPos = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 dir = previousPos - cam.ScreenToViewportPoint(Input.mousePosition);

            cam.transform.position = Target.position;
            cam.transform.Rotate(new Vector3(1, 0, 0), dir.y * 180);
            cam.transform.Rotate(new Vector3(0, 1, 0), -dir.x * 180, Space.World);
            cam.transform.Translate(new Vector3(0, 0, -Distance));

            previousPos = cam.ScreenToViewportPoint(Input.mousePosition);
        }
    }
}
