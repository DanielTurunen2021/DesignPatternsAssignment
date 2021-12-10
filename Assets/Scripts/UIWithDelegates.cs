using System;
using TMPro;
using UnityEngine;

public class UIWithDelegates : MonoBehaviour
{
    public TextMeshProUGUI healthpotiontext;
    public TextMeshProUGUI manapotiontext;
    private void Awake()
    {
        Inventory.onAddHealthPotion += UpdateHealthPotionAmount;
        Inventory.onAddManaPotion += UpdateManaPotionAmount;
    }

    private void OnDestroy()
    {
        Inventory.onAddHealthPotion -= UpdateHealthPotionAmount;
        Inventory.onAddManaPotion -= UpdateManaPotionAmount;
    }

    public void UpdateHealthPotionAmount(int amount)
    {
        healthpotiontext.text = $"Health potion amount: {amount}";
    }

    public void UpdateManaPotionAmount(int amount)
    {
        manapotiontext.text = $"Mana potion amount: {amount}";
    }
}
