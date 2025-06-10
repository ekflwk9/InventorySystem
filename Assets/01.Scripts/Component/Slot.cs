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

    /// <summary>
    /// 아이템 상태 체크
    /// </summary>
    /// <param name="_itemId"></param>
    /// <returns></returns>
    public bool CheckSlot(int _itemId)
    {
        var getItem = ItemManager.GetItem(_itemId);

        //일반 슬롯이거나 / 빈 아이템을 교체 시도 중이거나 / 아이템과 슬롯 타입이 같을 경우에만
        if (type == ItemType.None || _itemId == -1 || type == getItem.type)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// 슬롯 아이템 설정
    /// </summary>
    /// <param name="_itemId"></param>
    /// <returns></returns>
    public void GetItem(int _itemId)
    {
        var getItem = ItemManager.GetItem(_itemId);
        item = getItem;
    }

    /// <summary>
    /// 획득시 증감만 수행
    /// </summary>
    public void GetCount()
    {
        itemCount++;
    }

    /// <summary>
    /// 아이템을 합쳤을 경우 나머지 구하기
    /// </summary>
    /// <param name="_getCount"></param>
    /// <returns></returns>
    public int GetCount(int _getCount)
    {
        if (_getCount > item.maxCount)
        {
            itemCount = item.maxCount;
            return _getCount - item.maxCount;
        }

        else
        {
            itemCount = _getCount;
            return 0;
        }
    }
}
