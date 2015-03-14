using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/** Class for the Main Menu
 * Contains/Does the following:
 * Manages GUI for the Main Menu
 * Go to level 1
 * That is about it
*/

// for using IEnums with voids check:
// https://www.google.com/search?sourceid=chrome-psyapi2&ion=1&espv=2&es_th=1&ie=UTF-8&q=unity%20c%23%20call%20ienumerator%20from%20void&oq=unity%20c%23%20call%20ienumerator%20from%20void&aqs=chrome..69i57.39974j0j7
public class MainMenu : MonoBehaviour {
	public GameManager manager;
	public Button updateButton;
	public byte[] versionWWWByte;
	public Text updateButtonText;
	public string updateURL;
	WWW updateWWW;
	public float version;
	public string versionText;
	public float gotVersion;

	void Awake () {
		if(PlayerPrefs.HasKey("ResHeight")){
			Screen.SetResolution(PlayerPrefs.GetInt ("ResWidth"), PlayerPrefs.GetInt ("ResHeight"), false);
			if(PlayerPrefs.GetInt("GoFullscreen") == 1) {
				Screen.fullScreen = true;
			}
			else {
				Screen.fullScreen = false;
			}
		}
		updateButton = updateButton.GetComponent<Button> ();
		updateButtonText = updateButtonText.GetComponent<Text> ();
	}

	void Start () {
		manager = manager.GetComponent<GameManager> ();
		updateButtonText.resizeTextMaxSize = 14;
		updateButtonText.resizeTextForBestFit = true;
		/**
		StartCoroutine( Do() );

      		//or the less efficient version that takes a string, but is limited to a single parameter.:
      		StartCoroutine("Do" , parameter);
      		//The advantage to the string version is that you can call stop coroutine:
      		StopCoroutine("Do");
		*/
		StartCoroutine (GetVersion ());
		StopCoroutine (GetVersion ());
	}

	IEnumerator GetVersion () {
		updateWWW = new WWW (updateURL);
		yield return updateWWW;
		versionText = updateWWW.text.ToString();
		print (versionText);
		gotVersion = float.Parse (versionText);
		print (gotVersion);
		CheckIfVersionIsLatest ();
	}

	void CheckIfVersionIsLatest () {
		if (gotVersion == version || Application.isWebPlayer) {
			updateButton.enabled = false;
			updateButtonText.text = "Up to Date";
		} else {
			// do nothing
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
		Application.OpenURL("https://github.com/afroraydude/First_Unity_Game/releases/latest");
	}

	public void ToOptionsMenu() {
		Application.LoadLevel ("Options");
	}

	public void ToTesing() {
		Application.LoadLevel ("Animation");
	}

}
