using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public int itemId { get; private set; }
    private int count;

    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text countText;

    private void Reset()
    {
        icon = this.TryGetChildComponent<Image>(StringMap.Icon);
        if (icon != null) icon.color = Color.clear;

        countText = this.TryGetChildComponent<TMP_Text>(StringMap.Count);
        if (countText != null) countText.text = "";
    }

    public void SetSlot(int _itemId)
    {
        if (_itemId != 0)
        {
            var item = ItemManager.GetItem(_itemId);

            itemId = item.id;
            count = 1;
            icon.sprite = item.icon;
            icon.color = Color.white;
        }

        else if (itemId == _itemId && count > 1)
        {
            count++;
            countText.text = count.ToString();
        }

        else
        {
            itemId = 0;
            count = 0;
            countText.text = "";
            icon.color = Color.clear;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (itemId != 0)
        {
            UiManager.Active(UiType.Drag, true);
            UiManager.SetInt(UiType.Drag, itemId);
            UiManager.Active(UiType.ItemInfo, false);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        UiManager.UpdateUi(UiType.Drag);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        UiManager.Active(UiType.Drag, false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (itemId != 0)
        {
            UiManager.Active(UiType.ItemInfo, true);
            UiManager.SetInt(UiType.ItemInfo, itemId);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (itemId != 0)
        {
            UiManager.Active(UiType.ItemInfo, false);
        }
    }
}
