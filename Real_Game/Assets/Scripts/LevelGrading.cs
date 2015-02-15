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

	public GameManager manager;

	public Text time;
	public Text final;
	public Text death;
	public Canvas canvas;

	public char finalScoreLetter;
    public float fgs; // for final grading score

	public float[] timeGrading = new float[4]; // 4 for the 4 grades (A, B, C, D)
	int tgs; // For time grading score
	float timeGiven;
        
	public int[] deathGrading = new int[4]; // 4 for the 4 grades (A, B, C, D)
	int dgs; /// for death grading score
	int deathsGiven;
        
	char timeGradingLetter;
	char deathGradingLetter;

        
        
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
		if(timeGiven <= timeGrading[0]) {
			tgs = 5;
			timeGradingLetter = 'A';
		}
                // For B
		else if(timeGiven <= timeGrading[1]) {
			tgs = 4;
			timeGradingLetter = 'B';
		}
                // For C
		else if(timeGiven <= timeGrading[2]) {
			tgs = 3;
			timeGradingLetter = 'C';
		}
                // For D
         else if (timeGiven <= timeGrading[3]) {
			tgs = 2;
			timeGradingLetter = 'D';
		}
		else {
			tgs = 1;
			timeGradingLetter = 'F';
		}           
	}
        
	void GradeDeaths() {
                // For A
		if(deathsGiven <= deathGrading[0]) {
			dgs = 5;
			deathGradingLetter = 'A';
		}
                // For B
		else if(deathsGiven <= deathGrading[1]) {
			dgs = 4;
			deathGradingLetter = 'B';
		}
                // For C
		else if(deathsGiven <= deathGrading[2]) {
			dgs = 3;
			deathGradingLetter = 'C';
		}
                // For D
		else if (deathsGiven <= deathGrading[3]) {
			dgs = 2;
			deathGradingLetter = 'D';
		}
		else {
			dgs = 1;
			deathGradingLetter = 'F';
		}
	}
        
        void GradeFinal() {
                fgs = (tgs + dgs) / 2;
                // For A
                if(fgs > 4) {
                        finalScoreLetter = 'A';
                }
                // For B
                else if(fgs > 3) {
                        finalScoreLetter = 'B';
                }
                // For C
                else if(fgs > 2) {
                        finalScoreLetter = 'C';
                }
                // For D
                else if (fgs > 1) {
                        finalScoreLetter = 'D';
                }
                else {
                        finalScoreLetter = 'F';
                }
        }
}

