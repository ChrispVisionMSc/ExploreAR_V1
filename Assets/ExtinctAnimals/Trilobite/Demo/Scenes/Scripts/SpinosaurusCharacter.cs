using UnityEngine;
using System.Collections;

namespace JSukoAnimals
{
    public class SpinosaurusCharacter : MonoBehaviour
    {
        Animator spinosaurusAnimator;


        void Start()
        {
            spinosaurusAnimator = GetComponent<Animator>();
        }


        public void Attack()
        {
            spinosaurusAnimator.SetTrigger("Attack");
        }

        public void Hit()
        {
            spinosaurusAnimator.SetTrigger("Hit");
        }


        public void Death()
        {
            spinosaurusAnimator.SetBool("IsLived", false);
        }

        public void Rebirth()
        {
            spinosaurusAnimator.SetBool("IsLived", true);
        }

        public void SwimStart()
        {
            spinosaurusAnimator.SetBool("IsSwimming", true);
        }

        public void SwimEnd()
        {
            spinosaurusAnimator.SetBool("IsSwimming", false);
        }


        public void Move(float v, float h)
        {
            spinosaurusAnimator.SetFloat("Forward", v);
            spinosaurusAnimator.SetFloat("Turn", h);
        }
    }
}