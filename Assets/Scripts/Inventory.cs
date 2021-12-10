using System;
using UnityEngine;
public class Inventory
{
    public static ManaPotion manaPotion = new ManaPotion();
    public static HealthPotion HealthPotion = new HealthPotion();
    
    public delegate void Potionamount(int amount);
    
    public static event Potionamount onAddHealthPotion;
    public static event Potionamount onAddManaPotion;
    public static event Potionamount onUseHealthPotion;
    public static event Potionamount onUserManaPotion;
    
    public delegate void Healthandmana(int amount);

    public static event Healthandmana onAddHealth;
    public static event Healthandmana onAddMana;
    

    
   public static void AddHealthPotion(int amount)
    {
        HealthPotion.hp_potion_amount += 1;
        onAddHealthPotion.Invoke(HealthPotion.hp_potion_amount);
    }

   public static void useHealthPotion(int amount)
   {
       HealthPotion.hp_potion_amount -= 1;
       onUseHealthPotion.Invoke(HealthPotion.hp_potion_amount);
   }

    public static void AddManaPotion(int amount)
    {
        manaPotion.mp_potion_amount += 1;
        onAddManaPotion.Invoke(manaPotion.mp_potion_amount);
    }

    public static void useManaPotion(int amount)
    {
        manaPotion.mp_potion_amount -= 1;
        onUserManaPotion.Invoke(manaPotion.mp_potion_amount);
    }

    public static void ChangeHealth(int amount)
    {
        onAddHealth.Invoke(PlayerProfile.Instance.playerHealth);
    }

    public static void ChangeMana(int amount)
    {
        onAddMana.Invoke(PlayerProfile.Instance.playerMana);
    }
}


