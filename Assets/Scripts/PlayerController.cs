using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 15;
    public float turnSpeed = 30;
    public float jumpSpeed = 10;

    public Transform targetPlanet;
    Animator anim;

    bool isMoving;
    bool isJumping;
    bool canJump;

    public FloatingJoystick Joystick;

    public RawImage Fade; //Making camera fading while idling
    bool countStarted;
    bool canFade;

    void Start()
    {
        anim = GetComponent<Animator>();

        Fade.color = new Color(Fade.color.r, Fade.color.g, Fade.color.b, 1);
    }

    void OnCollisionEnter(Collision other)
    {
        isJumping = false;
        canJump = true;
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

        if (isJumping && canJump)
        {
            canJump = false;
            anim.SetBool("Jump", true);
        }
        else
            anim.SetBool("Jump", false);
    }

    void OrbitalRotate()
    {
        Vector3 direction = (transform.position - targetPlanet.position).normalized;
        Vector3 localUp = transform.up;

        Quaternion rot = Quaternion.FromToRotation(localUp, direction) * transform.rotation;

        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 3 * Time.deltaTime);
    }

    void Update()
    {
        Move();
        Animate();

        FadeController();

        OrbitalRotate();
    }

    void FadeController()
    {
        if (!isMoving && !isJumping)
        {
            if (!countStarted)
            {
                countStarted = true;
                StartCoroutine(WaitingToFade());
            }
        }
        else
        {
            canFade = false;
            if (countStarted)
            {
                countStarted = false;
                StopCoroutine(WaitingToFade());
            }
        }

        if (canFade)
            FadeIn();
        else
            FadeOut();
    }

    void FadeOut()
    {
        //Debug.Log("FadeOut");
        Fade.color = Color.Lerp(Fade.color, new Color(Fade.color.r, Fade.color.g, Fade.color.b, 1), 10 * Time.deltaTime);
    }

    void FadeIn()
    {
        //Debug.Log("FadeIn");
        Fade.color = Color.Lerp(Fade.color, new Color(Fade.color.r, Fade.color.g, Fade.color.b, 0), 10 * Time.deltaTime);
    }

    IEnumerator WaitingToFade()
    {
        yield return new WaitForSeconds(5);
        canFade = true;
    }
}


