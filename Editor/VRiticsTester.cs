#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace VRitics {
	public class VRiticsTester : EditorWindow {
		void OnGUI () {
			GUILayout.Label ("Collider Settings", EditorStyles.boldLabel);
			if (GUILayout.Button ("Test Connection")) {
			}
		}

		[MenuItem ("VRitics/Connection Tester")]
		public static void ShowWindow () {
			var window = (VRiticsTester)GetWindow (typeof (VRiticsTester));
			window.Show ();
		}
	}
}
#endif
