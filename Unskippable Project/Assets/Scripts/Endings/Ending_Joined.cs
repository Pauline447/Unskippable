using UnityEngine;
using UnityEngine.SceneManagement;
public class Ending_Joined : MonoBehaviour
{
    [SerializeField] private GameObject m_obj;
#region Singelton
    private static Ending_Joined instance;
    public static Ending_Joined Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("Ending_Popup is null");
            }

            return instance;
        }
    }


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one PlayerController in the scnene!");
        }

        instance = this;
    }
    #endregion

    public void ActivateObjs()
    {
        m_obj.SetActive(true);
    }

    public void ButtonEventQuitGame()
    {
        Application.Quit();
    }
    public void ButtonEventRestart()
    {
        SceneManager.LoadScene(0);
    }
}
