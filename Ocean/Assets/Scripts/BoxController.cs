using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheOcean
{
public class BoxController : MonoBehaviour
{
	[SerializeField]
	private int CurrentWorld = 1;
	[SerializeField]
	private float KillingVelocity = 5;
	private Rigidbody2D BoxBody;
	private BoxCollider2D Collider;
	public bool IsGrabbable = false;
	private bool BeingGrabbed = false;
	private bool IsSomethingAbove = false;
	[SerializeField]
	private float CloseDistance = 0.1f;
	private GameObject PlayerObject;

		public bool IsGrounded;
		public bool TouchingLeft;
		public bool TouchingRight;

	void Awake()
	{
		BoxBody = gameObject.GetComponent<Rigidbody2D>();
		Collider = gameObject.GetComponent<BoxCollider2D>();
		IsGrabbable = true;
		PlayerObject = GameObject.FindGameObjectWithTag("Player");
	}

	public void ToggleGrabbed()
	{
		BeingGrabbed = !BeingGrabbed;

			if (BeingGrabbed)
			{
				BoxBody.gravityScale = 0;
			}
			else
			{
				BoxBody.gravityScale = 1;
			}
	}

	void FixedUpdate()
	{
			IsGrounded = false;

		var CheckAbove = Raycast(new Vector2(0, Collider.size.y/2 + 0.05f), Vector2.up, CloseDistance, LayersManager.GetLayerMaskObjects(CurrentWorld));
			var CheckBelow = Raycast(new Vector2(0, -Collider.size.y / 2 - 0.05f), Vector2.down, CloseDistance, LayersManager.GetLayerMaskWorld(CurrentWorld));
			var CheckLeft = Raycast(new Vector2(-Collider.size.x / 2 - 0.001f, 0), Vector2.left, CloseDistance, LayersManager.GetLayerMaskWorld(CurrentWorld));
		var CheckRight = Raycast(new Vector2(Collider.size.x / 2 + 0.001f, 0), Vector2.right, CloseDistance, LayersManager.GetLayerMaskWorld(CurrentWorld));

			if (CheckLeft)
				TouchingLeft = true;
			else
				TouchingLeft = false;
			if (CheckRight)
				TouchingRight = true;
			else
				TouchingRight = false;
			if (CheckBelow)
				IsGrounded = true;


			if (CheckAbove)
			{
				IsGrabbable = false;
			}
			else
			{
				IsGrabbable = true;
			}

			// If this box is being grabbed, we want it to stop the player if it hits a ceiling/wall
			if (BeingGrabbed)
			{

				CheckAbove = Raycast(new Vector2(0, Collider.size.y / 2 + 0.05f), Vector2.up,
												   CloseDistance, LayersManager.GetLayerMaskWorld(CurrentWorld));
				if (CheckAbove)
				{
					PlayerObject.GetComponent<PlayerController>().HaltPlayerJump();
				}
			}
		}

		public void SetCurrentWorld(int newWorld)
		{
			CurrentWorld = newWorld;
		}

    void OnTriggerEnter2D(Collider2D other)
	{
		// Expected: if the box falls on the player, the player should die.
		// The killing collider is smaller than the actual collider, so it should only touch the player if the box is falling fast.
		// Just running into a still box shouldn't kill you. (Though you might hurt your toes)
		if (other.tag == "Player" && (gameObject.GetComponent<Rigidbody2D>().velocity.magnitude > KillingVelocity))
		{
			GameObject.FindGameObjectWithTag("ScriptHome").GetComponent<ResetController>().Reset();
		}
	}

	RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length, LayerMask mask)
	{
		//Record the player's position
		Vector2 pos = transform.position;

		//Send out the desired raycasr and record the result
		RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDirection, length, mask);

		//If we want to show debug raycasts in the scene...
		if (true)
		{
			//...determine the color based on if the raycast hit...
			Color color = hit ? Color.red : Color.green;
			//...and draw the ray in the scene view
			Debug.DrawRay(pos + offset, rayDirection * length, color);
		}

		//Return the results of the raycast
		return hit;
	}


	}
}