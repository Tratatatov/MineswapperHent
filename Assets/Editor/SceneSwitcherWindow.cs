using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Collections.Generic;
using System.IO;

public class SceneSwitcherWindow : EditorWindow
{
    // Список сцен для отображения
    private List<string> scenePaths = new List<string>();
    private List<string> sceneNames = new List<string>();

    [MenuItem("Tools/Scene Switcher")] // Добавляем пункт меню для открытия окна
    static void Init()
    {
        SceneSwitcherWindow window = (SceneSwitcherWindow)EditorWindow.GetWindow(typeof(SceneSwitcherWindow));
        window.titleContent = new GUIContent("Scene Switcher");
        window.Show();
    }

    void OnEnable()
    {
        // Загружаем список сцен при открытии окна
        RefreshSceneList();
    }

    void RefreshSceneList()
    {
        scenePaths.Clear();
        sceneNames.Clear();

        // Ищем все файлы сцен в проекте
        string[] guids = AssetDatabase.FindAssets("t:Scene");
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            scenePaths.Add(path);
            sceneNames.Add(Path.GetFileNameWithoutExtension(path));
        }
    }

    void OnGUI()
    {
        GUILayout.Label("Select a scene to load:", EditorStyles.boldLabel);

        // Кнопка для обновления списка сцен
        if (GUILayout.Button("Refresh Scenes"))
        {
            RefreshSceneList();
        }

        // Отображаем кнопки для каждой сцены
        for (int i = 0; i < sceneNames.Count; i++)
        {
            if (GUILayout.Button(sceneNames[i]))
            {
                // Загружаем выбранную сцену
                if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                {
                    EditorSceneManager.OpenScene(scenePaths[i]);
                }
            }
        }
    }
}