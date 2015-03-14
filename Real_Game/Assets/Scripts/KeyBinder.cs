using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeyBinder : MonoBehaviour {
	public InputField up;
	public InputField down;
	public InputField left;
	public InputField right;

	// Use this for initialization
	void Start () {
		up = up.GetComponent<InputField> ();
		down = down.GetComponent<InputField> ();
		left = left.GetComponent<InputField> ();
		right = right.GetComponent<InputField> ();
		if (!PlayerPrefs.HasKey ("UpKey")) {
			up.text = "W";
			down.text = "s";
			left.text = "a";
			right.text = "d";
		} else {
			//PlayerPrefs.GetString("UpKey")
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
