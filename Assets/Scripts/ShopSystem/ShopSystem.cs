using Assets.Scripts.ShopSystem;
using System;
using System.Numerics;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    public static Action OnUINeedUpdated;
    [SerializeField]
    private ScoreData scoreData;
    private void Start()
    {
        ShopItem.OnShopItemClick += ProcessPurchaseTransaction;
    }

    private void ProcessPurchaseTransaction(ShopItem item)
    {
        switch (item.ItemType)
        {
            case ItemShopType.Click:
                scoreData.ClickScore += BigInteger.Parse(item.ItemShopProfit);
                break;
            case ItemShopType.AutoClick:
                scoreData.IdleScore += BigInteger.Parse(item.ItemShopProfit);
                break;
        }
        scoreData.CurrentScore -= item.ItemCost;
        scoreData.SaveScoreData();
        OnUINeedUpdated?.Invoke();
    }
}
