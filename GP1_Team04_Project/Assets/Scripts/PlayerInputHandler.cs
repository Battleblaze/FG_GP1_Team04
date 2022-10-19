using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using FG.Managers;

public class PlayerInputHandler : MonoBehaviour
{
	[SerializeField] private GameObject pauseMenu;

	public void A(InputAction.CallbackContext context)
	{
			this.pauseMenu.SetActive(true);
	}

	public void B(InputAction.CallbackContext context)
	{

	}
}
