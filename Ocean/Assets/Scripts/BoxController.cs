using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
	[SerializeField]
	private int CurrentWorld = 1;
	[SerializeField]
	private float KillingVelocity = 5;
	private Rigidbody2D BoxBody;

	private bool BeingGrabbed = false;

	void Awake()
	{
		BoxBody = gameObject.GetComponent<Rigidbody2D>();
	}

	public void ToggleGrabbed()
	{
		BeingGrabbed = !BeingGrabbed;

		if (BeingGrabbed)
			BoxBody.gravityScale = 0;
		else
			BoxBody.gravityScale = 1;
	}
	

    void OnTriggerEnter2D(Collider2D other)
	{
		// Expected: if the box falls on the player, the player should die.
		// The killing collider is smaller than the actual collider, so it should only touch the player if the box is falling fast.
		// Just running into a still box shouldn't kill you. (Though you might hurt your toes)
		if (other.tag == "Player" && (gameObject.GetComponent<Rigidbody2D>().velocity.magnitude > KillingVelocity))
		{
			// Replace with actual respawn/room reset logic later
			Destroy(other.gameObject);
		}
	}
}
