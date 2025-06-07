using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ui종류 없을 경우 추가
/// </summary>
public enum UiType
{
    None,
    VolumeInventory,
    Drag,
}

public static class UiManager
{
    private static Dictionary<UiType, IUpdateUi> update = new Dictionary<UiType, IUpdateUi>();
    private static Dictionary<UiType, IActiveUi> active = new Dictionary<UiType, IActiveUi>();

    public static void Add<T> (UiType _type, T _ui) where T : class
    {
        if(_ui is IUpdateUi isUpdate)
        {
            if (!update.ContainsKey(_type)) update.Add(_type, isUpdate);
            else Service.Log($"{_type}키로 이미 추가된 상태");
        }

        if (_ui is IActiveUi isActive)
        {
            if (!active.ContainsKey(_type)) active.Add(_type, isActive);
            else Service.Log($"{_type}키로 이미 추가된 상태");
        }
    }
    
    public static void UpdateUi(UiType _type)
    {
        if (update.ContainsKey(_type)) update[_type].OnUpdateUi();
        else Service.Log($"{_type}키로 추가된 IUpdateUi는 존재하지 않음");
    }

    public static void Active(UiType _type, bool _isActive)
    {
        if (active.ContainsKey(_type)) active[_type].OnActive(_isActive);
        else Service.Log($"{_type}키로 추가된 IActive는 존재하지 않음");
    }
}
