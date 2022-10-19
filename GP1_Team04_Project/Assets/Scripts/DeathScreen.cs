using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI scoreText;

	[SerializeField] private TMP_InputField inputField;
	[SerializeField] private GameObject submitButton;

	private void OnEnable()
	{
		this.scoreText.text = FG.GameVariables.Score.ToString();

		Cursor.lockState = CursorLockMode.None;
	}

	private void OnDisable()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void Submit()
	{


		StartCoroutine(Upload(this.inputField.text, FG.GameVariables.Score));
	}

	IEnumerator Upload(string name, int score)
	{
		var highscore = new Highscore();
		highscore.name = name;
		highscore.score = score;
		highscore.version = Application.version;


		string json = JsonUtility.ToJson(highscore);

		using (UnityWebRequest req = new UnityWebRequest("http://129.151.223.57/highscore", "POST"))
		{
			byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
			req.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
			req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
			req.SetRequestHeader("Content-Type", "application/json");

			yield return req.SendWebRequest();

			if (req.result != UnityWebRequest.Result.Success)
			{
				Debug.Log(req.error);
			}
			else
			{
				this.submitButton.SetActive(false);
				this.inputField.gameObject.SetActive(false);
				Debug.Log("Form upload complete!");
			}
		}
	}

	public void Restart()
	{
		Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
	}

	public void Exit()
	{
		SceneManager.LoadScene("Main Menu");
	}
}
