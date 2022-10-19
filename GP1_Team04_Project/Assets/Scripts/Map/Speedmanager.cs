using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FG.Managers;

public class Speedmanager : MonoBehaviour
{
	public float speed = 10f;

	[SerializeField] private float speedmodder = 0.003f;

	// Update is called once per frame
	void Update()
	{

		if (GameObject.Find("GameManager").GetComponent<GameManager>().pausedgame)
		{
			return;
		}

		speed += Time.fixedDeltaTime * speedmodder;
	}
}
