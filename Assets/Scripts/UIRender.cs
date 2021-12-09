using UnityEngine;
public class UIRender : MonoBehaviour
{
   //Adds the rect to the inspector.
   private Rect health;
   private Rect mana;
   private Rect healthpotions;
   private Rect manapotions;
   
   //Gets called every frame.
   private void OnGUI()
   {
      //Checks if the playerprofile Singleton exists
      if(PlayerProfile.Instance != null)
      {
         //Displays the player health on the top left corner of the screen
         GUI.Label(health = new Rect(10, 0, 100, 100), $"Player health: {PlayerProfile.Instance.playerHealth}");
         GUI.Label(mana = new Rect(10, 30, 100, 100), $"Player mana: {PlayerProfile.Instance.playerMana}");
         GUI.Label(healthpotions = new Rect(10, 60, 100, 100), $"Health potions: {Inventory.HealthPotion.hp_potion_amount}");
         GUI.Label(healthpotions = new Rect(10, 80, 100, 100), $"Mana potions: {Inventory.manaPotion.mp_potion_amount}");
      }
   }
}
