using Assets.Scripts.ShopSystem;
using System;
using TMPro;
using UnityEngine;
using YG;

public class ShopItem : MonoBehaviour, IShopItem
{
    public static event Action<ShopItem> OnShopItemClick;

    public string ItemName { get => itemName; }
    public ulong ItemCost { get => itemCost; }
    public int ItemLevel { get => itemLevel; }
    public ulong ItemBaseCost { get => ulong.Parse(itemBaseCost); }
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

    [SerializeField]
    private ShopItemData shopitemData;

    private ulong itemCost;
    private int itemLevel;
    private void OnEnable() => YandexGame.GetDataEvent += InitShopItem;

    private void OnDisable() => YandexGame.GetDataEvent -= InitShopItem;
    public void BuyItem()
    {
        OnShopItemClick?.Invoke(this);
        itemLevel++;
        var costMultiplier = Mathf.Pow(this.costMultiplier, itemLevel);
        var itemCostDouble = (double)ItemCost * costMultiplier;
        itemCost = (ulong)itemCostDouble;
        UpdateUI();
        SaveBuyedItem();
    }

    public void SaveBuyedItem()
    {
        shopitemData.shopItemDataBase.SetFieldValue(itemName + "Cost", itemCost.ToString());
        shopitemData.shopItemDataBase.SetFieldValue(itemName + "Level", itemLevel);
        
        YandexGame.savesData.shopItemDataJson = shopitemData.shopItemDataBase.ToString();
        YandexGame.SaveProgress();
    }

    public void Start()
    {
        if (YandexGame.SDKEnabled)
        {
            InitShopItem();
        }
    }

    private void InitShopItem()
    {
        if (!ulong.TryParse(shopitemData.shopItemDataBase.GetFieldValue<string>(itemName + "Cost"), out itemCost))
        {
            itemCost = ulong.Parse(itemBaseCost);
        }

        itemLevel = shopitemData.shopItemDataBase.GetFieldValue<int>(itemName + "Level");
        UpdateUI();
    }

    private void UpdateUI()
    {
        costLabel.text = IntToStringConverter.Int2String(itemCost);
    }
}
