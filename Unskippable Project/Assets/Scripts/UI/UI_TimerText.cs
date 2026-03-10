using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UI_TimerText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_countdownText;
    [SerializeField] private float m_timeRemainingValue = 5f;
    [SerializeField] private List<UnityEvent> m_timeEndedEvent;
  
    private float m_timeRemaining;
    private int m_currentAd = 0;

    public int CurrentAd { get => m_currentAd; set => m_currentAd = value; }

    private void OnEnable()
    {
        m_timeRemaining = m_timeRemainingValue;
    }

    void Update()
    {
        if (m_timeRemaining > 0)
        {
            m_timeRemaining -= Time.deltaTime;
            m_countdownText.text = Mathf.Ceil(m_timeRemaining).ToString();
        }
        else
        {
            m_timeRemaining = 0;
            m_timeEndedEvent[CurrentAd].Invoke();
            CurrentAd++;
        }
    }
}
