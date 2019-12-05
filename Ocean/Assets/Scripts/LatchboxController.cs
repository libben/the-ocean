using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheOcean
{
	public class LatchboxController : MonoBehaviour
	{
		private bool IsOpen = false;
		[SerializeField]
		private Sprite SpriteOpen;
		[SerializeField]
		private Sprite SpriteClosed;

		public void OpenLatchbox()
		{
			var renderer = gameObject.GetComponent<SpriteRenderer>();
			renderer.sprite = SpriteOpen;
			var collider = gameObject.GetComponent<Collider2D>();
			collider.enabled = false;
		}

		public void CloseLatchbox()
		{
			var renderer = gameObject.GetComponent<SpriteRenderer>();
			renderer.sprite = SpriteClosed;
			var collider = gameObject.GetComponent<Collider2D>();
			collider.enabled = true;
		}
	}
}
