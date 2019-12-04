using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OceanGame
{
	public class WorldsController : MonoBehaviour
	{
		[SerializeField]
		private GameObject PlayerObject;
		private Rigidbody2D PlayerBody;
		private PlayerController Player;
		private PlayerInput Input;

		private const float SwitchCooldown = 1f;
		private float SwitchTimer = 0f;

		public static int PlayerCurrentWorld = 1; 

		void Awake()
		{
			Input = PlayerObject.GetComponent<PlayerInput>();
			PlayerBody = PlayerObject.GetComponent<Rigidbody2D>();
			Player = PlayerObject.GetComponent<PlayerController>();
			ToggleRenderers(1);

			foreach (GameObject overlapper in GameObject.FindGameObjectsWithTag("Overlap"))
			{
				var overlapSprite = overlapper.GetComponent<SpriteRenderer>();
				var tempColor = Color.red;
				tempColor.a = 0;
				overlapSprite.color = tempColor;
			}
		}

		void FixedUpdate()
		{
			if (Input.SwitchPressed && SwitchTimer >= SwitchCooldown)
			{
				SwitchTimer = 0;
				if (SwitchPlayerWorld())
					ToggleRenderers(PlayerCurrentWorld);
			}
			SwitchTimer += Time.deltaTime;
		}

		bool SwitchPlayerWorld()
		{
			if (CollidingInOtherWorld())
				return false;

			PlayerCurrentWorld *= -1;

			if (PlayerCurrentWorld > 0)
			{
				
				PlayerObject.layer = (int)Layers.PLAYERW1;

				// Need to inform the movement controller script that the ground is now world 1's ground
				Player.GroundLayer = LayersManager.GetLayerMaskWorld1();

				var currentBox = Player.GetGrabbedBox();
				if (currentBox)
				{
					if (currentBox.gameObject.layer != (int)Layers.OBJECTS_PERSISTENT)
					{
						currentBox.gameObject.layer = (int)Layers.OBJECTS1;
						currentBox.gameObject.GetComponent<Renderer>().sortingLayerName = "Objects1";
					}
				}
			}
			// 1->2
			else
			{
				PlayerObject.layer = (int)Layers.PLAYERW2;

				Player.GroundLayer = LayersManager.GetLayerMaskWorld2();

				var currentBox = Player.GetGrabbedBox();
				if (currentBox)
				{
					if (currentBox.gameObject.layer != (int)Layers.OBJECTS_PERSISTENT)
					{
						currentBox.gameObject.layer = (int)Layers.OBJECTS2;
						currentBox.gameObject.GetComponent<Renderer>().sortingLayerName = "Objects2";
					}
				}
			}

			return true;
		}

		bool CollidingInOtherWorld()
		{
			// Check if player is in bound of all overlap colliders and boxes
			// Todo: add level-specification.
			foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Overlap"))
			{
				if (obj.GetComponent<Collider2D>().bounds.Contains(Player.transform.position))
				{
					var tempColor = obj.GetComponent<SpriteRenderer>().color;
					tempColor.a = 1;
					obj.GetComponent<SpriteRenderer>().color = tempColor;
					IEnumerator fadeRoutine = FadeOut(obj.GetComponent<SpriteRenderer>());
					StartCoroutine(fadeRoutine);
					return true;
				}
			}
		
			foreach (GameObject box in GameObject.FindGameObjectsWithTag("Box"))
			{
				if (box.GetComponent<Collider2D>().bounds.Contains(Player.transform.position))
				{
					var tempColor = box.GetComponent<SpriteRenderer>().color;
					tempColor.a = 1;
					box.GetComponent<SpriteRenderer>().color = tempColor;
					IEnumerator fadeRoutine = FadeOutBox(box.GetComponent<SpriteRenderer>());
					StartCoroutine(fadeRoutine);
					return true;
				}
			}
			return false;
		}

		void ToggleRenderers(int newWorld)
		{
			Renderer current;
			// Going from 2 to 1.
			if (newWorld > 0)
			{
				foreach (GameObject obj in FindAllObjectsInWorld((int)Layers.OBJECTS1))
				{
					if (!obj.TryGetComponent<Renderer>(out current))
						continue;
					current.enabled = true;
					//obj.GetComponent<Renderer>().enabled = true;
				}
				foreach (GameObject obj in FindAllObjectsInWorld((int)Layers.PLATFORMS1))
				{
					if (!obj.TryGetComponent<Renderer>(out current))
						continue;
					current.enabled = true;
				}
				foreach (GameObject obj in FindAllObjectsInWorld((int)Layers.OBJECTS2))
				{
					if (!obj.TryGetComponent<Renderer>(out current))
						continue;
					current.enabled = false;
				}
				foreach (GameObject obj in FindAllObjectsInWorld((int)Layers.PLATFORMS2))
				{
					if (!obj.TryGetComponent<Renderer>(out current))
						continue;
					current.enabled = false;
				}
				foreach (GameObject obj in FindAllObjectsInWorld((int)Layers.BG1))
				{
					if (!obj.TryGetComponent<Renderer>(out current))
						continue;
					current.enabled = true;
				}
				foreach (GameObject obj in FindAllObjectsInWorld((int)Layers.BG2))
				{
					if (!obj.TryGetComponent<Renderer>(out current))
						continue;
					current.enabled = false;
				}
			}
			// Going from 1 to 2.
			else
			{
				foreach (GameObject obj in FindAllObjectsInWorld((int)Layers.OBJECTS1))
				{
					if (!obj.TryGetComponent<Renderer>(out current))
						continue;
					current.enabled = false;
				}
				foreach (GameObject obj in FindAllObjectsInWorld((int)Layers.PLATFORMS1))
				{
					if (!obj.TryGetComponent<Renderer>(out current))
						continue;
					current.enabled = false;
				}
				foreach (GameObject obj in FindAllObjectsInWorld((int)Layers.OBJECTS2))
				{
					if (!obj.TryGetComponent<Renderer>(out current))
						continue;
					current.enabled = true;
				}
				foreach (GameObject obj in FindAllObjectsInWorld((int)Layers.PLATFORMS2))
				{
					if (!obj.TryGetComponent<Renderer>(out current))
						continue;
					current.enabled = true;
				}
				foreach (GameObject obj in FindAllObjectsInWorld((int)Layers.BG1))
				{
					if (!obj.TryGetComponent<Renderer>(out current))
						continue;
					current.enabled = false;
				}
				foreach (GameObject obj in FindAllObjectsInWorld((int)Layers.BG2))
				{
					if (!obj.TryGetComponent<Renderer>(out current))
						continue;
					current.enabled = true;
				}
			}
		}

		// Gets all the objects in the specified world, so that we can iterate through them and turn off their renderers. Try not to call this too much because Find is slow.
		public GameObject[] FindAllObjectsInWorld(int world)
		{
			GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
			List<GameObject> result = new List<GameObject>();
			foreach (GameObject obj in allObjects)
			{
				if (obj.layer == world)
					result.Add(obj);
			}
			return result.ToArray();
		}

		IEnumerator FadeOut(SpriteRenderer objRenderer)
		{
			for (float ft = 1f; ft >= 0; ft -= 0.05f)
			{
				if (ft < 0.1)
					ft = 0;
				Color c = objRenderer.color;
				c.a = ft;
				objRenderer.color = c;
				yield return null;
			}
		}

		IEnumerator FadeOutBox(SpriteRenderer boxRenderer)
		{
			// when first called, turn on the renderer (if needed)
			// same fadeout
			// when reaching 0 alpha, turn off the renderer (if needed) but also turn the alpha back to 1
			bool NeedToDisable = false;
			if (!boxRenderer.enabled)
			{
				Debug.Log("enabling a box renderer from the other world");
				boxRenderer.enabled = true;
				NeedToDisable = true;
			}
			
			Color c = Color.red;
			Color originalColor = boxRenderer.color;
			for (float ft = 1f; ft >= 0; ft -= 0.05f)
			{
				if (ft < 0.1)
				{
					ft = 0;
				}
				c = Color.red;
				c.a = ft;
				boxRenderer.color = c;

				yield return null;
			}

			if (c.a <= 0.1)
			{
				boxRenderer.color = originalColor;

				if (NeedToDisable)
					boxRenderer.enabled = false;

				yield break;
			}
		}



	}

}