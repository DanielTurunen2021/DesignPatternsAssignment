using UnityEngine;
public class UIRender : MonoBehaviour
{
   //Adds the rect to the inspector.
   [SerializeField] private Rect rect;
   private void Update()
   {
      //Decrements health by 10.
      if (Input.GetKeyDown(KeyCode.A))
      {
         PlayerProfile.Instance.playerHealth -= 10;
      }
   }

   //Gets called every frame.
   private void OnGUI()
   {
      //Checks if the playerprofile Singleton exists
      if(PlayerProfile.Instance != null)
      {
         //Displays the player health on the top left corner of the screen
         GUI.Label(rect, PlayerProfile.Instance.playerHealth.ToString());
         
      }
   }
}
