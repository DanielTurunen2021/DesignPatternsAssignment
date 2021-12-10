using UnityEngine;

public class ItemCollisions : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ManaPotion"))
        {
            Inventory.AddManaPotion(1);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("HealthPotion"))
        {
            Inventory.AddHealthPotion(1);
            Destroy(other.gameObject);
        }
    }
}
        
    

