using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject Player;
    private GameObject[] LevelCenters;
    private Camera Camera;
    private const float SizeOfBlockInPixels = 16;
    [SerializeField] private float CameraViewboxWidthInPixels = 8*SizeOfBlockInPixels;

    [SerializeField] private float AspectRatio = 4/3;

    private GameObject currentClosestLevelCenter = null;
    [SerializeField] private float LerpDuration = 0.5f;
    private float TimeSpentLerping = 0f;
    private float TargetX;
    private float LerpOriginX;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        LevelCenters = GameObject.FindGameObjectsWithTag("LevelCenter");
        this.Camera = gameObject.GetComponent<Camera>();
        this.Camera.aspect = AspectRatio;
        this.Camera.orthographicSize = CameraViewboxWidthInPixels * 0.5f / AspectRatio;
        Refocus(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x != this.TargetX) {
            TimeSpentLerping += Time.deltaTime;
            var proportionDistanceTraveled = Mathf.Min(TimeSpentLerping/LerpDuration, 1f);
            print(proportionDistanceTraveled);
            var newX = Mathf.SmoothStep(LerpOriginX, this.TargetX, proportionDistanceTraveled);
            var curPosition = this.transform.position;
            curPosition.x = newX;
            this.transform.position = curPosition;
        }
        Refocus(true);
    }

    private GameObject FindClosestLevelCenter()
    {
        GameObject closestLevelCenter = null;
        float minDistance = float.PositiveInfinity;
        foreach (var levelCenter in LevelCenters)
        {
            float distanceFromPlayerToThisLevelCenter = Mathf.Abs(levelCenter.transform.position.x - Player.transform.position.x);
            if (distanceFromPlayerToThisLevelCenter < minDistance) {
                closestLevelCenter = levelCenter;
                minDistance = distanceFromPlayerToThisLevelCenter;
            }
        }
        return closestLevelCenter;
    }

    public void Refocus(bool animate)
    {
        var closestLevelCenter = FindClosestLevelCenter();
        if (closestLevelCenter != currentClosestLevelCenter) {
            currentClosestLevelCenter = closestLevelCenter;
            StartLerpingTowards(currentClosestLevelCenter);

            if (!animate)
            {
                var target = gameObject.transform.position;
                target.x = TargetX;
                this.gameObject.transform.position = target;
            }
        }

    }
    private void StartLerpingTowards(GameObject closestLevelCenter)
    {
        TargetX = closestLevelCenter.transform.position.x;
        LerpOriginX = gameObject.transform.position.x;
        TimeSpentLerping = 0f;
    }
}
