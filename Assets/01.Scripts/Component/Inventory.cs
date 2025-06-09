using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance { get; private set; }
    [field: SerializeField] public Item[] item { get; private set; }
    [field: SerializeField] public int[] count { get; private set; }

    public void Init(int _slotLength)
    {
        item = new Item[_slotLength];
        count = new int[_slotLength];

        var empty = Service.FindRresource<Item>(StringMap.Item, StringMap.EmptyItem);

        for (int i = 0; i < item.Length; i++)
        {
            item[i] = empty;
        }
    }

    private void Awake()
    {
        if (Inventory.instance == null) Inventory.instance = this;
    }

    /// <summary>
    /// 아이템 획득시
    /// </summary>
    /// <param name="_itemId"></param>
    public bool GetItem(int _itemId)
    {
        var gameItem = ItemManager.GetItem(_itemId);

        for (int i = 0; i < item.Length; i++)
        {
            if (count[i] < gameItem.maxCount)
            {
                if (item[i].id == _itemId)
                {
                    count[i]++;
                    UiManager.Instance.Get<InventoryUi>().SetInventoryView(i);
                    return true;
                }

                else if (item[i].id == -1)
                {
                    count[i]++;
                    item[i] = gameItem;
                    UiManager.Instance.Get<InventoryUi>().SetInventoryView(i);
                    return true;
                }
            }
        }

        return false;
    }

    public void RefreshSlot(int _firstSlot, int _secondSlot)
    {

    }
}
