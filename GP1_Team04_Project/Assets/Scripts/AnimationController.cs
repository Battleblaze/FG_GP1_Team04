using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
	[SerializeField] private Animator characterAnimator;
	[SerializeField] private Animator boardAnimator;
	[SerializeField] private Playermovement movementScript;

	// Start is called before the first frame update
	void Start()
	{
		// this.animator.speed = 1.2f;
	}

	// Update is called once per frame
	void Update()
	{
		float normalizedTime = this.characterAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;

		if (this.movementScript.getVelocity < 0f)
		{
			if (normalizedTime != 0.253f)
			{
				return;
			}
			this.Speed(0);
			this.Play("Normal", 0.253f); // The 19th frame
			return;
		}

		if (this.movementScript.getVelocity > 0f)
		{
			if (normalizedTime != 0.0f)
			{
				return;
			}
			this.Speed(0);
			this.Play("Normal", 0.0f); // The first frame
			return;
		}

		this.Speed(1);
	}

	void Speed(float speed)
	{
		this.characterAnimator.speed = speed;
		this.boardAnimator.speed = speed;
	}

	void Play(string name, float normalizedTime)
	{
		this.characterAnimator.Play(name, 0, normalizedTime);
		this.boardAnimator.Play(name, 0, normalizedTime);
	}
}
