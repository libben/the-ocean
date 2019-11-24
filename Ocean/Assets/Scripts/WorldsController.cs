using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OceanGame
{
	public class WorldsController : MonoBehaviour
	{
		[SerializeField]
		private GameObject PlayerObject;
		[SerializeField]
		private GameObject PlatformsWorld1;
		[SerializeField]
		private GameObject PlatformsWorld2;
		private const float SwitchCooldown = 1f;
		private float SwitchTimer = 0f;
		private PlayerInput Input;

		public static int PlayerCurrentWorld = 1; 

		void Awake()
		{
			Input = PlayerObject.GetComponent<PlayerInput>();
		}

		void Update()
		{
			SwitchTimer += Time.deltaTime;
		}

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
			if (CollidingInOtherWorld())
				return;

			PlayerCurrentWorld *= -1;

			if (PlayerCurrentWorld > 0)
			{
				
				PlayerObject.layer = (int)Layers.PLAYERW1;

				// Need to inform the movement controller script that the ground is now world 1's ground
				var movementController = PlayerObject.GetComponent<PlayerController>();
				movementController.groundLayer = LayersManager.GetLayerMaskWorld1();

				var currentBox = movementController.GetGrabbedBox();
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

				var movementController = PlayerObject.GetComponent<PlayerController>();
				movementController.groundLayer = LayersManager.GetLayerMaskWorld2();

				var currentBox = movementController.GetGrabbedBox();
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

		bool CollidingInOtherWorld()
		{
			var playerRigidBody = PlayerObject.GetComponent<Rigidbody2D>();

			// Make sure the player isn't inside a collider OR about to be in one.
			if (PlayerCurrentWorld > 0)
				return (PlayerObject.GetComponent<Collider2D>().IsTouchingLayers(LayersManager.GetLayerMaskWorld2()) ||
					    Physics2D.Raycast(PlayerObject.transform.position, playerRigidBody.velocity, 1f, LayersManager.GetLayerMaskWorld2()));
			else if (PlayerCurrentWorld < 0)
				return (PlayerObject.GetComponent<Collider2D>().IsTouchingLayers(LayersManager.GetLayerMaskWorld1()) ||
						Physics2D.Raycast(PlayerObject.transform.position, playerRigidBody.velocity, 1f, LayersManager.GetLayerMaskWorld1()));
			else
			{
				Debug.Log("ERROR: The player doesn't appear to be in any world.");
				return true;
			}
		}

		void ToggleRenderers(int newWorld)
		{
			var world1renderer = PlatformsWorld1.GetComponent<Renderer>();
			var world2renderer = PlatformsWorld2.GetComponent<Renderer>();

			// Going from 2 to 1.
			if (newWorld > 0)
			{
				world1renderer.enabled = true;
				world2renderer.enabled = false;

				foreach (GameObject obj in FindAllObjectsInWorld((int)Layers.OBJECTS1))
				{
					obj.GetComponent<Renderer>().enabled = true;
				}
				foreach (GameObject obj in FindAllObjectsInWorld((int)Layers.OBJECTS2))
				{
					obj.GetComponent<Renderer>().enabled = false;
				}
			}
			// Going from 1 to 2.
			else
			{
				world1renderer.enabled = false;
				world2renderer.enabled = true;

				foreach (GameObject obj in FindAllObjectsInWorld((int)Layers.OBJECTS1))
				{
					obj.GetComponent<Renderer>().enabled = false;
				}
				foreach (GameObject obj in FindAllObjectsInWorld((int)Layers.OBJECTS2))
				{
					obj.GetComponent<Renderer>().enabled = true;
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