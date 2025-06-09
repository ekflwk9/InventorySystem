using UnityEngine;

public class EmptyItem : Item
{
    public override int id { get; protected set; } = -1;
    public override string info { get; protected set; } = "";
    public override string itemName { get; protected set; } = "";
    public override int value { get; protected set; } = 0;
    public override int maxCount { get; protected set; } = 0;
    public override ItemType type { get; protected set; } = ItemType.None;
}
