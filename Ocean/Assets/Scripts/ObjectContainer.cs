using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheOcean
{
public class ObjectContainer : MonoBehaviour
{
    private Transform[] Children;
    private Vector3[] ChildPositions;

    void Start()
    {
        this.Children = GetComponentsInChildren<Transform>();
        this.ChildPositions = new Vector3[Children.Length];
        for (int i = 0; i < Children.Length; i++)
        {
            this.ChildPositions[i] = this.Children[i].position;
        }
    }
    public void ResetObjects()
    {
        for (int i = 0; i < Children.Length; i++)
        {
            this.Children[i].position = this.ChildPositions[i];
        }
    }
}
}