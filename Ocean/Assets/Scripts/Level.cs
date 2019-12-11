using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheOcean
{
public class Level : MonoBehaviour
{
    private Transform[] Children;
    private Vector3[] ChildPositions;
    private int[] ChildLayers;
    [SerializeField] private int Index;

    void Start()
    {
        this.Children = GetComponentsInChildren<Transform>();
        this.ChildPositions = new Vector3[Children.Length];
        this.ChildLayers = new int[Children.Length];
        for (int i = 0; i < Children.Length; i++)
        {
            this.ChildPositions[i] = this.Children[i].position;
            this.ChildLayers[i] = this.Children[i].gameObject.layer;
        }
    }
    public void ResetObjects()
    {
        for (int i = 0; i < Children.Length; i++)
        {
            this.Children[i].position = this.ChildPositions[i];
            this.Children[i].gameObject.layer = this.ChildLayers[i];
        }
    }

    public int GetIndex()
    {
        return Index;
    }
}
}