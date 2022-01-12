using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 15;
    public float turnSpeed = 30;
    public float jumpSpeed = 10;

    public Transform targetPlanet;
    Animator anim;

    bool isMoving;
    bool isJumping;

    public FloatingJoystick Joystick;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision other)
    {
        isJumping = false;
    }

    void Move()
    {
        Vector2 movement = Joystick.Direction;

        if (movement != Vector2.zero)
        {
            isMoving = true;

            transform.Translate(new Vector3(0, 0, movement.y) * moveSpeed * Time.deltaTime);
            transform.Rotate(new Vector3(0, movement.x, 0) * turnSpeed * Time.deltaTime);   
        }
        else
            isMoving = false;
        
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            GetComponent<Rigidbody>().AddForce(transform.up * jumpSpeed);
            isJumping = true;
        }
    }

    void Animate()
    {
        if (isMoving)
            anim.SetBool("Walk", true);
        else
            anim.SetBool("Walk", false);

        if (isJumping)
            anim.SetBool("Jump", true);
        else
            anim.SetBool("Jump", false);
    }

    void OrbitalRotate()
    {
        Vector3 direction = (transform.position - targetPlanet.position).normalized;
        Vector3 localUp = transform.up;

        Quaternion rot = Quaternion.FromToRotation(localUp, direction) * transform.rotation;

        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 50 * Time.deltaTime);
    }

    void Update()
    {
        Move();
        Animate();

        OrbitalRotate();
    }   
}


