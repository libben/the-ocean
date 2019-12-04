using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OceanGame
{
	public class SpikeController : MonoBehaviour
	{
		void OnTriggerEnter2D(Collider2D other)
		{
			// Spikes should kill the player as soon as they make contact.
			if (other.tag == "Player")
			{
				// Replace with actual respawn/room reset logic later
				Destroy(other.gameObject);
			}
		}
	}
}