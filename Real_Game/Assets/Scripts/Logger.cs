using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Logger : MonoBehaviour {
	public float frameRate;
	public int seconds;

	// Use this for initialization
	void Start() {

	}
	
	// Update is called once per frame
	void Update() {
		frameRate = 1 / Time.deltaTime;
		Debug.Log(frameRate.ToString());
	}
}
