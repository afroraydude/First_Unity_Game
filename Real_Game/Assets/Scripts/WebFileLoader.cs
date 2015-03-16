using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;

public class WebFileLoader : MonoBehaviour {

	public WWW www;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator GetURL (string url) {
		www = new WWW (url);
		yield return www;
	}
}
