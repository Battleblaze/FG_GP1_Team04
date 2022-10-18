using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // [SerializeField] public GameObject target;
    // private GameObject player;
    // private bool canRotateLeft = false;
    // private bool canRotateRight = false;

    // private Playermovement _playermovement;

    // private void Awake()
    // {
    //     player = GameObject.Find("Player");
    //     _playermovement = player.GetComponent<Playermovement>();
    // }

    // Update is called once per frame
    
    // void Update()
    // {
        //Debug.Log(_playermovement.lanePosition); // !Do not use until changed to new input system
        // if (Input.GetKeyDown(KeyCode.LeftArrow))
        // {
        //     rotateLeft();
        // }

        // if (Input.GetKeyDown(KeyCode.RightArrow))
        // {
        //     rotateRight();
        // }

        // if (_playermovement.lanePosition == 0)
        // {
        //     canRotateLeft = true;
        // }
        // else
        // {
        //    canRotateLeft = false;
        // }
        // if (_playermovement.lanePosition == 2)
        // {
        //     canRotateRight = true;
        // }
        // else
        // {
        //     canRotateRight = false;
        // }

    // }

    // public void rotateRight()
    // {
    //     if (canRotateRight)
    //     {
    //         gameObject.transform.RotateAround(target.transform.position, Vector3.right, 90);
    //         _playermovement.putPlayerInLane0();
    //     }
    // }

    // public void rotateLeft()
    // {
    //     if (canRotateLeft)
    //     {
    //         gameObject.transform.RotateAround(target.transform.position, Vector3.left, 90);
    //         _playermovement.putPlayerInLane2();
    //     }
        
    // }
}

