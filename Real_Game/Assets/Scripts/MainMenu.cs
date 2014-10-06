using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{


	void OnGUI()
	{
		// offset width, offset height, object width, object height
		if (GUI.Button(new Rect (10,10,100,45), "Play"))
		{
			print ("Button 'Play' has been pressed!");
			GameManager.CompleteLevel ();
		}
		if (GUI.Button(new Rect (10,65,100,45), "Quit"))
		{
			print ("Button 'Quit' has been pressed!");
			Application.Quit ();
		}
	}
}
