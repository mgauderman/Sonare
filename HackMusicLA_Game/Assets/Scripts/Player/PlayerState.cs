using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour 
{
	AttackAction attackAction;
	DropAction dropAction;
	JumpAction jumpAction;
	ScanAction scanAction;
	ThrowAction throwAction;

	// Use this for initialization
	void Start () 
	{
		attackAction = GetComponent<AttackAction> ();
		dropAction = GetComponent<DropAction> ();
		jumpAction = transform.GetChild(0).GetComponent<JumpAction> ();
		scanAction = GetComponent<ScanAction> ();
		throwAction = GetComponent<ThrowAction> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		/* Attack with right mouse click.
		   Also loot closest item to player. */
		if (Input.GetMouseButtonDown(1)) 
		{
			scanAction.PickUpClosestItem ();
		}

		// Drop an item with F.
		if (Input.GetKeyDown (KeyCode.F)) 
		{
			dropAction.DropSelectedGem ();
		}

		// Jump with spacebar.
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			jumpAction.Jump ();
		}

		// Throw an item with shift key.
		if (Input.GetKeyDown (KeyCode.LeftShift)) 
		{
			//throwAction.Throw ();
		}
	}
}
