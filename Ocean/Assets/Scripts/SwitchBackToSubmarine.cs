using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OceanGame
{
    public class SwitchBackToSubmarine : MonoBehaviour
    {
        [SerializeField]
        private GameObject EndOfLevel;

        void Start()
        {
        }

        void Update()
        {
            if (this.transform.position.x > this.EndOfLevel.transform.position.x)
            {
                SceneManager.LoadScene("OceanBase");
            }
        }
    }
}
