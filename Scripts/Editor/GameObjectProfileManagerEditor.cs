using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using WizardsCode.Extension;
using WizardsCode.Tools.DocGen;

namespace WizardsCode.Profile
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(GameObjectProfileManager), true)]
    public class GameObjectProfileManagerEditor : Editor
    {
        GameObjectProfileManager profileManager;

        bool helpExpanded = false;
        
        public void OnEnable()
        {
            profileManager = (GameObjectProfileManager)target;
        }

        public override void OnInspectorGUI()
        {
            List<string> displayed = new List<string>();
            this.DrawDocGenAttributes();

            displayed.Add("m_Script");

            DocGenAttribute docGen;
            FieldInfo[] fields = target.GetType().GetFields();
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType == typeof(Boolean[]))
                {
                    docGen = field.GetCustomAttribute<DocGenAttribute>();
                    if (docGen != null) {
                        Toggles(field.Name, field.GetValue(target) as bool[], docGen.helpText);
                    }
                    else
                    {
                        Toggles(field.Name, field.GetValue(target) as bool[]);
                    }
                    displayed.Add(field.Name);
                }
            }
            DrawPropertiesExcluding(serializedObject, displayed.ToArray());
        }

        /// <summary>
        /// Displays a Toggle for each of the profiles.
        /// </summary>
        internal void Toggles(string sectionTitle, bool[] values, string helpText = null)
        {
            GUIStyle helpStyle = GUI.skin.GetStyle("HelpBox");
            helpStyle.richText = true;

            GUIContent content = new GUIContent(sectionTitle.ToProperCase(), helpText);
            GUIStyle foldoutStyle = EditorStyles.foldoutHeader;
            foldoutStyle.fontStyle = FontStyle.Bold;
            helpExpanded = EditorGUILayout.BeginFoldoutHeaderGroup(helpExpanded, content, foldoutStyle);

            if (helpText != null && helpExpanded)
            {
                EditorGUILayout.TextArea(helpText, helpStyle);
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

            int i = 0;
            foreach (string title in Enum.GetNames(typeof(GameObjectProfileManager.Profiles)))
            {
                values[i] = EditorGUILayout.Toggle(title, values[i]);
                i++;
            }
        }
    }
}
