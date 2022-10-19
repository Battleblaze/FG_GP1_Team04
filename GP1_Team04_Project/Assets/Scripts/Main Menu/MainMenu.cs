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
		Debug.Log(PlayerPrefs.GetInt("Highscore").ToString());

		this.highscore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
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


