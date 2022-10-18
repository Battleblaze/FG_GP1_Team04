using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	[SerializeField] private Transform target;

	// Update is called once per frame
	void Update()
	{
		var targetPosition = target.position;

		var currentPosition = this.gameObject.transform.position;

		targetPosition.y = 0;

		currentPosition.y = 0;

		//this.gameObject.transform.forward = targetPosition;
	}
}
