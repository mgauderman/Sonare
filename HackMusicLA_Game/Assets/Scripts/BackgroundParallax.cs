using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour 
{
	public GameObject player;
	public float parallaxSpeed = 10.0f;

	Vector3 prevPos;

	void Awake()
	{
		prevPos = player.transform.position;
	}

	// Update is called once per frame
	void LateUpdate ()
	{
		Vector3 playerMovingDir = (player.transform.position - prevPos);
		playerMovingDir.Normalize ();
		float dP = Vector3.Dot (playerMovingDir, transform.right);
		if (Mathf.Abs (dP) < 0.1f) 
		{
			dP = 0;
		}

		if (dP > 0) 
		{
			transform.position += parallaxSpeed * transform.right * Time.deltaTime;
		} 
		else if (dP < 0) 
		{
			transform.position += -parallaxSpeed * transform.right * Time.deltaTime;
		}

		prevPos = player.transform.position;
	}
}