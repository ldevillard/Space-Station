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
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            isMoving = true;

            if (Input.GetKey(KeyCode.W))
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.S))
                transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.A))
                transform.Rotate(Vector3.down * turnSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.D))
                transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
        }
        else
            isMoving = false;
        
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            GetComponent<Rigidbody>().AddForce(transform.up * jumpSpeed);
            isJumping = true;
        }
    }

    void Jump()
    {

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

    void FixedUpdate()
    {
        Move();
        Jump();
        Animate();

        OrbitalRotate();
    }   
}
