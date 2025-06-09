using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private int itemId = -1;

    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text countText;

    private void Reset()
    {
        icon = this.TryGetChildComponent<Image>(StringMap.Icon);
        if (icon != null) Service.FindRresource<Sprite>(StringMap.Image, StringMap.EmptyItem);

        countText = this.TryGetChildComponent<TMP_Text>(StringMap.Count);
        if (countText != null) countText.text = "";
    }

    /// <summary>
    /// 현재 슬롯 상태 업데이트
    /// </summary>
    /// <param name="_item"></param>
    public void SetView(int _slotIndex)
    {
        var item = Inventory.instance.item[_slotIndex];

        if (item.id == -1)
        {
            countText.text = "";
        }

        else
        {
            var itemCount = Inventory.instance.count[_slotIndex];
            if (itemCount > 1) countText.text = itemCount.ToString();
        }

        itemId = item.id;
        icon.sprite = item.icon;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (itemId != -1)
        {
            UiManager.Instance.Get<DragUi>().SetIcon(itemId);
            UiManager.Instance.Show<DragUi>(true);
            UiManager.Instance.Show<ItemInfoUi>(false);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        UiManager.Instance.Get<DragUi>().FollowMouse();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        UiManager.Instance.Show<DragUi>(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (itemId != -1)
        {
            var item = ItemManager.GetItem(itemId);

            UiManager.Instance.Show<ItemInfoUi>(true);
            UiManager.Instance.Get<ItemInfoUi>().SetInfo(item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (itemId != -1)
        {
            UiManager.Instance.Show<ItemInfoUi>(false);
        }
    }
}
