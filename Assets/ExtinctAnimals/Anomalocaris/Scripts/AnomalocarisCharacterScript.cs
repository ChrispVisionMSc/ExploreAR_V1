using UnityEngine;
using System.Collections;

namespace JSukoAnimals
{
	public class AnomalocarisCharacterScript : MonoBehaviour
	{
		public Animator anomalocarisAnimator;
		public float anomalocarisSpeed = 1f;
		public float forwardSpeed = 0f;
		public float turnSpeed = 0f;
		public float upDownSpeed = 0f;
		public float maxTurnSpeed = .001f;
		public float maxForwardSpeed = .1f;

		void Start()
		{
			anomalocarisAnimator = GetComponent<Animator>();
			anomalocarisAnimator.speed = anomalocarisSpeed;
		}

		void FixedUpdate()
		{
			Move();
		}

		public void Hit()
		{
			anomalocarisAnimator.SetTrigger("Hit");
		}

		public void Attack()
		{
			anomalocarisAnimator.SetTrigger("Attack");
		}

		public void Shrink()
		{
			anomalocarisAnimator.SetTrigger("Shrink");
		}

		public void Move()
		{
			anomalocarisAnimator.SetFloat("Forward", forwardSpeed);
			anomalocarisAnimator.SetFloat("Turn", turnSpeed);
			anomalocarisAnimator.SetFloat("UpDown", upDownSpeed);

			transform.Translate((transform.forward * forwardSpeed + transform.up * upDownSpeed) * maxForwardSpeed * Time.deltaTime, Space.World);
			transform.RotateAround(transform.position, transform.up, maxTurnSpeed * turnSpeed * Time.deltaTime * Mathf.Sign(forwardSpeed));
		}
	}
}