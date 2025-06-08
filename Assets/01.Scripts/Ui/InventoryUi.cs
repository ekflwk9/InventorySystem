using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUi : MonoBehaviour, IValueUi<int>
{
    [SerializeField] private Slot[] slot;
    public bool isOutRange { get; private set; } = false;

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
        var item = ItemManager.GetItem(_value);

        for (int i = 0; i < slot.Length; i++)
        {
            slot[i].SetSlot(item);
            break;
        }
    }

    public void OutRangeMouse(bool _isOut)
    {
        isOutRange = _isOut;
    }
}