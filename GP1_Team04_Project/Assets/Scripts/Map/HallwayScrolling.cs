using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayScrolling : MonoBehaviour
{
    private Speedmanager _speedmanager;
    
    // Start is called before the first frame update
    void Start()
    {
        _speedmanager = GameObject.Find("GameManager").GetComponent<Speedmanager>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate( _speedmanager.speed * Time.deltaTime * Vector3.right);
    }
    
}
