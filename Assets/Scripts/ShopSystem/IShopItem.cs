using System.Numerics;

public interface IShopItem
{
    string ItemName { get; }
    BigInteger ItemCost { get; }
    BigInteger ItemBaseCost { get; }
    int ItemLevel { get; }
    void BuyItem();
    void SaveBuyedItem();
}
