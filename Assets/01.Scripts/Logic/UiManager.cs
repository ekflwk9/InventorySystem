using System;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance { get; private set; }
    private Dictionary<Type, UiBase> ui = new();

    private void Reset()
    {
        var uiBase = this.transform.GetComponentsInChildren<UiBase>();

        for (int i = 0; i < uiBase.Length; i++)
        {
            uiBase[i].Init();
        }
    }

    private void Awake()
    {
        if (UiManager.Instance == null)
        {
            UiManager.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Add<T>(UiBase _ui) where T : UiBase
    {
        var type = typeof(T);

        if (!ui.ContainsKey(type)) ui.Add(type, _ui);
        else Service.Log($"{_ui.name}은 이미 추가된 Ui");
    }

    public T Get<T>() where T : UiBase
    {
        var type = typeof(T); 

        if (ui.ContainsKey(type))
        {
            return ui[type] as T;
        }

        else
        {
            Service.Log($"{type.Name}이라는 Ui는 추가된적이 없음");
            return null;
        }
    }

    public void Show<T>(bool _isActive) where T : UiBase
    {
        var type = typeof(T);

        if (ui.ContainsKey(type)) ui[type].Show(_isActive);
        else Service.Log($"{type.Name}이라는 Ui는 추가된적이 없음");
    }
}
