using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAction : MonoBehaviour 
{
	public float jumpForce = 10.0f;
	public AudioClip[] jumpClips;


	AudioSource audio;
	const int GROUND_LAYER = 8;

	Rigidbody rb;
	bool isGrounded;

    Animator animator;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
        animator = GetComponent<Animator>();
		audio = GetComponent<AudioSource> ();
	}

	public void Jump()
	{
		if (isGrounded) 
		{
			rb.AddForce (jumpForce * Vector3.up, ForceMode.Impulse);
			audio.clip = jumpClips[Random.Range (0, jumpClips.Length)];
			audio.Play ();
		}
	}
		
	void OnCollisionStay(Collision collision)
	{
		if (collision.gameObject.layer == GROUND_LAYER && !isGrounded) 
		{
			isGrounded = true;
			animator.SetBool("jump", false);
		}
	}

	void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.layer == GROUND_LAYER) 
		{
			isGrounded = false;
            animator.SetBool("jump", true);
        }
	}
}
