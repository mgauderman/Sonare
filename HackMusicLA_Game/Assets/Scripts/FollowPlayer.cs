using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float distFromPlayer = 10;

	PlayerMovement playerMovement;

	void Start()
	{
		playerMovement = player.GetComponent<PlayerMovement> ();
	}

	// Update is called once per frame
	void LateUpdate ()
    {
        // Player has updated -> move to new location.
		GameObject[] parentAndChild = playerMovement.GetParentAndChild();

		parentAndChild [0].transform.position = new Vector3(parentAndChild [1].transform.position.x,
															parentAndChild [0].transform.position.y,
															parentAndChild [1].transform.position.z);
		parentAndChild [1].transform.localPosition = new Vector3 (0,
																  parentAndChild [1].transform.localPosition.y,
																  0);
        transform.position = player.transform.position - transform.forward * distFromPlayer;
	}
}
