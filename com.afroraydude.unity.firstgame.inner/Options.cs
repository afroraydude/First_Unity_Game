using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// using UnityEditor;
using PoqXert.MessageBox;
namespace com.afroraydude.unity.firstgame.inner
{
    public class Options : MonoBehaviour
    {
        public Text resText;
        public Slider resSlider;
        public Toggle fullscreenToggle;
        float oldScreenRes;
        float screenRes;
        public string[] res = new string[5];
        public int[] resHeight = new int[5];
        public int[] resWidth = new int[5];
        int screenResInt;

        // Use this for initialization
        void Start()
        {
            if (PlayerPrefs.HasKey("ResSlider"))
            {
                resSlider.value = PlayerPrefs.GetFloat("ResSlider");
                PlayerPrefs.GetInt("ResHeight");
                PlayerPrefs.GetInt("ResWidth");
                resText.text = PlayerPrefs.GetString("ResText");
            }
            resText = resText.GetComponent<Text>();
            resSlider = resSlider.GetComponent<Slider>();
            fullscreenToggle = fullscreenToggle.GetComponent<Toggle>();
            oldScreenRes = resSlider.value;
        }

        // Update is called once per frame
        void Update()
        {
            if (resSlider.value != oldScreenRes)
            {
                screenRes = resSlider.value;
                oldScreenRes = screenRes;
                screenResInt = (int)screenRes;
                DisplayNewRes();
            }
            else
            {
                screenRes = oldScreenRes;
            }
        }

        void DisplayNewRes()
        {
            resText.text = res[screenResInt];
        }

        public void ApplySettings()
        {
            Screen.SetResolution(resWidth[screenResInt], resHeight[screenResInt], false);
            if (fullscreenToggle.isOn)
            {
                Screen.fullScreen = true;
                PlayerPrefs.SetInt("GoFullscreen", 1);
            }
            else
            {
                Screen.fullScreen = false;
                PlayerPrefs.SetInt("GoFullscreen", 0);
            }

            PlayerPrefs.SetInt("ResHeight", resHeight[screenResInt]);
            PlayerPrefs.SetInt("ResWidth", resWidth[screenResInt]);
            PlayerPrefs.SetString("ResText", resText.text);
            //PlayerSettings.defaultScreenWidth.Equals(resWidth[screenResInt]);
            //PlayerSettings.defaultScreenHeight.Equals(resHeight[screenResInt]);
            PlayerPrefs.SetFloat("ResSlider", screenRes);
            PlayerPrefs.Save();
            print("Settings applied and saved");
            MsgBox.Show(0, "Settings have been applied", "Information", MsgBoxButtons.OK, MsgBoxStyle.Information, Done, true, "", "", "");

        }

        void Done(int i, DialogResult result)
        {
            MsgBox.Close();
        }

        public void GoBack()
        {
            Application.LoadLevel(0);
        }

    }
}
