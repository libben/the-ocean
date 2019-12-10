using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheOcean
{
public class CameraController : MonoBehaviour
{
    private Camera Camera;
    private const float SizeOfBlockInPixels = 16;
    [SerializeField] private float CameraViewboxWidthInPixels = 8*SizeOfBlockInPixels;

    [SerializeField] private float AspectRatio = 4/3;
    [SerializeField] private float LerpDuration = 0.5f;
    private float TimeSpentLerping = 0f;
    private float TargetX;
    private float LerpOriginX;

    // Start is called before the first frame update
    void Awake()
    {
        this.Camera = gameObject.GetComponent<Camera>();
        this.Camera.aspect = AspectRatio;
        this.Camera.orthographicSize = CameraViewboxWidthInPixels * 0.5f / AspectRatio;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x != this.TargetX) {
            TimeSpentLerping += Time.deltaTime;
            var proportionDistanceTraveled = Mathf.Min(TimeSpentLerping/LerpDuration, 1f);
            var newX = Mathf.SmoothStep(LerpOriginX, this.TargetX, proportionDistanceTraveled);
            var curPosition = this.transform.position;
            curPosition.x = newX;
            this.transform.position = curPosition;
        }
    }

    public void InitializeLevel(GameObject levelCenter)
    {
        Refocus(false, levelCenter);
    }

    public void NotifyNewLevel(GameObject levelCenter)
    {
        Refocus(true, levelCenter);
    }

    private void Refocus(bool animate, GameObject levelCenter)
    {
        float destinationXValue = levelCenter.transform.position.x;
        print($"Cam moving to {destinationXValue}");
        if (TargetX != destinationXValue) {
            StartLerpingTowards(destinationXValue);

            if (!animate)
            {
                var target = gameObject.transform.position;
                target.x = destinationXValue;
                this.gameObject.transform.position = target;
            }
        }

    }
    private void StartLerpingTowards(float XPosition)
    {
        TargetX = XPosition;
        LerpOriginX = gameObject.transform.position.x;
        TimeSpentLerping = 0f;
    }
}
}