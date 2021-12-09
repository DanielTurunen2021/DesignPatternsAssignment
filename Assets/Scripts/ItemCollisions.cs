using UnityEngine;


public class ItemCollisions : MonoBehaviour
{
    
    private void Awake()
    {
        Inventory.onAddPotion += Inventory.AddHealthPotion;
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ManaPotion"))
        {
            
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("HealthPotion"))
        {
            Inventory.AddHealthPotion(Inventory.HealthPotion.hp_potion_amount);
            Destroy(other.gameObject);
        }
    }
}
        
    

