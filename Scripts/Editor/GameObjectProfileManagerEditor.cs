using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace WizardsCode.Profile
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(GameObjectProfileManager), true)]
    public class GameObjectProfileManagerEditor : Editor
    {
        GameObjectProfileManager profileManager;
        
        public void OnEnable()
        {
            profileManager = (GameObjectProfileManager)target;
        }

        public override void OnInspectorGUI()
        {
            Toggles("Active", profileManager.active);

            FieldInfo[] fields = target.GetType().GetFields();
            foreach (FieldInfo field in fields)
            {
                if (field.Name != "active")
                {
                    Toggles(field.Name, field.GetValue(target) as bool[]);
                }
            }
        }

        /// <summary>
        /// Displays a Toggle for each of the profiles.
        /// </summary>
        internal void Toggles(string sectionTitle, bool[] values)
        {
            EditorGUILayout.LabelField(sectionTitle, EditorStyles.boldLabel);
            int i = 0;
            foreach (string title in Enum.GetNames(typeof(GameObjectProfileManager.Profiles)))
            {
                values[i] = EditorGUILayout.Toggle(title, values[i]);
                i++;
            }
        }
    }
}
