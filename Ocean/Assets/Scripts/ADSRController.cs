using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OceanGame
{
	public enum Phase { Attack, Decay, Sustain, Release, None };

	public class ADSRController
	{
		private float AttackDuration = 0.5f;
		private AnimationCurve Attack;

		private float DecayDuration = 0.0f;
		private AnimationCurve Decay;

		private float SustainDuration = 120.0f;
		private AnimationCurve Sustain;

		private float ReleaseDuration = 0.5f;
		private AnimationCurve Release;

		private GameObject Player;
		private PlayerController Controller;

		private float AttackTimer;
		private float DecayTimer;
		private float SustainTimer;
		private float ReleaseTimer;

		private float InputDirection = 0.0f;


		public Phase CurrentPhase;

		public ADSRController(AnimationCurve a, AnimationCurve d, AnimationCurve s, AnimationCurve r, GameObject player)
		{
			Player = player;
			Attack = a;
			Decay = d;
			Sustain = s;
			Release = r;
			CurrentPhase = Phase.None;
		}

		public float ADSREnvelope(float xInput)
		{
			float result = xInput;
			// If horizontal keys are pressed and player is stopped OR player let go, restart phases
			if (CurrentPhase == Phase.None || CurrentPhase == Phase.Release)
			{
				if (Mathf.Abs(xInput) > 0)
				{
					ResetTimers();
					CurrentPhase = Phase.Attack;
				}
				else
				{
					// Release
					result *= this.Release.Evaluate(this.ReleaseTimer / this.ReleaseDuration);
					this.ReleaseTimer += Time.deltaTime;
					if (this.ReleaseTimer > this.ReleaseDuration)
					{
						this.CurrentPhase = Phase.None;
					}
				}
			}

			if (Phase.Attack == this.CurrentPhase)
			{
				result *= this.Attack.Evaluate(this.AttackTimer / this.AttackDuration);
				this.AttackTimer += Time.deltaTime;
				if (this.AttackTimer > this.AttackDuration)
				{
					this.CurrentPhase = Phase.Sustain;
				}
			}
			/*
			else if (Phase.Decay == this.CurrentPhase)
			{
				result *= this.Decay.Evaluate(this.DecayTimer / this.DecayDuration);
				this.DecayTimer += Time.deltaTime;
				if (this.DecayTimer > this.DecayDuration)
				{
					this.CurrentPhase = Phase.Sustain;
				}
			}
			*/
			else if (Phase.Sustain == this.CurrentPhase)
			{
				if (Mathf.Abs(xInput) > 0)
				{
					result *= this.Sustain.Evaluate(this.SustainTimer / this.SustainDuration);
					this.SustainTimer += Time.deltaTime;
				}
				else
				{
					this.CurrentPhase = Phase.Release;
				}
			}

			return result;
		}

		private void ResetTimers()
		{
			Debug.Log("Resetting ADSR timers");
			this.AttackTimer = 0.0f;
			this.DecayTimer = 0.0f;
			this.SustainTimer = 0.0f;
			this.ReleaseTimer = 0.0f;
		}

	}
}
