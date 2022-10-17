using System;
using System.Collections;
using System.Collections.Generic;
using FG.Managers;
using Unity.VisualScripting;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public int lanePosition;//A int that saves the lane the player is currently in 0is left lane 1 is middle and 2 is right
    [SerializeField] private GameObject hallway;

    private Rotate _rotate;
    [SerializeField]private float horizontalspeed;

    private GameManager _gameManager;

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

        if (Input.GetKey(KeyCode.LeftArrow) && _gameManager.pasuedgame == false && gameObject.transform.position.z > -3)
        {
            transform.Translate( horizontalspeed * Time.deltaTime * -gameObject.transform.right);
        }

        if (Input.GetKey(KeyCode.RightArrow)&& _gameManager.pasuedgame == false && gameObject.transform.position.z < 3)
        {
            transform.Translate( horizontalspeed * Time.deltaTime * gameObject.transform.right);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_gameManager.pasuedgame == true)
            {
                _gameManager.pasuedgame = false;
            }
            else
            {
                _gameManager.pasuedgame = true;
            }
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
