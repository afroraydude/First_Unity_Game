using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public float highScore = 0f;
	public int currentLevel = 0;
	public int unlockedLevel;

	public Rect stopwatchRect;
	public Rect stopwatchBoxRect;
	public Rect highScoreRect;
	public Rect highScoreBox;

	public GUISkin skin;

	public float startTime;
	private string currentTime;
	public string highTime;

	void Start()
	{
		//DontDestroyOnLoad(gameObject);
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
		GUI.Label (highScoreRect, PlayerPrefs.GetString("Level" + currentLevel.ToString() + "Score"));
		GUI.Box (highScoreBox, "");
	}

	public void MainMenuToLevelOne()
	{
		currentLevel +=1;
		PlayerPrefs.SetInt("LevelsCompleted", currentLevel);
		PlayerPrefs.Save();
		Application.LoadLevel(currentLevel);
	}

	public void CompleteLevel()
	{
		if(highScore < startTime)
		{
			highScore = startTime;
			highTime = string.Format ("{0:0.0}", highScore);
			PlayerPrefs.SetString("Level" + currentLevel.ToString() + "Score", highTime);
		}

		if (currentLevel < 3)
		{
			currentLevel +=1;
			PlayerPrefs.SetInt("LevelsCompleted", currentLevel);
			PlayerPrefs.GetInt("LevelsCompleted");
			PlayerPrefs.Save();
			Application.LoadLevel(currentLevel);
		}

		else
		{
			print ("YOU WIN!");
		}
	}
	public void MainMenuStart()
	{

	}
}
