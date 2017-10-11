using System.Collections;
using System.Collections.Generic;
//using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public float speed = 10.0f;

	SpriteRenderer spriteRenderer;
	GameObject cam, player;
	Vector3 facingDirection;
    Animator animator;
	GameObject[] parentAndChild;
	GameObject sword;

	// Determine if player sprite is flipped.
	public bool IsFlipped() { return spriteRenderer.flipX; }

	void Start()
	{
		player = transform.GetChild (0).gameObject;
		spriteRenderer = player.GetComponent<SpriteRenderer> ();
		cam = Camera.main.gameObject;
		facingDirection = -cam.transform.right;

        animator = player.GetComponent<Animator>();

		// Used to compare movement of two in LateUpdate of follow scripts.
		parentAndChild = new GameObject[2];
		parentAndChild [0] = gameObject;
		parentAndChild [1] = player;

		//Inventory.instance.Add(new MusicalItem());

		sword = transform.GetChild (0).transform.GetChild (0).gameObject;
	}

	// Update is called once per frame
	void Update () 
	{
        Vector3 dir = Vector3.zero;
        
        // Move Up
        if (Input.GetKey(KeyCode.W))
        {
            EditDirection(ref dir, cam.transform.forward);
        }

        // Move Down
        if (Input.GetKey(KeyCode.S))
        {
            EditDirection(ref dir, -cam.transform.forward);
        }

        // Move Left
        if (Input.GetKey(KeyCode.A))
        {
            EditDirection(ref dir, -cam.transform.right);
        }

        // Move Right
        if (Input.GetKey(KeyCode.D))
        {
            EditDirection(ref dir, cam.transform.right);
        }

        if( dir != new Vector3(0, 0, 0) && dir.y == 0)
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }
			
		// Update player's position.
        transform.position += dir * speed * Time.deltaTime;

		// ********* Make player face direction of movement *********
		float dP = Vector3.Dot (dir, cam.transform.right);

		// Truncate float if player is not moving left or right.
		if (Mathf.Abs(dP) < 0.1f) 
		{
			dP = 0;
		}

		// Player should face right.
		if (dP > 0) 
		{
			spriteRenderer.flipX = true;
			sword.GetComponent<SpriteRenderer> ().flipX = true;
		} 
		// Player should face left.
		else if (dP < 0) 
		{
			spriteRenderer.flipX = false;
			sword.GetComponent<SpriteRenderer> ().flipX = false;
		}
    }

	// Adjusts the direction by truncating the y axis.
    void EditDirection(ref Vector3 dir, Vector3 inputDir)
    {
        dir += inputDir;
        dir.y = 0;
        dir.Normalize();

		// Store the facing direction.
		facingDirection = dir;
    }
		
	// Returns the last direction the player was moving in.
	public Vector3 GetDirection()
	{
		return facingDirection;
	}

	public GameObject[] GetParentAndChild()
	{
		return parentAndChild;
	}
}
