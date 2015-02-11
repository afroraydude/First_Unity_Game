using UnityEngine;
using System.Collections;

/** Class for last screen/End Screen
 * Does the following
 * Tells the player that they won
 * GUI for going back to the begining
 * GUI for exiting the game
*/
public class WinScript : MonoBehaviour {
	public GUISkin skin;
	public Rect winRect;
	protected string winString = "Game over, you win!";

	public GameManager manager;
	// Mostly only used to read the components in 
	void Start () 
	{
		manager = manager.GetComponent<GameManager>();
		//Destroy(gameObject);
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI ()
	{
		GUI.skin = skin;
		GUI.Label (new Rect (10,10,440,45), winString);
		if (GUI.Button(new Rect (10,205,100,45), "Quit"))
		{
			print ("Button 'Quit' has been pressed!");
			Application.Quit ();
		}
		if (GUI.Button(new Rect (10,260,200,45), "Back to Main Menu"))
		{
			print ("Going back!");
			manager.BackToMainMenu();
		}
	}
	
}
