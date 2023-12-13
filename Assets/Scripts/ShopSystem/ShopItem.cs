using Assets.Scripts.ShopSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

public class ShopItem : MonoBehaviour, IShopItem
{
    public static event Action<ShopItem> OnShopItemClick;

    public string ItemName { get => itemName; }
    public BigInteger ItemCost { get => itemCost; }
    public int ItemLevel { get => itemLevel; }
    public BigInteger ItemBaseCost { get => BigInteger.Parse(itemBaseCost); }
    public ItemShopType ItemType { get => itemType; }
    public string ItemShopProfit { get => itemShopProfit; }

    [SerializeField]
    private float costMultiplier = 1.07f;

    [SerializeField]
    private string itemName;

    [SerializeField]
    private ItemShopType itemType;

    [SerializeField]
    private string itemBaseCost;

    [SerializeField]
    private string itemShopProfit;

    [SerializeField]
    private TextMeshProUGUI costLabel;

    private BigInteger itemCost;
    private int itemLevel;
    public void BuyItem()
    {
        OnShopItemClick?.Invoke(this);
        itemLevel++;
        var costMultiplier = Mathf.Pow(this.costMultiplier, itemLevel);
        var itemCostDouble = (double)ItemCost * costMultiplier;
        itemCost = new BigInteger(itemCostDouble);
        UpdateUI();
        SaveBuyedItem();
    }

    public void SaveBuyedItem()
    {
        PlayerPrefs.SetString(itemName + "Cost", itemCost.ToString());
        PlayerPrefs.SetString(itemName + "Level", itemLevel.ToString());
    }

    public void Start()
    {
        itemCost = BigInteger.Parse(PlayerPrefs.GetString(itemName + "Cost", itemBaseCost));
        itemLevel = PlayerPrefs.GetInt(itemName + "Level", 1);
        UpdateUI();
    }

    private void UpdateUI()
    {
        costLabel.text = IntToStringConverter.Int2String(itemCost);
    }
}
