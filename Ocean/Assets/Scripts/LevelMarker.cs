using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMarker : ScriptableObject
{
    [SerializeField]
    private int Index;
    
    public int GetIndex()
    {
        return Index;
    }
}
