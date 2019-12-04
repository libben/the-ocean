using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OceanGame
{
    public class PlayerTopDownMovement : MonoBehaviour
    {
        private float MoveSpeed = 5.0f;
        private Rigidbody2D PlayerBody;
        private Vector2 Movement;

        void Update()
        {
            Movement.x = Input.GetAxisRaw("Horizontal");
            Movement.y = Input.GetAxisRaw("Vertical");
        }

        void FixedUpdate()
        {
            PlayerBody.MovePosition(this.PlayerBody.position + this.Movement * this.MoveSpeed * Time.fixedDeltaTime);
        }
    }
}