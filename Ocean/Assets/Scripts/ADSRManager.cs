using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OceanGame
{
	public class ADSRManager
	{
		[SerializeField]
		private float AttackDuration = 0.25f;
		[SerializeField]
		private AnimationCurve Attack;

		[SerializeField]
		private float DecayDuration = 0.0f;
		[SerializeField]
		private AnimationCurve Decay;

		[SerializeField]
		private float SustainDuration = 120.0f;
		[SerializeField]
		private AnimationCurve Sustain;

		[SerializeField]
		private float ReleaseDuration = 0.25f;
		[SerializeField]
		private AnimationCurve Release;

		private GameObject Player;
		private PlayerController Controller;

		private float AttackTimer;
		private float DecayTimer;
		private float SustainTimer;
		private float ReleaseTimer;

		private float InputDirection = 0.0f;

		private enum Phase { Attack, Decay, Sustain, Release, None };

		private Phase CurrentPhase;

		public ADSRManager(AnimationCurve a, AnimationCurve d, AnimationCurve s, AnimationCurve r, GameObject player)
		{
			Player = player;
			Attack = a;
			Decay = d;
			Sustain = s;
			Release = r;
		}

		void Update()
		{
			/*
			if (Input.GetButtonDown(RightInputButton))
			{
				this.ResetTimers();
				this.CurrentPhase = Phase.Attack;
				this.InputDirection = 1.0f;
			}

			if (Input.GetButton(RightInputButton))
			{
				this.InputDirection = 1.0f;
			}

			if (Input.GetButtonUp(RightInputButton))
			{
				this.InputDirection = 1.0f;
				this.CurrentPhase = Phase.Release;
			}

			if (Input.GetButtonDown(LeftInputButton))
			{
				this.ResetTimers();
				this.CurrentPhase = Phase.Attack;
				this.InputDirection = -1.0f;
			}

			if (Input.GetButton(LeftInputButton))
			{
				this.InputDirection = -1.0f;
			}

			if (Input.GetButtonUp(LeftInputButton))
			{
				this.InputDirection = -1.0f;
				this.CurrentPhase = Phase.Release;
			}

			if (this.CurrentPhase != Phase.None)
			{
				var position = this.gameObject.transform.position;
				position.x += this.InputDirection * this.Speed * this.ADSREnvelope() * Time.deltaTime;
				this.gameObject.transform.position = position;
			}
			*/
		}

		float ADSREnvelope(float xInput)
		{
			float velocity = 0.0f;

			if (Phase.Attack == this.CurrentPhase)
			{
				velocity = this.Attack.Evaluate(this.AttackTimer / this.AttackDuration) * xInput;
				this.AttackTimer += Time.deltaTime;
				if (this.AttackTimer > this.AttackDuration)
				{
					this.CurrentPhase = Phase.Decay;
				}
			}
			else if (Phase.Decay == this.CurrentPhase)
			{
				velocity = this.Decay.Evaluate(this.DecayTimer / this.DecayDuration);
				this.DecayTimer += Time.deltaTime;
				if (this.DecayTimer > this.DecayDuration)
				{
					this.CurrentPhase = Phase.Sustain;
				}
			}
			else if (Phase.Sustain == this.CurrentPhase)
			{
				velocity = this.Sustain.Evaluate(this.SustainTimer / this.SustainDuration);
				this.SustainTimer += Time.deltaTime;
				if (this.SustainTimer > this.SustainDuration)
				{
					this.CurrentPhase = Phase.Release;
				}
			}
			else if (Phase.Release == this.CurrentPhase)
			{
				velocity = this.Release.Evaluate(this.ReleaseTimer / this.ReleaseDuration);
				this.ReleaseTimer += Time.deltaTime;
				if (this.ReleaseTimer > this.ReleaseDuration)
				{
					this.CurrentPhase = Phase.None;
				}
			}
			return velocity;
		}

		private void ResetTimers()
		{
			this.AttackTimer = 0.0f;
			this.DecayTimer = 0.0f;
			this.SustainTimer = 0.0f;
			this.ReleaseTimer = 0.0f;
		}

	}
}

