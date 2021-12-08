using UnityEngine;

public class Potion : MonoBehaviour
{
    public class HealthPotion : IPotion
   {
       public int hp_potion_amount = 0;
       public void AddHealth()
       {
           PlayerProfile.Instance.playerHealth += Random.Range(50, 100);
       }
       public void AddMana()
       {
           PlayerProfile.Instance.playerMana += Random.Range(50, 100);
       }
   }
   public class ManaPotion : IPotion
   {
       public int mp_potion_amount = 0;
       public void AddHealth()
       {
           PlayerProfile.Instance.playerHealth += Random.Range(50, 100);
       }
       public void AddMana()
       {
           PlayerProfile.Instance.playerMana += Random.Range(50, 100);
       }
   }
}
