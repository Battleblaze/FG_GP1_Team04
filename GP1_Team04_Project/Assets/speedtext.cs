using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FG.Managers;

public class speedtext : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _text;

    // Update is called once per frame
    void Update()
    {
		this._text.text = GameObject.Find("GameManager").GetComponent<Speedmanager>().speed.ToString();
	}
}
