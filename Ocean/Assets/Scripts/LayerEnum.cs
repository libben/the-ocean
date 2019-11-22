using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OceanGame
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
	}
}