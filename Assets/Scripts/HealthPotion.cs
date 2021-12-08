using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class HealthPotion 
{
    private static HealthPotion _healthPotion;
    public int hp_potion_amount = 0;


    public static HealthPotion HpPotion
    {
        get
        {
            return _healthPotion;
        }
    }
    public void AddHealth()
    {
        PlayerProfile.Instance.playerHealth += Random.Range(50, 100);
    }
}
