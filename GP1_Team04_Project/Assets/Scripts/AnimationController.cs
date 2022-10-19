using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
	[SerializeField] private Animator animator;
	[SerializeField] private Playermovement movementScript;

	// Start is called before the first frame update
	void Start()
	{
		// this.animator.speed = 1.2f;
	}

	// Update is called once per frame
	void Update()
	{
		float normalizedTime = this.animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

		if (this.movementScript.getVelocity < 0f)
		{
			if (normalizedTime != 0.253f)
			{
				return;
			}
			this.animator.speed = 0.0f;
			this.animator.Play("Normal", 0, 0.253f); // The 19th frame
			return;
		}

		if (this.movementScript.getVelocity > 0f)
		{
			if (normalizedTime != 0.0f)
			{
				return;
			}
			this.animator.speed = 0.0f;
			this.animator.Play("Normal", 0, 0.0f); // the first frame
			return;
		}
		this.animator.speed = 1.0f;
		this.animator.Play("Normal");
	}
}
