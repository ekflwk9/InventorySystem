using System.Collections.Generic;
using UnityEngine;

public class InventoryUi : MonoBehaviour, IValueUi<int>
{
    [SerializeField] private Slot[] slot;

    private void Reset()
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
    }

    private void Awake()
    {
        UiManager.Add(UiType.Inventory, this);
    }

    public void SetValue(int _value)
    {
        for (int i = 0; i < slot.Length; i++)
        {
            var slotItem = slot[i].itemId;

            if (slotItem == 0 || slotItem == _value)
            {
                slot[i].SetSlot(_value);
                break;
            }
        }
    }
}