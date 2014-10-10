using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary; 

public class MainMenu : MonoBehaviour 
{

	public GUISkin skin;
	public Rect title = 10,10,440,45;
	public Rect version = 10,65,440,45;
	public Rect playButton = 10,150,100,45;
	public Rect quitButton = 10,205,100,45;
	public GameManager manager;
	
	// Mostly only used to read the components in 
	void Start () 
	{
		manager = manager.GetComponent<GameManager>();
		//Destroy(gameObject);
	}
	// GUI 
	void OnGUI()
	{
		
		GUI.skin = skin;
		/** 
		 * Offset x, offset y, object width, object height
		 * To set the offset height of a gui item that is under another
		 * gui item correctly, add 20 to the above gui item's 
		 * height/y offset.
		*/
		GUI.Label (title, "Afroraydude's Puzzle Game");
		GUI.Label (version, "Pre Alpha Version 2");
		if (GUI.Button(playButton, "Play"))
		{
			print ("Button 'Play' has been pressed!");
			manager.MainMenuToLevelOne();
		}
		if (GUI.Button(quitButton, "Quit"))
		{
			print ("Button 'Quit' has been pressed!");
			Application.Quit ();
		}
	}
}
