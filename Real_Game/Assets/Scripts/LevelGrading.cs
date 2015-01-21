using UnityEngine;
using System.Collections;

public class LevelGrading : MonoBehaviour {
        public float finalScore; // This is the final score you recieve
        public string finalScoreLetter; // 
        public float[] timeGrading = new float[5]; // 5 for the 5 grades (A, B, C D, F)
        public int[] deathGrading = new int[5]; // 5 for the 5 grades (A, B, C D, F)
        
        
        void Start() {
                
        }
        
        void Update() {
           //Probably would be empty     
        }
        
        void OnGUI() {
                // I might want to do the GUI
        }
        
}

