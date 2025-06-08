using UnityEngine;

public class LoadComponent : MonoBehaviour
{
    private void Awake()
    {
        ItemManager.Load();
    }
}