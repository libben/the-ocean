using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheOcean {
public class OpenHatchButtonController : AbstractButtonController
{
    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.tag == "Player" || other.tag == "Box")
        {
            GameObject.FindGameObjectWithTag("ScriptHome").GetComponent<DialogueController>().ShowHatchOpenDialogue();
        }
    }
}
}