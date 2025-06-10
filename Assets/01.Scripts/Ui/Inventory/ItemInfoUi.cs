using TMPro;
using UnityEngine;

public class ItemInfoUi : UiBase
{
    [SerializeField] private TMP_Text itemInfo;
    [SerializeField] private TMP_Text itemName;

    public override void Init()
    {
        itemName = this.TryGetChildComponent<TMP_Text>(StringMap.Name);
        itemInfo = this.TryGetChildComponent<TMP_Text>(StringMap.Info);
    }

    private void Start()
    {
        UiManager.Instance.Add<ItemInfoUi>(this);
        this.gameObject.SetActive(false);
    }

    public void SetInfo(int _slotIndex)
    {
        var slot = Inventory.Instance.slot[_slotIndex];

        itemInfo.text = slot.item.info;
        itemName.text = slot.item.itemName;

        this.transform.position = Input.mousePosition;
    }
}