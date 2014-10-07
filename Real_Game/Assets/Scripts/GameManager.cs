using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public int currentScore;
	public int highScore;
	public int currentLevel = 0;
	public int unlockedLevel;
	public Rect stopwatchRect;
	public Rect stopwatchBoxRect;

	public GUISkin skin;

	public float startTime;
	private string currentTime;

	void Start()
	{
		if (PlayerPrefs.GetInt("LevelsCompleted") > 0)
		{
			currentLevel = PlayerPrefs.GetInt("LevelsCompleted");
		}
		else
		{
			currentLevel = 0;
		}
	}

	void Update()
	{
		startTime += Time.deltaTime;
		currentTime = string.Format ("{0:0.0}", startTime);
	}
	void OnGUI()
	{
		GUI.skin = skin;
		GUI.Box (stopwatchBoxRect, "");
		GUI.Label(stopwatchRect, currentTime, skin.GetStyle ("Stopwatch"));
	}

	public void CompleteLevel()
	{
		if (currentLevel < 3)
		{
			currentLevel +=1;
			PlayerPrefs.SetInt("LevelsCompleted", currentLevel);
			PlayerPrefs.SetFloat("Level" + currentLevel.ToString() + "Score", startTime);
			PlayerPrefs.GetInt("LevelsCompleted");
			PlayerPrefs.Save();
			Application.LoadLevel(currentLevel);
		}
		else
		{
			print ("YOU WIN!");
		}
	}
}
