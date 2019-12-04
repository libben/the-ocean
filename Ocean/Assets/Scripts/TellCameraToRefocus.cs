using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheOcean
{
public class TellCameraToRefocus : Command
{
    override public void Execute(Object collider)
    {
        GameObject.FindGameObjectWithTag("MainCamera").BroadcastMessage("Refocus");
    }
}
}