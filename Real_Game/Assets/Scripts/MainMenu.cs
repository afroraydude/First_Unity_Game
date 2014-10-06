using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary; 

public class MainMenu : MonoBehaviour 
{
	public GUISkin skin;

	void OnGUI()
	{
		
		GUI.skin = skin;
		/** 
		 * Offset x, offset y, object width, object height
		 * To set the offset height of a gui item that is under another
		 * gui item correctly, add 20 to the above gui item's 
		 * height/y offset.
		*/
		GUI.Label (new Rect (10,10,440,45), "Afroraydude's Puzzle Game");
		GUI.Label (new Rect (10,65,440,45), "Pre Alpha Version 1");
		if (GUI.Button(new Rect (10,150,100,45), "Play"))
		{
			print ("Button 'Play' has been pressed!");
			GameManager.CompleteLevel ();
		}
		if (GUI.Button(new Rect (10,205,100,45), "Quit"))
		{
			print ("Button 'Quit' has been pressed!");
			Application.Quit ();
		}
	}
}
