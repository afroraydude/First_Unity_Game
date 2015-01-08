using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	// Score based stuff
	public float highScore = 0f;
	
	//Level based stuff
	public int currentLevel = 0;
	public int unlockedLevel;

	// Things that deal with GUI or whatever
	public Rect stopwatchRect;
	public Rect stopwatchBoxRect;
	public Rect highScoreRect;
	public Rect highScoreBox;
	public GUISkin skin;
	
	// Stuff that deals with the ingame stopwatch, which is my answer to the score system.	
	public float startTime;
	private string currentTime;
	public string highTime;
	
	// Once the level loads this happens
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
	
	// This is ran every tick
	void Update()
	{
		//This records the time it took to complete the level
		startTime += Time.deltaTime;
		//This puts it into a string so that it can be viewed on the GUI
		currentTime = string.Format ("{0:0.0}", startTime);
	}
	
	// GUI goes here
	void OnGUI()
	{
		GUI.skin = skin;
		GUI.Box (stopwatchBoxRect, "");
		GUI.Label(stopwatchRect, currentTime, skin.GetStyle ("Stopwatch"));
		GUI.Label (highScoreRect, PlayerPrefs.GetString("Level" + currentLevel.ToString() + "Score"));
		GUI.Box (highScoreBox, "");
	}

	/** 
	* So the main menu doesn't need to use another object in the scene to run,
	* Also so that there wont be a stopwatch calculationg time in the main menu.
	* The end screen doesn't need this because it is just a GUI.
	*/
	public void MainMenuToLevelOne()
	{
		currentLevel +=1;
		PlayerPrefs.SetInt("LevelsCompleted", currentLevel);
		PlayerPrefs.Save();
		Application.LoadLevel(currentLevel);
	}

	public void BackToMainMenu()
	{
		currentLevel -=1;
		PlayerPrefs.SetInt("LevelsCompleted", currentLevel);
		PlayerPrefs.Save();
		Application.LoadLevel(currentLevel);
	}
	// For when the player completes a level
	// TODO: Fix issue in flash were it does not care if the high score is > or < the startTime, it always overrides it.
	public void CompleteLevel()
	{
		if(highScore > startTime || highScore == 0)
		{
			highScore = startTime;
			highTime = string.Format ("{0:0.0}", highScore);
			PlayerPrefs.SetString("Level" + currentLevel.ToString() + "Score", highTime);
		}

		if (currentLevel < 5)
		{
			currentLevel +=1;
			PlayerPrefs.SetInt("LevelsCompleted", currentLevel);
			PlayerPrefs.GetInt("LevelsCompleted");
			PlayerPrefs.Save();
			Application.LoadLevel(currentLevel);
		}

		else
		{
			print ("Please increase level amount.");
		}
	}
	
}
