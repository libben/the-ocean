using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheOcean
{
public class Level : MonoBehaviour
{
    private GameObject[] Children;
    private Vector3[] ChildPositions;
    private int[] ChildLayers;
    [SerializeField] private int Index;

    void Start()
    {
        var transforms = GetComponentsInChildren<Transform>();
        this.Children = new GameObject[transforms.Length];
        for (int i = 0; i < transforms.Length; i++)
        {
            Children[i] = transforms[i].gameObject;
        }
        this.ChildPositions = new Vector3[Children.Length];
        this.ChildLayers = new int[Children.Length];
        for (int i = 0; i < Children.Length; i++)
        {
            this.ChildPositions[i] = this.Children[i].transform.position;
            this.ChildLayers[i] = this.Children[i].gameObject.layer;
        }
    }
    public void ResetObjects()
    {
        for (int i = 0; i < Children.Length; i++)
        {
            if (this.Children[i] != null)
            {
                this.Children[i].layer = this.ChildLayers[i];
                this.Children[i].transform.position = this.ChildPositions[i];
            }
        }
    }

    public int GetIndex()
    {
        return Index;
    }
}
}