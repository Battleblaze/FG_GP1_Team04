using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMovement : MonoBehaviour
{
	[SerializeField] private float yRotationDivider = 2.0f;
	[SerializeField] private float xRotationDivider = 2.0f;

	[SerializeField] private Playermovement movementScript;

	[SerializeField] private float deadZone = 0.15f;

	void Update()
	{
		if (this.movementScript.getVelocity > -this.deadZone && this.movementScript.getVelocity < this.deadZone)
		{
			return;
		}

		this.gameObject.transform.rotation = Quaternion.Euler(this.movementScript.getVelocity / this.xRotationDivider, this.movementScript.getVelocity / this.yRotationDivider, 0.0f);
	}
}
