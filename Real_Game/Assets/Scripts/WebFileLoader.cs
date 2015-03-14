using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;

public class WebFileLoader : MonoBehaviour {

	public WWW www;
	// Use this for initialization
	void Start () {

	}
	/**
	 * unnessesary
	public void startReadingURL() {
		StartCoroutine(GetURL())
	}
	*/

	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator GetURL (string url) {
		www = new WWW (url);
		yield return www;
	}
}
