using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : MonoBehaviour 
{
	public float SCAN_RADIUS = 1.8f; // Radius for scanning items.
	public LayerMask layerMask;
	public float castDistance = 1;

	PlayerMovement playerMovement;

	// Use this for initialization
	void Start () 
	{
		playerMovement = GetComponent<PlayerMovement> ();
		castDistance = SCAN_RADIUS * 0.5f;
	}

	public void Attack()
	{
		MusicalItem weapon = CraftingParent.instance.GetCurrentItem ();
		if (!weapon) 
		{
			Debug.Log ("no weapon");
			//return;
		}

		Vector3 dir = playerMovement.GetDirection();
		Vector3 castPosition = dir * castDistance;
		RaycastHit[] objectHits = Physics.SphereCastAll (castPosition, SCAN_RADIUS,
			                          transform.forward, SCAN_RADIUS);//, layerMask);
		foreach (RaycastHit hit in objectHits) 
		{
			Debug.Log (hit.transform.gameObject);
			//hit.collider.gameObject.GetComponent<Enemy1> ().Slay (weapon);
		}

		// 

		/*
		// Determine which direction to scan in.
		Vector3 dir = playerMovement.GetDirection();
		Vector3 castPosition = dir * castDistance;
		castPosition = transform.position + dir * castDistance;

		RaycastHit[] objectHits = Physics.SphereCastAll (castPosition, SCAN_RADIUS,
			transform.forward, SCAN_RADIUS, layerMask);

		// Loot musical item closest to player.
		MusicalItem closestItem = null;
		GameObject closestGameObject = null;
		float closestDistance = -1;
		foreach (RaycastHit hit in objectHits) 
		{
			float distance = (hit.transform.position - transform.position).magnitude;
			if (closestDistance < 0 || distance < closestDistance)
			{
				closestDistance = distance;
				closestItem = hit.collider.gameObject.GetComponent<Loot> ().GetItem ();
				closestGameObject = hit.collider.gameObject;
			}
		}

		// Add the closest musical item (if one exists)
		if (closestItem != null) 
		{		
			closestItem.PlayPickupSound (closestGameObject.transform.position);
			Inventory.instance.Add(closestItem);
			closestGameObject.GetComponent<Loot> ().DestroyLoot ();
		}*/
	}
}
