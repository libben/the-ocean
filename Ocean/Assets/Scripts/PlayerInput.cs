using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheOcean
{
	[DefaultExecutionOrder(-100)]
	public class PlayerInput : MonoBehaviour
	{
		[HideInInspector]
		public float Horizontal;
		[HideInInspector]
		public bool JumpHeld;
		[HideInInspector]
		public bool JumpPressed;
		[HideInInspector]
		public bool SwitchPressed;
		[HideInInspector]
		public bool GravityGunPressed;
		private bool ReadyToClear;

		[HideInInspector]
		public bool ResetPressed;

		void Update()
		{
			ClearInput();
			ProcessInputs();
			Horizontal = Mathf.Clamp(Horizontal, -1f, 1f);
		}

		void FixedUpdate()
		{
			ReadyToClear = true;
		}

		private void ClearInput()
		{
			if (!ReadyToClear)
				return;

			Horizontal = 0f;
			JumpPressed = false;
			JumpHeld = false;
			SwitchPressed = false;
			ReadyToClear = false;
			GravityGunPressed = false;
			ResetPressed = false;
		}

		private void ProcessInputs()
		{
			Horizontal += Input.GetAxis("Horizontal");
			JumpPressed = JumpPressed || Input.GetButtonDown("Jump");
			JumpHeld = JumpHeld || Input.GetButton("Jump");
			SwitchPressed = SwitchPressed || Input.GetButtonDown("SwitchWorlds");
			GravityGunPressed = GravityGunPressed || Input.GetButtonDown("GravityGun") || Input.GetButtonDown("Fire2");
			ResetPressed = ResetPressed || Input.GetButtonDown("Reset");
		}






	}



}
