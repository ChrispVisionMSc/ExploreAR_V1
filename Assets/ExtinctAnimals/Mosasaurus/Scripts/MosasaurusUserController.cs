using UnityEngine;
using System.Collections;

namespace JSukoAnimals
{
	public class MosasaurusUserController : MonoBehaviour
	{
		MosasaurusCharacter mosasaurusCharacter;

		void Start()
		{
			mosasaurusCharacter = GetComponent<MosasaurusCharacter>();
		}

		void Update()
		{
			if (Input.GetButtonDown("Fire1"))
			{
				mosasaurusCharacter.Attack2();
			}

			if (Input.GetButtonDown("Fire2"))
			{
				mosasaurusCharacter.Attack3();
			}

			mosasaurusCharacter.turnSpeed = Input.GetAxis("Horizontal");
			mosasaurusCharacter.upDownSpeed = -Input.GetAxis("Vertical");
		}
	}
}