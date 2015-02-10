using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
* Created By Afroraydude
* This class is the Framework Of the Game,
* very large compred to the other classes
* This does:
* Level transitions
* Score Keeping
* Score Saving
*/

// TODO: UPDATE GUI

public class GameManager : MonoBehaviour {
	
	// Score based stuff
	public float highScore;
	
	// Level based stuff
	public int currentLevel;
	int unlockedLevels;
	int LevelGradingID = 6;
	
	// Things that deal with GUI
	public Rect stopwatchRect;
	Rect stopwatchBoxRect;
	Rect highScoreRect; // Delete
	Rect highScoreBox; // Delete
	public GUISkin skin;
	public Text highscoreText;
	public Text stopwatchText;


	// Stuff that deals with the score system.	
	public float startTime;
	private string currentTime;
	public string highTime;
	public int deaths;
	
	//Load other classes
	// Could also be: public PlayerMovement player = new PlayerMovement();
	public PlayerMovement player;
	public LevelGrading levelGrading;
	
	// Once the level loads this happens
	void Start() {

		highscoreText = highscoreText.GetComponent<Text>();
		stopwatchText = stopwatchText.GetComponent<Text>();

		levelGrading = levelGrading.GetComponent<LevelGrading>();
		player = player.GetComponent<PlayerMovement>();

		unlockedLevels = PlayerPrefs.GetInt("LevelsCompleted");
		// DontDestroyOnLoad(gameObject);
		// If the levels you unlocked is less than the level you are at
		if (unlockedLevels < currentLevel) {
			// make it the same
			PlayerPrefs.SetInt("LevelsCompleted", currentLevel);
			PlayerPrefs.Save();
			unlockedLevels = PlayerPrefs.GetInt("LevelsCompleted");
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

		stopwatchText.text = currentTime;
		highscoreText.text = PlayerPrefs.GetString("Level" + currentLevel.ToString() + "Score");
	}
	
	// GUI goes here
	void OnGUI() {
		/** Old/Just for refrence
		GUI.skin = skin;
		GUI.Box (stopwatchBoxRect, "");
		GUI.Label(stopwatchRect, currentTime, skin.GetStyle ("Stopwatch"));
		GUI.Label (highScoreRect, PlayerPrefs.GetString("Level" + currentLevel.ToString() + "Score"));
		GUI.Box (highScoreBox, "");
		*/
	}
	
	public void MainMenuToLevelOne() {
		// To go to Level 1 
		currentLevel = 1;
		/** This might not be required anymore:
		PlayerPrefs.SetInt("LevelsCompleted", currentLevel);
		PlayerPrefs.Save();
		Application.LoadLevel(currentLevel);
		*/
	}

	public void BackToMainMenu() {
		// To go back to Main Menu from the End Game Menu
		currentLevel = 0;
		Application.LoadLevel(currentLevel);
	}
	
	// For when the player completes a level
	// TODO: Fix issue in flash were it does not care if the high score is > or < the startTime, it always overrides it.
	public void CompleteLevel() {
		
		// If the high score is less than the time it took you to complete the level
		if(highScore > startTime) {
			// Make it equal the time it took you to complete the level
			highScore = startTime;
			highTime = string.Format ("{0:0.0}", highScore);
			PlayerPrefs.SetString("Level" + currentLevel.ToString() + "Score", highTime);
		}
		
		deaths = player.deathCount;
		PlayerPrefs.SetInt("TempDeaths", deaths);
		PlayerPrefs.SetFloat("TempExactScore", startTime);
		
		// if the level you are at is less than the numer of levels in the game + game end scene:
		if (currentLevel < 5) {
			levelGrading.startGrade = true;
		}
		// In case it isn't, just to tell us we need to fix it
		else {
			print ("Please increase level amount.");
		}
		
		PlayerPrefs.Save();
	}
	
	/** After LevelGrading is done, this happens so that we can load the level's scores 
	*   Will be obsolete after the 4.6 update is done */
	public void AfterGrading() {
		// Go up a level
		currentLevel +=1;
		Application.LoadLevel(currentLevel);
	}
	
	// Pretty straightforward
	public void StartGame() {
		currentLevel = 0;
	}
	
	public int GetCurrentLevel() {
		return currentLevel;
	}
}
