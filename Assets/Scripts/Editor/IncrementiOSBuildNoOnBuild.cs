using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

public class IncrementiOSBuildNoOnBuild
{
	[PostProcessBuildAttribute(1)]
	public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
	{
		Debug.Log("My Build Post Process: "+pathToBuiltProject );
		int nr;
		if(int.TryParse(PlayerSettings.iOS.buildNumber, out nr))
        {
			nr++;
			PlayerSettings.iOS.buildNumber = nr.ToString();
			Debug.Log("iOS Build No: " + nr);
		}
	}
}