using UnityEngine;
using System.Collections;

/** Class for the Main Menu
 * Contains/Does the following:
 * Manages GUI for the Main Menu
 * Go to level 1
 * That is about it
*/
public class MainMenu : MonoBehaviour {
	public GameManager manager;
	
	// Mostly only used to read the components in 
	void Start() {
		manager = manager.GetComponent<GameManager>();
		//Destroy(gameObject);
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

}
