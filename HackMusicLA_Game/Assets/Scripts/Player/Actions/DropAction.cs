using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAction : MonoBehaviour 
{
	public float dropDistance = 1;

	Inventory inventory;
	PlayerMovement playerMovement;

	public MusicalItem testItem;

	void Start()
	{
		playerMovement = GetComponent<PlayerMovement> ();
		inventory = Inventory.instance;
	}

	public void DropSelectedGem()
	{
		MusicalItem item = inventory.currentSelected;
		if (item) 
		{
			item.SpawnGem (transform.position + dropDistance * playerMovement.GetDirection());
			inventory.Remove (item);
		}

		inventory.currentSelected = null;
	}
}
