using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OceanGame
{
    public class EelMovement : MonoBehaviour
    {
        [SerializeField]
        private GameObject Player;
        [SerializeField]
        private float SpeedIncrease = 0.55f;
        [SerializeField]
        private float AggroRange = 30.0f;
        private Rigidbody2D EelBody;
        private PlayerTopDownMovement PlayerMovement;
        private float MoveSpeed;

        void Start()
        {
            this.EelBody = this.GetComponent<Rigidbody2D>();
            this.PlayerMovement = this.Player.GetComponent<PlayerTopDownMovement>();
        }

        void Update()
        {
            float newSpeed = this.PlayerMovement.getPlayerThrust();
            this.MoveSpeed = newSpeed * this.SpeedIncrease;
            float distanceFromPlayer = Vector3.Distance(this.Player.transform.position, this.transform.position);
            
            Debug.Log(distanceFromPlayer);
            if (distanceFromPlayer < this.AggroRange)
            {
                this.transform.position = Vector2.MoveTowards(this.transform.position, this.Player.transform.position, this.MoveSpeed * Time.deltaTime);
            }
        }
    }
}
