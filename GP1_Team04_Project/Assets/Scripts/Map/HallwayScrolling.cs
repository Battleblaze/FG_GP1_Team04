using System;
using System.Collections;
using System.Collections.Generic;
using FG;
using FG.Managers;
using UnityEngine;

public class HallwayScrolling : MonoBehaviour
{
    private Speedmanager _speedmanager;
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _speedmanager = GameObject.Find("GameManager").GetComponent<Speedmanager>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( _gameManager.pausedgame == false)
        {
            gameObject.transform.Translate( _speedmanager.speed * Time.deltaTime * Vector3.right);
        }
    }
    
}
