using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }
    [field: SerializeField] public Slot[] slot { get; private set; }

    public void Init(SlotUi[] _slotUi)
    {
        slot = new Slot[_slotUi.Length];

        if (Inventory.Instance == null)
        {
            Inventory.Instance = this;
            var empty = Service.FindRresource<Item>(StringMap.Item, StringMap.EmptyItem);

            for (int i = 0; i < _slotUi.Length; i++)
            {
                slot[i] = new Slot(_slotUi[i].type, empty);
            }
        }
    }

    /// <summary>
    /// 아이템 획득시
    /// </summary>
    /// <param name="_itemId"></param>
    public bool GetItem(int _itemId)
    {
        var gameItem = ItemManager.GetItem(_itemId);

        for (int i = 0; i < slot.Length; i++)
        {
            //재료 / 최대 획득 카운트가 아닐 경우
            if (slot[i].item.id == _itemId && gameItem.type == ItemType.None && slot[i].itemCount < gameItem.maxCount)
            {
                slot[i].GetCount();
                UiManager.Instance.Get<InventoryUi>().SetInventoryView(i);
                return true;
            }

            //슬롯에 장비가 없을 경우
            else if (slot[i].item.id == -1)
            {
                slot[i].GetItem(_itemId);
                slot[i].GetCount();
                UiManager.Instance.Get<InventoryUi>().SetInventoryView(i);
                return true;
            }
        }

        return false;
    }

    public void RefreshSlot(int _lastSlot, int _nextSlot)
    {
        var lastItemCount = slot[_lastSlot].itemCount;
        var nextItemCount = slot[_nextSlot].itemCount;

        //아이템이 같음 / 재료, 소모품일 경우
        if (slot[_lastSlot].item.id == slot[_nextSlot].item.id && slot[_nextSlot].item.type == ItemType.None)
        {
            var resultCount = slot[_nextSlot].GetCount(lastItemCount + nextItemCount);

            if (resultCount == 0) slot[_lastSlot].GetItem(-1);

            slot[_lastSlot].GetCount(resultCount);
        }

        //장비 또는 서로 다를 경우 맞교환
        else
        {
            var lastItemId = slot[_lastSlot].item.id;
            var nextItemId = slot[_nextSlot].item.id;

            if (slot[_lastSlot].CheckSlot(nextItemId) && slot[_nextSlot].CheckSlot(lastItemId))
            {
                slot[_lastSlot].GetItem(nextItemId);
                slot[_nextSlot].GetItem(lastItemId);

                slot[_lastSlot].GetCount(nextItemCount);
                slot[_nextSlot].GetCount(lastItemCount);
            }
        }

        //Ui 업데이트
        var inventoryUi = UiManager.Instance.Get<InventoryUi>();

        inventoryUi.SetInventoryView(_lastSlot);
        inventoryUi.SetInventoryView(_nextSlot);
    }
}
