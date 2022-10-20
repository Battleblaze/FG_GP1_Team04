using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SliderSelectionScript : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField] private Animator targetAnimator;

	void ISelectHandler.OnSelect(BaseEventData eventData)
	{
		this.targetAnimator.Play("Highlighted");
		// this.targetAnimator.ResetTrigger("Normal");
	}

	void IDeselectHandler.OnDeselect(BaseEventData eventData)
	{
		this.targetAnimator.Play("Normal");
		// this.targetAnimator.RePlay("Highlighted");
	}

	void IPointerEnterHandler.OnPointerEnter(PointerEventData pointerEventData)
	{
		this.targetAnimator.Play("Highlighted");
		// this.targetAnimator.RePlay("Normal");
	}

	void IPointerExitHandler.OnPointerExit(PointerEventData pointerEventData)
	{
		this.targetAnimator.Play("Normal");
		// this.targetAnimator.ResetTrigger("Highlighted");
	}
}