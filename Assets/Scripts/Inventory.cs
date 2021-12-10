using System;
using UnityEngine;
public class Inventory
{
    public static ManaPotion manaPotion = new ManaPotion();
    public static HealthPotion HealthPotion = new HealthPotion();
    
    public delegate void Potionamount(int amount);
    public static event Potionamount onAddHealthPotion;
    public static event Potionamount onAddManaPotion;

    
   public static void AddHealthPotion(int amount)
    {
        HealthPotion.hp_potion_amount += 1;
        onAddHealthPotion.Invoke(HealthPotion.hp_potion_amount);
        Debug.Log($"health potion invoked");
    }

    public static void AddManaPotion(int amount)
    {
        manaPotion.mp_potion_amount += 1;
        onAddManaPotion.Invoke(manaPotion.mp_potion_amount);
        Debug.Log($"mana potion invoked");
    }
}


