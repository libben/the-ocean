using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheOcean
{
    public class PlayerTopDownMovement : MonoBehaviour
    {
        [SerializeField]
        private float BeginningThrust = 6.0f;
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
        [SerializeField]
        private GameObject Background;
        [SerializeField]
        private GameObject BackgroundAltered;
        [SerializeField]
        private float MaxTimeCanSpendInFireLevel = 4.0f;
        private float TimeSpentInFireSea = 0.0f;
        private Vector3 LightOffset = new Vector3(0.0f, .25f, 0.0f);
        private float SwitchCoolDown = 0.5f;
        private float CurrentCoolDownTime;
        private bool HasUsedSwitch = false;

        void Update()
        {
            // This code is from the Unity Documentation from transform.up with
            // some slight altertaions https://docs.unity3d.com/ScriptReference/Transform-up.html
            this.Light.transform.position = this.transform.position + this.LightOffset;
            canChangeRealities();
            canForceChange();

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                // Moves the gameobject in the direction you desire
                UpdateMoveSpeed();
                this.PlayerBody.AddForce(-1.0f * transform.right * this.CurrentThrust);
            }
            else
            {
                // Resets speed when stop moving altogether
                this.CurrentThrust = this.BeginningThrust;
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                //Rotate the sprite about the Z axis in the negative direction
                this.transform.Rotate(new Vector3(0, 0, -1 * this.RotationSpeed) * Time.deltaTime * this.CurrentThrust, Space.World);
                this.Light.transform.Rotate(new Vector3(0, 0, -1 * this.RotationSpeed) * Time.deltaTime * this.CurrentThrust, Space.World);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                //Rotate the sprite about the Z axis in the positive direction
                this.transform.Rotate(new Vector3(0, 0, this.RotationSpeed) * Time.deltaTime * this.CurrentThrust, Space.World);
                this.Light.transform.Rotate(new Vector3(0, 0, this.RotationSpeed) * Time.deltaTime * this.CurrentThrust, Space.World);
            }
            
            // Allows player to change realities 
            // There is a cooldown to prevent spamming
            if (Input.GetKey(KeyCode.Z))
            {
                if (this.HasUsedSwitch == false){
                   ChangeRealities();
                }
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

        // Function to switch realities
        void ChangeRealities()
        {
            this.HasUsedSwitch = true;

            if (this.Background.active) {
                this.Background.SetActive(false);
                this.BackgroundAltered.SetActive(true);
            }
            else
            {
                this.BackgroundAltered.SetActive(false);
                this.Background.SetActive(true);
            }
        }

        // Function to only allow swithching realities if the cooldown is done
        void canChangeRealities()
        {
            if (this.HasUsedSwitch == true)
            {
                this.CurrentCoolDownTime += Time.deltaTime;
                
                if (this.CurrentCoolDownTime > this.SwitchCoolDown)
                {
                    this.CurrentCoolDownTime = 0.0f;
                    this.HasUsedSwitch = false;
                }
            }
        }

        // Function to force the player out of the fire sea
        // It's too hot for him to stay there so the max amount of time he can stay there is 4 unity units
        void canForceChange()
        {
            bool isInFireSea = this.BackgroundAltered.active;
            
            if (isInFireSea)
            {
                this.TimeSpentInFireSea += Time.deltaTime;

                if (this.TimeSpentInFireSea > this.MaxTimeCanSpendInFireLevel)
                {
                    this.TimeSpentInFireSea = 0.0f;
                    this.BackgroundAltered.SetActive(false);
                    this.Background.SetActive(true);
                }
            }
        }

        // Function to get the thrust of the Player
        public float getPlayerThrust()
        {
            return this.CurrentThrust;
        }
    }
}
