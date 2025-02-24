using UnityEditor;
using UnityEditor.SceneManagement;
public class EditorScenesSwitcher : EditorWindow
{
    [MenuItem("Actions/SwitchScene/ToBootScene")]
    public static void OpenBootScene()
    {
       
        EditorSceneManager.OpenScene("Assets/DashRunner/Game/Scenes/BootScene.unity");
    }
    [MenuItem("Actions/SwitchScene/ToMainMenuScene")]
    public static void OpenMainMenuScene()
    {
        EditorSceneManager.OpenScene("Assets/DashRunner/Game/Scenes/MainMenuScene.unity");
    }
    [MenuItem("Actions/SwitchScene/ToGameScene")]
    public static void OpenGameScene()
    {
        EditorSceneManager.OpenScene("Assets/DashRunner/Game/Scenes/GameScene.unity");
    }
}
