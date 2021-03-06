using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using PoqXert.MessageBox;
namespace com.afroraydude.unity.firstgame.inner
{
    public class GetUpdateVersion : MonoBehaviour
    {

        public WWW update;
        public Button updateButton;
        public Text updateButtonText;
        public string updateURL = "http://afroraydude.pw/realgame/update.txt";
        public float version;
        public string gotVersionText = "null";
        public float gotVersion = 1234567890;
        public int versionDate; // alternate to version...either or could work

        // public WWW dateUpdate
        // public int gotVersionDate
        // public int gotVersionDateText

        // Use this for initialization
        void Awake()
        {
            print("Current Version: " + version.ToString());
            updateButtonText.resizeTextMaxSize = 14;
            updateButtonText.resizeTextForBestFit = true;
            /**
            StartCoroutine( Do() );
                //or the less efficient version that takes a string, but is limited to a single parameter.:
                StartCoroutine("Do" , parameter);
                //The advantage to the string version is that you can call stop coroutine:
                StopCoroutine("Do");
            */
            StartCoroutine(GetUpdateData());
        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator GetUpdateData()
        {
            update = new WWW(updateURL);
            yield return update;
            gotVersionText = update.text.ToString();
            print("Latest Version: " + gotVersionText);
            gotVersion = float.Parse(gotVersionText);
            CheckIfVersionIsLatest();
        }

        void CheckIfVersionIsLatest()
        {
            if (gotVersion <= version || Application.isWebPlayer)
            {
                updateButton.enabled = false;
                updateButtonText.text = "Up to Date";
                print("Version is up to date");
            }
            else
            {
                print("Warning: Not Up to Date! Please Update!");
                if (!PlayerPrefs.HasKey("UpdateChecked"))
                {
                    MsgBox.Show(0, "Would you like to open the download page?", "New Update Available", MsgBoxButtons.YES_NO, MsgBoxStyle.Warning, GoAndUpdate, true, "", "", "");
                }
            }
        }

        void GoAndUpdate(int i, DialogResult result)
        {
            print("Choice = " + result.ToString());
            if (result.ToString() == "YES_OK")
            {
                Application.OpenURL("http://afroraydude.pw/realgame/latest.zip");
            }
            MsgBox.Close();
        }

        void OnApplicationQuit()
        {
            PlayerPrefs.DeleteKey("UpdateChecked");
        }
    }

}