using UnityEngine;
using UnityEngine.UI;

public class DragUi : UiBase
{
    [SerializeField] private Image icon;

    public override void Init()
    {
        icon = this.TryGetComponent<Image>();
        if (icon != null) icon.color = Color.clear;
    }

    private void Start()
    {
        UiManager.Instance.Add<DragUi>(this);
    }

    public void FollowMouse()
    {
        this.transform.position = Input.mousePosition;
    }

    public override void Show(bool _isActive)
    {
        icon.color = _isActive ? Color.white : Color.clear;
    }

    public void SetIcon(int _itemId)
    {
        icon.sprite = ItemManager.GetItem(_itemId).icon;
    }
}
