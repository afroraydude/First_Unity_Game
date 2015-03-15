using UnityEngine;
using System.Collections;
using System;

public class UpdateChecker : MonoBehaviour {

	public DateTime dateTime;
	public DateTime oldDateTime;
	public MainMenu mainMenu;

	// Use this for initialization
	void Awake () {
		mainMenu = mainMenu.GetComponent<MainMenu> ();
		CheckVersion ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CheckVersion () {
		/** Basically...
		 * If we have not checked the version before, we will save the date and and check 
		 * if the version is the latest version (and save that too). 
		  */
		if (!PlayerPrefs.HasKey ("LastCheckedDate")) {
			dateTime = new DateTime (DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
			PlayerPrefs.SetString ("LastCheckedDate", dateTime.ToString());
			PlayerPrefs.Save ();
			mainMenu.StartGetVersion();
			/** Now...
			 * What if it has been checked before? If it has, then we will load that date up and get the current date
			 */
		} else if (PlayerPrefs.HasKey ("LastCheckedDate")) {
			oldDateTime = DateTime.Parse(PlayerPrefs.GetString("LastCheckedDate"));
			print (oldDateTime.ToString());
			dateTime = new DateTime (DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
			print (dateTime.ToString());
			/** What is next?
			 * Next we will see if the two dates are the same, if they are, and it is up to date, we say it is up-to-date
			  */
			if (oldDateTime == dateTime) {
				if(PlayerPrefs.HasKey("isUpToDate") && PlayerPrefs.GetInt("isUpToDate") == 1) {
					mainMenu.updateButtonText.text = "Up-To-Date";
					mainMenu.updateButton.enabled = false;
				}
			/** And if not...
			 * We repeate! Infinite loopsssssssssssssssssssss
			 */
			} else {
				mainMenu.StartGetVersion();
				CheckVersion();
			}
		}
	}
}
