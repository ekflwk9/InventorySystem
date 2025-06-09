using System.Collections.Generic;
using UnityEngine;

public class InventoryUi : UiBase
{
    [SerializeField] private Slot[] slot;

    public override void Init()
    {
        var tempList = new List<Slot>();

        for (int i = 0; i < this.transform.childCount; i++)
        {
            var child = this.transform.GetChild(i);
            var component = child.GetComponent<Slot>();

            if (component != null) tempList.Add(component);
        }

        slot = new Slot[tempList.Count];

        for (int i = 0; i < tempList.Count; i++)
        {
            slot[i] = tempList[i];
        }

        var inventory = FindObjectOfType<Inventory>();

        if (inventory != null) inventory.Init(slot.Length);
        else Service.Log("현재 Inventory 컴포넌트가 존재하는 오브젝트가 없음");
    }

    private void Start()
    {
        UiManager.Instance.Add<InventoryUi>(this);
    }

    public void SetInventoryView(int _slotIndex)
    {
        slot[_slotIndex].SetView(_slotIndex);
    }
}