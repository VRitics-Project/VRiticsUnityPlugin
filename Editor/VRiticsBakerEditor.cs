#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace VRitics {
	public class VRiticsBakerEditor : EditorWindow {
		static float _scale;
		static Vector3 _offset;
		static VRiticsBaker.MeshColliderType _meshColliderType;

		VRiticsBakerEditor () {
			VRiticsBaker.CopyPasteComponent += CopyPasteComponent;
			VRiticsBaker.SetDirty += SetDirtyGo;
		}

		~VRiticsBakerEditor () {
			VRiticsBaker.CopyPasteComponent -= CopyPasteComponent;
			VRiticsBaker.SetDirty -= SetDirtyGo;
		}
		
		void OnGUI () {
			GUILayout.Label ("Collider Settings", EditorStyles.boldLabel);
			_scale = EditorGUILayout.Slider ("Scale", _scale, 1f, 10);
			_offset = EditorGUILayout.Vector3Field ("Offset", _offset);
			_meshColliderType = (VRiticsBaker.MeshColliderType)EditorGUILayout.EnumPopup ("Mesh Collider Type", _meshColliderType);
			if (GUILayout.Button ("Bake")) {
				VRiticsBaker.BakeCollision (Selection.activeGameObject, _meshColliderType, _offset, _scale);
			}
		}

		[MenuItem ("VRitics/Collision Baker")]
		public static void ShowWindow () {
			var window = (VRiticsBakerEditor)GetWindow (typeof (VRiticsBakerEditor));
			window.Show ();
		}

		static void CopyPasteComponent (VRiticsCollision vRiticsCollision, Component component) {
			ComponentUtility.CopyComponent (component);
			ComponentUtility.PasteComponentAsNew (vRiticsCollision.ColliderGO);
		}

		static void SetDirtyGo (GameObject go) {
			EditorUtility.SetDirty (go);
		}
	}
}
#endif
