using UnityEngine;
using System.Collections;


public class LevelGrading : MonoBehaviour {
        
        public GameManager manager;
        
        public float[] finalGrading = new float[4]; // This is the final score you recieve
        public char finalScoreLetter; // 
        public float finalGradeScore;
        
        public float[] timeGrading = new float[4]; // 4 for the 4 grades (A, B, C, D)
        float timeGradingScore;
        
        
        public int[] deathGrading = new int[4]; // 4 for the 4 grades (A, B, C, D)
        int deathGradingScore;
        
        char timeGradingLetter;
        char deathGradingLetter;
        
        
        void Start() {
                
        }
        
        void Update() {
                //Probably would be empty     
        }
        
        void OnGUI() {
                // I might want to do the GUI
        }
        
        void StartGrading () {
                
        }
        
        void GradeTime(float givinTime) {
                // For A
                if() {
                        
                }
                // For B
                else if() {
                        
                }
                // For C
                else if() {
                        
                }
                // For D
                else if () {
                        
                }
                else {
                        
                }
                
        }
        
        void GradeDeaths(int givenDeaths) {
                // For A
                if() {
                        
                }
                // For B
                else if() {
                        
                }
                // For C
                else if() {
                        
                }
                // For D
                else if () {
                        
                }
                else {
                        
                }
        }
        
        void GradeFinal() {
                
        }
        
}

