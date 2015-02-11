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
	public Button endButton;
	public Canvas canvas;
	// public EventSystem eventSystem;
        
	public float[] finalGrading = new float[4]; // This is the final score you recieve
	public char finalScoreLetter; // 
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
		endButton = endButton.GetComponent<Button>();
		final = final.GetComponent<Text>();
		manager = manager.GetComponent<GameManager>();
		canvas = canvas.GetComponent<Canvas>();
		// eventSystem = eventSystem.GetComponent<EventSystem>();
		time.enabled = false;
		final.enabled = false;
		death.enabled = false;
		endButton.enabled = false;
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
		death.text = dgs.ToString();
		time.text = tgs.ToString();
		final.text = finalScoreLetter.ToString();
		time.enabled = true;
		canvas.enabled = true;
		final.enabled = true;
		death.enabled = true;
		endButton.enabled = true;
	}
        
	void GradeTime() {
                // For A
		if(timeGiven < timeGrading[1]) {
			tgs = 5;
		}
                // For B
		else if(timeGiven < timeGrading[2]) {
			tgs = 4;
		}
                // For C
		else if(timeGiven < timeGrading[3]) {
			tgs = 3;
		}
                // For D
                else if (timeGiven < timeGrading[4]) {
			tgs = 2;
                }
                else {
			tgs = 1;
                }
                
        }
        
        void GradeDeaths() {
                // For A
                if(deathsGiven < deathGrading[1]) {
			dgs = 5;
                }
                // For B
                else if(deathsGiven < deathGrading[2]) {
			dgs = 4;
                }
                // For C
                else if(deathsGiven < deathGrading[3]) {
			dgs = 3;
                }
                // For D
                else if (deathsGiven < deathGrading[4]) {
			dgs = 2;
		}
                else {
			dgs = 1;
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

	public void PlayerExit() {
		manager.AfterGrading();
	}   
}

