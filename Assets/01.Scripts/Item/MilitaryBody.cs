using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryBody : Item
{
    public override int id { get; protected set; } = 100;
    public override string info { get; protected set; } = "군용 전용 조끼";
    public override string itemName { get; protected set; } = "전투 조끼";
    public override int value { get; protected set; } = 5;
    public override int maxCount { get; protected set; } = 1;
    public override ItemType type { get; protected set; } = ItemType.Armor;
}
