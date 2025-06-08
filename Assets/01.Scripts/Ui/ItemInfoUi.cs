using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoUi : MonoBehaviour, IValueUi<bool>, IValueUi<int>
{
    [SerializeField] private TMP_Text itemInfo;
    [SerializeField] private TMP_Text itemName;

    private void Reset()
    {
        itemName = this.TryGetChildComponent<TMP_Text>(StringMap.Name);
        itemInfo = this.TryGetChildComponent<TMP_Text>(StringMap.Info);
    }

    private void Awake()
    {
        this.gameObject.SetActive(false);
        UiManager.Add(UiType.ItemInfo, this);
    }

    public void SetValue(bool _value)
    {
        this.gameObject.SetActive(_value);
    }

    public void SetValue(int _value)
    {
        var item = ItemManager.GetItem(_value);

        itemName.text = item.name;
        itemInfo.text = item.info;
    }
}