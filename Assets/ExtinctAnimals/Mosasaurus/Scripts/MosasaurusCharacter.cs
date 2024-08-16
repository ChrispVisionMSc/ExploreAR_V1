using UnityEngine;
using System.Collections;

namespace JSukoAnimals
{
	public class MosasaurusCharacter : MonoBehaviour
	{
		public Animator mosasaurusAnimator;
		Rigidbody mosasaurusRigid;
		public float maxTurnSpeed = 30000f;
		public float maxForwardSpeed = 30000f;
		public float turnSpeed;
		public float upDownSpeed;
		public float forwardSpeed;

		void Start()
		{
			mosasaurusAnimator = GetComponent<Animator>();
			mosasaurusRigid = GetComponent<Rigidbody>();
		}

		void FixedUpdate()
		{
			Move();
		}

		public void Move()
		{
			mosasaurusAnimator.SetFloat("UpDown", upDownSpeed);
			mosasaurusAnimator.SetFloat("Turn", turnSpeed);
			mosasaurusAnimator.SetFloat("Forward", forwardSpeed);

			mosasaurusRigid.AddTorque(transform.up * maxTurnSpeed * turnSpeed);
			mosasaurusRigid.AddTorque(transform.right * maxTurnSpeed * (-upDownSpeed));
			mosasaurusRigid.AddForce(transform.forward * maxForwardSpeed * forwardSpeed);
		}

		public void SpeedChange(float speed)
		{
			forwardSpeed = speed;
		}

		public void Attack1()
		{
			mosasaurusAnimator.SetTrigger("Attack1");
		}

		public void Attack2()
		{
			mosasaurusAnimator.SetTrigger("Attack2");
		}

		public void Attack3()
		{
			mosasaurusAnimator.SetTrigger("Attack3");
		}
	}
}