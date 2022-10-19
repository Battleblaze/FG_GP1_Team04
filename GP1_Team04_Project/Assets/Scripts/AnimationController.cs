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
		if (this.movementScript.getVelocity < -0.15f)
		{
			this.animator.CrossFade("Right", 0.6f);
			return;
		}

		if (this.movementScript.getVelocity > 0.15f)
		{
			Debug.Log("abiw");
			this.animator.CrossFade("Left", 0.6f);
			return;
		}

		this.animator.CrossFade("Normal", 0.6f);
	}
}
