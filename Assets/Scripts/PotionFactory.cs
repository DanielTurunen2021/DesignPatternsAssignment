using UnityEngine;
using Random = UnityEngine.Random;

public enum PotionType
{
    Health,
    Mana
}

public class PotionFactory : MonoBehaviour
{
    public PotionType type;


    private void Update()
    {

        switch (type)
        {
            case PotionType.Health:
                CreateHealthPotion();
                break;
            case PotionType.Mana:
                CreateManaPotion();
                break;
        }
    }



    public void AddHealth()
    {
        PlayerProfile.Instance.playerHealth += Random.Range(50, 100);
    }

    public void AddMana()
    {
        PlayerProfile.Instance.playerMana += Random.Range(50, 100);
    }

    public static void CreateHealthPotion()
    {
        Inventory.HealthPotion.hp_potion_amount += 1;
    }

    public void CreateManaPotion()
    {
        Inventory.manaPotion.mp_potion_amount += 1;
    }
}

