public class Body : Item
{
    public override int id { get; protected set; } = 103;
    public override string info { get; protected set; } = "일반 조끼";
    public override string itemName { get; protected set; } = "허름한 조끼";
    public override int value { get; protected set; } = 2;
    public override int maxCount { get; protected set; } = 1;
    public override ItemType type { get; protected set; } = ItemType.Armor;
}
