using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public int itemId { get; private set; }
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text count;

    private void Reset()
    {
        icon = this.TryGetChildComponent<Image>(StringMap.Icon);
        if (icon != null) icon.color = Color.clear;

        count = this.TryGetChildComponent<TMP_Text>(StringMap.Count);
        if (count != null) count.text = "";
    }

    public void SetSlot(Item _item)
    {
        itemId = _item.id;
        icon.sprite = _item.icon;
        icon.color = Color.white;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (itemId != 0)
        {
            UiManager.Active(UiType.Drag, true);
            UiManager.SetInt(UiType.Drag, itemId);
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
