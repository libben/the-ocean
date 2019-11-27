using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OceanGame
{

	public class PlayerController : MonoBehaviour
	{
		// Note: much of this is from Unity 2D Training Day 2018, Berlin with minor tweaks:
		// https://www.youtube.com/watch?v=j29NgzV8Dw4&list=PLX2vGYjWbI0REfhDHPpdIBjjrzDHDP-xT&index=1 

		public bool drawDebugRaycasts = true;   //Should the environment checks be visualized

		[Header("Movement Properties")]
		public float speed = 5f;                //Player speed
		public float airSpeedDivisor = 3f;		//Speed reduction after player jumps (but not falling)
		public float CoyoteDurationMax = .05f;     //How long the player can jump after falling
		public float maxFallSpeed = -20f;       //Max speed player can fall

		[Header("Jump Properties")]
		public float JumpForce = 8f;
		public float MaxJumpVelocity = 20f;

		[Header("Environment Check Properties")]
		public float groundDistance = .2f;      //Distance player is considered to be on the ground
		public LayerMask groundLayer;           //Walkable layer mask (objects and platforms of current world, persistent objects)

		[Header("Status Flags")]
		public bool IsGrounded;                 // Is the player on the ground?
		public bool PlayerJumped;               // is the fall caused by player action

		PlayerInput input;                      // The current inputs for the player
		BoxCollider2D bodyCollider;             // The collider component
		Rigidbody2D rigidBody;                  // The rigidbody component

		float CoyoteTime = 0;               //Variable to hold coyote duration

		float originalXScale;                   //Original scale on X axis
		int direction = 1;                      //Direction player is facing

		// Gravity gun related fields
		[SerializeField]
		private float GravityGunRange = 0.5f;
		private bool GravityGunActive = false;
		private BoxController GrabbedBox = null;
		private Vector2 BoxOffset;
		private Vector2 OriginalColliderSize;

		private bool CanMove = true;

		void Start()
		{
			//Get a reference to the required components
			input = GetComponent<PlayerInput>();
			rigidBody = GetComponent<Rigidbody2D>();

			var allPlayerColliders = gameObject.GetComponents<BoxCollider2D>();
			foreach (BoxCollider2D collider in allPlayerColliders)
			{
				if (!collider.isTrigger)
					bodyCollider = collider;
			}

			originalXScale = transform.localScale.x;
			OriginalColliderSize = bodyCollider.size;

			groundLayer = LayersManager.GetLayerMaskWorld1();
		}

		void FixedUpdate()
		{
			//Check the environment to determine status
			PhysicsCheck();

			//Process ground and air movements
			if (CanMove)
			{
				GroundMovement();
				MidAirMovement();
			}

			GravityGunControl();

			// TESTING PURPOSES:
			// See the ray that determines whether a box is within gravity gun range.
			Raycast(new Vector2(direction * 0.5f, 0.5f), direction * Vector2.right, GravityGunRange, LayersManager.GetLayerMaskObjects(WorldsController.PlayerCurrentWorld));
		}

		void PhysicsCheck()
		{
			IsGrounded = false;

			if (Raycast(Vector2.zero, Vector2.down, groundDistance))
			{
				IsGrounded = true;
				PlayerJumped = false;
			}
		}

		void GroundMovement()
		{
			//Calculate the desired velocity based on inputs
			float xVelocity = speed * input.Horizontal;

			// Tighten the player's jump arc by reducing velocity if they jumped.
			// We might want to have this happen for all falls OR none at all.
			
			if (PlayerJumped)
				xVelocity /= airSpeedDivisor;

			//If the sign of the velocity and direction don't match, flip the character
			if (xVelocity * direction < 0f && !GravityGunActive)
				FlipCharacterDirection();

			//Apply the desired velocity 
			rigidBody.velocity = new Vector2(xVelocity, rigidBody.velocity.y);

			//If the player is on the ground, extend the coyote time window
			if (IsGrounded)
				CoyoteTime = Time.time + CoyoteDurationMax;

		}

		void MidAirMovement()
		{
			//If the jump key is pressed AND the player isn't already jumping AND EITHER
			//the player is on the ground or within the coyote time window...
			if (input.JumpPressed && (IsGrounded || CoyoteTime > Time.time))
			{
				//...The player is no longer on the groud and is jumping...
				IsGrounded = false;
				PlayerJumped = true;

				//...add the jump force to the rigidbody...
				rigidBody.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);

				//...and tell the Audio Manager to play the jump audio
				//AudioManager.PlayJumpAudio();
			}

			// Limit vertical speed
			if (rigidBody.velocity.y < maxFallSpeed)
				rigidBody.velocity = new Vector2(rigidBody.velocity.x, maxFallSpeed);
			else if (rigidBody.velocity.y > MaxJumpVelocity)
				rigidBody.velocity = new Vector2(rigidBody.velocity.x, MaxJumpVelocity);
		
		}

		void FlipCharacterDirection()
		{
			//Turn the character by flipping the direction
			direction *= -1;

			//Record the current scale
			Vector3 scale = transform.localScale;

			//Set the X scale to be the original times the direction
			scale.x = originalXScale * direction;

			//Apply the new scale
			transform.localScale = scale;
		}

		void GravityGunControl()
		{
			if (GrabbedBox)
			{
				GrabbedBox.gameObject.transform.position = BoxOffset + (Vector2)gameObject.transform.position;
			}

			if (!input.GravityGunPressed)
				return;
			else
			{
				if (!GravityGunActive)
					GravityGunOn();
				else
					GravityGunOff();
			}
		}

		void GravityGunOn()
		{
			// Check if box is in front of us.
			var boxInRange = Raycast(new Vector2(direction * 0.5f, 0.5f), direction * Vector2.right,
										GravityGunRange, LayersManager.GetLayerMaskObjects(WorldsController.PlayerCurrentWorld));
			if (boxInRange && boxInRange.transform.gameObject.tag == "Box")
			{
				GravityGunActive = true;

				// Grab box, turn off its colliders, save its position relative to player, expand player collider
				GrabbedBox = boxInRange.transform.gameObject.GetComponent<BoxController>();
				GrabbedBox.ToggleGrabbed();
				var boxColliders = GrabbedBox.gameObject.GetComponents<Collider2D>();

				foreach (Collider2D collider in boxColliders)
					if (!collider.isTrigger)
						collider.enabled = false;

				BoxOffset = new Vector2(GrabbedBox.transform.position.x - gameObject.transform.position.x, GrabbedBox.transform.position.y - gameObject.transform.position.y);
				bodyCollider.size = new Vector2(Mathf.Abs(BoxOffset.x) + bodyCollider.size.x, bodyCollider.size.y);
				bodyCollider.offset = new Vector2(direction * BoxOffset.x / 2, bodyCollider.offset.y);

				// If player grabs a box but isn't on the ground, they should be stuck dangling.
				if (!IsGrounded)
				{
					rigidBody.velocity = new Vector2(0, 0);
					rigidBody.gravityScale = 0;
					CanMove = false;
				}

				Debug.Log("Gravity gun on");
			}
		}

		void GravityGunOff()
		{
			if (!GrabbedBox)
				return;

			GravityGunActive = false;
			bodyCollider.size = OriginalColliderSize;
			bodyCollider.offset = new Vector2(0, bodyCollider.offset.y);
			GrabbedBox.ToggleGrabbed();
			var boxColliders = GrabbedBox.gameObject.GetComponents<Collider2D>();

			foreach (Collider2D collider in boxColliders)
				collider.enabled = true;

			GrabbedBox = null;

			if (!CanMove)
			{
				rigidBody.gravityScale = 1;
				CanMove = true;
			}

			Debug.Log("Gravity gun off");
		}

		//These two Raycast methods wrap the Physics2D.Raycast() and provide some extra
		//functionality
		RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length)
		{
			//Call the overloaded Raycast() method using the ground layermask and return 
			//the results
			return Raycast(offset, rayDirection, length, groundLayer);
		}

		RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length, LayerMask mask)
		{
			//Record the player's position
			Vector2 pos = transform.position;

			//Send out the desired raycasr and record the result
			RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDirection, length, mask);

			//If we want to show debug raycasts in the scene...
			if (drawDebugRaycasts)
			{
				//...determine the color based on if the raycast hit...
				Color color = hit ? Color.red : Color.green;
				//...and draw the ray in the scene view
				Debug.DrawRay(pos + offset, rayDirection * length, color);
			}

			//Return the results of the raycast
			return hit;
		}

		public bool GetGravityGunActive()
		{
			return GravityGunActive;
		}

		public BoxController GetGrabbedBox()
		{
			return GrabbedBox;
		}

		}	}


