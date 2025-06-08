using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemManager
{
    public static Dictionary<int, Item> item { get; private set; } = new();

    public static void Load()
    {
        var items = Resources.LoadAll<Item>("Item");

        for (int i = 0; i < items.Length; i++)
        {
            if (!item.ContainsKey(items[i].id)) item.Add(items[i].id, items[i]);
            else Service.Log($"{items[i].name}은 이미 추가된 아이템");
        }
    }

    public static Item GetItem(int _id)
    {
        if (item.ContainsKey(_id)) return item[_id];
        else Service.Log($"{_id}번 아이템은 추가된적 없음");

        return null;
    }
}
