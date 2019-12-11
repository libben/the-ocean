using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheOcean
{
    public class EelMovement : MonoBehaviour
    {
        [SerializeField]
        private GameObject Player;
        [SerializeField]
        private Vector3 PlayerSpawnPoint = new Vector3(-5.6f, -11.0f, 0.0f);
        [SerializeField]
        private float SpeedIncrease = 0.55f;
        [SerializeField]
        private float AggroRange = 30.0f;
        public GameObject EelCurrentSpawnPoint;
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
            
            if (distanceFromPlayer < this.AggroRange)
            {
                this.transform.position = Vector2.MoveTowards(this.transform.position, this.Player.transform.position, this.MoveSpeed * Time.deltaTime);
            }
        }

        // Function to check if the Player collides with the eel
        void OnTriggerEnter2D(Collider2D Collider)
        {
            if (Collider.name == "Player")
            {
                this.Player.transform.position = this.PlayerSpawnPoint;
                this.transform.position = this.EelCurrentSpawnPoint.transform.position;
            }
        }
    }
}
