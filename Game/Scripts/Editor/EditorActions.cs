using UnityEngine;
using UnityEditor;
public class EditorActions : EditorWindow
{
    [MenuItem("Actions/ResetProgress")]
    public static void ResetProgress()
    {
        Debug.Log("Reset progress");
    }
}
