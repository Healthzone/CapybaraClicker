using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemBuyChecker : MonoBehaviour
{
    [SerializeField]
    private ScoreData scoreData;

    private ShopItem shopItem;
    private Button itemButton;

    private void Start()
    {
        shopItem = GetComponent<ShopItem>();
        itemButton = GetComponent<Button>();
        ClickerScoring.PlayerClicked += CheckItemBuyAbility;
        ShopSystem.OnUINeedUpdated += CheckItemBuyAbility;
    }

    public void CheckItemBuyAbility()
    {
        if (scoreData.ScoreDataBase.CurrentScore >= shopItem.ItemCost)
        {
            itemButton.interactable = true;
        }
        else
        {
            itemButton.interactable = false;
        }
    }
}
