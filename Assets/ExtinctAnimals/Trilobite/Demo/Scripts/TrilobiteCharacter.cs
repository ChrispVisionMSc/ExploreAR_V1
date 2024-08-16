using UnityEngine;
using System.Collections;
namespace JSukoAnimals
{
    public class TrilobiteCharacter : MonoBehaviour
    {
        Animator trilobiteAnimator;
        Rigidbody trilobiteRigid;
        public float forwardSpeed;
        public float turnSpeed;

        public bool isSwimming = false;

        void Start()
        {
            trilobiteAnimator = GetComponent<Animator>();
            trilobiteRigid = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            Move();
        }

        public void Attack()
        {
            trilobiteAnimator.SetTrigger("Attack");
        }

        public void Hit()
        {
            trilobiteAnimator.SetTrigger("Hit");
        }


        public void DefenseStart()
        {
            trilobiteAnimator.SetBool("IsDefense", true);

        }
        public void DefenseEnd()
        {
            trilobiteAnimator.SetBool("IsDefense", false);
        }

        public void SwimStart()
        {
            trilobiteAnimator.SetBool("IsSwimming", true);
            trilobiteRigid.useGravity = false;
            trilobiteAnimator.applyRootMotion = false;
            trilobiteRigid.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            isSwimming = true;

        }

        public void SwimEnd()
        {
            trilobiteAnimator.SetBool("IsSwimming", false);
            trilobiteRigid.useGravity = true;
            trilobiteAnimator.applyRootMotion = true;
            trilobiteRigid.constraints = RigidbodyConstraints.FreezeRotation;
            isSwimming = false;
        }


        public void Move()
        {
            trilobiteAnimator.SetFloat("Forward", forwardSpeed);
            trilobiteAnimator.SetFloat("Turn", turnSpeed);

            if (isSwimming)
            {
                trilobiteAnimator.SetFloat("Up", forwardSpeed);
                trilobiteRigid.AddForce(transform.up * forwardSpeed * .2f + transform.forward * .58f);
                trilobiteRigid.AddTorque(transform.up * turnSpeed * .01f);
            }
        }
    }
}