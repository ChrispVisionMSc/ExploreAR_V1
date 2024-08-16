using UnityEngine;
using System.Collections;

namespace JSukoAnimals
{
	public class ArchaeopteryxCharacterScript : MonoBehaviour
	{
		public Animator archaeopteryxAnimator;
		public float archaeopteryxSpeed = 1f;
		Rigidbody archaeopteryxRigid;
		public bool isFlying = false;
		public float groundCheckDistance = .3f;
		public float groundCheckOffset = .1f;
		public bool isGrounded = true;
		public float maxTurnSpeed = .005f;
		public float turnSpeed = 0f;
		public float maxForwardSpeed = 2f;
		public float forwardSpeed = 0f;

		void Start()
		{
			archaeopteryxAnimator = GetComponent<Animator>();
			archaeopteryxAnimator.speed = archaeopteryxSpeed;
			archaeopteryxRigid = GetComponent<Rigidbody>();
			if (isFlying)
			{
				archaeopteryxAnimator.SetTrigger("Soar");
				archaeopteryxAnimator.applyRootMotion = false;
				isFlying = true;
			}
		}

		void FixedUpdate()
		{
			Move();
			GroundedCheck();
		}

		public void SpeedSet(float animSpeed)
		{
			archaeopteryxAnimator.speed = animSpeed;
		}

		public void Landing()
		{
			if (isFlying)
			{
				archaeopteryxAnimator.SetTrigger("Landing");
				archaeopteryxAnimator.applyRootMotion = true;
				//archaeopteryxRigid.interpolation = RigidbodyInterpolation.Extrapolate;
				isFlying = false;
			}
		}

		public void Soar()
		{
			if (!isFlying)
			{
				archaeopteryxAnimator.SetTrigger("Soar");
				archaeopteryxAnimator.applyRootMotion = false;
				//archaeopteryxRigid.interpolation = RigidbodyInterpolation.None;
				isFlying = true;
			}
		}

		public void Attack()
		{
			archaeopteryxAnimator.SetTrigger("Attack");
		}

		public void Hit()
		{
			archaeopteryxAnimator.SetTrigger("Hit");
		}

		public void Bite()
		{
			archaeopteryxAnimator.SetTrigger("Bite");
		}

		void GroundedCheck()
		{
			RaycastHit hit;
			if (Physics.Raycast(transform.position + Vector3.up * groundCheckOffset, Vector3.down, out hit, groundCheckDistance))
			{
				if (forwardSpeed == 0f && turnSpeed == 0f)
				{
					Landing();
					isGrounded = true;
				}
			}
			else
			{
				isGrounded = false;
			}
		}

		public void Move()
		{
			archaeopteryxAnimator.SetFloat("Forward", forwardSpeed);
			archaeopteryxAnimator.SetFloat("Turn", turnSpeed);
			if (isFlying)
			{
				if (forwardSpeed > 0.1f)
				{
					archaeopteryxRigid.AddForce((transform.forward * maxForwardSpeed + transform.up * 4f) * forwardSpeed);
				}
				else if (forwardSpeed < 0.1f)
				{
					archaeopteryxRigid.AddForce((transform.forward * .5f + transform.up * 5f) * (-forwardSpeed));
				}
				else
				{
					archaeopteryxRigid.AddForce(transform.up * 7f);
				}

				archaeopteryxRigid.AddTorque(transform.up * turnSpeed * maxTurnSpeed);

			}
		}
	}
}