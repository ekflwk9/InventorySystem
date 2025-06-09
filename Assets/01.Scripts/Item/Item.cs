using System.Text;
using UnityEngine;

public enum ItemType
{
    None,
    Armor,
    Weapon,
}

public abstract class Item : MonoBehaviour
{
    public abstract int id { get; protected set; }
    public abstract string info { get; protected set; }
    public abstract string itemName { get; protected set; }
    public abstract int value { get; protected set; }
    public abstract int maxCount { get; protected set; }
    public abstract ItemType type { get; protected set; }
    [field: SerializeField] public Sprite icon { get; private set; }

    private void Reset()
    {
        icon = Service.FindRresource<Sprite>(StringMap.Image, this.name);
    }
}