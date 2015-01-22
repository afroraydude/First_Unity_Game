using UnityEngine;
using System.Collections;

/**
* Created By Afroraydude
* This class is the Framework Of the Game,
* very large compred to the other classes
* This does:
* Level transitions
* Score Keeping
* Score Saving
*/
public class GameManager : MonoBehaviour {
	
	// Score based stuff
	public float highScore = 0f;
	
	// Level based stuff
	public int currentLevel = 0;
	public int unlockedLevels;
	public int LevelGradingID = 6;

	// Things that deal with GUI
	// why are there 2 of all of them? IDK
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
	void Start() {
		unlockedLevels = PlayerPrefs.GetInt("LevelsCompleted");
		// DontDestroyOnLoad(gameObject);
		if (unlockedLevels < currentLevel) {
			PlayerPrefs.SetInt("LevelsCompleted", currentLevel);
			unlockedLevels = PlayerPrefs.GetInt("LevelsCompleted");
			PlayerPrefs.Save();
		}
		
		else {
			// do nothing
		}
	}
	
	// This is ran every tick
	void Update() {
		//This records the time it took to complete the level
		startTime += Time.deltaTime;
		//This puts it into a string so that it can be viewed on the GUI
		currentTime = string.Format ("{0:0.0}", startTime);
	}
	
	// GUI goes here
	void OnGUI() {
		GUI.skin = skin;
		GUI.Box (stopwatchBoxRect, "");
		GUI.Label(stopwatchRect, currentTime, skin.GetStyle ("Stopwatch"));
		GUI.Label (highScoreRect, PlayerPrefs.GetString("Level" + currentLevel.ToString() + "Score"));
		GUI.Box (highScoreBox, "");
	}
	
	public void MainMenuToLevelOne() {
		currentLevel = 1;
		PlayerPrefs.SetInt("LevelsCompleted", currentLevel);
		PlayerPrefs.Save();
		Application.LoadLevel(currentLevel);
	}

	public void BackToMainMenu() {
		currentLevel = 0;
		Application.LoadLevel(currentLevel);
	}
	
	// For when the player completes a level
	// TODO: Fix issue in flash were it does not care if the high score is > or < the startTime, it always overrides it.
	public void CompleteLevel() {
		
		if(highScore > startTime || highScore == 0) {
			highScore = startTime;
			highTime = string.Format ("{0:0.0}", highScore);
			PlayerPrefs.SetString("Level" + currentLevel.ToString() + "Score", highTime);
		}

		if (currentLevel < 5) {
			Application.LoadLevel(LevelGradingID);
		}

		else {
			print ("Please increase level amount.");
		}
	}
	
	public void AtLevelBegin
	
	// After LevelGrading is done, this happens
	public void AfterGrading() {
		currentLevel +=1;
		Application.LoadLevel(currentLevel);
	}
	
	public void StartGame() {
		currentLevel = 0;
	}
}
