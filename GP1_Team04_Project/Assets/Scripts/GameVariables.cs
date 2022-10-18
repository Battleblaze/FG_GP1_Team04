using UnityEngine;

namespace FG
{
	public static class GameVariables
	{
		public static int Score { get; set; } = 0;

		public static void UpdatePlayerPrefs()
		{
			var old = PlayerPrefs.GetInt("Highscore", 0); // Set local highscore

			if (FG.GameVariables.Score > old)
			{
				PlayerPrefs.SetInt("Highscore", FG.GameVariables.Score);
			}
		}
	}
}