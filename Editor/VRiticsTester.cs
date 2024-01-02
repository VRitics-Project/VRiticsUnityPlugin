#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace VRitics {
	public class VRiticsTester : EditorWindow {
		
		string appId = "";
		string token = "";
		string result = "Use send button to test";

		void OnGUI () {
			GUILayout.Label ("Fill appId and Token info, then click testSession button to verify setup correctness", EditorStyles.boldLabel);
			
			appId = EditorGUILayout.TextField ("AppID:", appId);
			token = EditorGUILayout.TextField ("Token:", token);
			
			if (GUILayout.Button ("Test Connection")) {
				result = "";
				result = EventsSessionRecorder.TestSession (token, appId);
			}
			
			GUILayout.Label ("Result:", EditorStyles.boldLabel);
			GUILayout.Label (result, EditorStyles.boldLabel);
		}

		[MenuItem ("VRitics/Connection Tester")]
		public static void ShowWindow () {
			var window = (VRiticsTester)GetWindow (typeof (VRiticsTester));
			window.Show ();
		}
	}
}
#endif
