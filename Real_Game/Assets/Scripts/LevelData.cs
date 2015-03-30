using UnityEngine;
using System.Collections;

public class LevelData : MonoBehaviour {
	public int levelcount = 5; // always make this 1 more than the amount of levels
	public ArrayList timea = new ArrayList();
	public ArrayList timeb = new ArrayList();
	public ArrayList timec = new ArrayList();
	public ArrayList timed = new ArrayList();
	public ArrayList deatha = new ArrayList();
	public ArrayList deathb = new ArrayList();
	public ArrayList deathc = new ArrayList();
	public ArrayList deathd = new ArrayList();
	public ArrayList tempTime = new ArrayList();
	public ArrayList tempDeath = new ArrayList();

	public bool doneProcessing = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ProcessInfo (int templevelId) {
		tempTime.Add (timea [templevelId]);
		tempTime.Add (timeb [templevelId]);
		tempTime.Add (timec [templevelId]);
		tempTime.Add (timed [templevelId]);
		tempDeath.Add (deatha [templevelId]);
		tempDeath.Add (deathb [templevelId]);
		tempDeath.Add (deathc [templevelId]);
		tempDeath.Add (deathd [templevelId]);
		Debug.Log (tempTime [0].ToString () + " " + tempTime [1].ToString () + " " + tempTime [2].ToString () + " " + tempTime [3].ToString ());
		Debug.Log (tempDeath [0].ToString () + " " + tempTime [1].ToString () + " " + tempTime [2].ToString () + " " + tempTime [3].ToString ());
		doneProcessing = true;
	}
}
