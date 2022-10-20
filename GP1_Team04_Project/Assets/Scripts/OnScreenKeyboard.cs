using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using TMPro;

public class OnScreenKeyboard : MonoBehaviour
{
	[SerializeField] private Button firstSelected;

	[SerializeField] private TMP_InputField inputField;

	[SerializeField] private PlayerInput player;

	[SerializeField] private Button nextSelected;

	private InputAction action;

	// Start is called before the first frame update
	void OnEnable()
	{
		this.firstSelected.Select();
		this.action = this.player.actions["Cancel"];

		action.performed += context => {
			this.nextSelected.Select();
			this.gameObject.SetActive(false);
		};
}

	// Update is called once per frame
	void OnDisable()
	{

	}

	public void Click(string letter)
	{
		this.inputField.text += letter;
		this.inputField.stringPosition++;
	}
}
