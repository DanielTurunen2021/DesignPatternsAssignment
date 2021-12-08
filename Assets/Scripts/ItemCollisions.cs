using UnityEngine;

public class ItemCollisions : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ManaPotion"))
        {
            Inventory.manaPotion
        }
    }
}
        
    

