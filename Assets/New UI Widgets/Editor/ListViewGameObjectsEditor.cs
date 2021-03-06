namespace UIWidgets
{
	using System;
	using System.Collections.Generic;
	using UnityEditor;
	using UnityEngine;

	/// <summary>
	/// ListViewGameObjects editor.
	/// </summary>
	[CanEditMultipleObjects]
	#pragma warning disable 0618
	[CustomEditor(typeof(ListViewGameObjects), true)]
	#pragma warning restore 0618
	public class ListViewGameObjectsEditor : Editor
	{
		Dictionary<string, SerializedProperty> serializedProperties = new Dictionary<string, SerializedProperty>();

		string[] properties = new string[]
		{
			"objects",

			"DestroyGameObjects",
			"multipleSelect",
			"selectedIndex",

			"Container",
			"Navigation",
		};

		/// <summary>
		/// Init.
		/// </summary>
		protected virtual void OnEnable()
		{
			Array.ForEach(properties, x => serializedProperties.Add(x, serializedObject.FindProperty(x)));
		}

		/// <summary>
		/// Draw inspector GUI.
		/// </summary>
		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			Array.ForEach(properties, x => { EditorGUILayout.PropertyField(serializedProperties[x], true); });

			serializedObject.ApplyModifiedProperties();
		}
	}
}