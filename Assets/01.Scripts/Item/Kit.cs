using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kit : Item
{
    public override int id { get; protected set; } = 101;
    public override string info { get; protected set; } = "회복 키트";
    public override string itemName { get; protected set; } = "의료용 키트";
    public override int value { get; protected set; } = 10;
    public override int maxCount { get; protected set; } = 10;
    public override ItemType type { get; protected set; } = ItemType.None;
}
