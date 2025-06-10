using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public class DebugToolWindow : EditorWindow
{
    [SerializeField] private int itemId;

    [MenuItem("Window/DebugTool")]
    public static void ShowWindow()
    {
        GetWindow<DebugToolWindow>("DebugTool");
    }

    private void OnGUI()
    {
        //GUILayout.Label("디버그 전용 패널");
        //GUILayout.Space(10f);

        itemId = EditorGUILayout.IntField("획득할 아이템 아이디", itemId);

        GUILayout.Space(5f);
        if (GUILayout.Button("아이템 획득")) GetItem();
    }

    private void GetItem()
    {
        Inventory.Instance.GetItem(itemId);
    }
}
#endif
