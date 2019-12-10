using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheOcean
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class AbstractButtonController : MonoBehaviour
	{
		private bool IsPressed;
		private Vector2 OriginalScale;

		private SpriteRenderer MSpriteRenderer;

		[SerializeField]
		Sprite UnpushedSprite;
		[SerializeField]
		Sprite PushedSprite;

		void Awake()
		{
			OriginalScale = gameObject.transform.localScale;
			MSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		}
		
		public virtual void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "Player" || other.tag == "Box")
			{
				IsPressed = true;
				MSpriteRenderer.sprite = PushedSprite;
			}
		}

		public virtual void OnTriggerStay2D(Collider2D other)		
		{
			if (other.tag == "Player" || other.tag == "Box")
			{
				IsPressed = true;
				MSpriteRenderer.sprite = PushedSprite;
			}
		}

		public virtual void OnTriggerExit2D(Collider2D other)
		{
			IsPressed = false;
			MSpriteRenderer.sprite = UnpushedSprite;
		}

	}
}
