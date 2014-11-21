using UnityEngine;
using System.Collections;

public class WinScript : MonoBehaviour {
	public GUISkin skin;
	public Rect winRect;
	public string winString = "Game over, you win!";

	void OnGUI ()
	{
		GUI.skin = skin;
		GUI.Label (new Rect (10,10,440,45), winString);
		if (GUI.Button(new Rect (10,205,100,45), "Quit"))
		{
			print ("Button 'Quit' has been pressed!");
			Application.Quit ();
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
