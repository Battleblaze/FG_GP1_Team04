using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButtonSelection : MonoBehaviour
{
	[SerializeField]private GameObject firstSelected;
	private EventSystem eventSystem;

	private void OnEnable()
	{
		this.eventSystem = EventSystem.current;

		this.eventSystem.SetSelectedGameObject(this.firstSelected);
	}
}
