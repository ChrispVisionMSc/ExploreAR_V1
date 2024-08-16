using UnityEngine;
using System.Collections;

namespace JSukoAnimals
{
	public class AmmoniteUserController : MonoBehaviour
	{
		AmmoniteCharacter ammoniteCharacter;

		void Start()
		{
			ammoniteCharacter = GetComponent<AmmoniteCharacter>();
		}

		void Update()
		{
			if (Input.GetButtonDown("Fire1"))
			{
				ammoniteCharacter.Attack();
			}
			if (Input.GetKeyDown(KeyCode.H))
			{
				ammoniteCharacter.Hit();
			}
			if (Input.GetKeyDown(KeyCode.P))
			{
				ammoniteCharacter.Predation();
			}
			if (Input.GetKeyDown(KeyCode.K))
			{
				ammoniteCharacter.Death();
			}
			if (Input.GetKeyDown(KeyCode.R))
			{
				ammoniteCharacter.Rebirth();
			}

		}

		private void FixedUpdate()
		{
			float h = Input.GetAxis("Horizontal");
			float v = Input.GetAxis("Vertical");
			ammoniteCharacter.forwardAcceleration = v;
			ammoniteCharacter.turnAcceleration = h;

			if (Input.GetKeyDown(KeyCode.N))
			{
				ammoniteCharacter.upDownAcceleration = -1f;
			}
			if (Input.GetKeyDown(KeyCode.U))
			{
				ammoniteCharacter.upDownAcceleration = 1f;
			}
			if (Input.GetKeyUp(KeyCode.N))
			{
				ammoniteCharacter.upDownAcceleration = 0f;
			}
			if (Input.GetKeyUp(KeyCode.U))
			{
				ammoniteCharacter.upDownAcceleration = 0f;
			}
		}
	}
}