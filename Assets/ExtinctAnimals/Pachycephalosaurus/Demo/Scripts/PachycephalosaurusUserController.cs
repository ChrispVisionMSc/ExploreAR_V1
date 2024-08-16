using UnityEngine;
using System.Collections;

namespace JSukoAnimals
{
    public class PachycephalosaurusUserController : MonoBehaviour
    {
        PachycephalosaurusCharacter pachycephalosaurusCharacter;

        void Start()
        {
            pachycephalosaurusCharacter = GetComponent<PachycephalosaurusCharacter>();
        }

        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                pachycephalosaurusCharacter.Attack();
            }
            if (Input.GetButtonDown("Jump"))
            {
                pachycephalosaurusCharacter.Jump();
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                pachycephalosaurusCharacter.Hit();
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                pachycephalosaurusCharacter.Death();
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                pachycephalosaurusCharacter.Rebirth();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                pachycephalosaurusCharacter.EatStart();
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                pachycephalosaurusCharacter.EatEnd();
            }



            if (Input.GetKeyDown(KeyCode.N))
            {
                pachycephalosaurusCharacter.Sleep();
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                pachycephalosaurusCharacter.WakeUp();
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                pachycephalosaurusCharacter.Gallop();
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                pachycephalosaurusCharacter.Walk();
            }

            pachycephalosaurusCharacter.forwardSpeed = pachycephalosaurusCharacter.maxWalkSpeed * Input.GetAxis("Vertical");
            pachycephalosaurusCharacter.turnSpeed = Input.GetAxis("Horizontal");
        }
    }
}