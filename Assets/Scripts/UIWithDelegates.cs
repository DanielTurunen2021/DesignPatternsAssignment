using System;
using TMPro;
using UnityEngine;

public class UIWithDelegates : MonoBehaviour
{
    public TextMeshProUGUI healthpotiontext;
    public TextMeshProUGUI manapotiontext;
    public TextMeshProUGUI health;
    public TextMeshProUGUI mana;
    private void Awake()
    {
        Inventory.onAddHealthPotion += UpdateHealthPotionAmount;
        Inventory.onAddManaPotion += UpdateManaPotionAmount;
        Inventory.onAddHealth += UpdateHealthAmount;
        Inventory.onAddMana += UpdateManaAmount;
        Inventory.onUseHealthPotion += UpdateHealthPotionAmount;
        Inventory.onUserManaPotion += UpdateManaPotionAmount;
    }

    private void OnDestroy()
    {
        Inventory.onAddHealthPotion -= UpdateHealthPotionAmount;
        Inventory.onAddManaPotion -= UpdateManaPotionAmount;
        Inventory.onAddHealth -= UpdateHealthAmount;
        Inventory.onAddMana -= UpdateManaAmount;
        Inventory.onUseHealthPotion -= UpdateHealthPotionAmount;
        Inventory.onUserManaPotion -= UpdateManaPotionAmount;
    }

    public void UpdateHealthPotionAmount(int amount)
    {
        healthpotiontext.text = $"Health potion amount: {amount}";
    }

    public void UpdateManaPotionAmount(int amount)
    {
        manapotiontext.text = $"Mana potion amount: {amount}";
    }

    public void UpdateHealthAmount(int amount)
    {
        health.text = $"current health {amount}";
    }

    public void UpdateManaAmount(int amount)
    {
        mana.text = $"Curent mana {amount}";
    }
}
