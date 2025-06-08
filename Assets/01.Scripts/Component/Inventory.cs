using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> item = new();

    public void GetItem(int _itemId)
    {
        var gameItem = ItemManager.GetItem(_itemId);
        item.Add(gameItem);

        UiManager.SetInt(UiType.Inventory, _itemId);
    }
}
