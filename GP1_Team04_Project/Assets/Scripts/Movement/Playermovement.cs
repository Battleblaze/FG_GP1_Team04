using System;
using System.Collections;
using System.Collections.Generic;
using FG.Managers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playermovement : MonoBehaviour
{
	[SerializeField] private GameObject hallway;

	private Rotate _rotate;
	[SerializeField] private float horizontalspeed = 10.0f;

	[SerializeField] private float acceleration = 2.0f;
	[SerializeField] private float maxWidth;

	[SerializeField] private float decelerationModifier = 2.0f;

	[SerializeField] private float deadZone = 0.15f;

	private GameManager _gameManager;
	private bool left = false;
	private bool right = false;

	private float velocity = 0.0f;

	public float getVelocity
	{
		get { return this.velocity; }
	}


	private void Awake()
	{
		_rotate = hallway.GetComponent<Rotate>();
		_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	// Update is called once per frame
	void Update()
	{
		if (this.left)
		{
			this.velocity -= this.acceleration * Time.deltaTime;
		}
		else if (this.right)
		{
			this.velocity += this.acceleration * Time.deltaTime;
		}
		else // If no button is pressed decelerate
		{
			this.Decelerate();
		}

		if (this.velocity >= this.horizontalspeed) // Cap the speed to horizontal speed
		{
			this.velocity = this.horizontalspeed;
		}
		else if (this.velocity <= -this.horizontalspeed)
		{
			this.velocity = -this.horizontalspeed;
		}

		transform.Translate(this.velocity * Time.deltaTime * Vector3.forward, Space.World); // is forward because the map uses +x as forward while unity uses +z

		this.CheckWall();
	}

	void Decelerate()
	{
		if (this.velocity < 0)
		{
			this.velocity += this.acceleration * Time.deltaTime * this.decelerationModifier;
		}
		else if (this.velocity > 0)
		{
			this.velocity -= this.acceleration * Time.deltaTime * this.decelerationModifier;
		}

		if (this.velocity > -this.deadZone && this.velocity < this.deadZone)
		{
			this.velocity = 0;
		}
	}

	public void Move(InputAction.CallbackContext context)
	{
		var vec = context.ReadValue<Vector2>();
		if (vec.x > 0) // if right 
		{
			this.right = context.performed;
		}
		else if (vec.x == 0) // stop moving when neither direction
		{
			this.right = false;
			this.left = false;
		}
		else // else its left
		{
			this.left = context.performed;
		}
	}

	void CheckWall()
	{
		if (transform.position.z > this.maxWidth)
		{
			var old = transform.position;
			old.z = this.maxWidth;
			transform.position = old;
		}
		else if (transform.position.z < -this.maxWidth)
		{
			var old = transform.position;
			old.z = -this.maxWidth;
			transform.position = old;
		}
	}
}
