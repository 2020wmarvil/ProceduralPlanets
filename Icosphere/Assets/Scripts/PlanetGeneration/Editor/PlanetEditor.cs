using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Planet))]
public class PlanetEditor : Editor {
	Planet planet;

	Editor shapeEditor;
	Editor colorEditor;

	private void OnEnable() {
		planet = (Planet)target;
	}

	public override void OnInspectorGUI() {
		using (var check = new EditorGUI.ChangeCheckScope()) {
			base.OnInspectorGUI();
			if (check.changed) {
				planet.GeneratePlanet();
			}
		}

		if (GUILayout.Button("Generate Planet")) {
			planet.GeneratePlanet();
		}

		DrawSettingsEditor(planet.shapeSettings, planet.OnShapeSettingsUpdated, ref planet.shapeSettingsFoldout, ref shapeEditor);
		DrawSettingsEditor(planet.colorSettings, planet.OnColorSettingsUpdated, ref planet.colorSettingsFoldout, ref colorEditor);
	}

	void DrawSettingsEditor(Object settings, System.Action onSettingsUpdated, ref bool foldout, ref Editor editor) {
		if (settings == null) return;

		foldout = EditorGUILayout.InspectorTitlebar(foldout, settings);

		using (var check = new EditorGUI.ChangeCheckScope()) {
			if (foldout) {
				CreateCachedEditor(settings, null, ref editor);
				editor.OnInspectorGUI();

				if (check.changed) {
					if (onSettingsUpdated != null) {
						onSettingsUpdated();
					}
				}
			}
		}
	}
}
