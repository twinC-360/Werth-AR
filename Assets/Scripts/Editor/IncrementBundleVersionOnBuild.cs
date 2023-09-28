using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

public class IncrementBundleVersionOnBuild {
	[PostProcessBuildAttribute(1)]
	public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject) {
		Debug.Log("My Build Post Process: "+pathToBuiltProject );
		PlayerSettings.Android.bundleVersionCode++;
		Debug.Log("bundleVersionCode: "+PlayerSettings.Android.bundleVersionCode);
	}
}