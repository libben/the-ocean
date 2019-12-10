using UnityEngine;
using System.Collections;

public class SceneCounter : MonoBehaviour
{
    public static int counter = 0;

    void Start()
    {
        counter += 1;
        Debug.Log(counter);
    }
}