using UnityEngine;

public class ItemCollisions : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ManaPotion"))
        {
            Inventory.manaPotion.mp_potion_amount += 1;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("HealthPotion"))
        {
            Inventory.HealthPotion.hp_potion_amount += 1;
            Destroy(other.gameObject);
        }
    }
}
        
    

