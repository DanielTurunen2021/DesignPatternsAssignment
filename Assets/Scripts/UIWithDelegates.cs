using TMPro;
using UnityEngine;

public class UIWithDelegates : MonoBehaviour
{
    public TextMeshProUGUI healthpotiontext;
    private void Awake()
    {
        //Inventory.HealthPotion.onAddPotion += UpdateInventory;
    }

    public void UpdateInventory(int amount)
    {
        healthpotiontext.text = $"Health potion amount: {amount}";
    }
}
