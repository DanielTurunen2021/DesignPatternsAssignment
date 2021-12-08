using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ManaPotion
{
    private static ManaPotion _manaPotion;
    public int mp_potion_amount = 0;

    public static ManaPotion MpPotion
    {
        get
        {
            return _manaPotion;
        }
    }

    public void AddMana()
    {
        PlayerProfile.Instance.playerMana += Random.Range(50, 100);
    }
}