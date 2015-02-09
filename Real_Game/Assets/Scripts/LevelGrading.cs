using UnityEngine;
using System.Collections;

public class LevelGrading : MonoBehaviour {
        
        public GameManager manager;
        
        public float finalScore; // This is the final score you recieve
        public string finalScoreLetter; // 
        
        public float[] timeGrading = new float[4]; // 4 for the 4 grades (A, B, C, D)
        public float timeGradingScore;
        
        public int[] deathGrading = new int[4]; // 4 for the 4 grades (A, B, C, D)
        public int deathGradingScore;
        
        public char timeGradingLetter;
        public char deathGradingLetter;
        
        
        void Start() {
                
        }
        
        void Update() {
                //Probably would be empty     
        }
        
        void OnGUI() {
                // I might want to do the GUI
        }
        
        void GradeTime() {
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
                else 
                
        }
        
        void GradeDeaths() {
                
        }
        
        void GradeFinal () {
                
        }
        
}

