using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	private Animator anim;

	public float Speed;

	Rigidbody rb;

	void Start()
	{
		anim = gameObject.GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.W))
		{
			anim.SetInteger("AnimationPar", 1);
		}
		else
		{
			anim.SetInteger("AnimationPar", 0);
		}

		if (Input.GetKey(KeyCode.W))
			transform.Translate(Vector3.forward * Speed);
		else if (Input.GetKey(KeyCode.S))
			transform.Translate(Vector3.back * Speed);

		if (Input.GetKey(KeyCode.A))
			transform.Translate(Vector3.left * Speed);
		else if (Input.GetKey(KeyCode.D))
			transform.Translate(Vector3.right * Speed);
	}
}
