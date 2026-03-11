using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_TimerText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_countdownText;
    [SerializeField] private float m_timeRemainingValue = 5f;
    [SerializeField] private List<UnityEvent> m_timeEndedEvent;

    [SerializeField] private Slider m_slider;
  
    private float m_timeRemaining;
    private float m_sliderValue;
    private int m_currentAd = 0;

    public int CurrentAd { get => m_currentAd; set => m_currentAd = value; }

    private void OnEnable()
    {
        m_timeRemaining = m_timeRemainingValue;
        m_sliderValue = 0;
    }

    void Update()
    {
        if (m_timeRemaining > 0)
        {
            m_timeRemaining -= Time.deltaTime;
            m_sliderValue += Time.deltaTime;
            m_slider.value = m_sliderValue;

            m_countdownText.text = Mathf.Ceil(m_timeRemaining).ToString();
        }
        else
        {
            m_sliderValue = m_timeRemainingValue;
            m_timeRemaining = 0;
            m_timeEndedEvent[CurrentAd].Invoke();
            CurrentAd++;
        }
    }
}
