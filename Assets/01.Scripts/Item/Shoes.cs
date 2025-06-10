public class Shoes : Item
{
    public override int id { get; protected set; } = 102;
    public override string info { get; protected set; } = "군용 신발";
    public override string itemName { get; protected set; } = "전투용 신발";
    public override int value { get; protected set; } = 3;
    public override int maxCount { get; protected set; } = 1;
    public override ItemType type { get; protected set; } = ItemType.Shoes;
}
