using UnityEngine;
using UnityEngine.UI;

public class UI_FillBar : MonoBehaviour
{
    [SerializeField] private float m_speed;
    private Slider m_slider;
    private bool m_fillBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_slider = GetComponent<Slider>();
    }

    private void Update()
    {
        if(m_fillBar && m_slider.value<1)
        {
            m_slider.value += m_speed *Time.deltaTime;
        }
    }


    public void StartFillBar()
    {
        m_fillBar = true;
    }
    public void StopFillBar()
    {
        m_fillBar = false;
    }

    public void EmptyBar()
    {
        m_slider.value = 0;
    }
}
