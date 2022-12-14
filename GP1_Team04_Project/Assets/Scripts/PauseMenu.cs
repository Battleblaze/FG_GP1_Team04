using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FG.Managers;
using TMPro;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] private GameManager _gameManager;
	[SerializeField] private TextMeshProUGUI _score;

	void OnEnable()
	{
		this._gameManager.pausedgame = true;
		this._score.text = FG.GameVariables.Score.ToString();
		AudioManager.instance.PauseAudio();


		Cursor.lockState = CursorLockMode.None;
	}

	void OnDisable()
	{
		this._gameManager.pausedgame = false;
		AudioManager.instance.UnPauseAudio();

		Cursor.lockState = CursorLockMode.Locked;
	}
}
