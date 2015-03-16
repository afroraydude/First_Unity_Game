using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WebFileLoader : MonoBehaviour {

	public WWW update;
	
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator GetURL (string url) {
		www = new WWW (url);
		yield return www;
	}
}
