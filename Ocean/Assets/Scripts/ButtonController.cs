using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheOcean
{
	public class ButtonController : MonoBehaviour
	{
		[SerializeField]
		private GameObject LinkedObject;
		private LatchboxController LinkedController;
		private bool IsPressed;
		[SerializeField]
		private Sprite SpriteDown;
		[SerializeField]
		private Sprite SpriteUp;
		private SpriteRenderer ButtonRenderer;

		void Awake()
		{
			if (!LinkedObject.TryGetComponent<LatchboxController>(out LinkedController))
				Debug.Log("Error: Button couldn't find associated latchbox's controller.");
			ButtonRenderer = gameObject.GetComponent<SpriteRenderer>();
		}
		
		void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "Player" || other.tag == "Box")
			{
				IsPressed = true;
				ButtonRenderer.sprite = SpriteDown;
				LinkedController.OpenLatchbox();
			}
		}

		void OnTriggerStay2D(Collider2D other)		
		{
			if (other.tag == "Player" || other.tag == "Box")
			{
				IsPressed = true;
				ButtonRenderer.sprite = SpriteDown;
				LinkedController.OpenLatchbox();
			}
		}

		void OnTriggerExit2D(Collider2D other)
		{
			IsPressed = false;
			ButtonRenderer.sprite = SpriteUp;
			LinkedController.CloseLatchbox();
		}

	}
}
