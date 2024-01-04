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
                scoreData.ScoreDataBase.ClickScore += ulong.Parse(item.ItemShopProfit);
                break;
            case ItemShopType.AutoClick:
                scoreData.ScoreDataBase.IdleScore += ulong.Parse(item.ItemShopProfit);
                break;
        }
        scoreData.ScoreDataBase.CurrentScore -= item.ItemCost;
        scoreData.SaveScoreData();
        OnUINeedUpdated?.Invoke();
    }
}
