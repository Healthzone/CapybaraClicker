using Assets.Scripts.ShopSystem;
using UnityEngine;
using YG;

public class ShopItemData : MonoBehaviour
{
    public ShopItemDataBase shopItemDataBase { get; set; }

    private void OnEnable()
    {
        shopItemDataBase = new ShopItemDataBase();
        YandexGame.GetDataEvent += InitItemShopData;
    }

    private void OnDisable() => YandexGame.GetDataEvent -= InitItemShopData;

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
