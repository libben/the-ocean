using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheOcean
{
	// User defined layers in Unity start from 8.
	// Don't forget to cast to int before use.
	enum Layers
	{
		BG1 = 8,
		BG2,
		PLATFORMS1,
		PLATFORMS2,
		OBJECTS1,
		OBJECTS2,
		OBJECTS_PERSISTENT,
		PLAYERW1,
		PLAYERW2
	};

	static class LayersManager
	{
		public static int GetLayerMaskWorld1()
		{
			return LayerMask.GetMask("Platforms1", "Objects1", "ObjectsPersistent");
		}

		public static int GetLayerMaskWorld2()
		{
			return LayerMask.GetMask("Platforms2", "Objects2", "ObjectsPersistent");
		}

		public static int GetLayerMaskAll()
		{
			return LayerMask.GetMask("Platforms1", "Platforms2", "Objects1", "Objects2", "ObjectsPersistent");
		}

		public static int GetLayerMaskObjects(int currentWorld)
		{
			switch (currentWorld)
			{
				case -1:
					return LayerMask.GetMask("Objects2", "ObjectsPersistent");
				case 1:
					return LayerMask.GetMask("Objects1", "ObjectsPersistent");
				default:
					Debug.Log("ERROR: Bad argument for GetLayerMaskObjects, no such world");
					return 0;
			}
		}

		public static int GetLayerMaskWorld(int currentWorld)
		{
			switch (currentWorld)
			{
				case -1:
					return LayerMask.GetMask("Platforms2", "Objects2", "ObjectsPersistent");
				case 1:
					return LayerMask.GetMask("Platforms1", "Objects1", "ObjectsPersistent");
				default:
					Debug.Log("ERROR: Bad argument for GetLayerMaskWorld, no such world");
					return 0;
			}
		}

		// Converts a Layers enum value to 1 (world 1) or -1 (world 2). Don't use this for persistent objects.
		public static int GetCurrentWorld(int currentLayer)
		{
			if (currentLayer == (int)Layers.OBJECTS1 || currentLayer == (int)Layers.PLATFORMS1 || currentLayer == (int)Layers.PLAYERW1)
				return 1;
			else if (currentLayer == (int)Layers.OBJECTS2 || currentLayer == (int)Layers.PLATFORMS2 || currentLayer == (int)Layers.PLAYERW2)
				return -1;
			else
				return 0;
		}

	}


}