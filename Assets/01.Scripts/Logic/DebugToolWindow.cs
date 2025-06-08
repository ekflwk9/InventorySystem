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
        //GUILayout.Label("디버그 전용 패널");
        //GUILayout.Space(10f);

        if (GUILayout.Button("일반 아이템 획득")) GetItem();
    }

    private void GetItem()
    {
        GameManager.inventory.GetItem(100);
    }
}
#endif
