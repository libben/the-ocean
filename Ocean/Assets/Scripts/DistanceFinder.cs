using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DistanceFinder
{
    public static GameObject FindMinimumDistance(GameObject player, GameObject[] levelCenters)
    {
        GameObject closestLevelCenter = null;
        float minDistance = float.PositiveInfinity;
        foreach (var levelCenter in levelCenters)
        {
            float distanceFromPlayerToThisLevelCenter = Mathf.Abs(levelCenter.transform.position.x - player.transform.position.x);
            if (distanceFromPlayerToThisLevelCenter < minDistance) {
                closestLevelCenter = levelCenter;
                minDistance = distanceFromPlayerToThisLevelCenter;
            }
        }
        return closestLevelCenter;
    }
}
