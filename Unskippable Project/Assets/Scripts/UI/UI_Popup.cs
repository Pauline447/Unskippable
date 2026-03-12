using UnityEngine;

public class UI_Popup : MonoBehaviour
{
   public void ButtonEventSpawnNextPopup()
   {
       Destroy(this.gameObject);
       Ending_Popup.Instance.SpawnPopup();
   }

    public void ButtonEventCloseGame()
    {
        Application.Quit();
    }
    public void ButtonEventActivateJoinEnding()
    {
        Ending_Joined.Instance.ActivateObjs();
    }
}
