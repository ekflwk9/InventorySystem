using UnityEngine;
using UnityEngine.UI;

public class DragUi : UiBase
{
    [SerializeField] private Image icon;
    private int lastSlot, nextSlot;

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

    public void LastSlot(int _lastSlot)
    {
        lastSlot = _lastSlot;

        icon.sprite = Inventory.Instance.slot[_lastSlot].item.icon;
        icon.color = Color.white;
    }

    public void NextSlot(int _nextSlot)
    {
        nextSlot = _nextSlot;
    }

    public void EndDrag()
    {
        if (nextSlot != -1)
        {
            if(lastSlot != nextSlot) Inventory.Instance.RefreshSlot(lastSlot, nextSlot);

            UiManager.Instance.Show<ItemInfoUi>(true);
            UiManager.Instance.Get<ItemInfoUi>().SetInfo(nextSlot);
        }

        icon.color = Color.clear;

        nextSlot = -1;
        lastSlot = -1;
    }
}
