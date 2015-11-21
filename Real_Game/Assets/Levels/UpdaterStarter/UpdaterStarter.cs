using UnityEngine;
using System.Collections;
using System.Diagnostics;
public class UpdaterStarter : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void StartUpdaterProgram() { 
        try
        {
            Process myProcess = new Process();
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.StartInfo.UseShellExecute = false;
            string file = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), "\\Afroraydude\\FUG\\AwesomeUpdates.exe");
            myProcess.StartInfo.FileName = file;
            myProcess.EnableRaisingEvents = true;
            myProcess.Start();
            myProcess.WaitForExit();
            int ExitCode = myProcess.ExitCode;
            print(ExitCode);
        }
         catch (System.Exception e)
         {
            print(e);
        }
    }
}
