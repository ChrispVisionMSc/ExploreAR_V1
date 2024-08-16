using UnityEngine;
using System.Collections;

namespace JSukoAnimals
{
    public class SpinosaurusUserControoller : MonoBehaviour
    {
        SpinosaurusCharacter spinosaurusCharacter;

        void Start()
        {
            spinosaurusCharacter = GetComponent<SpinosaurusCharacter>();
        }

        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                spinosaurusCharacter.Attack();
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                spinosaurusCharacter.Hit();
            }


            if (Input.GetKeyDown(KeyCode.K))
            {
                spinosaurusCharacter.Death();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                spinosaurusCharacter.Rebirth();
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                spinosaurusCharacter.SwimStart();
            }
            if (Input.GetKeyUp(KeyCode.M))
            {
                spinosaurusCharacter.SwimEnd();
            }


        }

        private void FixedUpdate()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            if (Input.GetKey(KeyCode.LeftShift)) v *= 2f;
            spinosaurusCharacter.Move(v, h);
        }
    }
}