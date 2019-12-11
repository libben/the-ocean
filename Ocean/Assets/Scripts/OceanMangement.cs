using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheOcean
{
    public class OceanMangement : MonoBehaviour
    {
        [SerializeField]
        private GameObject HatchOne;
        [SerializeField]
        private GameObject HatchTwo;
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
        private GameObject Player;
        [SerializeField]
        private GameObject BackgroundAltered;
        [SerializeField]
        private float DistanceFromHatchToTriggerDialogue = 8.0f;
        private DialogueController MDialogueController;
        private bool ThirdHatchHasBeenSightedInSceneFive = false;

        void Awake()
        {
            MDialogueController = gameObject.GetComponent<DialogueController>();
            if (Player == null)
                Player = GameObject.FindGameObjectWithTag("Player");
        }
        void Start()
        {
            int currentSceneCounter = SceneCounter.counter;

            if (currentSceneCounter == 3)
            {
                // Opens up the hatch 2 and closes hatch 1.
                // Spawns Eel in spawn location 2
                this.Player.transform.position = this.HatchOne.transform.position;
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
                this.Player.transform.position = this.HatchTwo.transform.position;
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
                MDialogueController.ShowUnderwaterDialogue();
            }
            MDialogueController.ShowUnderwaterDialogue();
        }
        
        void Update()
        {
            canThirdHatchOpen();
        }

        void FixedUpdate()
        {
            if (!ThirdHatchHasBeenSightedInSceneFive &&
                SceneCounter.counter == 5 &&
                Vector3.Distance(Player.transform.position, this.HatchThreeClosed.transform.position) < DistanceFromHatchToTriggerDialogue)
            {
                ThirdHatchHasBeenSightedInSceneFive = true;
                MDialogueController.ShowHatchSightedDialogue();
            }
        }

        // Function to check if the third hatch can be open or not 
        void canThirdHatchOpen()
        {
            bool isInFireWorld = this.BackgroundAltered.active;
            float distanceFromHatch = Vector3.Distance(this.Eel.transform.position, this.HatchThreeClosedAltered.transform.position);
            
            if (Input.GetKey(KeyCode.Z) && distanceFromHatch < 8.0f)
            {
                this.HatchThreeClosedAltered.SetActive(false);
                this.HatchThreeOpenedAltered.SetActive(true);
                var eelScript = this.Eel.GetComponent<EelMovement>();
                eelScript.enabled = false;
                this.Eel.SetActive(false);
            }
        }
        
    }
}
