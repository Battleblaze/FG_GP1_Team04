using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;

public class HighscoreHandler : MonoBehaviour
{
	[SerializeField] private GameObject contentParent;
	[SerializeField] private GameObject textPrefab;
	[SerializeField] private ContentType contentType;

	[SerializeField] private Transform parent;

	public enum ContentType
	{
		TopTen,
		All,
	}

	// Update is called once per frame
	void Start()
	{
		this.Reload();
	}

	void Reload()
	{
		foreach (Transform child in this.contentParent.transform)
		{
			GameObject.Destroy(child.gameObject);
		}

		StartCoroutine(GetPage(this.contentType));
	}

	void NewScores(Highscore[] highscores)
	{
		for (int i = highscores.Length - 1; i >= 0; i--)
		{
			GameObject score = Instantiate(this.textPrefab, this.parent, false);

			var handler = score.GetComponent<HighscoreText>();

			handler.userName = highscores[i].name;
			handler.score = highscores[i].score;
		}
	}

	IEnumerator GetPage(ContentType contentType)
	{
		string uri = "";
		switch (contentType)
		{
			case ContentType.TopTen:
				uri = "http://129.151.223.57/highscores";
				break;
			case ContentType.All:
				uri = "http://129.151.223.57/highscores";
				break;
		}

		// https://docs.unity3d.com/ScriptReference/Networking.UnityWebRequest.Get.html
		using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
		{
			yield return webRequest.SendWebRequest();

			string[] pages = uri.Split('/');
			int page = pages.Length - 1;

			switch (webRequest.result)
			{
				case UnityWebRequest.Result.ConnectionError:
				case UnityWebRequest.Result.DataProcessingError:
					Debug.LogError(pages[page] + ": Error: " + webRequest.error);
					break;
				case UnityWebRequest.Result.ProtocolError:
					Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
					break;
				case UnityWebRequest.Result.Success:
					Highscore[] highscores = JsonHelper.getJsonArray<Highscore>(webRequest.downloadHandler.text);
					this.NewScores(highscores);
					break;
			}
		}

	}
}



[Serializable]
public class Highscore
{
	public int score;
	public string name;
	public string version;
}