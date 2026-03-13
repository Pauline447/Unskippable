using TMPro;
using UnityEngine;

public class UI_Popup : MonoBehaviour
{
    [SerializeField] private TMP_Text m_text;

    public TMP_Text Text { get => m_text; set => m_text = value; }

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
