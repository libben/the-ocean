using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Took the camera code from Hw1 and applied to move in all directions
public class TopDownCamera : MonoBehaviour
{
    public GameObject Target;
    public float Speed = 0.75f;
    private Vector3 TargetPosition;

    void Start()
    {
        this.TargetPosition = this.transform.position;
    }

    void LateUpdate()
    {
        if (this.Target)
        {
            var from = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            var to = new Vector3(this.Target.transform.position.x, this.Target.transform.position.y, this.transform.position.z);
            transform.position = Vector3.Lerp(from, to, this.Speed);
        }
    }
}
