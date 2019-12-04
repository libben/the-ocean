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
        private Vector2 Movement;
        private Vector2 MousePosition;

        void Update()
        {
            // This code is from the Unity Documentation from transform.up with
            // some slight altertaions https://docs.unity3d.com/ScriptReference/Transform-up.html
            
            if (Input.GetKey(KeyCode.UpArrow))
            {
                // Moves the gameobject in the direction you desire
                transform.position += transform.up * this.MoveSpeed * Time.deltaTime;
            }

/*            if (Input.GetKey(KeyCode.DownArrow))
            {
                //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
                this.PlayerBody.velocity = -transform.forward * this.MoveSpeed;
            }*/

            if (Input.GetKey(KeyCode.RightArrow))
            {
                //Rotate the sprite about the Z axis in the negative direction
                this.transform.Rotate(new Vector3(0, 0, -1 * this.RotationSpeed) * Time.deltaTime * this.MoveSpeed, Space.World);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //Rotate the sprite about the Z axis in the positive direction
                this.transform.Rotate(new Vector3(0, 0, this.RotationSpeed) * Time.deltaTime * this.MoveSpeed, Space.World);
            }
        }
    }
}
