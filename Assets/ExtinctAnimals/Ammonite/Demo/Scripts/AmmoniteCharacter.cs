using UnityEngine;
using System.Collections;

namespace JSukoAnimals
{
	public class AmmoniteCharacter : MonoBehaviour
	{
		Animator ammoniteAnimator;
		Rigidbody ammoniteRigid;

		public float maxForwardSpeed = 30f;
		public float maxTurnSpeed = 10f;
		public float maxUpDownSpeed = 5f;

		public float forwardSpeed = 0f;
		public float turnSpeed = 0f;
		public float upDownSpeed = 0f;

		public float forwardAcceleration = 0f;
		public float turnAcceleration = 0f;
		public float upDownAcceleration = 0f;

		public bool isLived = true;

		void Start()
		{
			ammoniteRigid = GetComponent<Rigidbody>();
			ammoniteAnimator = GetComponent<Animator>();
		}

		public void Attack()
		{
			ammoniteAnimator.SetTrigger("Attack");
		}

		public void Hit()
		{
			ammoniteAnimator.SetTrigger("Hit");
		}

		public void Predation()
		{
			ammoniteAnimator.SetTrigger("Predation");
		}

		public void Death()
		{
			ammoniteAnimator.SetBool("IsLived", false);
			ammoniteAnimator.SetTrigger("Death");
			isLived = false;
		}

		public void Rebirth()
		{
			ammoniteAnimator.SetBool("IsLived", true);
			isLived = true;
		}

		void FixedUpdate()
		{
			if (isLived)
			{
				Move();
			}
		}

		public void Move()
		{
			ammoniteAnimator.SetFloat("Forward", forwardSpeed);
			ammoniteAnimator.SetFloat("Turn", turnSpeed);
			forwardSpeed = Mathf.Clamp(forwardSpeed + forwardAcceleration * Time.deltaTime, -.1f, maxForwardSpeed);
			turnSpeed = Mathf.Clamp(turnSpeed + turnAcceleration * Time.deltaTime, -maxTurnSpeed, maxTurnSpeed);
			if (forwardAcceleration == 0f)
			{
				forwardSpeed = Mathf.Lerp(forwardSpeed, 0, Time.deltaTime * 3f);
			}

			if (turnAcceleration == 0f)
			{
				turnSpeed = Mathf.Lerp(turnSpeed, 0, Time.deltaTime * 3f);
			}
			ammoniteAnimator.SetFloat("UpDown", upDownSpeed);

			if (upDownAcceleration == 0f)
			{
				upDownSpeed = Mathf.Lerp(upDownSpeed, 0, Time.deltaTime * 3f);
			}
			upDownSpeed = Mathf.Clamp(upDownSpeed + upDownAcceleration * Time.deltaTime, -maxUpDownSpeed, maxUpDownSpeed);
			transform.RotateAround(transform.position, transform.up, Time.deltaTime * turnSpeed * 100f);
			ammoniteRigid.velocity = transform.up * upDownSpeed - transform.forward * forwardSpeed;

		}
	}
}