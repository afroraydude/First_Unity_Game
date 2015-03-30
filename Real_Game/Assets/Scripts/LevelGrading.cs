using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

/**
 * Class LevelGrading by Afroraydude
 * Contains/Does the following:
 * Grading the player's time
 * Grading the players death count
*/
public class LevelGrading : MonoBehaviour {

	public bool startGrade = false;

	public int levelId;

	public GameManager manager;
	public LevelData leveldata;

	public Text time;
	public Text final;
	public Text death;
	public Canvas canvas;

	public string finalScoreLetter;
    	public float fgs; // for final grading score

	public ArrayList timeGrading = new ArrayList(); // 4 for the 4 grades (A, B, C, D)
	int tgs; // For time grading score
	float timeGiven;
        
	public ArrayList deathGrading = new ArrayList(); // 4 for the 4 grades (A, B, C, D)
	int dgs; /// for death grading score
	int deathsGiven;
        
	string timeGradingLetter;
	string deathGradingLetter;

        
        
	void Start() {
		time = time.GetComponent<Text>();
		death = death.GetComponent<Text>();
		final = final.GetComponent<Text>();
		manager = manager.GetComponent<GameManager>();
		canvas = canvas.GetComponent<Canvas>();
		// eventSystem = eventSystem.GetComponent<EventSystem>();
		deathsGiven = PlayerPrefs.GetInt("TempDeaths");
		timeGiven = PlayerPrefs.GetFloat("TempExactScore");
		canvas.enabled = false;
		leveldata = leveldata.GetComponent<LevelData> ();

		levelId = Application.loadedLevel;

	}
        
	void Update() {
		if (startGrade) {
			WhenStartGrade();
		}
	}
        
        void OnGUI() {
                // I might want to do the GUI
        }
        
	void WhenStartGrade() {
		leveldata.ProcessInfo (levelId);
		timeGrading = leveldata.tempTime;
		deathGrading = leveldata.tempDeath;
		deathGrading = leveldata.tempDeath;
		GradeTime();
		GradeDeaths();
		GradeFinal();
		canvas.enabled = true;
		death.text = "Death Score: " + deathGradingLetter.ToString();
		time.text = "Time Score: " + timeGradingLetter.ToString();
		final.text = "Final Score: " + finalScoreLetter.ToString();

	}
        
	void GradeTime() {
                // For A
		if(timeGiven <= float.Parse(timeGrading[0].ToString())) {
			tgs = 5;
			timeGradingLetter = "A";
		}
                // For B
		else if(timeGiven <= float.Parse(timeGrading[1].ToString())) {
			tgs = 4;
			timeGradingLetter = "B";
		}
                // For C
		else if(timeGiven <= float.Parse(timeGrading[2].ToString())) {
			tgs = 3;
			timeGradingLetter = "C";
		}
                // For D
		else if (timeGiven <= float.Parse(timeGrading[3].ToString())) {
			tgs = 2;
			timeGradingLetter = "D";
		}
		else {
			tgs = 1;
			timeGradingLetter = "F";
		}           
	}
        
	void GradeDeaths() {
                // For A
		if(deathsGiven <= float.Parse(deathGrading[0].ToString())) {
			dgs = 5;
			deathGradingLetter = "A";
		}
                // For B
		else if(deathsGiven <= float.Parse(deathGrading[1].ToString())) {
			dgs = 4;
			deathGradingLetter = "B";
		}
                // For C
		else if(deathsGiven <= float.Parse(deathGrading[2].ToString())) {
			dgs = 3;
			deathGradingLetter = "C";
		}
                // For D
		else if (deathsGiven <= float.Parse(deathGrading[3].ToString())) {
			dgs = 2;
			deathGradingLetter = "D";
		}
		else {
			dgs = 1;
			deathGradingLetter = "F";
		}
	}
        
	void GradeFinal() {
		fgs = (tgs + dgs) / 2;
                // For A
		if(fgs > 4) {
			finalScoreLetter = "A";
		}
		// For B
		else if(fgs > 3) {
			finalScoreLetter = "B";
                }
                // For C
		else if(fgs > 2) {
			finalScoreLetter = "C";
		}
                // For D
		else if (fgs > 1) {
			finalScoreLetter = "D";
		}
                else {
			finalScoreLetter = "F";
		}
	}
}

