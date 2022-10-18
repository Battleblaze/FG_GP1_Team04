using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreText : MonoBehaviour
{
    private string _userName = "Placeholder";
    private int _score = -1;

    [SerializeField] private TMP_Text nameRef;
    [SerializeField] private TMP_Text scoreRef;

    public string userName
    {
        get { return this._userName; }
        set
        {
            this._userName = value;
            this.nameRef.text = value;
        }
    }

    public int score
    {
        get { return this._score; }
        set
        {
            this._score = value;
            this.scoreRef.text = value.ToString();
        }
    }

    void Awake() // Set the text to the placeholder text
    {
        this.score = this._score;
        this.userName = this._userName;
    }
}
