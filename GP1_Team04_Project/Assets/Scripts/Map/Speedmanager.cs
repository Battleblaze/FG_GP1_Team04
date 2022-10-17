using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedmanager : MonoBehaviour
{
    public float speed;

    [SerializeField] private float speedmodder;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        speed += Time.fixedDeltaTime * speedmodder;
    }
}
