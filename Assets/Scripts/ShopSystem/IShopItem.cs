public interface IShopItem
{
    string ItemName { get; }
    ulong ItemCost { get; }
    ulong ItemBaseCost { get; }
    int ItemLevel { get; }
    void BuyItem();
    void SaveBuyedItem();
}
