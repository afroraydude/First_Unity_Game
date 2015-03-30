using UnityEngine;
using System.Xml;
using System.Collections;
using System.Xml.Serialization;
//using System.IO;

public class XMLParser : MonoBehaviour {
	XmlDocument projectDoc;
	public string xml = "http://afroraydude.com/unity/game.xml";
	public int tempId;
	public LevelData levelData;
	WWW www;
	public bool xmlLoaded = false;
	TextAsset textasset;
	// public WWW itemsWWW;
	
	// Use this for initialization
	void Awake() {
		levelData = levelData.GetComponent<LevelData>();
		textasset = Resources.Load ("TextAsset/game") as TextAsset;
	}

	void Start () {
		projectDoc = new XmlDocument ();
		StartCoroutine (LoadURL());
	}
	
	public IEnumerator LoadURL () {
		www = new WWW (xml);
		yield return www;
		if (www.error == null && !www.text.Contains("Backup")) {
			//Sucessfully loaded the XML
			Debug.Log ("Loaded XML from URL.");
			//Create a new XML document out of the loaded data
			projectDoc.LoadXml (www.text);
			//Point to the item nodes and process them
			ProccessItems (projectDoc.SelectNodes("game/level"));
		}
		else {
			Debug.Log("ERROR: " + www.error);
			Debug.LogWarning("Error loading from URL, using backup file.");
			projectDoc.LoadXml(textasset.text);
		}
		
	}
	/**
	IEnumerator UpdateBackup () {

	}
	*/
	//Converts an XmlNodeList into item objects and shows a item out of it on the screen
	void ProccessItems(XmlNodeList nodes) {

		foreach (XmlNode node in nodes) {
			levelData.timea.Add(node.SelectSingleNode("time/a").InnerText);
			levelData.timeb.Add(node.SelectSingleNode("time/b").InnerText);
			levelData.timec.Add(node.SelectSingleNode("time/c").InnerText);
			levelData.timed.Add(node.SelectSingleNode("time/d").InnerText);
			levelData.deatha.Add(node.SelectSingleNode("death/a").InnerText);
			levelData.deathb.Add(node.SelectSingleNode("death/b").InnerText);
			levelData.deathc.Add(node.SelectSingleNode("death/c").InnerText);
			levelData.deathd.Add (node.SelectSingleNode("death/d").InnerText);

			tempId = int.Parse(node.Attributes.GetNamedItem("id").Value.ToString());
			Debug.Log("Loading Grading data for Level #" + tempId.ToString());

			levelData.timea.Insert(tempId, node.SelectSingleNode("time/a").InnerText);
			levelData.timeb.Insert(tempId, node.SelectSingleNode("time/b").InnerText);
			levelData.timec.Insert(tempId, node.SelectSingleNode("time/c").InnerText);
			levelData.timed.Insert(tempId, node.SelectSingleNode("time/d").InnerText);
			levelData.deatha.Insert(tempId, node.SelectSingleNode("death/a").InnerText);
			levelData.deathb.Insert(tempId, node.SelectSingleNode("death/b").InnerText);
			levelData.deathc.Insert(tempId, node.SelectSingleNode("death/c").InnerText);
			levelData.deathd.Insert(tempId, node.SelectSingleNode("death/d").InnerText);

		}
		xmlLoaded = true;
		Debug.Log (levelData.timec [1] + "!");
	}

	// Update is called once per frame
	void Update () {
		
	}
}