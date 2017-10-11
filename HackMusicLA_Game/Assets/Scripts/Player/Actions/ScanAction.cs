using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanAction : MonoBehaviour 
{
	public float SCAN_RADIUS = 1.8f; // Radius for scanning items.
	public float castDistance = 1;

	GameObject sword;

	PlayerMovement playerMovement;

	void Awake()
	{
		sword = transform.GetChild (0).transform.GetChild (0).gameObject;
		sword.GetComponent<SpriteRenderer> ().enabled = false;
		Debug.Log (sword);

	}

	// Use this for initialization
	void Start () 
	{
		playerMovement = GetComponent<PlayerMovement> ();
		castDistance = SCAN_RADIUS * 0.5f;
	}

	public void PickUpClosestItem()
	{
		List<MusicalItem> allItems = new List<MusicalItem> ();

		// Determine which direction to scan in.
		Vector3 dir = playerMovement.GetDirection();
		Vector3 castPosition = dir * castDistance;
		castPosition = transform.position + dir * castDistance;

		RaycastHit[] objectHits = Physics.SphereCastAll (castPosition, SCAN_RADIUS,
			                          transform.forward, SCAN_RADIUS);

		bool canAttack = false;

		// Loot musical item closest to player.
		MusicalItem closestItem = null;
		GameObject closestGameObject = null;
		float closestDistance = -1;
		foreach (RaycastHit hit in objectHits) 
		{
			Debug.Log(hit.transform.gameObject);

			// Scanned object is an item.
			if (hit.transform.gameObject.layer == 9) 
			{ 
				float distance = (hit.transform.position - transform.position).magnitude;
				if (closestDistance < 0 || distance < closestDistance) 
				{
					closestDistance = distance;
					closestItem = hit.collider.gameObject.GetComponent<MusicalEntity> ().GetItem ();
					closestGameObject = hit.collider.gameObject;
				}
			}
			// Scanned object is an enemy.
			else if (hit.transform.gameObject.layer == 10) 
			{
				MusicalItem weapon = CraftingParent.instance.GetCurrentItem ();
				if (weapon) 
				{
					canAttack = true;
					hit.collider.gameObject.GetComponent<Enemy1> ().Slay (weapon);
				}
			}
		}

		// Add the closest musical item (if one exists)
		if (closestItem != null) 
		{		
			closestItem.PlayPickupSound (closestGameObject.transform.position);
			Inventory.instance.Add(closestItem);
			closestGameObject.GetComponent<MusicalEntity> ().DestroyMusicalEntity ();
		}

		// Swing sword bc we can attack
		if (canAttack) 
		{
			sword.GetComponent<SpriteRenderer>().enabled = true;
			sword.GetComponent<SpriteRenderer> ().flipX = playerMovement.IsFlipped();
			sword.GetComponent<Animator> ().SetTrigger ("swing");
			Invoke ("OnSwordAnimationEnd", 0.5f);
		}
	}

	void OnSwordAnimationEnd()
	{
		sword.GetComponent<SpriteRenderer>().enabled = false;
	}
}
