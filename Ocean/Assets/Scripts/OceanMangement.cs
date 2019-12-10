using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OceanGame
{
    public class OceanMangement : MonoBehaviour
    {
        [SerializeField]
        private GameObject HatchOneOpened;
        [SerializeField]
        private GameObject HatchOneClosed;
        [SerializeField]
        private GameObject HatchOneOpenedAltered;
        [SerializeField]
        private GameObject HatchOneClosedAltered;
        [SerializeField]
        private GameObject HatchTwoOpened;
        [SerializeField]
        private GameObject HatchTwoClosed;
        [SerializeField]
        private GameObject HatchTwoOpenedAltered;
        [SerializeField]
        private GameObject HatchTwoClosedAltered;
        [SerializeField]
        private GameObject HatchThreeOpened;
        [SerializeField]
        private GameObject HatchThreeClosed;
        [SerializeField]
        private GameObject HatchThreeOpenedAltered;
        [SerializeField]
        private GameObject HatchThreeClosedAltered;
        [SerializeField]
        private GameObject SpawnPointOne;
        [SerializeField]
        private GameObject SpawnPointTwo;
        [SerializeField]
        private GameObject SpawnPointThree;
        [SerializeField]
        private GameObject Eel;
        [SerializeField]
        private GameObject BackgroundAltered;

        void Start()
        {
            int currentSceneCounter = SceneCounter.counter;

            if (currentSceneCounter == 3)
            {
                // Opens up the hatch 2 and closes hatch 1.
                // Spawns Eel in spawn location 2
                var eelScript = this.Eel.GetComponent<EelMovement>();
                eelScript.EelCurrentSpawnPoint.transform.position = this.SpawnPointTwo.transform.position;
                this.HatchOneOpened.SetActive(false);
                this.HatchOneOpenedAltered.SetActive(false);
                this.HatchOneClosed.SetActive(true);
                this.HatchOneClosedAltered.SetActive(true);

                this.HatchTwoOpened.SetActive(true);
                this.HatchTwoOpenedAltered.SetActive(true);
                this.HatchTwoClosed.SetActive(false);
                this.HatchTwoClosedAltered.SetActive(false);
                var spawnLocation = SpawnPointTwo.transform.position;
                this.Eel.transform.position = new Vector3(spawnLocation.x, spawnLocation.y, 0.0f);
            } else if (currentSceneCounter == 5)
            {
                // Opens up the hatch 3 and closes hatch 2.
                // Spawns Eel in spawn location 3
                var eelScript = this.Eel.GetComponent<EelMovement>();
                eelScript.EelCurrentSpawnPoint.transform.position = this.SpawnPointThree.transform.position;
                this.HatchTwoOpened.SetActive(false);
                this.HatchTwoOpenedAltered.SetActive(false);
                this.HatchTwoClosed.SetActive(true);
                this.HatchTwoClosedAltered.SetActive(true);

                this.HatchThreeOpened.SetActive(true);
                this.HatchThreeOpenedAltered.SetActive(true);
                this.HatchThreeClosed.SetActive(false);
                this.HatchThreeClosedAltered.SetActive(false);
                var spawnLocation = SpawnPointThree.transform.position;
                this.Eel.transform.position = new Vector3(spawnLocation.x, spawnLocation.y, 0.0f);
            }
        }
        
        void Update()
        {
            canThirdHatchOpen();
        }

        // Function to check if the third hatch can be open or not 
        void canThirdHatchOpen()
        {
            bool isInFireWorld = this.BackgroundAltered.active;
            float distanceFromHatch = Vector3.Distance(this.Eel.transform.position, this.HatchThreeClosedAltered.transform.position);
            
            if (isInFireWorld == true && distanceFromHatch < 8.0f)
            {
                this.HatchThreeClosedAltered.SetActive(false);
                this.HatchThreeOpenedAltered.SetActive(true);
                var eelScript = this.Eel.GetComponent<EelMovement>();
                eelScript.enabled = false;
            }
        }
        
    }
}
