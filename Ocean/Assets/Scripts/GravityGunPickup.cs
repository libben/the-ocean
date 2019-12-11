using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheOcean {
public class GravityGunPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        print("Collided");
        if (other.tag == "Player")
        {
            EnableGravityGunOn(other.gameObject.GetComponent<PlayerController>());
            GameObject.FindGameObjectWithTag("ScriptHome").GetComponent<DialogueController>().ShowGravityGunInstructions();
            Destroy(gameObject);
        }
    }

    private void EnableGravityGunOn(PlayerController playCon)
    {
        playCon.EnableGravityGun();
    }

}
}