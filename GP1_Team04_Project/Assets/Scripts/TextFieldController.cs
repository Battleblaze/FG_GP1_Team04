using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using TMPro;

public class TextFieldController : MonoBehaviour, ISelectHandler, IDeselectHandler
{
	[SerializeField] private GameObject onScreenKeyboard;
	[SerializeField] private PlayerInput player;

	void ISelectHandler.OnSelect(BaseEventData eventData)
	{
		StartCoroutine(DisableTextField()); // Cant select twice in the same frame
	}

	IEnumerator DisableTextField()
	{
		yield return new WaitForSeconds(0);
		Debug.Log(this.player.currentControlScheme);
		if (this.player.currentControlScheme == "Gamepad")
		{
			// this.gameObject.GetComponent<TMP_InputField>().OnPointerClick(null);
			EventSystem.current.SetSelectedGameObject(null);
			this.onScreenKeyboard.SetActive(true);
		}
	}

	void IDeselectHandler.OnDeselect(BaseEventData eventData)
	{

	}

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
