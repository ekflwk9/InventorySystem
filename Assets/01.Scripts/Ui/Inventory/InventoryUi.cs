using System.Collections.Generic;
using UnityEngine;

public class InventoryUi : UiBase
{
    [SerializeField] private SlotUi[] slot;

    public override void Init()
    {
        slot = this.transform.GetComponentsInChildren<SlotUi>();
        var inventory = FindObjectOfType<Inventory>();

        if (inventory != null) inventory.Init(slot.Length);
        else Service.Log("현재 Inventory 컴포넌트가 존재하는 오브젝트가 없음");

        for (int i = 0; i < slot.Length; i++)
        {
            slot[i].Init(i);
        }
    }

    private void Start()
    {
        UiManager.Instance.Add<InventoryUi>(this);
        this.gameObject.SetActive(false);
    }

    public void SetInventoryView(int _slotIndex)
    {
        slot[_slotIndex].SetView();
    }
}