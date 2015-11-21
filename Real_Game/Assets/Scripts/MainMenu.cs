﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/** Class for the Main Menu
 * Contains/Does the following:
 * Manages GUI for the Main Menu
 * Go to level 1
 * That is about it
*/

public class MainMenu : MonoBehaviour {
	public GameManager manager;
	//Ping ping;
	public Button updateButton;
	public byte[] versionWWWByte;
	public Text updateButtonText;
	public Button startButton;
	public string updateURL;
	public Button foolButton;
	public float version;
	public string versionText;
	public float gotVersion;
	public XMLParser xml;
    public UpdaterStarter updateStarter;

    void Awake () {
        //ping = new Ping("8.8.8.8");
        updateStarter = updateStarter.GetComponent<UpdaterStarter>();
        if (PlayerPrefs.HasKey("ResHeight")){
			Screen.SetResolution(PlayerPrefs.GetInt ("ResWidth"), PlayerPrefs.GetInt ("ResHeight"), false);
			if(PlayerPrefs.GetInt("GoFullscreen") == 1) {
				Screen.fullScreen = true;
			}
			else {
				Screen.fullScreen = false;
			}
		}
		xml = xml.GetComponent<XMLParser> ();
		startButton = startButton.GetComponent<Button> ();
		foolButton = foolButton.GetComponent<Button> ();
		updateButton = updateButton.GetComponent<Button> ();
		updateButtonText = updateButtonText.GetComponent<Text> ();
		updateButtonText.resizeTextMaxSize = 14;
		updateButtonText.resizeTextForBestFit = true;
		manager = manager.GetComponent<GameManager> ();
		startButton.enabled = false;
		foolButton.enabled = false;
	}

	void Start () {
		/**
		StartCoroutine( Do() );

      		//or the less efficient version that takes a string, but is limited to a single parameter.:
      		StartCoroutine("Do" , parameter);
      		//The advantage to the string version is that you can call stop coroutine:
      		StopCoroutine("Do");
		*/
	}

	public void Update() {
		if (xml.xmlLoaded) {
			startButton.enabled = true;
			foolButton.enabled = true;
		}
	}

	public void StartGame() {
		print ("Button 'Play' has been pressed!");
		manager.MainMenuToLevelOne();
	}
	public void EndGame() {
		print ("Button 'Quit' has been pressed!");
		Application.Quit ();
	}
	public void UpdateGame() {
        updateStarter.StartUpdaterProgram();
	}

	public void ToOptionsMenu() {
		Application.LoadLevel ("Options");
	}

	public void ToTesing() {
		Application.LoadLevel ("Animation");
	}

	void OnApplicationQuit () {
		PlayerPrefs.DeleteKey ("UpdateChecked");
	}
}
