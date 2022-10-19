using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI highscore;

	void OnEnable()
	{
		this.highscore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();

		Cursor.lockState = CursorLockMode.None;
	}

	public void PlayGame()
	{
		SceneManager.LoadScene(1);
	}

	public void QuitGame()
	{
		Application.Quit();
		Debug.Log("Quitting");
	}
}


