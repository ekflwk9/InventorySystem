using UnityEngine;

public class Slot
{
    public ItemType type { get; protected set; }
    public Item item { get; protected set; }
    public int itemCount { get; protected set; }

    public Slot(ItemType _type, Item _item)
    {
        type = _type;
        item = _item;
    }

    public bool GetItem(Item _item)
    {
        if (item.type == type)
        {
            item = _item;
            return true;
        }

        else
        {
            return false;
        }
    }

    public bool GetItem(int _itemId)
    {
        var getItem = ItemManager.GetItem(_itemId);

        if (item.type == type)
        {
            item = getItem;
            return true;
        }

        else
        {
            return false;
        }
    }
}
