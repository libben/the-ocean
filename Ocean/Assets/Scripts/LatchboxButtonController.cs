using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheOcean {
public class LatchboxButtonController : AbstractButtonController
{
    [SerializeField]
    private GameObject LinkedObject;
    private LatchboxController LinkedController;

    // Start is called before the first frame update
    void Start()
    {	
        if (!LinkedObject.TryGetComponent<LatchboxController>(out LinkedController))
			Debug.Log("Error: Button couldn't find associated latchbox's controller.");
    }

        public override void OnTriggerEnter2D(Collider2D other)
		{
            base.OnTriggerEnter2D(other);
			if (other.tag == "Player" || other.tag == "Box")
			{
				LinkedController.OpenLatchbox();
			}
		}

		public override void OnTriggerStay2D(Collider2D other)		
		{
            base.OnTriggerStay2D(other);
			if (other.tag == "Player" || other.tag == "Box")
			{
				LinkedController.OpenLatchbox();
			}
		}

		public override void OnTriggerExit2D(Collider2D other)
		{
			base.OnTriggerExit2D(other);
			LinkedController.CloseLatchbox();
		}
}
}