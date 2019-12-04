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
		private const float SwitchCooldown = 1f;
		private float SwitchTimer = 0f;
		private PlayerInput Input;
		private bool CanSwitch = true;
		private Collider2D PlatformsWorld1;
		private Collider2D PlatformsWorld2;
		private int PlayerW1Mask;
		private int PlayerW2Mask;

		public static int PlayerCurrentWorld = 1; 

		void Awake()
		{
			Input = PlayerObject.GetComponent<PlayerInput>();
			PlayerBody = PlayerObject.GetComponent<Rigidbody2D>();
			Player = PlayerObject.GetComponent<PlayerController>();
			var platform1object = GameObject.Find("Platforms 1");
			var platform2object = GameObject.Find("Platforms 2");
			PlatformsWorld1 = platform1object.GetComponent<Collider2D>();
			PlatformsWorld2 = platform2object.GetComponent<Collider2D>();


			Physics2D.IgnoreLayerCollision((int)Layers.PLAYERW1, (int)Layers.PLATFORMS2);
			Physics2D.IgnoreLayerCollision((int)Layers.PLAYERW1, (int)Layers.OBJECTS2);
			PlayerW1Mask = Physics2D.GetLayerCollisionMask((int)Layers.PLAYERW1);
			Physics2D.IgnoreLayerCollision((int)Layers.PLAYERW2, (int)Layers.PLATFORMS1);
			Physics2D.IgnoreLayerCollision((int)Layers.PLAYERW2, (int)Layers.OBJECTS1);
			PlayerW2Mask = Physics2D.GetLayerCollisionMask((int)Layers.PLAYERW2);
		}
		/*
		void Update()
		{
			SwitchTimer += Time.deltaTime;
		}
		*/

		void FixedUpdate()
		{
			if (Input.SwitchPressed)
			{
				SwitchTimer = 0f;
				SwitchPlayerWorld();
				ToggleRenderers(PlayerCurrentWorld);
			}
		}

		void SwitchPlayerWorld()
		{
			CanSwitch = !CollidingInOtherWorld();
			Debug.Log(CanSwitch);
			if (!CanSwitch)
				return;

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
		}

		public bool CollidingInOtherWorld()
		{
			// Make sure the player isn't inside a collider OR about to be in one.
			// || PlatformsWorld1.bounds.Contains(PlayerBody.transform.position)
			Vector2 differentSize = new Vector2(PlayerObject.GetComponent<BoxCollider2D>().size.x, PlayerObject.GetComponent<BoxCollider2D>().size.y - 0.4f);
			// Current = 1
			if (PlayerCurrentWorld > 0)
			{
				Physics2D.SetLayerCollisionMask((int)Layers.PLAYERW1, (PlayerW1Mask | PlayerW2Mask));
				/*if (Physics2D.OverlapPoint(PlayerObject.transform.position, LayersManager.GetLayerMaskWorld2()) ||
					PlayerBody.IsTouchingLayers(LayersManager.GetLayerMaskWorld2()) ||
					Physics2D.Raycast(PlayerObject.transform.position, PlayerBody.velocity, 1f, LayersManager.GetLayerMaskWorld2()))*/
				if (Physics2D.OverlapBox(PlayerObject.transform.position, differentSize, 0, LayersManager.GetLayerMaskWorld2()))
				{
					Physics2D.SetLayerCollisionMask((int)Layers.PLAYERW1, PlayerW1Mask);
					return true;
				}
				Physics2D.SetLayerCollisionMask((int)Layers.PLAYERW1, PlayerW1Mask);
			}
			// Current = 2
			else if (PlayerCurrentWorld < 0)
			{
				Physics2D.SetLayerCollisionMask((int)Layers.PLAYERW2, (PlayerW1Mask | PlayerW2Mask));
				/*if (Physics2D.OverlapPoint(PlayerObject.transform.position, LayersManager.GetLayerMaskWorld1()) ||
					PlayerBody.IsTouchingLayers(LayersManager.GetLayerMaskWorld1()) ||
					Physics2D.Raycast(PlayerObject.transform.position, PlayerBody.velocity, 1f, LayersManager.GetLayerMaskWorld1()))*/
				if (Physics2D.OverlapBox(PlayerObject.transform.position, differentSize, 0, LayersManager.GetLayerMaskWorld1()))
				{
					Physics2D.SetLayerCollisionMask((int)Layers.PLAYERW2, PlayerW2Mask);
					return true;
				}
				Physics2D.SetLayerCollisionMask((int)Layers.PLAYERW2, PlayerW2Mask);
			}
			else
			{
				Debug.Log("ERROR: The player doesn't appear to be in any world.");
				return true;
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

	}

}