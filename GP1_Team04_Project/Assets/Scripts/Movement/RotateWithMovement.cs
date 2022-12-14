using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMovement : MonoBehaviour
{
	[SerializeField] private float yRotationDivider = 2.0f;
	[SerializeField] private float xRotationDivider = 2.0f;

	[SerializeField] private Playermovement movementScript;

	void Update()
	{
		this.gameObject.transform.rotation = Quaternion.Euler(this.movementScript.getVelocity / this.xRotationDivider, this.movementScript.getVelocity / this.yRotationDivider, 0.0f);
	}
}
