using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OceanGame
{
	public class ButtonController : MonoBehaviour
	{
		[SerializeField]
		private GameObject LinkedObject;
		private LatchboxController LinkedController;
		private bool IsPressed;
		private Vector2 OriginalScale;

		void Awake()
		{
			if (!LinkedObject.TryGetComponent<LatchboxController>(out LinkedController))
				Debug.Log("Error: Button couldn't find associated latchbox's controller.");
			OriginalScale = gameObject.transform.localScale;
		}
		
		void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "Player" || other.tag == "Box")
			{
				IsPressed = true;
				gameObject.transform.localScale = new Vector2(OriginalScale.x, OriginalScale.y / 2);
				LinkedController.OpenLatchbox();
			}
		}

		void OnTriggerStay2D(Collider2D other)		
		{
			if (other.tag == "Player" || other.tag == "Box")
			{
				IsPressed = true;
				gameObject.transform.localScale = new Vector2(OriginalScale.x, OriginalScale.y / 2);
				LinkedController.OpenLatchbox();
			}
		}

		void OnTriggerExit2D(Collider2D other)
		{
			IsPressed = false;
			gameObject.transform.localScale = OriginalScale;
			LinkedController.CloseLatchbox();
		}

	}
}
