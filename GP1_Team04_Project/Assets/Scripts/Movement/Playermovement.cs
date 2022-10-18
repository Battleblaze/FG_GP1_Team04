using System;
using System.Collections;
using System.Collections.Generic;
using FG.Managers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playermovement : MonoBehaviour
{
	public int lanePosition;//A int that saves the lane the player is currently in 0is left lane 1 is middle and 2 is right
	[SerializeField] private GameObject hallway;

	private Rotate _rotate;
	[SerializeField] private float horizontalspeed;

	[SerializeField] private float acceleration;
	[SerializeField] private float maxWidth;

	private GameManager _gameManager;
	private bool left = false;
	private bool right = false;

	private float velocity = 0.0f;


	private void Awake()
	{
		_rotate = hallway.GetComponent<Rotate>();
		_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	// Start is called before the first frame update
	void Start()
	{
		lanePosition = 1;
		horizontalspeed = 10f;
	}

	// Update is called once per frame
	void Update()
	{

		if (this.left)
		{
			transform.Translate(horizontalspeed * Time.deltaTime * -gameObject.transform.forward); // is forward because the map uses +x as forward while unity uses +z
		}
		else if (this.right)
		{
			transform.Translate(horizontalspeed * Time.deltaTime * gameObject.transform.forward); // is forward because the map uses +x as forward while unity uses +z
		}

		this.CheckWall();
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
			// this.acceleration = 0.0f;
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

	public void putPlayerInLane0()
	{
		gameObject.transform.position = new Vector3(0, -3, -3);
		lanePosition = 0;
	}
	public void putPlayerInLane2()
	{
		gameObject.transform.position = new Vector3(0, -3, 3);
		lanePosition = 2;
	}

}
