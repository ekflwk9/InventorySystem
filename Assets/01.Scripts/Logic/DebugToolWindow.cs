using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public class DebugToolWindow : EditorWindow
{
    [MenuItem("Window/DebugTool")]
    public static void ShowWindow()
    {
        GetWindow<DebugToolWindow>("DebugTool");
    }

    private void OnGUI()
    {
        GUILayout.Label("디버그 전용 패널");

        if (GUILayout.Button("일반 아이템 획득")) GetItem();
        else if (GUILayout.Button("볼륨 아이템 획득")) VolumeGetItem();
    }

    private void GetItem()
    {

    }

    private void VolumeGetItem()
    {

    }
}
#endif
