using UnityEngine;
using System.Collections;

namespace JSukoAnimals
{
    public class PachycephalosaurusCharacter : MonoBehaviour
    {
        Animator pachycephalosaurusAnimator;
        public bool jumpStart = false;
        public float groundCheckDistance = 0.1f;
        public float groundCheckOffset = 0.01f;
        public bool isGrounded = true;
        public float jumpSpeed = 2000f;
        Rigidbody pachycephalosaurusRigid;
        public float forwardSpeed;
        public float turnSpeed;
        public float walkMode = 0.5f;
        public float jumpStartTime = 0f;
        public float maxWalkSpeed = 1f;

        void Start()
        {
            pachycephalosaurusAnimator = GetComponent<Animator>();
            pachycephalosaurusRigid = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            CheckGroundStatus();
            Move();
            jumpStartTime += Time.deltaTime;
            maxWalkSpeed = Mathf.Lerp(maxWalkSpeed, walkMode, Time.deltaTime);
        }

        public void Attack()
        {
            pachycephalosaurusAnimator.SetTrigger("Attack");
        }

        public void Hit()
        {
            pachycephalosaurusAnimator.SetTrigger("Hit");
        }

        public void Death()
        {
            pachycephalosaurusAnimator.SetBool("IsLived", false);
        }

        public void Rebirth()
        {
            pachycephalosaurusAnimator.SetBool("IsLived", true);
        }

        public void Sleep()
        {
            pachycephalosaurusAnimator.SetBool("IsSleeping", true);
        }

        public void WakeUp()
        {
            pachycephalosaurusAnimator.SetBool("IsSleeping", false);
        }

        public void EatStart()
        {
            pachycephalosaurusAnimator.SetBool("IsEating", true);
        }
        public void EatEnd()
        {
            pachycephalosaurusAnimator.SetBool("IsEating", false);
        }



        public void Gallop()
        {
            walkMode = 1f;
        }



        public void Walk()
        {
            walkMode = .5f;
        }

        public void Jump()
        {
            if (isGrounded)
            {
                pachycephalosaurusAnimator.SetTrigger("Jump");
                jumpStart = true;
                jumpStartTime = 0f;
                isGrounded = false;
                pachycephalosaurusAnimator.SetBool("IsGrounded", false);
            }
        }

        void CheckGroundStatus()
        {
            RaycastHit hitInfo;
            isGrounded = Physics.Raycast(transform.position + (transform.up * groundCheckOffset), Vector3.down, out hitInfo, groundCheckDistance);

            if (jumpStart)
            {
                if (jumpStartTime > .25f)
                {
                    jumpStart = false;
                    pachycephalosaurusRigid.angularDrag = 1f;
                    pachycephalosaurusRigid.AddForce((transform.up + transform.forward * forwardSpeed) * jumpSpeed, ForceMode.Impulse);
                    pachycephalosaurusAnimator.applyRootMotion = false;
                    //pachycephalosaurusRigid.interpolation = RigidbodyInterpolation.None;
                    pachycephalosaurusAnimator.SetBool("IsGrounded", false);
                }
            }

            if (isGrounded && !jumpStart && jumpStartTime > .5f)
            {
                pachycephalosaurusAnimator.applyRootMotion = true;
                //pachycephalosaurusRigid.interpolation = RigidbodyInterpolation.Extrapolate;
                pachycephalosaurusRigid.angularDrag = 0f;
                pachycephalosaurusRigid.angularVelocity = new Vector3(0f, 0f, 0f);
                pachycephalosaurusAnimator.SetBool("IsGrounded", true);
            }
            else
            {
                if (!jumpStart)
                {
                    pachycephalosaurusAnimator.applyRootMotion = false;
                    //pachycephalosaurusRigid.interpolation = RigidbodyInterpolation.None;
                    pachycephalosaurusAnimator.SetBool("IsGrounded", false);
                }
            }
        }

        public void Move()
        {
            pachycephalosaurusAnimator.SetFloat("Forward", forwardSpeed);
            pachycephalosaurusAnimator.SetFloat("Turn", turnSpeed);
        }
    }
}