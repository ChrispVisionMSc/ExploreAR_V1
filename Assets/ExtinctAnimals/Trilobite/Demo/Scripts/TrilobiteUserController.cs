using UnityEngine;
using System.Collections;
namespace JSukoAnimals
{
    public class TrilobiteUserController : MonoBehaviour
    {
        TrilobiteCharacter trilobiteCharacter;

        void Start()
        {
            trilobiteCharacter = GetComponent<TrilobiteCharacter>();
        }

        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                trilobiteCharacter.Attack();
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                trilobiteCharacter.Hit();
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                trilobiteCharacter.SwimStart();
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                trilobiteCharacter.SwimEnd();
            }


            if (Input.GetKeyDown(KeyCode.F))
            {
                trilobiteCharacter.DefenseStart();
            }
            if (Input.GetKeyUp(KeyCode.F))
            {
                trilobiteCharacter.DefenseEnd();
            }


            trilobiteCharacter.forwardSpeed = Input.GetAxis("Vertical");
            trilobiteCharacter.turnSpeed = Input.GetAxis("Horizontal");
        }
    }
}
