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
    [SerializeField]private float horizontalspeed;

    private GameManager _gameManager;
    private bool left = false;
    private bool right = false;

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
            transform.Translate( horizontalspeed * Time.deltaTime * -gameObject.transform.right);
        } else if (this.right)
        {
            transform.Translate( horizontalspeed * Time.deltaTime * gameObject.transform.right);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_gameManager.pausedgame == true)
            {
                _gameManager.pausedgame = false;
            }
            else
            {
                _gameManager.pausedgame = true;
            }
        }

    }

    public void Move(InputAction.CallbackContext context)
    {
        var vec = context.ReadValue<Vector2>();
        Debug.Log("aaaa");
        if (vec.x > 0 ) // if right 
        {
            this.right = context.performed;
        } else if (vec.x == 0)
        {
            this.right = false;
            this.left = false;
        } else // else its left
        {
            this.left = context.performed;
        } 
    }

    public void putPlayerInLane0()
    {
        gameObject.transform.position = new Vector3(0,-3, -3);
        lanePosition = 0;
    }
    public void putPlayerInLane2()
    {
        gameObject.transform.position = new Vector3(0,-3, 3);
        lanePosition = 2;
    }
    
}
