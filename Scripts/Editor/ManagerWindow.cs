using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace WizardsCode.Profile
{
    public class ManagerWindow : EditorWindow
    {
        string playButtonText = "Play";

        string statusText = "Idle";

        int selectedProfileIndex = 0;

        [MenuItem("Window/Wizards Code/Manager Window")]
        static void Init()
        {
            ManagerWindow window = (ManagerWindow)EditorWindow.GetWindow(typeof(ManagerWindow));
            window.titleContent = new GUIContent("Manager Wizard");
            window.Show();
        }

        void OnGUI()
        {
            EditorGUILayout.LabelField("Playback", EditorStyles.boldLabel);
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Status: ", statusText);
            if (GUILayout.Button(playButtonText))
            {
                if (EditorApplication.isPlaying)
                {
                    Stop();
                }
                else
                {
                    Play();
                }
            }
            EditorGUILayout.EndHorizontal();

            string[] profiles = Enum.GetNames(typeof(GameObjectProfileManager.Profiles)) as string[];
            selectedProfileIndex = EditorGUILayout.Popup(
                "Selected Profile:",
                selectedProfileIndex,
                profiles
                );

            if (GUILayout.Button("Configure Scene"))
            {
                ConfigureScene();
            }
        }

        private void Play()
        {
            ConfigureScene();
            EditorApplication.isPlaying = true;
            playButtonText = "Stop";
            statusText = "Playing";
        }

        private void Stop()
        {
            EditorApplication.isPlaying = false;
            statusText = "Idle";
            playButtonText = "Play with selected profile";
        }

        private void ConfigureScene()
        {
            GameObjectProfileManager[] all = Resources.FindObjectsOfTypeAll(typeof(GameObjectProfileManager)) as GameObjectProfileManager[];
            foreach(GameObjectProfileManager obj in all)
            {
                obj.Configure((GameObjectProfileManager.Profiles)Enum.ToObject(typeof(GameObjectProfileManager.Profiles), selectedProfileIndex));
            }
        }
    }
}