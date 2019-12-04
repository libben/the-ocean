using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OceanGame
{
    public class PlayerTopDownMovement : MonoBehaviour
    {
        [SerializeField]
        private float MoveSpeed = 5.0f;
        [SerializeField]
        private float RotationSpeed = 30.0f;
        [SerializeField]
        private Rigidbody2D PlayerBody;
        [SerializeField]
        private GameObject Light;
        private Vector2 Movement;
        private Vector2 MousePosition;
        private Vector3 LightOffset = new Vector3(0.0f, .25f, 0.0f);

        void Update()
        {
            // This code is from the Unity Documentation from transform.up with
            // some slight altertaions https://docs.unity3d.com/ScriptReference/Transform-up.html
            
            if (Input.GetKey(KeyCode.W))
            {
                // Moves the gameobject in the direction you desire
                this.transform.position += this.transform.up * this.MoveSpeed * Time.deltaTime;
                this.Light.transform.position = this.transform.position + this.LightOffset;
            }

/*            if (Input.GetKey(KeyCode.DownArrow))
            {
                //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
                this.PlayerBody.velocity = -transform.forward * this.MoveSpeed;
            }*/

            if (Input.GetKey(KeyCode.D))
            {
                //Rotate the sprite about the Z axis in the negative direction
                this.transform.Rotate(new Vector3(0, 0, -1 * this.RotationSpeed) * Time.deltaTime * this.MoveSpeed, Space.World);
            }

            if (Input.GetKey(KeyCode.A))
            {
                //Rotate the sprite about the Z axis in the positive direction
                this.transform.Rotate(new Vector3(0, 0, this.RotationSpeed) * Time.deltaTime * this.MoveSpeed, Space.World);
            }
        }
    }
}
