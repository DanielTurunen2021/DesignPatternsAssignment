using UnityEngine;

public class Inventory
{
    public static ManaPotion manaPotion = new ManaPotion();
    public static HealthPotion HealthPotion = new HealthPotion();
    
    public delegate void potionamount(int amount);

    
    public static event potionamount onAddPotion;
    

   public static void AddHealthPotion(int amount)
    {
        HealthPotion.hp_potion_amount += 1;
    }

    public static void AddManaPotion(int amount)
    {
        manaPotion.mp_potion_amount += 1;
    }
}


