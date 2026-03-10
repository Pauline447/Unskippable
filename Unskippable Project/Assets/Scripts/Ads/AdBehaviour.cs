using UnityEngine;

public class AdBehaviour : MonoBehaviour
{
    [SerializeField] UI_TimerText m_skipTimer;
    [SerializeField] int m_currentAd;

    private void OnEnable()
    {
        m_skipTimer.gameObject.SetActive(true);
        m_skipTimer.CurrentAd = m_currentAd;
    }
}
