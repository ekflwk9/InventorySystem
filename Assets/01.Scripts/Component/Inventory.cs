using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }
    [field: SerializeField] public Slot[] slot { get; private set; }
    [field: SerializeField] public int[] count { get; private set; }

    public void Init(int _slotLength)
    {
        slot = new Slot[_slotLength];
        count = new int[_slotLength];
    }

    private void Awake()
    {
        if (Inventory.Instance == null)
        {
            Inventory.Instance = this;
            var empty = Service.FindRresource<Item>(StringMap.Item, StringMap.EmptyItem);

            for (int i = 0; i < slot.Length; i++)
            {
                slot[i] = new Slot(ItemType.None, empty);
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
            if (count[i] < gameItem.maxCount)
            {
                if (slot[i].item.id == _itemId)
                {
                    count[i]++;
                    UiManager.Instance.Get<InventoryUi>().SetInventoryView(i);
                    return true;
                }

                else if (slot[i].item.id == -1)
                {
                    count[i]++;
                    slot[i].GetItem(gameItem);
                    UiManager.Instance.Get<InventoryUi>().SetInventoryView(i);
                    return true;
                }
            }
        }

        return false;
    }

    public void RefreshSlot(int _lastSlot, int _nextSlot)
    {
        //아이템이 같음 / 재료, 소모품일 경우
        if (slot[_lastSlot].item.id == slot[_nextSlot].item.id && slot[_nextSlot].item.type == ItemType.None)
        {
            var upCount = count[_lastSlot] + count[_nextSlot];

            //현재 최대 획득 카운트를 넘겼을 경우
            if (upCount > slot[_nextSlot].item.maxCount)
            {
                count[_lastSlot] = upCount - slot[_nextSlot].item.maxCount;
                count[_nextSlot] = slot[_nextSlot].item.maxCount;
            }

            //모두 합칠 수 있는 상황일 경우
            else
            {
                slot[_lastSlot].GetItem(-1);
                count[_lastSlot] = 0;

                count[_nextSlot] = upCount;
            }
        }

        //장비 또는 서로 다를 경우 맞교환
        else
        {
            var tempItem = slot[_lastSlot];
            var tempCount = count[_lastSlot];

            slot[_lastSlot] = slot[_nextSlot];
            slot[_nextSlot] = tempItem;

            count[_lastSlot] = count[_nextSlot];
            count[_nextSlot] = tempCount;
        }

        //Ui 업데이트
        var inventoryUi = UiManager.Instance.Get<InventoryUi>();

        inventoryUi.SetInventoryView(_lastSlot);
        inventoryUi.SetInventoryView(_nextSlot);
    }
}
