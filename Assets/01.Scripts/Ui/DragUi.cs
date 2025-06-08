using UnityEngine;
using UnityEngine.UI;

public class DragUi : MonoBehaviour, IValueUi<int>, IValueUi<bool>, IUpdateUi
{
    [SerializeField] private Image icon;

    private void Reset()
    {
        icon = this.TryGetComponent<Image>();
        if (icon != null) icon.color = Color.clear;
    }

    private void Awake()
    {
        UiManager.Add(UiType.Drag, this);
    }

    public void OnUpdateUi()
    {
        this.transform.position = Input.mousePosition;
    }

    public void SetValue(bool _value)
    {
        icon.color = _value ? Color.white : Color.clear;
    }

    public void SetValue(int _value)
    {
        icon.sprite = ItemManager.GetItem(_value).icon;
    }
}
