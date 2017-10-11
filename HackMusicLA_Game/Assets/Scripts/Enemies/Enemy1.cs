using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MusicalEntity 
{
	float jumpForce = 7;
	Rigidbody rb;

	protected override void Start()
	{
		base.Start ();
		rb = GetComponent<Rigidbody> ();
		Invoke ("Jump", Random.Range (1, 7));
	}

	public void Slay(MusicalItem item)
	{
		if (m_item.GetNote () == Note.C ||
		    m_item.GetNote () == Note.E ||
		    m_item.GetNote () == Note.G) {
			item.PlayPickupSound (transform.position);
			DestroyMusicalEntity ();
		} 
		else 
		{
			item.PlayWeakSound (transform.position);
		}
	}

	void Jump()
	{
		// Determine direction on XZ plane.
		float angleAround = Random.Range (0, 360);
		Vector3 dir = Quaternion.AngleAxis (angleAround, Vector3.up) * transform.forward;
		dir.y = 0;
		dir.Normalize ();

		// Determine directoin on Y plane.
		float angleUp = Random.Range (30, 60);
		Vector3 rightVec = Vector3.Cross(Vector3.up, dir);
		dir = Quaternion.AngleAxis (-angleUp, rightVec) * dir;
		dir.Normalize ();

		// Make frog jump!
		rb.AddForce (jumpForce * dir, ForceMode.Impulse);

		m_item.PlayJumpSound (transform.position);
		Invoke ("Jump", Random.Range (5, 10));
	}
}
