using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheOcean
{

	public class PlayerController : MonoBehaviour
	{
		// Note: much of this is from Unity 2D Training Day 2018, Berlin with minor tweaks:
		// https://www.youtube.com/watch?v=j29NgzV8Dw4&list=PLX2vGYjWbI0REfhDHPpdIBjjrzDHDP-xT&index=1 

		public bool drawDebugRaycasts = true;   //Should the environment checks be visualized

		[Header("Movement Properties")]
		public float Speed = 5f;                //Player Speed
		public float AirSpeedDivisor = 3f;      //Speed reduction after player jumps (but not falling)
		public float CoyoteDuration = .05f;     //How long the player can jump after falling
		public float MaxFallSpeed = -25f;       //Max Speed player can fall

		[Header("Jump Properties")]
		public float JumpForce = 8f;          //Initial force of jump
		public float JumpHoldForce = 0f;      //Incremental force when jump is held
		public float JumpHoldDuration = .1f;    //How long the jump key can be held
		public float MaxJumpVelocity = 20f;

		[Header("Environment Check Properties")]
		public float GroundDistance = .2f;      //Distance player is considered to be on the ground
		public LayerMask GroundLayer;           //Walkable layer mask (objects and platforms of current world, persistent objects)

		[Header("Status Flags")]
		public bool IsGrounded;                 //Is the player on the ground?
		public bool IsJumping;                  //Is player jumping?
		public bool PlayerJumped;               // is the fall caused by player action

		PlayerInput input;                      //The current inputs for the player
		BoxCollider2D bodyCollider;             //The collider component
		Rigidbody2D rigidBody;                  //The rigidbody component

		// Animation related values
		Animator Anim;
		int XVelocityHash = Animator.StringToHash("XVelocity");
		int IsGroundedHash = Animator.StringToHash("IsGrounded");
		int GravityGunActiveHash = Animator.StringToHash("GravityGunActive");

		float JumpTime;                         //Variable to hold jump duration
		float CoyoteTime;                       //Variable to hold coyote duration

		float originalXScale;                   //Original scale on X axis
		int Direction = 1;                      //Direction player is facing

		// Gravity gun related fields
		[SerializeField]
		private float GravityGunRange = 1f;
		[SerializeField]
		private bool GravityGunActive = false;
		[SerializeField]
		private BoxController GrabbedBox = null;
		private Vector2 BoxOffset;
		private Vector2 OriginalColliderSize;

		private bool CanMove = true;

		private Vector3 PositionToResetTo;
		private int DirectionToResetTo;

		void Start()
		{
			//Get a reference to the required components
			input = GetComponent<PlayerInput>();
			rigidBody = GetComponent<Rigidbody2D>();
			Anim = GetComponent<Animator>();

			var allPlayerColliders = gameObject.GetComponents<BoxCollider2D>();
			foreach (BoxCollider2D collider in allPlayerColliders)
			{
				if (!collider.isTrigger)
					bodyCollider = collider;
			}

			//Record the original x scale of the player
			originalXScale = transform.localScale.x;
			OriginalColliderSize = bodyCollider.size;

			GroundLayer = LayersManager.GetLayerMaskWorld1();
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
			Raycast(new Vector2(Direction * 0.5f, 0.5f), Direction * Vector2.right, GravityGunRange, LayersManager.GetLayerMaskObjects(WorldsController.PlayerCurrentWorld));
		}

		void PhysicsCheck()
		{
			//Start by assuming the player isn't on the ground and the head isn't blocked
			IsGrounded = false;

			// Note: The player sprite's pivot is set to Bottom, and the collider has been manually adjusted.
			// Before adjusting the collider box myself, it was making the player float above ground weirdly.
			// That's why we can just use 0,0 as the origin.

			if (Raycast(Vector2.zero, Vector2.down, GroundDistance))
			{
				IsGrounded = true;
				PlayerJumped = false;
			}

			Anim.SetBool(IsGroundedHash, IsGrounded);
		}

		public void UpdateResetData()
		{
			this.PositionToResetTo = this.transform.position;
			this.DirectionToResetTo = this.Direction;
		}

		public void Reset()
		{
			this.transform.position	= PositionToResetTo;
			if (this.DirectionToResetTo != this.Direction) {
				FlipCharacterDirection();
			}
		}

		void GroundMovement()
		{
			//Calculate the desired velocity based on inputs
			float xVelocity = Speed * input.Horizontal;

			// Tighten the player's jump arc by reducing velocity if they jumped.
			// We might want to have this happen for all falls OR none at all.

			/*
			if (PlayerJumped)
				xVelocity /= AirSpeedDivisor;
			*/

			//If the sign of the velocity and Direction don't match, flip the character
			if (xVelocity * Direction < 0f && !GravityGunActive)
				FlipCharacterDirection();

			//Apply the desired velocity 
			rigidBody.velocity = new Vector2(xVelocity, rigidBody.velocity.y);
			Anim.SetFloat(XVelocityHash, Mathf.Abs(rigidBody.velocity.x));

			if (GrabbedBox)
			{
				GrabbedBox.gameObject.transform.position = BoxOffset + (Vector2)gameObject.transform.position;
			}

			//If the player is on the ground, extend the coyote time window
			if (IsGrounded)
				CoyoteTime = Time.time + CoyoteDuration;

		}

		void MidAirMovement()
		{
			//If the jump key is pressed AND the player isn't already jumping AND EITHER
			//the player is on the ground or within the coyote time window...
			if (input.JumpPressed && !IsJumping && (IsGrounded || CoyoteTime > Time.time))
			{
				//...The player is no longer on the groud and is jumping...
				IsGrounded = false;
				IsJumping = true;
				PlayerJumped = true;

				//...record the time the player will stop being able to boost their jump...
				JumpTime = Time.time + JumpHoldDuration;

				//...add the jump force to the rigidbody...
				rigidBody.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);

				//...and tell the Audio Manager to play the jump audio
				//AudioManager.PlayJumpAudio();
			}
			//Otherwise, if currently within the jump time window...
			else if (IsJumping)
			{
				//...and the jump button is held, apply an incremental force to the rigidbody...
				if (input.JumpHeld)
					rigidBody.AddForce(new Vector2(0f, JumpHoldForce), ForceMode2D.Impulse);

				//...and if jump time is past, set IsJumping to false
				if (JumpTime <= Time.time)
					IsJumping = false;
			}

			//If player is falling to fast, reduce the Y velocity to the max
			if (rigidBody.velocity.y < MaxFallSpeed)
				rigidBody.velocity = new Vector2(rigidBody.velocity.x, MaxFallSpeed);
			else if (rigidBody.velocity.y > MaxJumpVelocity)
				rigidBody.velocity = new Vector2(rigidBody.velocity.x, MaxJumpVelocity);

		}

		void FlipCharacterDirection()
		{
			//Turn the character by flipping the Direction
			Direction *= -1;

			//Record the current scale
			Vector3 scale = transform.localScale;

			//Set the X scale to be the original times the Direction
			scale.x = originalXScale * Direction;

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

			Anim.SetBool(GravityGunActiveHash, GravityGunActive);
		}

		void GravityGunOn()
		{
			// Check if box is in front of us.
			var boxInRange = Raycast(new Vector2(Direction * 0.5f, 0.5f), Direction * Vector2.right,
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
				bodyCollider.offset = new Vector2(Direction * BoxOffset.x / 2, bodyCollider.offset.y);

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
			return Raycast(offset, rayDirection, length, GroundLayer);
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
	}
}

