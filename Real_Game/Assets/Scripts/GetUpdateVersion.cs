using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetUpdateVersion : MonoBehaviour {

	public WWW update;
	public Button updateButton;
	public Text updateButtonText;
	public string updateURL;
	public float version;
	public string gotVersionText;
	public float gotVersion;
	
	// Use this for initialization
	void Awake () {
		Debug.Log ("Current Version: " + version.ToString());
		updateButtonText.resizeTextMaxSize = 14;
		updateButtonText.resizeTextForBestFit = true;
		/**
		StartCoroutine( Do() );
      		//or the less efficient version that takes a string, but is limited to a single parameter.:
      		StartCoroutine("Do" , parameter);
      		//The advantage to the string version is that you can call stop coroutine:
      		StopCoroutine("Do");
		*/
		StartCoroutine (GetUpdateData ());
	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator GetUpdateData () {
		update = new WWW (updateURL);
		yield return update;
		gotVersionText = update.text.ToString();
		Debug.Log ("Latest Version: " + gotVersionText);
		gotVersion = float.Parse (gotVersionText);
		CheckIfVersionIsLatest ();
	}

	void CheckIfVersionIsLatest () {
		if (gotVersion <= version || Application.isWebPlayer) {
			updateButton.enabled = false;
			updateButtonText.text = "Up to Date";
			Debug.Log ("Version is up to date");
		} else {
			Debug.LogWarning("Not Up to Date! Please Update!");
		}
	}
}
