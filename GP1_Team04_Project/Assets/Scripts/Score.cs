using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public int score;
    [SerializeField]
    private float _scoreAmount = 100f;
    
    [SerializeField]
    [Tooltip("Optional text mesh pro text")]
    private TextMeshProUGUI _text;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = "Score: " + score;
    }
}
