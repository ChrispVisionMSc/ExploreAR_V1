using UnityEngine;
using System.Collections;

namespace JSukoAnimals
{
	public class AnomalocarisUserControllerScript : MonoBehaviour
	{
		public AnomalocarisCharacterScript anomalocarisCharacter;
		public float upDownChangeSpeed = 3f;

		void Start()
		{
			anomalocarisCharacter = GetComponent<AnomalocarisCharacterScript>();
		}

		void Update()
		{

			if (Input.GetKeyDown(KeyCode.H))
			{
				anomalocarisCharacter.Hit();
			}

			if (Input.GetButtonDown("Fire1"))
			{
				anomalocarisCharacter.Attack();
			}

			if (Input.GetKeyDown(KeyCode.Z))
			{
				anomalocarisCharacter.Shrink();
			}

			if (Input.GetKey(KeyCode.N))
			{
				anomalocarisCharacter.upDownSpeed = Mathf.Clamp(anomalocarisCharacter.upDownSpeed - Time.deltaTime * upDownChangeSpeed, -1f, 1f);
			}
			if (Input.GetKey(KeyCode.U))
			{
				anomalocarisCharacter.upDownSpeed = Mathf.Clamp(anomalocarisCharacter.upDownSpeed + Time.deltaTime * upDownChangeSpeed, -1f, 1f);
			}

		}

		void FixedUpdate()
		{
			float v = Input.GetAxis("Vertical");
			float h = Input.GetAxis("Horizontal");
			anomalocarisCharacter.turnSpeed = h;
			anomalocarisCharacter.forwardSpeed = v;

			anomalocarisCharacter.upDownSpeed = Mathf.Lerp(anomalocarisCharacter.upDownSpeed, 0f, Time.deltaTime);

		}
	}
}