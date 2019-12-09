using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Took the camera code from Hw1 and applied to move in all directions
public class TopDownCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject Target;
    [SerializeField]
    private float Speed = 2.0f;
    private Vector3 TargetPosition;
    private Vector3 CurrentPosition;
    private Vector3 NextPosition;

    void Start()
    {
        this.TargetPosition = this.transform.position;
    }

    void Update()
    {
        this.CurrentPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        this.NextPosition = new Vector3(this.Target.transform.position.x, this.Target.transform.position.y, this.transform.position.z);
    }

    void LateUpdate()
    {
        if (this.Target)
        {
            transform.position = Vector3.Lerp(this.CurrentPosition, this.NextPosition, this.Speed);
        }
    }
}
