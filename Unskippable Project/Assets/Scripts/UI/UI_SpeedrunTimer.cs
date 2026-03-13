using TMPro;
using UnityEngine;

public class UI_SpeedrunTimer : MonoBehaviour
{
    public TMP_Text timerText;

    private float m_elapsedTime = 0f;
    private bool m_timerRunning = true;
    private string m_currentTime;

    public string CurrentTime { get => m_currentTime; set => m_currentTime = value; }

    void Update()
    {
        if (m_timerRunning)
        {
            m_elapsedTime += Time.deltaTime;

            int minutes = Mathf.FloorToInt(m_elapsedTime / 60f);
            int seconds = Mathf.FloorToInt(m_elapsedTime % 60f);
            int milliseconds = Mathf.FloorToInt((m_elapsedTime * 1000f) % 1000f);

            timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        }
    }

    public void StopTimer()
    {
        CurrentTime = timerText.text;
        m_timerRunning = false;
    }

    public void ResetTimer()
    {
        m_elapsedTime = 0f;
    }
}
