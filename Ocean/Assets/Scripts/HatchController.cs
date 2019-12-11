using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OceanGame
{
    public class HatchController : MonoBehaviour
    {
        [SerializeField]
        private Collider2D PlayerCollider;
        [SerializeField]
        private GameObject Hatch;

        void OnTriggerEnter2D(Collider2D Player)
        {
            if (Player.name == "Player")
            {
                if (this.Hatch.name == "Hatch 1 Open")
                {
                    SceneManager.LoadScene("Arc 1");
                }
                else if (this.Hatch.name == "Hatch 2 Open")
                {
                    SceneManager.LoadScene("Arc 2");
                }
                else if (this.Hatch.name == "Hatch 3 Open")
                {
                    SceneManager.LoadScene("PostgameScroll");
                }
            }
        }
    }
}
