using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    private int _score;

    public int score {
        get { return _score; }
        set 
        {
            this._score = value;

            FG.GameVariables.Score = value;
        }
    }

    [SerializeField]
    private float _scoreAmount = 100f;
    
    [SerializeField]
    [Tooltip("Optional text mesh pro text")]
    private TextMeshProUGUI _text;
    
    // Start is called before the first frame update
    void Start()
    {
        this.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this._text.text = "Score: " + this.score;
    }
}
