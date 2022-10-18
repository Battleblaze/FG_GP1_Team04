using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	[SerializeField] private Transform target;

	[SerializeField] private float division = 2f;

	// Update is called once per frame
	void Update()
	{
		float offset;
		if (target != null)
		{
			offset = target.position.z;
		}
		else
		{
			offset = 0f;
		}


		transform.rotation = Quaternion.Euler(0.0f, -90f + offset / this.division, 0.0f);
	}
}
