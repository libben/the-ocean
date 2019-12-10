using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OceanGame
{
    public class PlayerTopDownMovement : MonoBehaviour
    {
        [SerializeField]
        private float CurrentThrust = 6.0f;
        [SerializeField]
        private float MaxThrust = 10.0f;
        [SerializeField]
        private float Accelertion = 0.5f;
        [SerializeField]
        private float CurrentAccelTime = 0.0f;
        [SerializeField]
        private float RotationSpeed = 7.0f;
        [SerializeField]
        private float SecondToStop = 0.0f;
        [SerializeField]
        private Rigidbody2D PlayerBody;
        [SerializeField]
        private GameObject Light;
        private Vector3 LightOffset = new Vector3(0.0f, .25f, 0.0f);

        void Update()
        {
            // This code is from the Unity Documentation from transform.up with
            // some slight altertaions https://docs.unity3d.com/ScriptReference/Transform-up.html
            this.Light.transform.position = this.transform.position + this.LightOffset;
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                // Moves the gameobject in the direction you desire
                UpdateMoveSpeed();
                this.PlayerBody.AddForce(transform.up * this.CurrentThrust);
            }
            else
            {
                // Resets speed when stop moving altogether
                this.CurrentThrust = 6.0f;
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                //Rotate the sprite about the Z axis in the negative direction
                this.transform.Rotate(new Vector3(0, 0, -1 * this.RotationSpeed) * Time.deltaTime * this.CurrentThrust, Space.World);
            }

            
            if (Input.GetKey(KeyCode.E))
            {
                //Rotate the sprite about the Z axis in the negative direction
                this.transform.Rotate(new Vector3(0, 0, -1 * this.RotationSpeed) * Time.deltaTime * this.CurrentThrust, Space.World);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                //Rotate the sprite about the Z axis in the positive direction
                this.transform.Rotate(new Vector3(0, 0, this.RotationSpeed) * Time.deltaTime * this.CurrentThrust, Space.World);
            }
        }

        // Function to update the player's movement speed
        void UpdateMoveSpeed()
        {
            this.CurrentAccelTime += Time.deltaTime;
                
            if (this.CurrentAccelTime > 1.0f) 
            {
                if (this.CurrentThrust > this.MaxThrust)
                {
                    this.CurrentThrust = this.MaxThrust;
                }
                else
                {
                    this.CurrentThrust += this.Accelertion;
                }

                this.CurrentAccelTime = 0.0f;
            }
        }
    }
}
