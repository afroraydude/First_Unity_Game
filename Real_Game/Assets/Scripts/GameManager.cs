using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static int currentScore;
	public static int highScore;
	public static int currentLevel = 0;
	public static int unlockedLevel;
	public Rect stopwatchRect;
	public Rect stopwatchBoxRect;

	public GUISkin skin;

	public float startTime;
	private string currentTime;

	void Update()
	{
		startTime += Time.deltaTime;
		currentTime = string.Format ("{0:0.0}", startTime);
	}
	void OnGUI()
	{
		GUI.skin = skin;
		GUI.Box (stopwatchBoxRect, "");
		GUI.Label(stopwatchRect, currentTime, skin.GetStyle ("Stopwatch"));
	}

	public static void CompleteLevel()
	{
		if (currentLevel < 3)
		{
			currentLevel +=1;
			Application.LoadLevel(currentLevel);
		}
		else
		{
			print ("YOU WIN!");
		}
	}
}
