using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotUi : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    protected bool isFull;

    [field: SerializeField] public ItemType type { get; private set; }
    [SerializeField] protected int slotIndex;

    [SerializeField] protected Image icon;
    [SerializeField] protected TMP_Text countText;

    public void Init(int _slotIndex)
    {
        slotIndex = _slotIndex;

        icon = this.TryGetChildComponent<Image>(StringMap.Icon);
        if (icon != null) Service.FindRresource<Sprite>(StringMap.Image, StringMap.EmptyItem);

        countText = this.TryGetChildComponent<TMP_Text>(StringMap.Count);
        if (countText != null) countText.text = "";
    }

    /// <summary>
    /// 현재 슬롯 상태 업데이트
    /// </summary>
    /// <param name="_item"></param>
    public void SetView()
    {
        var slot = Inventory.Instance.slot[slotIndex];

        if (slot.item.id == -1)
        {
            isFull = false;
            countText.text = "";
        }

        else
        {
            isFull = true;

            var itemCount = slot.itemCount;

            if (itemCount > 1) countText.text = itemCount.ToString();
            else countText.text = "";
        }

        icon.sprite = slot.item.icon;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isFull)
        {
            UiManager.Instance.Get<DragUi>().LastSlot(slotIndex);
            UiManager.Instance.Show<ItemInfoUi>(false);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isFull) UiManager.Instance.Get<DragUi>().FollowMouse();
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        if (isFull)
        {
            UiManager.Instance.Get<DragUi>().EndDrag();
            UiManager.Instance.Show<ItemInfoUi>(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isFull)
        {
            UiManager.Instance.Show<ItemInfoUi>(true);
            UiManager.Instance.Get<ItemInfoUi>().SetInfo(slotIndex);
        }

        UiManager.Instance.Get<DragUi>().NextSlot(slotIndex);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isFull) UiManager.Instance.Show<ItemInfoUi>(false);
        UiManager.Instance.Get<DragUi>().NextSlot(-1);
    }
}
