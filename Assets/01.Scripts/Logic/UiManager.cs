using System.Collections.Generic;

/// <summary>
/// Ui종류 없을 경우 추가
/// </summary>
public enum UiType
{
    None,
    Inventory,
    Drag,
    ItemInfo,
}

public static class UiManager
{
    private static Dictionary<UiType, IUpdateUi> update = new();
    private static Dictionary<UiType, IValueUi<int>> integer = new();
    private static Dictionary<UiType, IValueUi<bool>> boolean = new();

    public static void Add<T>(UiType _type, T _ui) where T : class
    {
        if (_ui is IUpdateUi isUpdate)
        {
            if (!update.ContainsKey(_type)) update.Add(_type, isUpdate);
            else Service.Log($"{_type}키로 이미 update에 추가된 상태");
        }

        if (_ui is IValueUi<bool> isBoolean)
        {
            if (!boolean.ContainsKey(_type)) boolean.Add(_type, isBoolean);
            else Service.Log($"{_type}키로 이미 Boolean에 추가된 상태");
        }

        if (_ui is IValueUi<int> isInteger)
        {
            if (!integer.ContainsKey(_type)) integer.Add(_type, isInteger);
            else Service.Log($"{_type}키로 이미 Integer에 추가된 상태");
        }
    }

    /// <summary>
    /// Ui 상태 업데이트
    /// </summary>
    /// <param name="_type"></param>
    public static void UpdateUi(UiType _type)
    {
        if (update.ContainsKey(_type)) update[_type].OnUpdateUi();
        else Service.Log($"{_type}키로 추가된 IUpdateUi는 존재하지 않음");
    }

    public static void Active(UiType _type, bool _isActive)
    {
        if (boolean.ContainsKey(_type)) boolean[_type].SetValue(_isActive);
        else Service.Log($"{_type}키로 추가된 IActive는 존재하지 않음");
    }

    public static void SetInt(UiType _type, int _value)
    {
        if (integer.ContainsKey(_type)) integer[_type].SetValue(_value);
        else Service.Log($"{_type}키로 추가된 Integer는 존재하지 않음");
    }
}
