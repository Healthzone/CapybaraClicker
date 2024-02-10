using Assets.Scripts.ShopSystem;
using UnityEngine;
using YG;

public class ShopItemData : MonoBehaviour
{
    public ShopItemDataBase shopItemDataBase { get; set; }

    private void OnEnable()
    {
        shopItemDataBase = new ShopItemDataBase();
    }

    public void Awake()
    {
        if (YandexGame.SDKEnabled)
        {
            InitItemShopData();
        }
    }

    private void InitItemShopData()
    {
        if (YandexGame.savesData.shopItemDataJson != "")
        {
            shopItemDataBase = JsonUtility.FromJson<ShopItemDataBase>(YandexGame.savesData.shopItemDataJson);
        }
    }
}
