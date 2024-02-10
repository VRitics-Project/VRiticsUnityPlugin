using System.IO;
using UnityEditor;
using UnityEngine;
using Application = UnityEngine.Device.Application;
namespace VRitics.Editor {
	public class VRiticsIntroduction : EditorWindow {

		static bool _isFirstRun = true;

		string appId = "";
		string token = "";

		VRiticsConfigFile configFile;
		bool sendOnDestroy;
		string sessionName = "";
		bool startOnStart;

		void OnEnable () {
			if (_isFirstRun) {
				ShowWindow ();
				_isFirstRun = false;
			}
		}

		void OnGUI () {
			GUILayout.Label ("Welcome to VRitics!", EditorStyles.boldLabel);
			EditorGUILayout.Space ();

			GUILayout.Label ("To have access to data analysis you need to create account and obtain AppID and Token from VRitics website.", EditorStyles.wordWrappedLabel);

			if (GUILayout.Button ("Open VRitics website")) {
				Application.OpenURL ("https://dashboard.vritics.com/");
			}

			EditorGUILayout.Space ();
			GUILayout.Label ("Fill the AppID and Token information below and create config file", EditorStyles.wordWrappedLabel);

			appId = EditorGUILayout.TextField ("AppID:", appId);
			token = EditorGUILayout.TextField ("Token:", token);

			if (GUILayout.Button ("Create config file")) {
				CreateConfigFile (appId, token);
			}

			GUILayout.Label ("Create VRiticsSetup GameObject in one of the scenes that will be used.", EditorStyles.wordWrappedLabel);
			EditorGUILayout.Space ();
			GUILayout.Label ("The best practice is to put this GameObject on a scene that will be run first e.g. main menu.", EditorStyles.wordWrappedLabel);
			GUILayout.Label ("Following button will create the VRiticsSetup GameObject in currently open scene.", EditorStyles.wordWrappedLabel);

			if (GUILayout.Button ("Create setup GameObject")) {
				var setupObject = new GameObject ("VRiticsSetup");
				var vRiticsSetup = setupObject.AddComponent<VRiticsSetup> ();
				vRiticsSetup.configFile = configFile;
			}

			GUILayout.Label ("Create VRiticsSession GameObject in the scene where you want collect the analytics data.", EditorStyles.wordWrappedLabel);
			sessionName = EditorGUILayout.TextField ("SessionName:", sessionName);

			if (GUILayout.Button ("Create session GameObject")) {
				var setupObject = new GameObject ("VRiticsSession");
				var vRiticsSession = setupObject.AddComponent<EventsSessionRecorder> ();
				vRiticsSession.sessionName = sessionName;
			}
			//
			// EditorGUILayout.Space ();
			// if (GUILayout.Button ("Open full manual file")) {
			// 	Application.OpenURL (Path.GetFullPath("Packages/com.vritics-project.vriticsunityplugin/Documentation/VRiticsManual.pdf"));
			// }
		}

		void CreateConfigFile (string appId, string token) {
			var myScriptableObject = CreateInstance<VRiticsConfigFile> ();

			myScriptableObject.AppId = appId;
			myScriptableObject.Token = token;

			string path = EditorUtility.SaveFilePanel ("Create VRiticsConfigFile", "Assets", "VRiticsConfig", "asset");
			if (!string.IsNullOrEmpty (path)) {
				path = FileUtil.GetProjectRelativePath (path);
				AssetDatabase.CreateAsset (myScriptableObject, path);
				AssetDatabase.SaveAssets ();
				AssetDatabase.Refresh ();
				EditorUtility.FocusProjectWindow ();
				Selection.activeObject = myScriptableObject;
			}

			configFile = myScriptableObject;
		}

		[MenuItem ("VRitics/Introduction")]
		public static void ShowWindow () {
			GetWindow (typeof (VRiticsIntroduction), false, "Plugin Intro");
		}
	}
}
