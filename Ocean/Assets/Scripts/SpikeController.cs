using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheOcean
{
	public class SpikeController : MonoBehaviour
	{
		void OnTriggerEnter2D(Collider2D other)
		{
			// Spikes should kill the player as soon as they make contact.
			if (other.tag == "Player")
			{
				other.GetComponent<PlayerController>().Reset();
				GameObject.FindGameObjectWithTag("WorldManager").BroadcastMessage("Reset");
				gameObject.GetComponentInParent<ObjectContainer>().ResetObjects();
			}
		}
	}
}