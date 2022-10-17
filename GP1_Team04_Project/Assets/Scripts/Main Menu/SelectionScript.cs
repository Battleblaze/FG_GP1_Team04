using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectionScript : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Button targetButton;
	
	void ISelectHandler.OnSelect(BaseEventData eventData) 
	{
		this.targetButton.Select();
	}

	void IDeselectHandler.OnDeselect(BaseEventData eventData) 
	{
		this.targetButton.OnDeselect(eventData);
	}

	void IPointerEnterHandler.OnPointerEnter(PointerEventData pointerEventData)
	{
		this.targetButton.Select();
	}

	void IPointerExitHandler.OnPointerExit(PointerEventData pointerEventData)
	{
		EventSystem.current.SetSelectedGameObject(null);
	}
}
