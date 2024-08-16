using UnityEngine;
using System.Collections;

namespace JSukoAnimals
{
	public class ArchaeopteryxUserControllerScript : MonoBehaviour
	{
		public ArchaeopteryxCharacterScript archaeopteryxCharacter;

		void Start()
		{
			archaeopteryxCharacter = GetComponent<ArchaeopteryxCharacterScript>();
		}

		void Update()
		{
			if (Input.GetButtonDown("Jump"))
			{
				archaeopteryxCharacter.Soar();
			}

			if (Input.GetButtonDown("Fire1"))
			{
				archaeopteryxCharacter.Attack();
			}

			if (Input.GetKeyDown(KeyCode.H))
			{
				archaeopteryxCharacter.Hit();
			}

			if (Input.GetKeyDown(KeyCode.B))
			{
				archaeopteryxCharacter.Bite();
			}
		}

		void FixedUpdate()
		{
			archaeopteryxCharacter.forwardSpeed = Input.GetAxis("Vertical");
			archaeopteryxCharacter.turnSpeed = Input.GetAxis("Horizontal");
		}
	}
}